#nullable enable

using System.Collections.Generic;

namespace Dune.Framework
{
    public class ChildrenRenderDuneElement : RenderDuneElement
    {
        private List<DuneElement> _children = null!;
        
        public ChildrenRenderDuneElement(DuneObject o) : base(o)
        {
        }

        public override void Mount(DuneElement? parent)
        {
            base.Mount(parent);
            ChildrenRenderDuneObject childrenObject = (Object as ChildrenRenderDuneObject)!;
            List<DuneElement> newChildren = new List<DuneElement>(childrenObject.Children.Count);
            for (var i = 0; i < newChildren.Capacity; i++)
            {
                newChildren.Add(childrenObject.Children[i].CreateElement());
                newChildren[i].Mount(this);
            }

            _children = newChildren;
        }
    }
}