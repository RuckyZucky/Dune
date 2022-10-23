#nullable enable
using System.Collections;
using System.Threading.Tasks;
using Dune.Descriptors;
using Dune.Descriptors.Physics;
using Dune.Descriptors.Scripts;
using Dune.Framework;
using Dune.Objects;
using Dune.Objects.Primitives;
using UnityEngine;

namespace Dune.Examples
{
    public class Player : StatefulDuneObject
    {
        private bool _useGravity = false;

        public Player()
        {
            
        }

        public override DuneObject Build()
        {
            // return new DuneEmpty();
            
            return new DuneScriptable
            {
                Update = () =>
                {
                    if (Input.GetKeyDown("space"))
                    {
                        SetState(() => _useGravity ^= true);
                    }  
                },
                Target = new DuneRigidbody
                {
                    UseGravity = _useGravity,
                    Target = new DuneCapsule
                    {
                        Name = "Player",
                        Tag = "Player",
                        Children = { new DuneCube { }, new DuneEmpty { } }
                    },
                }
            };
        }
    }
}
