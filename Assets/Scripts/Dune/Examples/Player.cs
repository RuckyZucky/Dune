#nullable enable
using System.Collections.Generic;
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

        private List<DuneObject> _children = new List<DuneObject>();

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
                        SetState(() => _children.Add(new DuneCube()));
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
    }
}
