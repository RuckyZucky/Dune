using System.Collections.Generic;

namespace Dune.Framework
{
    public interface ITreeOwner
    {
        List<DuneElement> InactiveElements { get; }

        void UnmountInactiveElements();
    }
}