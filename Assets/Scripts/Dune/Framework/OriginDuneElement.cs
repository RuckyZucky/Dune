#nullable enable

using System.Collections.Generic;
using UnityEngine;

namespace Dune.Framework
{
    public class OriginDuneElement : RenderDuneElement, ITreeOwner
    {
        private DuneElement? _child;

        public List<DuneElement> InactiveElements { get; } = new List<DuneElement>();

        public OriginDuneElement(OriginDuneObject o) : base(o)
        {
        }

        protected override GameObject? Render => (Object as OriginDuneObject)!.CreateGameObject();

        public override void Mount(DuneElement? parent)
        {
            base.Mount(null);
            Owner = this;
            _child = (Object as OriginDuneObject)!.Child.CreateElement();
            _child.Mount(this);
        }

        public void UnmountInactiveElements()
        {
            foreach (var inactiveElement in InactiveElements)
            {
                inactiveElement.Unmount();
            }
        }
    }
}