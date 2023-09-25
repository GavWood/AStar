using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BWTransform
{
    //Breadth-first search
    public static Transform FindDeepChild(this Transform aParent, string aName)
    {
        Queue<Transform> queue = new Queue<Transform>();
        queue.Enqueue(aParent);
        while (queue.Count > 0)
        {
            var c = queue.Dequeue();
            if (c.name == aName)
                return c;
            foreach (Transform t in c)
                queue.Enqueue(t);
        }
        return null;
    }

    public static GameObject FindAlways(string name)
    {
#if UNITY_EDITOR
        // Check if the function is being called from Update
        System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
        System.Diagnostics.StackFrame[] stackFrames = stackTrace.GetFrames();
        foreach (var frame in stackFrames)
        {
            if (frame.GetMethod().Name == "Update")
            {
                Debug.LogWarning("FindDeepChildAlways is being called from Update. Consider moving it to Start for better performance.");
                break;
            }
        }
#endif
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            objectsInScene.Add(go);
        }
        return objectsInScene.Find(x => x.name == name);
    }

    public static GameObject FindDeepChildAlways(this Transform aParent, string name)
    {
#if UNITY_EDITOR
        // Check if the function is being called from Update
        System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
        System.Diagnostics.StackFrame[] stackFrames = stackTrace.GetFrames();
        foreach (var frame in stackFrames)
        {
            if (frame.GetMethod().Name == "Update")
            {
                Debug.LogWarning("FindDeepChildAlways is being called from Update. Consider moving it to Start for better performance.");
                break;
            }
        }
#endif
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if ((go.name == name) && aParent.root )
            {
                return go;
            }
        }
        return null;
    }
}
