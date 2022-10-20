﻿#nullable enable
using System.Collections.Generic;
using UnityEngine;

namespace Dune.Framework
{
    public class DuneEmpty : ChildrenRenderDuneObject
    {
        public string Name { get; init; } = "Empty";

        public string Tag { get; init; } = "Untagged";

        public int Layer { get; init; } = 0;

        public DuneEmpty() : base(new List<DuneObject>())
        {

        }

        public override GameObject CreateGameObject()
        {
            var gameObject = new GameObject(name: Name)
            {
                tag = Tag,
                layer = Layer
            };
            return gameObject;
        }

        public override void UpdateGameObject(ref GameObject gameObject)
        {
            gameObject.name = Name;
            gameObject.tag = Tag;
            gameObject.layer = Layer;
        }
    }
}