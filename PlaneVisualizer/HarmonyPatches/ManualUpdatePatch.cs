using HarmonyLib;
using IPA.Utilities;
using System.Reflection;
using UnityEngine;

namespace PlaneVisualizer.HarmonyPatches
{
    [HarmonyPatch(typeof(Saber), "ManualUpdate")]
    public class ManualUpdatePatch
    {
        static void Postfix(ref SaberMovementData ____movementData, ref Transform ____topPos, ref Transform ____bottomPos, ref SaberTypeObject ____saberType)
        {
            if (!Config.enabled)
                return;
            var data = typeof(SaberMovementData).GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(____movementData) as SaberMovementData.Data[];
            int nextAddIndex = (int) typeof(SaberMovementData).GetField("_nextAddIndex", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(____movementData);

            var num = data.Length;
            int addIndex = nextAddIndex == 0 ? num - 1 : nextAddIndex - 1;
            var prevAddIndex = addIndex == 0 ? num - 1 : addIndex - 1;

            Vector3 prevTopPos = data[prevAddIndex].topPos;
            Vector3 prevBottomPos = data[prevAddIndex].bottomPos;
            var throwaway = Vector3.zero;
            Quaternion orientation = Quaternion.identity;

            var topPos = ____topPos.position;
            var bottomPos = ____bottomPos.position;
            GeometryTools.ThreePointsToBox(topPos, bottomPos, (prevBottomPos + prevTopPos) * 0.5f, out throwaway, out throwaway, out orientation);

            //Logger.log.Debug("test");
            PlaneVisualizerController.instance.visualizer.UpdatePlane(topPos, orientation, ____saberType.saberType);
        }
    }
}