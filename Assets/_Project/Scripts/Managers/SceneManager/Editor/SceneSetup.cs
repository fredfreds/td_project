using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace TDProject.SceneManager
{
    [InitializeOnLoad]
    public class SceneSetup
    {
        static SceneSetup()
        {
            EditorSceneManager.newSceneCreated += CreateScene;
        }

        public static void CreateScene(Scene scene, NewSceneSetup setup, NewSceneMode mode)
        {
            Transform light = GameObject.Find("Directional Light").transform;
            Transform lights = new GameObject("Lights").transform;
            light.parent = lights;

            Transform camera = Camera.main.transform;
            Transform cams = new GameObject("Cameras").transform;
            camera.parent = cams;

            Transform setupObj = new GameObject("[SETUP]").transform;
            cams.parent = setupObj;
            lights.parent = setupObj;

            Transform world = new GameObject("[WORLD]").transform;
            Transform staticObjs = new GameObject("Static").transform;
            Transform dynamicObjs = new GameObject("Dynamic").transform;
            staticObjs.parent = world;
            dynamicObjs.parent = world;

            Transform ui = new GameObject("[UI]").transform;

            Debug.Log("Scene created!");
        }
    }
}