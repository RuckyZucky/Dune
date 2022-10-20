using System;
using UnityEngine;

namespace Dune.Framework
{
    
    public abstract class DuneOrigin<T> : MonoBehaviour where T : DuneObject
    {
        [SerializeField] private T duneObject;

        protected abstract T GetInstance();
        
        private void Awake()
        {
            duneObject = GetInstance();
            new OriginDuneObject(
                origin: gameObject,
                child: GetInstance()
            ).CreateElement().Mount(null);
        }
    }
}