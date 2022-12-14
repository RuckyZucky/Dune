#nullable enable
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dune.Framework
{
    public abstract class ChildrenRenderDuneObject : RenderDuneObject
    {
        private readonly List<DuneObject> _children = new();

        public List<DuneObject> Children
        {
            get => _children;
            init => _children = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override DuneElement CreateElement()
        {
            return new ChildrenRenderDuneElement(this);
        }
    }
}