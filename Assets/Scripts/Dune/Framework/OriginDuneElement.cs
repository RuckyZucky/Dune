#nullable enable

using UnityEngine;

namespace Dune.Framework
{
    public class OriginDuneElement : RenderDuneElement
    {
        private DuneElement? _child;
        
        public OriginDuneElement(OriginDuneObject o) : base(o)
        {
        }

        protected override GameObject? Render => (Object as OriginDuneObject)!.CreateGameObject();

        public override void Mount(DuneElement? parent)
        {
            base.Mount(null);
            _child = (Object as OriginDuneObject)!.Child.CreateElement();
            _child.Mount(this);
        }
    }
}