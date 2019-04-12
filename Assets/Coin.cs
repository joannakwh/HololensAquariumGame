using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AUTHOR      : Jaeheon (Joe) Jung
/// CREATE DATE : 03/15/2019
/// PURPOSE     : 
/// This class is for coins that falling from fish, and it spins while falling.
/// refered to https://unity3d.com/kr/learn/tutorials/topics/scripting/spinning-cube

public class Coin : MonoBehaviour
{

    float spinSpeed = 430.0f;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(255, 215, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, spinSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.001f, transform.position.z);
    }

}
