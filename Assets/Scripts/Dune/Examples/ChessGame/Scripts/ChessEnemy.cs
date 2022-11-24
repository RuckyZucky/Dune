#nullable enable
using Dune.Descriptors;
using Dune.Framework;
using Dune.Objects;
using UnityEngine;

namespace Dune.Examples.ChessGame.Scripts
{
    public class ChessEnemy : StatelessDuneObject
    {
        public Vector2 Position { get; init; }
        
        public override DuneObject Build()
        {
            return new DuneTransform
            {
                Position = new Vector3(Position.x + 0.5f, 0.5f, Position.y + 0.5f),
                Target = new DuneEmpty
                {
                    Name = "Enemy",
                    Children =
                    {
                        new DunePrefabObject{ PrefabPath = "Prefabs/BlackPawn" }
                    }
                }
            };
        }
    }
}