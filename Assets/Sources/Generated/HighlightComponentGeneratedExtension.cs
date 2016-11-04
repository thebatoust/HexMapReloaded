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

        public HighlightComponent highlight { get { return (HighlightComponent)GetComponent(CoreComponentIds.Highlight); } }
        public bool hasHighlight { get { return HasComponent(CoreComponentIds.Highlight); } }

        public Entity AddHighlight(HighlightMode newMode) {
            var component = CreateComponent<HighlightComponent>(CoreComponentIds.Highlight);
            component.Mode = newMode;
            return AddComponent(CoreComponentIds.Highlight, component);
        }

        public Entity ReplaceHighlight(HighlightMode newMode) {
            var component = CreateComponent<HighlightComponent>(CoreComponentIds.Highlight);
            component.Mode = newMode;
            ReplaceComponent(CoreComponentIds.Highlight, component);
            return this;
        }

        public Entity RemoveHighlight() {
            return RemoveComponent(CoreComponentIds.Highlight);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherHighlight;

        public static IMatcher Highlight {
            get {
                if(_matcherHighlight == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Highlight);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherHighlight = matcher;
                }

                return _matcherHighlight;
            }
        }
    }
