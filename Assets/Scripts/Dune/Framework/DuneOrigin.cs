#nullable enable
using System;
using UnityEngine;

namespace Dune.Framework
{
    
    public abstract class DuneOrigin<T> : MonoBehaviour where T : DuneObject
    {
        [SerializeField] private T duneObject = null!;
        private OriginDuneElement _originElement = null!;

        protected abstract T GetInstance();
        
        private void Awake()
        {
            duneObject = GetInstance();
            _originElement = (OriginDuneElement) new OriginDuneObject(
                origin: gameObject,
                child: GetInstance()
            ).CreateElement();
            _originElement.Mount(null);
        }

        private void LateUpdate()
        {
            _originElement.UnmountInactiveElements();
        }
    }
}