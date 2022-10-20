#nullable enable
using Dune.Framework;
using UnityEngine;

namespace Dune.Descriptors
{
    public class DuneRigidbody : DuneDescriptor<Rigidbody>
    {
        public bool UseGravity { get; init; }

        public override void PopulateComponent(ref Rigidbody component)
        {
            component.useGravity = UseGravity;
        }
    }
}