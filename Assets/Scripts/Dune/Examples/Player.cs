#nullable enable
using System.Collections.Generic;
using Dune.Descriptors;
using Dune.Descriptors.Physics;
using Dune.Descriptors.Scripts;
using Dune.Framework;
using Dune.Objects.Primitives;
using UnityEngine;

namespace Dune.Examples
{
    public struct PlayerState
    {
        public bool UseGravity { get; set; }
        public List<DuneObject> Children { get; set; }
    }
    
    public class Player : StatefulDuneObject<PlayerState>
    {

        private PlayerState _state = new PlayerState
        {
            UseGravity = false,
            Children = new(),
        };

        public override PlayerState State
        {
            get => _state;
            set => _state = value;
        }

        public Player()
        {
            
        }

        public override DuneObject Build()
        {
            return new DuneScriptable
            {
                Update = () =>
                {
                    if (Input.GetKeyDown("space"))
                    {
                        SetState(() => _state.UseGravity ^= true);
                    }

                    if (Input.GetKeyDown(KeyCode.KeypadPlus))
                    {
                        SetState(() => _state.Children.Add(GenerateChild(_state.Children.Count)));
                    }
                    
                    if (Input.GetKeyDown(KeyCode.KeypadMinus))
                    {
                        SetState(() => _state.Children.RemoveAt(_state.Children.Count - 1));
                    }
                },
                Target = new DuneRigidbody
                {
                    UseGravity = _state.UseGravity,
                    Target = new DuneCapsule
                    {
                        Name = "Player",
                        Tag = "Player",
                        Children = _state.Children
                    },
                }
            };
        }

        private DuneObject GenerateChild(int index)
        {
            return new DuneTransform
            {
                Scale = new Vector3(0.1f, 0.1f, 0.1f),
                Position = new Vector3(0.5f, (index + 1) * 0.2f, 0.5f),
                Target = new DuneCube(),
            };
        }
    }
}
