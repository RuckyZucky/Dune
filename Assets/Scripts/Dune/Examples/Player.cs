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
    public class Player : StatefulDuneObject
    {
        private bool _useGravity = false;

        private List<DuneObject> _children = new();

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
                        SetState(() => _useGravity ^= true);
                    }

                    if (Input.GetKeyDown(KeyCode.KeypadPlus))
                    {
                        SetState(() => _children.Add(GenerateChild(_children.Count)));
                    }
                    
                    if (Input.GetKeyDown(KeyCode.KeypadMinus))
                    {
                        SetState(() => _children.RemoveAt(_children.Count - 1));
                    }
                },
                Target = new DuneRigidbody
                {
                    UseGravity = _useGravity,
                    Target = new DuneCapsule
                    {
                        Name = "Player",
                        Tag = "Player",
                        Children = _children
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
