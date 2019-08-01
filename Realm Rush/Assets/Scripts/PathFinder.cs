using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        //ExploreNeighbours();
        PathFind();
        EnlistPath();
        ColorWaypoints();
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();

            if (searchCenter == endWaypoint)
            {
                print("Start and end are the same, therefore stopped running");
                break;
            }

            QueueNewNeighbours(searchCenter);
        }
        print("Finished pathfinding");
    }

    private void QueueNewNeighbours(Waypoint searchCenter)
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoords = searchCenter.GetGridPos() + direction;

            try
            {
                if (grid[explorationCoords].isExplored == true)
                {
                    continue;
                }
                else
                {
                    queue.Enqueue(grid[explorationCoords]);
                    grid[explorationCoords].isExplored = true;
                    grid[explorationCoords].previousWaypoint = searchCenter;
                }
            }
            catch
            {

            }
        }
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoords = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoords].SetTopColor(Color.blue);
            }
            catch
            {

            }
        }
    }

    private void ColorWaypoints()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void EnlistPath()
    {
        Waypoint currentWaypoint = endWaypoint;
        do
        {
            path.Add(currentWaypoint);
            currentWaypoint = currentWaypoint.previousWaypoint;
        } while (currentWaypoint != startWaypoint);

        path.Add(currentWaypoint);

        path.Reverse();
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
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }

    public List<Waypoint> GetPath()
    {
        return path;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
