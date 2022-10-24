#nullable enable
using Dune.Framework;
using UnityEngine;

namespace Dune.Descriptors.Physics
{
    public abstract class DuneCollider<T> : DuneDescriptor<T> where T : Collider
    {
        public bool IsTrigger { get; init; }
        
        public PhysicMaterial? Material { get; init; }
        
        public override void PopulateComponent(ref T component)
        {
            component.isTrigger = IsTrigger;
            component.material = Material;
        }
    }
}