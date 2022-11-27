#nullable enable
using System.Collections.Generic;
using Dune.Descriptors;
using Dune.Framework;
using Dune.Objects;
using UnityEngine;

namespace Dune.Examples.ChessGame.Scripts
{
    public class ChessEnemyInfo
    {
        public Vector2 Pos { get; set; }
        public bool Beatable { get; set; }
        
        public bool Check { get; set; }
    }
    
    public struct ChessEnemyState
    {
        public bool Sleeping { get; set; }
    }
    
    public class ChessEnemy : StatefulDuneObject<ChessEnemyState>
    {
        public Vector2 Position { get; init; }
        public bool Beatable { get; init; }
        
        public bool Check { get; init; }

        private ChessEnemyState _state = new()
        {
            Sleeping = true
        };
        
        public override ChessEnemyState State
        {
            get => _state; 
            set => _state = value;
        }


        public override DuneObject Build()
        {
            var children = new List<DuneObject>
            {
                new DunePrefabObject{ PrefabPath = "Prefabs/BlackPawn" },
            };
            if (Beatable)
            {
                children.Add(new DuneTransform
                {
                    LocalPosition = new Vector3(0, -0.5f, 0),
                    Target = new DunePrefabObject
                    {
                        PrefabPath = "Prefabs/Beatable"
                    }
                });
            }

            if (Check)
            {
                children.Add(new DuneTransform
                {
                    LocalPosition = new Vector3(0, -0.5f, 0),
                    Target = new DunePrefabObject
                    {
                        PrefabPath = "Prefabs/Check"
                    }
                });
            }
            
            return new DuneTransform
            {
                Position = new Vector3(Position.x + 0.5f, 0.5f, Position.y + 0.5f),
                Target = new DuneEmpty
                {
                    Name = "Enemy",
                    Children = children,
                }
            };
        }
    }
}