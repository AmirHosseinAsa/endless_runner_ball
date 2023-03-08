//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateContext {

    public GameStateEntity jumpingEntity { get { return GetGroup(GameStateMatcher.Jumping).GetSingleEntity(); } }

    public bool isJumping {
        get { return jumpingEntity != null; }
        set {
            var entity = jumpingEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isJumping = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    static readonly JumpingComponent jumpingComponent = new JumpingComponent();

    public bool isJumping {
        get { return HasComponent(GameStateComponentsLookup.Jumping); }
        set {
            if (value != isJumping) {
                var index = GameStateComponentsLookup.Jumping;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : jumpingComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameStateMatcher {

    static Entitas.IMatcher<GameStateEntity> _matcherJumping;

    public static Entitas.IMatcher<GameStateEntity> Jumping {
        get {
            if (_matcherJumping == null) {
                var matcher = (Entitas.Matcher<GameStateEntity>)Entitas.Matcher<GameStateEntity>.AllOf(GameStateComponentsLookup.Jumping);
                matcher.componentNames = GameStateComponentsLookup.componentNames;
                _matcherJumping = matcher;
            }

            return _matcherJumping;
        }
    }
}
