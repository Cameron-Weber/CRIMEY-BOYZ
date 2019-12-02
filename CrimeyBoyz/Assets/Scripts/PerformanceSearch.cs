using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

//Script to help with performance optimisation (specifically for issues we have had with the android build of mission control)
//This script searches for obects that may cause performance issues and logs a warning of any such objects found
//Specifically, this script searches
// - Mesh & Sprite renderers with their "Sorting Layer" set to anything contained in the "sus layers" list
// - Mesh & Sprite renderers not set to "Order In Layer" or 0
// - Sprite Masks that cross multiple layers, or use a sus layer
// - Sprite Masks set to a sorting range of not "1" and "-1" for front and back values
// - Check that and LWRP Light2D scripts are not using any of the sus layers listed

//This script can run in the editor mode and does not need the game to be running
//How to use:
// Attach this script to a gameobject in the scene where testing is desired
// If wanting to check LWRP lights conform to the standard: must edit CrimeyBoyz\Library\PackageCache\com.unity.render-pipelines.lightweight@6.9.1\Runtime\2D\Light2D.cs line 302 to being public (IsLitLayer method)
namespace CrimeyBoyz.Tests {

    [ExecuteInEditMode]
    public class PerformanceSearch : MonoBehaviour {

        public string[] susLayers = { "mid-background", "Default" };

        void Start() {

            foreach(string layer in susLayers) {
                if (SortingLayer.NameToID(layer) == -1) {
                    Debug.LogError("Layer string in susLayers variable is not a valid, layer in this project");
                }
            }

            Renderer[] allRenderers = Resources.FindObjectsOfTypeAll<Renderer>();

            foreach (Renderer r in allRenderers) {

                if(r.transform.root.gameObject.scene.name == null) {
                    continue;
                }

                if (r.sortingOrder != 0) {
                    Debug.LogWarning("Found a renderer with \"Order In Layer\" not 0 - " + GetGameObjectPath(r.gameObject), r);
                }

                if (r.GetType().Equals(typeof(SpriteMask))) {
                    SpriteMask m = (SpriteMask) r;

                    if (m.backSortingLayerID != m.frontSortingLayerID) {
                        Debug.LogWarning("Found a SpriteMask that crosses multiple sorting layers, could harm android performance - " + GetGameObjectPath(r.gameObject), r);
                    }

                    if(m.backSortingOrder != -1 | m.frontSortingOrder != 1) {
                        Debug.LogWarning("Found a SpriteMask that has front and back \"order in layer\" not equal to -1 and 1, could harm android performance - " + GetGameObjectPath(r.gameObject), r);
                    }

                    foreach (string layer in susLayers) {
                        int layerID = SortingLayer.NameToID(layer);
                        if (m.frontSortingLayerID == layerID) {
                            Debug.LogWarning("Found a SpriteMask set to unexpected front sorting layer (" + layer + ") - " + GetGameObjectPath(r.gameObject), r);
                        }
                        if (m.backSortingLayerID == layerID) {
                            Debug.LogWarning("Found a SpriteMask set to unexpected back sorting layer (" + layer + ") - " + GetGameObjectPath(r.gameObject), r);
                        }
                    }


                } else {
                    foreach (string layer in susLayers) {
                        if (r.sortingLayerName.Equals(layer)) {
                            Debug.LogWarning("Found a renderer with set to unexpected sorting layer (" + r.sortingLayerName + ") - " + GetGameObjectPath(r.gameObject), r);
                        }
                    }
                }
            }

            Light2D[] allLights = Resources.FindObjectsOfTypeAll<Light2D>();

            var method = typeof(Light2D).GetMethod("IsLitLayer");

            if (method != null) {
                foreach (Light2D l in allLights) {
                    foreach (string layer in susLayers) {
                        object result = method.Invoke(l, new object[] { SortingLayer.NameToID(layer) });
                        if ((bool) result) {
                            Debug.LogWarning("Found a light set to light and unexpected sorting layer (" + layer + ") - " + GetGameObjectPath(l.gameObject), l);
                        }
                    }
                }
            } else {
                Debug.LogWarning("IsLitLayer() method not found in Light2D script, will not get the most out of this script");
            }
        }

        private string GetGameObjectPath(GameObject obj) {
            string path = obj.name;
            Transform parent = obj.transform.parent;
            while (parent != null) {
                path = parent.name + "/" + path;
                parent = parent.parent;
            }

            return path;
        }
    }
}
