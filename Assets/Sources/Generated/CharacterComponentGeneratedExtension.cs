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

        public CharacterComponent character { get { return (CharacterComponent)GetComponent(CoreComponentIds.Character); } }
        public bool hasCharacter { get { return HasComponent(CoreComponentIds.Character); } }

        public Entity AddCharacter(string newName) {
            var component = CreateComponent<CharacterComponent>(CoreComponentIds.Character);
            component.Name = newName;
            return AddComponent(CoreComponentIds.Character, component);
        }

        public Entity ReplaceCharacter(string newName) {
            var component = CreateComponent<CharacterComponent>(CoreComponentIds.Character);
            component.Name = newName;
            ReplaceComponent(CoreComponentIds.Character, component);
            return this;
        }

        public Entity RemoveCharacter() {
            return RemoveComponent(CoreComponentIds.Character);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherCharacter;

        public static IMatcher Character {
            get {
                if(_matcherCharacter == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Character);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherCharacter = matcher;
                }

                return _matcherCharacter;
            }
        }
    }