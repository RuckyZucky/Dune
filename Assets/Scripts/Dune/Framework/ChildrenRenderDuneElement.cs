#nullable enable

using System.Collections.Generic;
using System.Linq;

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
            for (var i = 0; i < newChildren.Count; i++)
            {
                newChildren.Add(childrenObject.Children[i].CreateElement());
                newChildren[i].Mount(this);
            }

            _children = newChildren;
        }

        public override void Unmount()
        {
            foreach (var child in _children)
            {
                child.Unmount();
            }

            base.Unmount();
        }

        public override void Rebuild()
        {
            base.Rebuild();
            List<DuneElement> oldChildren = _children;
            List<DuneObject> newObjects = (Object as ChildrenRenderDuneObject)!.Children;
            List<DuneElement?> newChildren = Enumerable.Repeat<DuneElement?>(null, newObjects.Count).ToList();
            for (var index = 0; index < newChildren.Count; index++)
            {
                var child = oldChildren.ElementAtOrDefault(index);
                var newObject = newObjects[index];
                var newChild = newObject.CreateElement();
                if (child != null)
                {
                    if (child.Object?.GetType() == newObject.GetType())
                    {
                        child.Update(ref newObject);
                        newChildren[index] = child;
                    }
                    else
                    {
                        Owner!.InactiveElements.Add(child);
                        newChildren[index] = newChild;
                        newChild.Mount(this);
                    }
                }
                else
                {
                    newChildren[index] = newChild;
                    newChild.Mount(this);
                }
            }

            for (var index = newChildren.Count; index < oldChildren.Count; index++)
            {
                Owner!.InactiveElements.Add(oldChildren![index]);
            }

            _children = newChildren!;
        }
    }
}