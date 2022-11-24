#nullable enable
using Dune.Framework;
using UnityEngine;

namespace Dune.Descriptors
{
    public class DuneTransform : DuneDescriptor<Transform>
    {
        public Vector3? Position { get; init; }
        
        public Vector3? LocalPosition { get; init; }
        
        public Quaternion? Rotation { get; init; }
        
        public Vector3? Scale { get; init; }
        
        public override Component ApplyComponent(GameObject gameObject)
        {
            // GameObjects always have transforms
            var transform = gameObject.transform;
            PopulateComponent(ref transform);
            return transform;
        }

        public override void PopulateComponent(ref Transform transform)
        {
            if (Position != null) transform.position = Position.Value;
            if (LocalPosition != null) transform.localPosition = LocalPosition.Value;
            if (Rotation != null) transform.rotation = Rotation.Value;
            if (Scale != null) transform.localScale = Scale.Value;
        }
    }
}