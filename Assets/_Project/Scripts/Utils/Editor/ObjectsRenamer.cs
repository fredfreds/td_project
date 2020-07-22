using UnityEngine;
using UnityEditor;

namespace TDProject
{
    public class ObjectsRenamer : ScriptableWizard
    {
        public string NewName = "Waypoint";
        public bool DoRename = true;

        [MenuItem("Tools/Rename Objects")]
        static void CreateWizard()
        {
            DisplayWizard(("Rename Objects"), typeof(ObjectsRenamer), "Select and Rename");
        }

        void OnWizardCreate()
        {
            if (DoRename)
            {
                RenameObjects(NewName);
            }
        }

        void RenameObjects(string name)
        {
            GameObject[] objs = Selection.gameObjects;
            foreach (GameObject obj in objs)
            {
                obj.name = name;
            }
        }
    }
}