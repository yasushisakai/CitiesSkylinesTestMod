using ICities;
using UnityEngine;

namespace CitiesSkylinesTestMod
{
    public class TestModLoading : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            Debug.Log("Cities Skylines Test Mod Loaded");               
        }
    }
}
