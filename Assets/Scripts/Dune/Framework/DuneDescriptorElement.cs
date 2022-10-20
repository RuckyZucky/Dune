#nullable enable
using System;
using UnityEngine;

namespace Dune.Framework
{

    interface IDuneDescriptor
    {
        Component InterfaceComponent { get; set; }
    }
    
    public abstract class DuneDescriptorElement : ChildDuneElement, IDuneDescriptor
    {
        public Component Component
        {
            get { return ((IDuneDescriptor)this).InterfaceComponent; }
            set { ((IDuneDescriptor)this).InterfaceComponent = value; }
        }

        Component IDuneDescriptor.InterfaceComponent { get; set; } = null!;

        public DuneDescriptorElement(DuneObject? o) : base(o)
        {
        }
    }
    
    public class DuneDescriptorElement<T> : DuneDescriptorElement, IDuneDescriptor where T : Component
    {
        private T _component = null!;

        Component IDuneDescriptor.InterfaceComponent
        {
            get => _component;
            set => _component = value ? (T)value : throw new ArgumentNullException(nameof(value));
        }

        public DuneDescriptorElement(DuneObject? o) : base(o)
        {
            
        }

        public override void Update(ref DuneObject duneObject)
        {
            base.Update(ref duneObject);
            (Object as DuneDescriptor<T>)!.PopulateComponent(ref _component);
        }
    }
}