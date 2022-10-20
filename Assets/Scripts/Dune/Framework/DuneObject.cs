#nullable enable
using System;
using UnityEngine;

namespace Dune.Framework
{
    public abstract class DuneObject
    {
        public abstract DuneElement CreateElement();
    }
}