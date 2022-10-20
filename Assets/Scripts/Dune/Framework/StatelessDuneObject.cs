#nullable enable
namespace Dune.Framework
{
    public abstract class StatelessDuneObject : ChildDuneObject
    {
        public override DuneElement CreateElement()
        {
            return new StatelessDuneElement(this);
        }
    }
}