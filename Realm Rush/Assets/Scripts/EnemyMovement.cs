using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;
    [SerializeField] float waitTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        path = FindObjectOfType<PathFinder>().GetPath();
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        //print("Starting patrol...");
        yield return new WaitForSeconds(waitTime);

        foreach (Waypoint waypoint in path)
        {
            //print("Visiting block: " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }

        //print("Ending patrol.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
