using ICities;
using UnityEngine;

namespace CitiesSkylinesTestMod
{
    public class CitiesSkylinesTestMod : IUserMod
    {
        public string Name
        {
            get
            {
                return "Test Mod";
            }
        }

        public string Description
        {
            get
            {
                return "This is a test mod.";
            }
        }
    }

}
