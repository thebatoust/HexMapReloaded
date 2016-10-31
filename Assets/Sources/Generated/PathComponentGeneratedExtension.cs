//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

namespace Entitas {

    public partial class Entity {

        public PathComponent path { get { return (PathComponent)GetComponent(CoreComponentIds.Path); } }
        public bool hasPath { get { return HasComponent(CoreComponentIds.Path); } }

        public Entity AddPath(UnityEngine.Vector3[] newMapPositions) {
            var component = CreateComponent<PathComponent>(CoreComponentIds.Path);
            component.MapPositions = newMapPositions;
            return AddComponent(CoreComponentIds.Path, component);
        }

        public Entity ReplacePath(UnityEngine.Vector3[] newMapPositions) {
            var component = CreateComponent<PathComponent>(CoreComponentIds.Path);
            component.MapPositions = newMapPositions;
            ReplaceComponent(CoreComponentIds.Path, component);
            return this;
        }

        public Entity RemovePath() {
            return RemoveComponent(CoreComponentIds.Path);
        }
    }

    public partial class Pool {

        public Entity pathEntity { get { return GetGroup(CoreMatcher.Path).GetSingleEntity(); } }
        public PathComponent path { get { return pathEntity.path; } }
        public bool hasPath { get { return pathEntity != null; } }

        public Entity SetPath(UnityEngine.Vector3[] newMapPositions) {
            if(hasPath) {
                throw new EntitasException("Could not set path!\n" + this + " already has an entity with PathComponent!",
                    "You should check if the pool already has a pathEntity before setting it or use pool.ReplacePath().");
            }
            var entity = CreateEntity();
            entity.AddPath(newMapPositions);
            return entity;
        }

        public Entity ReplacePath(UnityEngine.Vector3[] newMapPositions) {
            var entity = pathEntity;
            if(entity == null) {
                entity = SetPath(newMapPositions);
            } else {
                entity.ReplacePath(newMapPositions);
            }

            return entity;
        }

        public void RemovePath() {
            DestroyEntity(pathEntity);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherPath;

        public static IMatcher Path {
            get {
                if(_matcherPath == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Path);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherPath = matcher;
                }

                return _matcherPath;
            }
        }
    }
