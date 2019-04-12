using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ===============================
// AUTHOR     : Jaeheon (Joe) Jung
// CREATE DATE     : 03/15/2019
// PURPOSE     : This Monster class runs toward user (or fish) when created.
// ===============================
// Change History:
//
//==================================
public class Monster : MonoBehaviour
{
    public GameObject preyPrefab;
    public bool hunting;

    private void Awake()
    {
        hunting = true;
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(DirRoutine());
    }

    IEnumerator DirRoutine()
    {
        while (true)
        {
            float dist = Vector3.Distance(transform.position, Camera.main.GetComponent<Shoot>().fishSpawner.transform.position);
            if (dist <= 2.5f && Camera.main.GetComponent<Shoot>().fish.Count > 0)
            {
                GameObject obj = Camera.main.GetComponent<Shoot>().fish[Camera.main.GetComponent<Shoot>().fish.Count - 1];
                Camera.main.GetComponent<Shoot>().fish.Remove(obj);
                Destroy(obj);
                Camera.main.GetComponent<Shoot>().ui.setFish(--Camera.main.GetComponent<Shoot>().ui.fishCount);
            }

            yield return new WaitForSeconds(5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hunting)
        {
            transform.LookAt(Camera.main.GetComponent<Shoot>().fishSpawner.transform.position);
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 0.5f;

        }
    }
}

