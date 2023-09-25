#nullable enable
using System;
using System.Collections.Generic;
using UnityEngine;

public class BWAStarNode : IComparable<BWAStarNode>
{
    public Vector2Int Position { get; set; }
    public float GCost { get; set; }
    public float HCost { get; set; }
    public float Height { get; set; }
    public BWAStarNode? Parent { get; set; }
    public List<BWAStarNode> Neighbors { get; } = new List<BWAStarNode>();

    public BWAStarNode(Vector2Int pos, float gCost, float hCost, float height, BWAStarNode? parent = null)
    {
        Position = pos;
        Parent = parent;
        GCost = gCost;
        HCost = hCost;
        Height = height;
        Neighbors = new List<BWAStarNode>();
    }    
    public float FCost => GCost + HCost;

    public override bool Equals(object obj)
    {
        if (obj is BWAStarNode other)
        {
            return Position.Equals(other.Position);
        }
        return false;
    }

    public override int GetHashCode()
    {
        int hashCode = (Position.x * 10000) + Position.y;
        return hashCode;
    }

    public int CompareTo(BWAStarNode other)
    {
        int compare = FCost.CompareTo(other.FCost);
        if (compare == 0)
        {
            // If FCosts are equal, compare HCosts for tie-breaking
            compare = HCost.CompareTo(other.HCost);
        }
        return -compare; // Invert to dequeue the node with the lowest FCost first
    }
}
