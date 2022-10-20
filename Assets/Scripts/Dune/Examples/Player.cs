#nullable enable
using System.Collections;
using System.Threading.Tasks;
using Dune.Descriptors;
using Dune.Framework;
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
            return new DuneScriptable
            {
                Update = () =>
                {
                    if (Input.GetKeyDown("space"))
                    {
                        SetState(() => _useGravity = true);
                    }  
                },
                Target = new DuneRigidbody
                {
                    UseGravity = _useGravity,
                    Target = new DuneEmpty
                    {
                        Name = "Player",
                        Tag = "Player",
                        Children = { new DuneEmpty { }, new DuneEmpty { } }
                    },
                }
            };
        }
    }
}
