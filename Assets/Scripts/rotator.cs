using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public int rotx;
    public int roty;
    public int rotz;

 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotx * Time.deltaTime, roty * Time.deltaTime, rotz * Time.deltaTime);
    }
}
