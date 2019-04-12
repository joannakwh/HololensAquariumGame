using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ===============================
/// AUTHOR      : Jaeheon (Joe) Jung
/// CREATE DATE : 03/15/2019
/// PURPOSE     : This class is to manipulate the behaviour of the fish.
///               GameObject with this script behaves, based on the current mode.
///               1: swim (normal)
///               2: feed
///               3: change its swimming direction, based on a random chance.
///               4. die
///               
///               In Update() method, fish's behaviours will be determined
///               based on the if-statement of the value of mode
/// ===============================
///
/// Unity Collider OnTrigger Example
/// https://unity3d.com/kr/learn/tutorials/topics/physics/colliders-triggers
/// 
/// Move Object Smoothly
/// https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html
/// 
/// Unity IComparable Example
/// https://answers.unity.com/questions/1196323/listsort-with-icomparer.html
/// 
/// Unity Fish Model Resource
/// https://www.youtube.com/watch?v=yvGSnh-Lc7o
/// 
/// C# List Sort()
/// https://www.geeksforgeeks.org/how-to-sort-list-in-c-sharp-set-1/
/// 
/// </summary>
public class Fish : MonoBehaviour, System.IComparable<Fish>
{

///           1: swim (normal)
///           2: feed
///           3: change its swimming direction, based on a random chance.
///           4. die
    public int mode;

    public GameObject centerPrefab;
    float speed;
    bool trigged;
    Vector3 initForward;
    public Coin coinPrefab;
    float maxHungerGaze;
    float warningGaze;
    public float hungerGaze;
    public GameObject food;


    // Use this for initialization
    void Start()
    {
        centerPrefab = Camera.main.GetComponent<Shoot>().fishSpawner;
        mode = 1;

        speed = 0.6f;


        trigged = false;

        initForward = transform.forward;

        maxHungerGaze = 5.0f;
        warningGaze = 3.0f;
        hungerGaze = 0.0f;

        StartCoroutine(DirRoutine());
        
        StartCoroutine(CreateCoins());
    }

    IEnumerator DirRoutine()
    {
        while (true)
        {
            float randMode = Random.Range(0f, 10f);
            if (randMode > 7f)
            {
                if (mode != 4)
                    mode = 3;
            }

            //hungerGaze++;
            if (hungerGaze >= maxHungerGaze)
            {
                mode = 4;
            }
            else if (hungerGaze >= warningGaze)
            {
                transform.Find("svgMesh2").gameObject.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 1f);
            }
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator CreateCoins()
    {
        while (true)
        {
            if (mode != 4) {
                Coin tmpCoin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
                tmpCoin.transform.Rotate(0, 0, 90);
            }
            yield return new WaitForSeconds(20);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == 1) {
            transform.Translate(0, 0, Time.deltaTime * speed);

            float diffX = centerPrefab.transform.position.x - transform.position.x;
            if (diffX <= -0.5f)
                transform.SetPositionAndRotation(new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z),
                                                            transform.rotation);

            if (diffX >= 0.5f)
                transform.SetPositionAndRotation(new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z),
                                                            transform.rotation);

            float diffY = centerPrefab.transform.position.y - transform.position.y;
            if (diffY <= -1.2f)
                transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z),
                                                            transform.rotation);

            if (diffY >= 1.2f)
                transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z),
                                                            transform.rotation);
        }
        else if (mode == 2)
        {
            if (food == null)
                mode = 1;
            else
            {
                var obj = transform.Find("Mouth").gameObject;
                float dist = Vector3.Distance(food.transform.position, obj.transform.position);

                if (dist >= 0.5f)
                {
                    transform.LookAt(food.transform.position);
                    transform.localPosition = Vector3.Lerp(transform.localPosition, food.transform.position, Time.deltaTime);
                }
                else
                {
                    Destroy(food.gameObject);
                    Destroy(food);
                    food = null;
                    hungerGaze = 0.0f;
                    //transform.Find("svgMesh2").gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
                    if (transform.eulerAngles.y < 90 || transform.eulerAngles.y > 270)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }

                    //transform.Rotate(0, 180, 0);

                    trigged = false;
                    mode = 1;
                }
            }
        }
        else if (mode == 3)
        {

            speed -= Time.deltaTime*0.2f;


            if (-0.25f >= speed)
            {
                speed = 0.6f;
                mode = 1;
                float randMode = Random.Range(0f, 2f);
                if (randMode > 1f)
                {
                    trigged = true;
                }
            }
            else if (0.05f >= speed)
            {
            }
            else
            {
                transform.Translate(0, 0, Time.deltaTime * speed);
            }
        }
        else if (mode == 4)
        {
            speed -= Time.deltaTime * 0.2f;
            transform.Translate(0, Time.deltaTime * -0.2f, 0);
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
            if (0.05f >= speed)
            {
                Destroy(gameObject);
                Destroy(this);
            }
        }
        
        if (trigged)
        {
            Vector3 lookDir = Vector3.Cross(transform.forward, Vector3.up); 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDir), 8f * Time.deltaTime);

            float curAngleDiff = Vector3.Angle(initForward, transform.forward); 

            if (170.5f <= curAngleDiff || curAngleDiff <= 10.0f)
            {

                trigged = false;

                if (transform.eulerAngles.y < 90 || transform.eulerAngles.y > 270)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                initForward = transform.forward;

            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        trigged = true;
    }

    public int CompareTo(Fish other)
    {
        return other.hungerGaze.CompareTo(hungerGaze);
    }
}
