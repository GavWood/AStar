using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BWRiver))]
public class BWRiverEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Cast the target to MyComponent
        BWRiver river = (BWRiver)target;

        // Add a button to the inspector
        if (GUILayout.Button("Create River"))
        {
            river.CreateRiver();
        }

        // Button to delete the river
        if (GUILayout.Button("Delete River"))
        {
            river.DeleteRiver();
        }

        // Button to flatten the terrain
        if (GUILayout.Button("Flatten Terrain"))
        {
            river.FlattenTerrain();
        }
    }
}
