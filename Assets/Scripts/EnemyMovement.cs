using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;
    [SerializeField] float waitTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        path = FindObjectOfType<PathFinder>().GetPath();
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        
        yield return new WaitForSeconds(waitTime);

        foreach (Waypoint waypoint in path)
        {
            //print("Visiting block: " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }

        GetComponent<EnemyHealth>().Explode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
