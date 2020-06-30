using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PlaneVisualizer
{
	public class Visualizer : MonoBehaviour
    {
        private GameObject planeA;
        private GameObject planeB;
        private static Vector3 scale = new Vector3(2f, 0.03f, 0.1f);

        private void Awake()
        {
            planeA = GameObject.CreatePrimitive(PrimitiveType.Cube);
            planeB = GameObject.CreatePrimitive(PrimitiveType.Cube);
            planeA.transform.localScale = scale;
            planeA.transform.localScale = scale;
        }

        internal void UpdatePlane(Vector3 topPos, Quaternion orientation, SaberType saberType)
        {
            GameObject plane = saberType.Equals(SaberType.SaberA) ? planeA : planeB;
            DrawPlane(topPos, orientation, ref plane);
        }

        private void DrawPlane(Vector3 pos, Quaternion rot, ref GameObject plane)
        {
            plane.transform.position = pos;
            plane.transform.localRotation = rot;
            plane.transform.localScale = scale;
            plane.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }
}
