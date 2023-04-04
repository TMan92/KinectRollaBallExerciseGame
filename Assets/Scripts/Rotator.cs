//Code referenced from https://github.com/erajan0305/Roll-a-Ball-Kinect
using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}