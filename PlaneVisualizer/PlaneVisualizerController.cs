using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PlaneVisualizer
{
	public class PlaneVisualizerController : MonoBehaviour
    {
        public static PlaneVisualizerController instance { get; private set; }
        public Visualizer visualizer { get; private set; } 

        private void Awake()
        {
            if (instance != null)
            {
                Logger.log?.Warn($"Instance of {this.GetType().Name} already exists, destroying.");
                GameObject.DestroyImmediate(this);
                return;
            }
            GameObject.DontDestroyOnLoad(this); // Don't destroy this object on scene changes
            instance = this;
            Logger.log?.Debug($"{name}: Awake()");
        }

        internal void OnGameSceneLoad()
        {
            visualizer = new GameObject("Plane Visualizer").AddComponent<Visualizer>();
        }
    }
}
