using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[ExecuteInEditMode]
public class BWRiver : MonoBehaviour
{
    [SerializeField]
    GameObject _riverStart;

    [SerializeField]
    GameObject _riverEnd;

    [SerializeField]
    LineRenderer _lineRenderer;

    [SerializeField]
    private Terrain _terrain;

    private AStar _aStar;
    private List<Vector2Int> _path;

    public void FlattenTerrain()
    {
        // Get the terrain data
        TerrainData terrainData = _terrain.terrainData;

        UnityEngine.Debug.Log("Flattening terrain of resolution " + terrainData.heightmapResolution);

        // Create a 2D array based on terrain width and height
        float[,] heights = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];

        // Fill the array with a flat value (e.g., 0.5f to set it to half the max height)
        for (int x = 0; x < terrainData.heightmapResolution; x++)
        {
            for (int y = 0; y < terrainData.heightmapResolution; y++)
            {
                heights[x, y] = 0;
            }
        }

        // Set the heights to the terrain data
        terrainData.SetHeights(0, 0, heights);
    }

    private float CalcHeightDifference(BWAStarNode current, BWAStarNode next)
    {
        // implement your cost calculation here, 
        // e.g., use Vector2Int.Distance(a.Position, b.Position);
        float euclidianDistance = Vector2Int.Distance(current.Position, next.Position);

        float cost = euclidianDistance + Mathf.Abs(current.Height - next.Height);

        return cost;
    }

    public void CreateRiver()
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start(); // Start timing

        UnityEngine.Debug.Log("Create River was pressed");

        BWTerrainToAStar aStarFromTerrain = new BWTerrainToAStar(_terrain);

        Vector2Int riverStartPoint = aStarFromTerrain.ConvertFromWorldToLocalGridPoint(_riverStart.transform.position);
        Vector2Int riverEndPoint = aStarFromTerrain.ConvertFromWorldToLocalGridPoint(_riverEnd.transform.position);

        BWAStarNode start = aStarFromTerrain._nodes.Find(node => node.Position == riverStartPoint);
        BWAStarNode end   = aStarFromTerrain._nodes.Find(node => node.Position == riverEndPoint);

        // Do the A Star calculation
        _aStar = new AStar(aStarFromTerrain._nodes, start, end, CalcHeightDifference);

        _path = _aStar.CalculateAStar();

        stopwatch.Stop(); // Stop timing

        UnityEngine.Debug.Log("Points " + _path.Count);
        UnityEngine.Debug.Log("Time taken: " + stopwatch.Elapsed.TotalMilliseconds + " ms");

        _lineRenderer.startColor = Color.white;
        _lineRenderer.endColor = Color.white;
        _lineRenderer.startWidth = 5.0f;
        _lineRenderer.endWidth = 5.0f;

        // Render this using the line renderer
        _lineRenderer.positionCount = _path.Count;
        for (int i = 0; i < _path.Count; i++)
        {
            Vector3 worldPos = aStarFromTerrain.ConvertFromLocalGridPointToWorld(_path[i]);
            worldPos.y += 0.1f;
            _lineRenderer.SetPosition(i, worldPos);
        }
    }

    public void DeleteRiver()
    {
        _lineRenderer.positionCount = 0;

        if (_path != null)
        {
            _path.Clear();
        }
    }
}
