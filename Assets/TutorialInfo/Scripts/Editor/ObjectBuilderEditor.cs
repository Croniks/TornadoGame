using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(ObjectBuilder))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ObjectBuilder myScript = (ObjectBuilder)target;
        if(GUILayout.Button("Build objects"))
        {
            myScript.BuildObjects();
        }
    }
}