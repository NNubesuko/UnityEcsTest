using Unity.Entities;
using UnityEngine;

namespace UnityEcsTest.Main.Executes.EntityScene_01
{
    public class ExecuteAuthoring : MonoBehaviour
    {
        class Baker : Baker<ExecuteAuthoring>
        {
            public override void Bake(ExecuteAuthoring authoring)
            {
                AddComponent<Execute>();
            }
        }
    }

    public struct Execute : IComponentData
    {
    }
}