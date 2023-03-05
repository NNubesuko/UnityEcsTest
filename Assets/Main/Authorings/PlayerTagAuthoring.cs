using Unity.Entities;
using UnityEngine;

namespace UnityEcsTest.Main.Authorings
{
    public class PlayerTagAuthoring : MonoBehaviour
    {
        class Baker : Baker<PlayerTagAuthoring>
        {
            public override void Bake(PlayerTagAuthoring authoring)
            {
                AddComponent(new PlayerTag());
            }
        }
    }

    public struct PlayerTag : IComponentData
    {
    }
}