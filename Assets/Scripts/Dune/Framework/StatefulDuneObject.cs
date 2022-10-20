#nullable enable
using System;

namespace Dune.Framework
{
    public abstract class StatefulDuneObject : ChildDuneObject
    {
        private StatefulDuneElement _element = null!;
        
        public override DuneElement CreateElement()
        {
            var element = new StatefulDuneElement(this);
            _element = element;
            return element;
        } 
        
        protected void SetState(Action action)
        {
            action();
            _element.Rebuild();
        }
    }
}