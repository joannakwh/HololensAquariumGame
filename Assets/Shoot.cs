using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;
using UnityEngine.Events;

/// <summary>
/// ===============================
/// AUTHOR      : Jaeheon (Joe) Jung
/// CREATE DATE : 03/15/2019
/// PURPOSE     : This class is for the main camera. It can be considered as a main driver
///               which controls mouse input, timer, and money in the game.
/// ===============================
/// Unity Documentation: Raycast 
/// https://docs.unity3d.com/ScriptReference/Physics.RaycastAll.html
/// 
/// Shoot bow tutorial
/// https://www.youtube.com/watch?v=ayiXNHhUhQE
/// 
/// Hololens Input System - IInputClickHandler
/// https://forums.hololens.com/discussion/8295/iinputclickhandler-and-iinputhandler
/// 
/// Unity Asset Resource: Rocks
/// https://assetstore.unity.com/packages/3d/environments/landscapes/free-rocks-19288
/// 
/// Sand Texture Resource 
/// http://kidskunst.info/38/11607-sand-texture-seamless.htm
/// 
/// Fog Effect
/// https://www.youtube.com/watch?v=UgJE3TgT3o8
/// 
/// </summary>



public class Shoot : MonoBehaviour, IInputClickHandler
{
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootForce = 5f;
    
    public GameObject foodSpawnerPrefab;


    public GameObject shop;
    public BuyStuff buy;
    public Action[] del;
    public int money;

    public GameObject monspawner;
    public GameObject mons;
    public int time = 0;

    public GameObject fishSpawner;
    public GameObject fishPrefab;

    /// 0 - turtle
    /// 1 - guppy
    /// 2 - angelfish
    /// 3 - clownfish
    /// 4 - discus
    /// 5 - squid
    public GameObject[] fishPrefabs;
    public List<GameObject> fish;

    public UIHandler ui;

    // Use this for initialization
    void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
        
        buy = shop.GetComponent<BuyStuff>();
        del = buy.buttons;
        money = 0;
        ui = transform.Find("Canvas").gameObject.GetComponent<UIHandler>();
        StartCoroutine(Timer());
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Timer()
    {
        while (true)
        {
            time++;
            if (time % 35 == 0)
            {
                Instantiate(mons, new Vector3(monspawner.transform.position.x, monspawner.transform.position.y, monspawner.transform.position.z - 1.5f), Quaternion.identity);
                Instantiate(mons, monspawner.transform.position, Quaternion.identity);
                Instantiate(mons, new Vector3(monspawner.transform.position.x, monspawner.transform.position.y, monspawner.transform.position.z + 1.5f), Quaternion.identity);
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(
                Camera.main.transform.position,
                Camera.main.transform.forward,
                out hitInfo,
                100.0f,
                Physics.DefaultRaycastLayers))
        {
            if (hitInfo.collider.tag.Equals("centerWall"))
            {
                GameObject go = Instantiate(foodSpawnerPrefab, Camera.main.transform.position, Quaternion.identity);
                Rigidbody rb = go.GetComponent<Rigidbody>();
                rb.velocity = Camera.main.transform.forward * 10f;
                return;
            }

            char num = hitInfo.collider.tag[hitInfo.collider.tag.Length - 1];
            string hitTag = hitInfo.collider.tag.Substring(0, hitInfo.collider.tag.Length - 1);

            if (hitTag.Equals("button"))
            {
                if (buy.itemInfo[num - '0' - 1].price <= buy.balance) {
                    del[num - '0' - 1]();
                    Instantiate(fishPrefabs[num - '0' - 1], fishSpawner.transform.position, fishSpawner.gameObject.transform.rotation);
                    ui.setFish(++ui.fishCount);
                }
                return;
            }
        }

        GameObject go2 = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
        Rigidbody rb2 = go2.GetComponent<Rigidbody>();
        rb2.velocity = Camera.main.transform.forward * shootForce;
    }
}
