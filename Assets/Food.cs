using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AUTHOR      : Jaeheon (Joe) Jung
/// CREATE DATE : 03/15/2019
/// PURPOSE     : This class is to implement the slowly falling food.
/// 
/// </summary>
public class Food : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y - 0.001f, transform.position.z);

    }
}
