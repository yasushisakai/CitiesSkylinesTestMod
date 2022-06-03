using ICities;
using UnityEngine;
using ColossalFramework;

namespace CitiesSkylinesTestMod
{

    public class TestModLoading : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            Debug.Log("Cities Skylines Test Mod Loaded");
            GameObject go = new GameObject("Custom Object");
            go.AddComponent<CustomObject>();
            go.AddComponent<IntervalObject>();

        }
    }
}
