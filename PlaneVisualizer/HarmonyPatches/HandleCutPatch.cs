//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using HarmonyLib;
//using UnityEngine;

//namespace PlaneVisualizer.HarmonyPatches
//{
//    [HarmonyPatch(typeof(GameNoteController), "HandleCut")]
//    public class HandleCutPatch
//    {
//        static void Postfix(ref Quaternion orientation, ref Vector3 cutPoint)
//        {
//            Logger.log.Debug("Patching");
//            //Vector3 vector = orientation * Vector3.up;
//            //Plane plane = new Plane(vector, cutPoint);
//            //Utils.DrawPlane(cutPoint, vector);
//            //Utils.DrawCube(cutPoint);
//            Utils.DrawPlane(cutPoint, orientation);
//        }
//    }
//}