using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ModelSlicerScript))]
public class ModelSlicerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ModelSlicerScript myScript = (ModelSlicerScript)target;
        if (GUILayout.Button("Slice Model"))
        {
            myScript.SliceModel();
        }
    }
}