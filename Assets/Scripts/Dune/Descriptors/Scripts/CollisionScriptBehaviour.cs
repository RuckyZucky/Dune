#nullable enable
using System;
using UnityEngine;

namespace Dune.Descriptors.Scripts
{
    public class CollisionScriptBehaviour : MonoBehaviour
    {
        public Action<Collision>? OnCollisionEnterAction { get; set; } = null;
        public Action<Collision>? OnCollisionExitAction { get; set; } = null;
        public Action<Collision>? OnCollisionStayAction { get; set; } = null;
        public Action<Collider>? OnTriggerEnterAction { get; set; } = null;
        public Action<Collider>? OnTriggerExitAction { get; set; } = null;
        public Action<Collider>? OnTriggerStayAction { get; set; } = null;
        

        private void OnCollisionEnter(Collision collision)
        {
            OnCollisionEnterAction?.Invoke(collision);
        }

        private void OnCollisionExit(Collision other)
        {
            OnCollisionExitAction?.Invoke(other);
        }

        private void OnCollisionStay(Collision collisionInfo)
        {
            OnCollisionStayAction?.Invoke(collisionInfo);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterAction?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExitAction?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerStayAction?.Invoke(other);
        }
    }
}