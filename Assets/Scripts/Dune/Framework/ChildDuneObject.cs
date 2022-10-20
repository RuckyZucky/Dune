#nullable enable
namespace Dune.Framework
{
    public abstract class ChildDuneObject : DuneObject
    {
        public abstract DuneObject Build();
    }
}