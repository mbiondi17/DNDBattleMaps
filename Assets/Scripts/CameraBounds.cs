using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{

    public GameObject boundingBox;
    
    private float xMin;
    private float yMin;
    private float zMin;
    private float xMax;
    private float yMax;
    private float zMax;
    
    


    void Start()
    {
        var rend = boundingBox.GetComponent<Renderer>();

        xMin = rend.bounds.min.x;
        yMin = rend.bounds.min.y;
        zMin = rend.bounds.min.z;

        xMax = rend.bounds.max.x;
        yMax = rend.bounds.max.y;
        zMax = rend.bounds.max.z;
    }

    // Update is called once per frame
    void Update()
    {
        var clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);
        var clampedY = Mathf.Clamp(transform.position.y, yMin, yMax);
        var clampedZ = Mathf.Clamp(transform.position.z, zMin, zMax);
        
        this.transform.position = new Vector3(clampedX, clampedY, clampedZ);
    }
}
