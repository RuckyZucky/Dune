#nullable enable
using System;
using UnityEngine;

namespace Dune.Descriptors
{
    public class ScriptableBehaviour : MonoBehaviour
    {
        private Action? _updateAction;

        public Action? UpdateAction
        {
            get => _updateAction;
            set => _updateAction = value;
        }

        private void Update()
        {
            _updateAction?.Invoke();
        }
    }
}