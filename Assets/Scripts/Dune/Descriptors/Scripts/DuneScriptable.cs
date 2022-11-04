#nullable enable
using System;
using Dune.Framework;
using UnityEngine;

namespace Dune.Descriptors.Scripts
{
    public class DuneScriptable : DuneDescriptor<ScriptableBehaviour>
    {
        public Action? Update { get; init; } = null;
        public Action? Awake { get; init; } = null;
        public Action? Reset { get; init; } = null;
        public Action? Start { get; init; } = null;
        public Action? FixedUpdate { get; init; } = null;
        public Action? LateUpdate { get; init; } = null;
        public Action? OnEnable { get; init; } = null;
        public Action? OnDisable { get; init; } = null;
        public Action? OnDestroy { get; init; } = null;
        public Action? OnApplicationFocus { get; init; } = null;
        public Action? OnApplicationPause { get; init; } = null;
        public Action? OnApplicationQuit { get; init; } = null;
        public Action? OnBecameVisible { get; init; } = null;
        public Action? OnBecameInvisible { get; init; } = null;
        public Action<Collision>? OnCollisionEnter { get; init; } = null;
        public Action<Collision>? OnCollisionExit { get; init; } = null;
        public Action<Collision>? OnCollisionStay { get; init; } = null;
        public Action? OnMouseDown { get; init; } = null;
        public Action? OnMouseDrag { get; init; } = null;
        public Action? OnMouseEnter { get; init; } = null;
        public Action? OnMouseExit { get; init; } = null;
        public Action? OnMouseOver { get; init; } = null;
        public Action? OnMouseUp { get; init; } = null;
        public Action? OnMouseUpAsButton { get; init; } = null;
        public Action<Collider>? OnTriggerEnter { get; init; } = null;
        public Action<Collider>? OnTriggerExit { get; init; } = null;
        public Action<Collider>? OnTriggerStay { get; init; } = null;

        public override void PopulateComponent(ref ScriptableBehaviour component)
        {
            component.UpdateAction = Update;
            component.AwakeAction = Awake;
            component.ResetAction = Reset;
            component.StartAction = Start;
            component.FixedUpdateAction = FixedUpdate;
            component.LateUpdateAction = LateUpdate;
            component.OnEnableAction = OnEnable;
            component.OnDisableAction = OnDisable;
            component.OnDestroyAction = OnDestroy;
            component.OnApplicationFocusAction = OnApplicationFocus;
            component.OnApplicationPauseAction = OnApplicationPause;
            component.OnApplicationQuitAction = OnApplicationQuit;
            component.OnBecameVisibleAction = OnBecameVisible;
            component.OnBecameInvisibleAction = OnBecameInvisible;
            component.OnCollisionEnterAction = OnCollisionEnter;
            component.OnCollisionExitAction = OnCollisionExit;
            component.OnCollisionStayAction = OnCollisionStay;
            component.OnMouseDownAction = OnMouseDown;
            component.OnMouseDragAction = OnMouseDrag;
            component.OnMouseEnterAction = OnMouseEnter;
            component.OnMouseExitAction = OnMouseExit;
            component.OnMouseOverAction = OnMouseOver;
            component.OnMouseUpAction = OnMouseUp;
            component.OnMouseUpAsButtonAction = OnMouseUpAsButton;
            component.OnTriggerEnterAction = OnTriggerEnter;
            component.OnTriggerExitAction = OnTriggerExit;
            component.OnTriggerStayAction = OnTriggerStay;
        }
    }
}