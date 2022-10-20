#nullable enable

namespace Dune.Framework
{
    public abstract class DuneElement
    {
        private DuneObject? _object;

        public DuneObject? Object => _object;

        private DuneElement? _parent;

        public DuneElement? Parent => _parent;

        protected DuneElement(DuneObject? o)
        {
            _object = o;
        }

        public virtual void Mount(DuneElement? parent)
        {
            _parent = parent;
        }

        public abstract void Rebuild();
        
        
        public virtual void Update(ref DuneObject duneObject)
        {
            _object = duneObject;
        }
    }
}