#nullable enable
namespace Dune.Framework
{
    public class StatefulDuneElement<T> : ChildDuneElement
    {
        public StatefulDuneElement(StatefulDuneObject<T> o) : base(o)
        {
            
        }

        public override void Update(ref DuneObject duneObject)
        {
            var currentState = (Object as StatefulDuneObject<T>)!.State;
            (duneObject as StatefulDuneObject<T>)!.Element = this;
            (duneObject as StatefulDuneObject<T>)!.State = currentState;
            base.Update(ref duneObject);
            
        }
    }
}