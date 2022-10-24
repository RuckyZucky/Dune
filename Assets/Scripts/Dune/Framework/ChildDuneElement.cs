#nullable enable
namespace Dune.Framework
{
    public class ChildDuneElement : DuneElement
    {
        private DuneElement? _child;
        
        public ChildDuneElement(DuneObject? o) : base(o)
        {
        }

        public override void Mount(DuneElement? parent)
        {
            base.Mount(parent);
            Rebuild();
        }

        public override void Unmount()
        {
            _child?.Unmount();
            base.Unmount();
        }

        public override void Rebuild()
        {
            
            var built = (Object as ChildDuneObject)!.Build();
            var newChild = built.CreateElement();
            if (_child != null)
            {
                if (_child.Object?.GetType() == built.GetType())
                {
                    _child.Update(ref built);
                }
                else
                {
                    Owner!.InactiveElements.Add(_child);
                    _child = newChild;
                    _child.Mount(this);
                }
            }
            else
            {
                _child = newChild;
                _child.Mount(this);
            }
        }

        public override void Update(ref DuneObject duneObject)
        {
            base.Update(ref duneObject);
            Rebuild();
        }
    }
}