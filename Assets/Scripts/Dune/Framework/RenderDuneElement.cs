#nullable enable
using UnityEngine;

namespace Dune.Framework
{
    public class RenderDuneElement : DuneElement
    {
        private GameObject? _render;

        protected virtual GameObject? Render => _render;
        
        public RenderDuneElement(DuneObject o) : base(o) {}

        public override void Mount(DuneElement? parent)
        {
            base.Mount(parent);
            _render = (Object as RenderDuneObject)!.CreateGameObject();
            DuneElement? ancestor = parent;
            while (ancestor != null && ancestor is not RenderDuneElement)
            {
                if (ancestor is DuneDescriptorElement element)
                {
                    var component = (element.Object as DuneDescriptor)!.ApplyComponent(_render);
                    element.Component = component;
                }
                ancestor = ancestor.Parent;
            }

            _render.transform.parent = (ancestor as RenderDuneElement)?.Render!.transform;
        }

        public override void Unmount()
        {
            base.Unmount();
            UnityEngine.Object.Destroy(_render);
        }

        public override void Rebuild()
        {
            (Object as RenderDuneObject)!.UpdateGameObject(ref _render);
        }

        public override void Update(ref DuneObject duneObject)
        {
            base.Update(ref duneObject);
            Rebuild();
        }
    }
}