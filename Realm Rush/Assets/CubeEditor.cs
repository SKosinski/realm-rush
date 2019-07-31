using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [Range(1, 20)] int gridSize = 11;


    void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        TextMesh cubeCords = GetComponentInChildren<TextMesh>();

        string labelText = transform.position.x / gridSize + "," + transform.position.z / gridSize;

        cubeCords.text = labelText;
        gameObject.name = "Cube " + labelText;
    }

}
