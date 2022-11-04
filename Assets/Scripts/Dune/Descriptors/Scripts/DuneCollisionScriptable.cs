#nullable enable
using System;
using Dune.Framework;
using UnityEngine;

namespace Dune.Descriptors.Scripts
{
    public class DuneCollisionScriptable : DuneDescriptor<CollisionScriptBehaviour>
    {
        public Action<Collision>? OnCollisionEnter { get; init; } = null;
        public Action<Collision>? OnCollisionExit { get; init; } = null;
        public Action<Collision>? OnCollisionStay { get; init; } = null;
        public Action<Collider>? OnTriggerEnter { get; init; } = null;
        public Action<Collider>? OnTriggerExit { get; init; } = null;
        public Action<Collider>? OnTriggerStay { get; init; } = null;

        public override void PopulateComponent(ref CollisionScriptBehaviour component)
        {
            
            component.OnCollisionEnterAction = OnCollisionEnter;
            component.OnCollisionExitAction = OnCollisionExit;
            component.OnCollisionStayAction = OnCollisionStay;
            
            component.OnTriggerEnterAction = OnTriggerEnter;
            component.OnTriggerExitAction = OnTriggerExit;
            component.OnTriggerStayAction = OnTriggerStay;
        }
    }
}