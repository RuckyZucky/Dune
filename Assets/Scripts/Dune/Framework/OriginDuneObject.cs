#nullable enable
using UnityEngine;

namespace Dune.Framework
{
    public class OriginDuneObject : RenderDuneObject
    {
        private DuneObject _child;

        public DuneObject Child => _child;

        private GameObject _origin;

        public OriginDuneObject(GameObject origin, DuneObject child)
        {
            _origin = origin;
            _child = child;
        }

        public override GameObject CreateGameObject()
        {
            return _origin;
        }

        public override void UpdateGameObject(ref GameObject gameObject)
        {
            // should never happen
            throw new System.NotImplementedException("Oh no. The origin should never be updated!!");
        }

        public override DuneElement CreateElement()
        {
            return new OriginDuneElement(this);
        }
    }
}