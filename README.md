# AStar
Completely original code for implementing A* on terrains

![image](https://github.com/GavWood/AStar/assets/17795588/e92f2499-568f-49aa-97e9-d4ad54289a2a)

Figure 1. Picture of a river winding its away around some higher relief on a terrain.

This code base is yours to use for exploring pathing and written to be a very neat and simple implementation of A*.

The A* is currently setup from a terrain and uses this cost function which is can be used to path find a river or robot that does not like inclines.

    private float CalcHeightDifference(BWAStarNode current, BWAStarNode next)
    {
        // implement your cost calculation here, 
        // e.g., use Vector2Int.Distance(a.Position, b.Position);
        float euclidianDistance = Vector2Int.Distance(current.Position, next.Position);

        float cost = euclidianDistance + Mathf.Abs(current.Height - next.Height);

        return cost;
    }
    
