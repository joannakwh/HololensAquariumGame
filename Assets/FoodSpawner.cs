using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AUTHOR      : Jaeheon (Joe) Jung
/// CREATE DATE : 03/15/2019
/// PURPOSE     : This class is to spawn food for fish.
///               This class checks the hungry gaze of each fish (by sorting)
///               and makes the hungriest fish take the food.
///               The comparator is used in Fish.cs 
/// 
/// C# List Sort()
/// https://www.geeksforgeeks.org/how-to-sort-list-in-c-sharp-set-1/
/// 
/// </summary>
public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    float radius;
    GameObject[] foods;
    List<Fish> fishes;

    bool firstSpawned;
    

    // Use this for initialization
    void Start()
    {
        radius = 4.0f;
        firstSpawned = false;

        foods = new GameObject[3];
        fishes = new List<Fish>();
    }

    // Update is called once per frame
    void Update()
    {

        if (firstSpawned)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.005f, transform.position.z);
        }
    }

    IEnumerator DestroyAll()
    {

        while (true)
        {
            fishes.Clear();
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].tag.Equals("myFish"))
                {
                    fishes.Add(hitColliders[i].GetComponent<Fish>());
                }

                i++;
            }
            Debug.Log("foods.Count::" + foods.Length);
            fishes.Sort();
            for (int x = 0, y = 0; x < 3; x++)
            {
                if (foods[x] != null) {
                    for (; y < fishes.Count;)
                    {
                        //Debug.Log(y);
                        if (fishes[y].mode != 4)
                        {
                            fishes[y].food = foods[x];
                            fishes[y].mode = 2;
                            y++;
                            break;
                        }
                    }
                }
            }

            int length = 0;
            for (int z = 0; z < foods.Length; z++)
            {
                if (foods[z] == null)
                {
                    length++;
                }
            }
            if (length == 3)
            {
                Destroy(gameObject);
                Destroy(this);
            }
            yield return new WaitForSeconds(2f);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!firstSpawned && collision.collider.tag.Equals("centerWall"))
        {

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Vector3 pos = transform.position;
            foods[0] = Instantiate(foodPrefab, new Vector3(pos.x, pos.y, pos.z - 0.5f), Quaternion.identity);
            foods[1] = Instantiate(foodPrefab, transform.position, Quaternion.identity);
            foods[2] = Instantiate(foodPrefab, new Vector3(pos.x, pos.y, pos.z + 0.5f), Quaternion.identity);

            firstSpawned = true;

            StartCoroutine(DestroyAll());
        }
    }
}
