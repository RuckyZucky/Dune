#nullable enable
using System;
using Dune.Descriptors;
using Dune.Descriptors.Scripts;
using Dune.Framework;
using Dune.Objects;
using UnityEngine;

namespace Dune.Examples.ChessGame.Scripts
{
    public struct ChessPlayerState
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
    
    public class ChessPlayer : StatefulDuneObject<ChessPlayerState>
    {
        public Action<Vector2> OnMoved { get; init; } = null!;

        private ChessPlayerState _state = new()
        {
            PosX = 0,
            PosY = 0,
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
                Position = new Vector3(_state.PosX + 0.5f, 0.5f, _state.PosY + 0.5f),
                // Scale = new Vector3(0.7f, 0.7f, 0.7f),
                Target = new DuneScriptable
                {
                    Update = () =>
                    {
                        var posX = _state.PosX;
                        var posY = _state.PosY;
                        if (Input.GetKeyUp(KeyCode.A))
                        {
                            SetState(() => _state.PosX--);
                            OnMoved(new Vector2(posX, posY));
                        }
                        if (Input.GetKeyUp(KeyCode.D))
                        {
                            SetState(() => _state.PosX++);
                            OnMoved(new Vector2(posX, posY));
                        }
                        if (Input.GetKeyUp(KeyCode.W))
                        {
                            SetState(() => _state.PosY++);
                            OnMoved(new Vector2(posX, posY));
                        }
                        if (Input.GetKeyUp(KeyCode.S))
                        {
                            SetState(() => _state.PosY--);
                            OnMoved(new Vector2(posX, posY));
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