using System;
using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    public delegate float HeuristicDelegate(BWAStarNode current, BWAStarNode next);

    #region Private Variables
    private List<BWAStarNode> _nodes;
    private BWPriorityQueue<BWAStarNode> _openSet;
    private HashSet<BWAStarNode> _closedSet;
    private BWAStarNode[,] _grid;
    private BWAStarNode _startNode;
    private BWAStarNode _endNode;
    private readonly HeuristicDelegate _heuristicCalculation;
    #endregion

    #region Constructors
    public AStar( List<BWAStarNode> nodes, BWAStarNode start, BWAStarNode end, HeuristicDelegate heuristicCalculation)
    {
        _heuristicCalculation = heuristicCalculation;
        
        this._openSet = new BWPriorityQueue<BWAStarNode>();
        this._closedSet = new HashSet<BWAStarNode>();
        this._nodes = nodes;
        this._startNode = start;
        this._endNode = end;

        // Calculate the hCost for each node based on a heuristic function like Euclidean distance or Manhattan distance to the end node.
        // For all other nodes except start, set gCost to infinity or a very high value initially.
        // For the start node, set gCost to 0.

        foreach (BWAStarNode node in nodes)
        {
            node.HCost = CalculateCost(node, end);
            node.GCost = Mathf.Infinity;
        }
        start.GCost = 0;
    }

    #endregion

    #region Private Methods

    private List<Vector2Int> RetracePath(BWAStarNode current)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        while (!current.Equals(_startNode))
        {
            path.Add(current.Position);
            current = current.Parent;
        }
        path.Add(_startNode.Position);
        path.Reverse();
        return path;
    }
    #endregion

    #region Public Interface
    public List<Vector2Int> CalculateAStar()
    {
        _openSet.Clear();
        _closedSet.Clear();
        _openSet.Enqueue(_startNode);

        while (_openSet.Count > 0)
        {
            BWAStarNode currentNode = _openSet.Dequeue();

            if (currentNode.Equals(_endNode))
            {
                return RetracePath(currentNode);
            }

            _closedSet.Add(currentNode);

            foreach (BWAStarNode neighbour in currentNode.Neighbors)
            {
                if (_closedSet.Contains(neighbour))
                {
                    continue;
                }

                float tentativeGCost = currentNode.GCost + CalculateCost(currentNode, neighbour);

                if (!_openSet.Contains(neighbour) || tentativeGCost < neighbour.GCost)
                {
                    neighbour.GCost = tentativeGCost;
                    neighbour.HCost = CalculateCost(neighbour, _endNode);
                    neighbour.Parent = currentNode;

                    if (!_openSet.Contains(neighbour))
                    {
                        _openSet.Enqueue(neighbour);
                    }
                }
            }
        }
        return new List<Vector2Int>(); // or throw an exception
    }

    private float CalculateCost(BWAStarNode a, BWAStarNode b)
    {
        if (_heuristicCalculation != null )
        {
            return _heuristicCalculation(a, b);
        }
        else
        {
            // implement your cost calculation here, 
            // e.g., use Vector2Int.Distance(a.Position, b.Position);
            float euclidianDistance = Vector2Int.Distance(a.Position, b.Position);

            float cost = euclidianDistance + Mathf.Abs(a.Height - b.Height);
            return cost;
        }
    }
    #endregion
}
