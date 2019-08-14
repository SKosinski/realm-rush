using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] int maxTowers = 3;
    [SerializeField] int numberOfTowers = 0;

    Queue<Tower> towerQueue = new Queue<Tower>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceATower(Waypoint waypoint)
    {
        if(towerQueue.Count<maxTowers)
        {
            InstantiateNewTower(waypoint);
        }
        else
        {
            MoveATower(waypoint);
        }
    }

    private void InstantiateNewTower(Waypoint waypoint)
    {
        Tower newTower = Instantiate(tower, new Vector3(waypoint.transform.position.x, 0f, waypoint.transform.position.z), Quaternion.identity);
        newTower.transform.parent = transform;
        newTower.baseWaypoint = waypoint;
        towerQueue.Enqueue(newTower);
    }

    private void MoveATower(Waypoint waypoint)
    {
        Tower sameTower = towerQueue.Dequeue();
        sameTower.transform.parent = transform;
        sameTower.baseWaypoint.isPlaceable = true;
        sameTower.baseWaypoint = waypoint;
        sameTower.transform.position = waypoint.transform.position;
        towerQueue.Enqueue(sameTower);
    }

}
