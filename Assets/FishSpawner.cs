using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AUTHOR      : Jaeheon (Joe) Jung
/// CREATE DATE : 03/15/2019
/// PURPOSE     : 
///  This script is to spawn/manipulate fish objects and take coins when the focus at the center meets the coin.
///     In Update() method, it gets and filters the target objects when using "raycastAll" method.
///     (raycastAll method takes all the objects on the line of raycasting and makes it an array).
/// 
///  "How to filter gameobjects from RaycastAll"
///  http://docs.unity3d.com/Documentation/Components/Layers.html
///  https://docs.unity3d.com/ScriptReference/Physics.RaycastAll.html
/// </summary>
public class FishSpawner : MonoBehaviour
{
    public float newFlockerDelay = 0.0001f;
    public float spawnRadius = 0.05f;
    public GameObject fish;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit[] hits;
        hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward, 100.0F);

        for (int i = 0; i < hits.Length; i++)
        {

            if (hits[i].collider.tag.Equals("myCoin"))
            {
                Camera.main.gameObject.GetComponent<Shoot>().money += 300;
                Camera.main.gameObject.GetComponent<Shoot>().buy.balance += 300;
                Camera.main.gameObject.GetComponent<Shoot>().buy.updateText();
                Camera.main.gameObject.transform.Find("Canvas").gameObject.GetComponent<UIHandler>().setMoney(Camera.main.gameObject.GetComponent<Shoot>().money);
                Destroy(hits[i].collider.gameObject);
                Destroy(hits[i].collider.gameObject.GetComponent<Shoot>());
            }
        }

    }
}
