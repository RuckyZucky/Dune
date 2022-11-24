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
        public List<Vector2> Enemies { get; set; }
    }
    
    public class Board : StatefulDuneObject<BoardState>
    {

        private BoardState _state = new ()
        {
            Enemies = new()
            {
                new Vector2(3, 3),
                new Vector2(-4, 3),
                new Vector2(-2, -4),
            }
        };

        public override BoardState State
        {
            get => _state;
            set => _state = value;
        }

        public override DuneObject Build()
        {
            var actors = _state.Enemies.Select<Vector2, DuneObject>(pos => new ChessEnemy { Position = pos })
                .Append(new ChessPlayer
                {
                    OnMoved = UpdateAIOnPlayerPos
                }).ToList();

            return new DuneEmpty
            {
                Name = "BoardActors",
                Children = actors,
            };
        }

        private void UpdateAIOnPlayerPos(Vector2 playerPos)
        {
            SetState(() =>
            {
                for (var i = 0; i < _state.Enemies.Count; i++)
                {
                    var enemies = _state.Enemies;
                    var direction = enemies[i] - playerPos;
                    if (Math.Abs(direction.x) > Math.Abs(direction.y))
                    {
                        _state.Enemies[i] = new Vector2(enemies[i].x - Math.Sign(direction.x), enemies[i].y);
                    }
                    else
                    {
                        _state.Enemies[i] = new Vector2(enemies[i].x, enemies[i].y - Math.Sign(direction.y));
                    }
                }
            });
        }
    }
}