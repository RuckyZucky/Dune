#nullable enable
using Dune.Framework;
using UnityEngine;

namespace Dune.Descriptors.Physics
{
    public class DuneBoxCollider : DuneCollider<BoxCollider>
    {
        public Vector3 Center { get; init; }
        public Vector3 Size { get; init; }
        
        public override void PopulateComponent(ref BoxCollider component)
        {
            base.PopulateComponent(ref component);
            component.center = Center;
            component.size = Size;
        }
    }
}