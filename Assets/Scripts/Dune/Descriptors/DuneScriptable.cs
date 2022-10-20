#nullable enable
using System;
using Dune.Framework;

namespace Dune.Descriptors
{
    public class DuneScriptable : DuneDescriptor<ScriptableBehaviour>
    {
        public Action? Update { get; init; }
        
        public override void PopulateComponent(ref ScriptableBehaviour component)
        {
            component.UpdateAction = Update;
        }
    }
}