#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Dune.Framework;
using Dune.Objects;
using UnityEngine;

namespace Dune.Examples.ChessGame.Scripts
{
    public struct BoardState
    {
        public bool GameOver { get; set; }
        
        public List<ChessEnemyInfo> Enemies { get; set; }
        
        public Vector2 PlayerPos { get; set; }
    }
    
    public class Board : StatefulDuneObject<BoardState>
    {

        private BoardState _state = new ()
        {
            GameOver = false,
            Enemies = new()
            {
                new ChessEnemyInfo
                {
                    Beatable = false,
                    Pos = new Vector2(3, 3),
                },
                new ChessEnemyInfo
                {
                    Beatable = false,
                    Pos = new Vector2(-2, -4),
                },
                new ChessEnemyInfo
                {
                    Beatable = false,
                    Pos = new Vector2(-4, 3),
                },
            },
            PlayerPos = new Vector2(0, 0)
        };

        public override BoardState State
        {
            get => _state;
            set => _state = value;
        }

        public override DuneObject Build()
        {
            var actors = _state.Enemies.Select<ChessEnemyInfo, DuneObject>(info => new ChessEnemy { Position = info.Pos, Beatable = info.Beatable, Check = info.Check })
                .Append(new ChessPlayer
                {
                    OnMoved = UpdateAIOnPlayerPos,
                    TryBeat = PlayerTriesBeat,
                    Pos = _state.PlayerPos
                }).ToList();

            return new DuneEmpty
            {
                Name = "BoardActors",
                Children = actors,
            };
        }

        private Vector2? PlayerTriesBeat()
        {
            if (_state.GameOver)
            {
                return null;
            }
            
            foreach (var enemy in _state.Enemies.Where(enemy => enemy.Beatable))
            {
                _state.Enemies.Remove(enemy);
                return enemy.Pos;
            }

            return null;
        }

        private void UpdateAIOnPlayerPos(Vector2 playerPos)
        {
            if (_state.GameOver)
            {
                return;
            }
            
            SetState(() =>
            {
                _state.PlayerPos = playerPos;
                for (var i = 0; i < _state.Enemies.Count; i++)
                {
                    var enemies = _state.Enemies;
                    Vector2 target = Vector2.positiveInfinity;
                    for (int x = -1; x < 2; x+=2)
                    {
                        for (int y = -1; y < 2; y+=2)
                        {
                            var direction = enemies[i].Pos - (playerPos + new Vector2(x, y));
                            if (target.sqrMagnitude > direction.sqrMagnitude)
                            {
                                target = direction;
                            }
                        }
                    }
                    
                    if (target.sqrMagnitude < 0.1f)
                    {
                        _state.GameOver = true;
                        _state.Enemies[i].Check = true;
                        continue;
                    }
                    
                    if (Math.Abs(target.x) > Math.Abs(target.y))
                    {
                        _state.Enemies[i].Pos = new Vector2(enemies[i].Pos.x - Math.Sign(target.x), enemies[i].Pos.y);
                    }
                    else
                    {
                        _state.Enemies[i].Pos = new Vector2(enemies[i].Pos.x, enemies[i].Pos.y - Math.Sign(target.y));
                    }

                    _state.Enemies[i].Beatable = Math.Abs(Math.Abs(_state.Enemies[i].Pos.x - playerPos.x) - 1) < 0.1 &&
                                                 Math.Abs(Math.Abs(_state.Enemies[i].Pos.y - playerPos.y) - 1) < 0.1;
                }
            });
        }
    }
}