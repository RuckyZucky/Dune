#nullable enable
using Dune.Framework;
using UnityEngine;

namespace Dune.Objects
{
    public class DunePrefabObject : RenderDuneObject
    {
        public string PrefabPath { get; init; } = null!;
        
        public override GameObject CreateGameObject()
        {
            return Object.Instantiate(Resources.Load<GameObject>(PrefabPath));
        }

        public override void UpdateGameObject(ref GameObject gameObject)
        {
            gameObject = CreateGameObject();
        }
    }
}