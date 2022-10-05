using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float forwardSpeed;
    void Update()
    {
        if(Variables.firstTouch == 1)
        transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
    }
}
