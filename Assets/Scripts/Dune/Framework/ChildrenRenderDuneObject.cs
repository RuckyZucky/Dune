#nullable enable
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dune.Framework
{
    public abstract class ChildrenRenderDuneObject : RenderDuneObject
    {
        private List<DuneObject> _children;

        public List<DuneObject> Children
        {
            get => _children;
            init => _children = value ?? throw new ArgumentNullException(nameof(value));
        }

        protected ChildrenRenderDuneObject(List<DuneObject> children)
        {
            _children = children;
        }

        public override DuneElement CreateElement()
        {
            return new ChildrenRenderDuneElement(this);
        }
    }
}