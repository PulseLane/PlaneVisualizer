//using HarmonyLib;
//using UnityEngine;

//namespace PlaneVisualizer.HarmonyPatches
//{
//    [HarmonyPatch(typeof(SaberMovementData), "AddNewData")]
//    public class AddNewDataPatch
//    {
//        static void Postfix(ref SaberMovementData __instance, Vector3 topPos, Vector3 bottomPos, ref SaberMovementData.Data[] ____data, ref int ____nextAddIndex)
//        {
//            var num = ____data.Length;
//            int addIndex = (____nextAddIndex - 1) % num;
//            int prevAddIndex = (addIndex - 1) % num;
//            Vector3 prevTopPos = ____data[prevAddIndex].topPos;
//            Vector3 prevBottomPos = ____data[prevAddIndex].bottomPos;
//            var throwaway = Vector3.zero;
//            Quaternion orientation = Quaternion.identity;
//            GeometryTools.ThreePointsToBox(topPos, bottomPos, (prevBottomPos + prevTopPos) * 0.5f, out throwaway, out throwaway, out orientation);
//            Logger.log.Debug("test");
//            Utils.UpdatePlane(__instance, topPos, orientation);
//            //Vector3 vector = orientation * Vector3.up;
//            //Plane plane = new Plane(vector, cutPoint);
//            //Utils.DrawPlane(cutPoint, vector);
//            //Utils.DrawCube(cutPoint);
//            //Utils.DrawPlane(cutPoint, orientation);
//        }
//    }
//}