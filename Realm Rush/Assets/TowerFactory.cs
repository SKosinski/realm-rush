using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] int maxTowers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceATower(GameObject waypoint)
    {
        GameObject newTower = Instantiate(tower, new Vector3(waypoint.transform.position.x, 0f, waypoint.transform.position.z), Quaternion.identity);
        newTower.transform.parent = transform;
    }
}
