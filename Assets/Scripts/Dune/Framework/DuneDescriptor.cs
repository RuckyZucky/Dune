#nullable enable
using System;
using UnityEngine;

namespace Dune.Framework
{
    public abstract class DuneDescriptor : ChildDuneObject
    {
        private readonly DuneObject _target = null!;
        
        public DuneObject Target
        {
            get => _target;
            init => _target = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override DuneObject Build() => Target;
        
        public abstract Component ApplyComponent(GameObject gameObject);
    }
    
    public abstract class DuneDescriptor<T> : DuneDescriptor where T : Component
    {

        public override DuneElement CreateElement()
        {
            return new DuneDescriptorElement<T>(this);
        }

        public abstract void PopulateComponent(ref T component);

        public override Component ApplyComponent(GameObject gameObject)
        {
            return ApplyTypedComponent(gameObject);
        }

        private T ApplyTypedComponent(GameObject gameObject)
        {
            var component = gameObject.AddComponent<T>();
            PopulateComponent(ref component);
            return component;
        }
    }
}