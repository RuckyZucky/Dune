#nullable enable
using System;

namespace Dune.Framework
{
    public abstract class StatefulDuneObject<T> : ChildDuneObject
    {
        private StatefulDuneElement<T> _element = null!;

        public abstract T State { get; set; }
        
        public StatefulDuneElement<T> Element
        {
            set => _element = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override DuneElement CreateElement()
        {
            var element = new StatefulDuneElement<T>(this);
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