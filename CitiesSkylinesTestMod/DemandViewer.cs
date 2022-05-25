using ICities;
using UnityEngine;
using UnityEngine.Networking;

namespace CitiesSkylinesTestMod
{
    public class DemandViewer : DemandExtensionBase
    {
        public override int OnCalculateResidentialDemand(int originalDemand) {
            string mes = "residential demand: " + originalDemand;
            Debug.Log(mes);
            return originalDemand;
        }

        public override int OnCalculateCommercialDemand(int originalDemand) {
            string mes = "commercial demand: " + originalDemand;
            Debug.Log(mes);
            return originalDemand;
        }

        public override int OnCalculateWorkplaceDemand(int originalDemand) {
            string mes = "workplace demand: " + originalDemand;
            Debug.Log(mes);
            return originalDemand;
        }
    }
}
