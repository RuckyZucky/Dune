#nullable enable
using System;
using Dune.Descriptors;
using Dune.Descriptors.Scripts;
using Dune.Framework;
using Dune.Objects;
using Unity.VisualScripting;
using UnityEngine;

namespace Dune.Examples.ChessGame.Scripts
{
    public struct ChessPlayerState
    {
        
    }
    
    public class ChessPlayer : StatefulDuneObject<ChessPlayerState>
    {
        public Action<Vector2> OnMoved { get; init; } = null!;
        public Func<Vector2?> TryBeat { get; init; } = null!;
        public Vector2 Pos { get; init; } = Vector2.zero;

        private ChessPlayerState _state = new()
        {
            
        };

        public override ChessPlayerState State
        {
            get => _state; 
            set => _state = value;
        }

        public override DuneObject Build()
        {
            return new DuneTransform
            {
                Position = new Vector3(Pos.x + 0.5f, 0.5f, Pos.y + 0.5f),
                // Scale = new Vector3(0.7f, 0.7f, 0.7f),
                Target = new DuneScriptable
                {
                    Update = () =>
                    {
                        var posX = Pos.x;
                        var posY = Pos.y;
                        if (Input.GetKeyUp(KeyCode.A))
                        {
                            OnMoved(new Vector2(posX - 1, posY));
                        }
                        if (Input.GetKeyUp(KeyCode.D))
                        {
                            OnMoved(new Vector2(posX + 1, posY));
                        }
                        if (Input.GetKeyUp(KeyCode.W))
                        {
                            OnMoved(new Vector2(posX, posY + 1));
                        }
                        if (Input.GetKeyUp(KeyCode.S))
                        {
                            OnMoved(new Vector2(posX, posY - 1));
                        }

                        if (Input.GetKeyUp(KeyCode.Return))
                        {
                            var pos = TryBeat();
                            if (pos != null)
                            {
                                OnMoved(pos.Value);
                            }
                        }
                    },
                    Target = new DuneEmpty
                    {
                        Name = "Player",
                        Children = { new DunePrefabObject{ PrefabPath = "Prefabs/WhitePawn" } }
                    }
                }
            };
        }
    }
}