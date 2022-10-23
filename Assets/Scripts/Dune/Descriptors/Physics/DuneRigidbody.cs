#nullable enable
using Dune.Framework;
using UnityEngine;

namespace Dune.Descriptors.Physics
{
    public class DuneRigidbody : DuneDescriptor<Rigidbody>
    {
        public bool UseGravity { get; init; } = false;

        public float Mass { get; init; } = 1.0f;
        
        public float Drag { get; init; } = 0.0f;
        
        public float AngularDrag { get; init; } = 0.0f;

        public RigidbodyInterpolation Interpolation { get; init; } = RigidbodyInterpolation.None;

        public CollisionDetectionMode CollisionDetectionMode { get; init; } = CollisionDetectionMode.Discrete;

        public override void PopulateComponent(ref Rigidbody component)
        {
            component.useGravity = UseGravity;
            component.mass = Mass;
            component.drag = Drag;
            component.angularDrag = AngularDrag;
            component.interpolation = Interpolation;
            component.collisionDetectionMode = CollisionDetectionMode;
        }
    }
}