using UnityEngine;

namespace Dune.Framework
{
    public abstract class RenderDuneObject : DuneObject
    {
        public abstract GameObject CreateGameObject();

        public abstract void UpdateGameObject(ref GameObject gameObject);

        public override DuneElement CreateElement()
        {
            return new RenderDuneElement(this);
        }
    }
}