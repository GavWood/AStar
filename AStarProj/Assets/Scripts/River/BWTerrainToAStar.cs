using UnityEngine;
using System.Collections.Generic;

public class BWTerrainToAStar
{
    public List<BWAStarNode> _nodes;
    private Terrain _terrain;

    public BWTerrainToAStar(Terrain terrain)
    {
        _terrain = terrain;
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        int resolution = _terrain.terrainData.heightmapResolution;

        BWAStarNode[,] _grid = new BWAStarNode[resolution, resolution];

        _grid = new BWAStarNode[resolution, resolution];

        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                float gCost = float.MaxValue;
                float hCost = 0;
                float height = _terrain.terrainData.GetHeight(x, y);

                _grid[x, y] = new BWAStarNode(new Vector2Int(x, y), gCost, hCost, height);
            }
        }

        // Add the neighbours
        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                List<BWAStarNode> neighbours = new List<BWAStarNode>();
                int[,] offsets = {
                    {  0,  1 },   // Up
                    {  1,  0 },   // Right
                    {  0, -1 },   // Down
                    { -1,  0 }    // Left
                };

                for (int i = 0; i < 4; i++)
                {
                    int dx = offsets[i, 0];
                    int dy = offsets[i, 1];
                    int nx = x + dx;
                    int ny = y + dy;

                    if (nx >= 0 && nx < resolution && ny >= 0 && ny < resolution)
                    {
                        _grid[x, y].Neighbors.Add(_grid[nx, ny]);
                    }
                }
            }
        }

        _nodes = new List<BWAStarNode>();

        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                _nodes.Add( _grid[x, y] );
            }
        }
    }

    public Vector2Int ConvertFromWorldToLocalGridPoint(Vector3 worldPosition)
    {
        Vector3 terrainSize = _terrain.terrainData.size;
        float resolution = (float)_terrain.terrainData.heightmapResolution - 1;
        Vector3 cellSize = new Vector3(terrainSize.x / resolution, 0, terrainSize.z / resolution);

        Vector3 localPosition = worldPosition - _terrain.transform.position;

        Vector2Int gridCoord = new Vector2Int(
            Mathf.FloorToInt(localPosition.x / cellSize.x),
            Mathf.FloorToInt(localPosition.z / cellSize.z)
        );
        return gridCoord;
    }

    public Vector3 ConvertFromLocalGridPointToWorld(Vector2Int gridCoord)
    {
        Vector3 terrainSize = _terrain.terrainData.size;
        float resolution = (float)_terrain.terrainData.heightmapResolution - 1;

        Vector3 cellSize = new Vector3(terrainSize.x / resolution, 0, terrainSize.z / resolution);

        Vector3 localPosition = new Vector3(gridCoord.x * cellSize.x, 0, gridCoord.y * cellSize.z);
        Vector3 worldPosition = localPosition + _terrain.transform.position;

        // You might want to adjust the Y-coordinate based on the terrain's height at that point.
        worldPosition.y = _terrain.SampleHeight(worldPosition);

        return worldPosition;
    }
}
