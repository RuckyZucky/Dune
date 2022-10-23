#nullable enable
using UnityEngine;

namespace Dune.Descriptors.Physics
{
    public enum CapsuleDirection
    {
        X = 0,
        Y = 1,
        Z = 2
    }
    
    public class DuneCapsuleCollider : DuneCollider<CapsuleCollider>
    {
        public Vector3 Center { get; init; }
        
        public float Height { get; init; }
        
        public CapsuleDirection Direction { get; init; }
        
        public float Radius { get; init; }
        
        public override void PopulateComponent(ref CapsuleCollider component)
        {
            base.PopulateComponent(ref component);
            component.center = Center;
            component.height = Height;
            component.direction = (int) Direction;
            component.radius = Radius;
        }
    }
}