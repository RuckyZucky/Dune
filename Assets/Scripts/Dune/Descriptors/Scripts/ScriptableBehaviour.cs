#nullable enable
using System;
using UnityEngine;

namespace Dune.Descriptors.Scripts
{
    public class ScriptableBehaviour : MonoBehaviour
    {
        public Action? UpdateAction { get; set; } = null;
        public Action? AwakeAction { get; set; } = null;
        public Action? ResetAction { get; set; } = null;
        public Action? StartAction { get; set; } = null;
        public Action? FixedUpdateAction { get; set; } = null;
        public Action? LateUpdateAction { get; set; } = null;
        public Action? OnEnableAction { get; set; } = null;
        public Action? OnDisableAction { get; set; } = null;
        public Action? OnDestroyAction { get; set; } = null;
        public Action? OnApplicationFocusAction { get; set; } = null;
        public Action? OnApplicationPauseAction { get; set; } = null;
        public Action? OnApplicationQuitAction { get; set; } = null;
        public Action? OnBecameVisibleAction { get; set; } = null;
        public Action? OnBecameInvisibleAction { get; set; } = null;
        public Action<Collision>? OnCollisionEnterAction { get; set; } = null;
        public Action<Collision>? OnCollisionExitAction { get; set; } = null;
        public Action<Collision>? OnCollisionStayAction { get; set; } = null;
        public Action? OnMouseDownAction { get; set; } = null;
        public Action? OnMouseDragAction { get; set; } = null;
        public Action? OnMouseEnterAction { get; set; } = null;
        public Action? OnMouseExitAction { get; set; } = null;
        public Action? OnMouseOverAction { get; set; } = null;
        public Action? OnMouseUpAction { get; set; } = null;
        public Action? OnMouseUpAsButtonAction { get; set; } = null;
        public Action<Collider>? OnTriggerEnterAction { get; set; } = null;
        public Action<Collider>? OnTriggerExitAction { get; set; } = null;
        public Action<Collider>? OnTriggerStayAction { get; set; } = null;

        private void Update()
        {
            UpdateAction?.Invoke();
        }

        private void Awake()
        {
            AwakeAction?.Invoke();
        }

        private void Reset()
        {
            ResetAction?.Invoke();
        }

        private void Start()
        {
            StartAction?.Invoke();
        }

        private void FixedUpdate()
        {
            FixedUpdateAction?.Invoke();
        }

        private void LateUpdate()
        {
            LateUpdateAction?.Invoke();
        }

        private void OnEnable()
        {
            OnEnableAction?.Invoke();
        }

        private void OnDisable()
        {
            OnDisableAction?.Invoke();
        }

        private void OnDestroy()
        {
            OnDestroyAction?.Invoke();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            OnApplicationFocusAction?.Invoke();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            OnApplicationPauseAction?.Invoke();
        }

        private void OnApplicationQuit()
        {
            OnApplicationQuitAction?.Invoke();
        }

        private void OnBecameInvisible()
        {
            OnBecameVisibleAction?.Invoke();
        }

        private void OnBecameVisible()
        {
            OnBecameInvisibleAction?.Invoke();
        }

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

        private void OnMouseDown()
        {
            OnMouseDownAction?.Invoke();
        }

        private void OnMouseDrag()
        {
            OnMouseDragAction?.Invoke();
        }

        private void OnMouseEnter()
        {
            OnMouseEnterAction?.Invoke();
        }

        private void OnMouseExit()
        {
            OnMouseExitAction?.Invoke();
        }

        private void OnMouseOver()
        {
            OnMouseOverAction?.Invoke();
        }

        private void OnMouseUp()
        {
            OnMouseUpAction?.Invoke();
        }

        private void OnMouseUpAsButton()
        {
            OnMouseUpAsButtonAction?.Invoke();
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