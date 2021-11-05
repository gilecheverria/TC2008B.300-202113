using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    [SerializeField] int size;

    // Update is called once per frame
    void Update()
    {
       // Draw X axis
       Debug.DrawLine(Vector3.zero, new Vector3(size, 0, 0), Color.red);
       // Draw Y axis
       Debug.DrawLine(Vector3.zero, new Vector3(0, size, 0), Color.green);
       // Draw Z axis
       Debug.DrawLine(Vector3.zero, new Vector3(0, 0, size), Color.blue);
    }
}
