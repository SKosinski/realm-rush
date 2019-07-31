using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            //add to dictionary
            if (isOverlapping)
            {
                Debug.LogWarning("Overlapping block: " + waypoint);
            }
            grid.Add(waypoint.GetGridPos(), waypoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
