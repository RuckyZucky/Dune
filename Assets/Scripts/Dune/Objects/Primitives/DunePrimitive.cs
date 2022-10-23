#nullable enable
using Dune.Framework;
using UnityEngine;

namespace Dune.Objects.Primitives
{
    public abstract class DunePrimitive : ChildrenRenderDuneObject
    {
        protected readonly PrimitiveType Type;

        protected DunePrimitive(PrimitiveType type)
        {
            Type = type;
        }

        public string? Name { get; init; } = null;

        public string Tag { get; init; } = "Untagged";

        public int Layer { get; init; } = 0;
        
        public override GameObject CreateGameObject()
        {
            var gameObject = GameObject.CreatePrimitive(Type);
            gameObject.name = Name ?? Type.ToString();
            gameObject.layer = Layer;
            gameObject.tag = Tag;
            return gameObject;
        }

        public override void UpdateGameObject(ref GameObject gameObject)
        {
            gameObject.name = Name ?? Type.ToString();
            gameObject.layer = Layer;
            gameObject.tag = Tag;
        }
    }
}