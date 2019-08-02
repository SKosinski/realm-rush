using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int gridPos;
    public bool isExplored = false;
    public bool isPlaceable = true;

    public Waypoint previousWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColor(Color color)
    {
        var topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    public Color GetTopColor()
    {
        var topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        return topMeshRenderer.material.color;
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        if(Input.GetMouseButtonDown(0) && isPlaceable)
        {
            Debug.Log("Clicked Cube " + GetGridPos());
        }
    }
}
