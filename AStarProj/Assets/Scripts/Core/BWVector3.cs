using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BWVector3
{
    public static bool ApproxEquals(this Vector3 a, Vector3 b, float tolerance = float.NaN)
    {
        if (float.IsNaN(tolerance))
        {
            tolerance = Mathf.Epsilon;
        }

        float sqrDist = (a - b).sqrMagnitude;
        return sqrDist <= tolerance * tolerance;
    }
}
