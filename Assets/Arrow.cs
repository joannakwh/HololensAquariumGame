using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AUTHOR     : Jaeheon (Joe) Jung
/// CREATE DATE     : 02/27/2019
/// PURPOSE     : This class is to create projectile when a user shoots bullet.
/// 
/// Reference : "Shoot bows tutorial"
/// https://www.youtube.com/watch?v=ayiXNHhUhQE
/// </summary>
public class Arrow : MonoBehaviour
{

    Rigidbody myBody;
    private float lifeTimer = 2f;
    private float timer;
    private bool hitSomething = false;

    // Use this for initialization
    void Start()
    {
        timer = 0f;
        myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(myBody.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTimer)
        {
            Destroy(gameObject);
            Destroy(this);
        }

        if (!hitSomething)
        {
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("monster"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
        Destroy(this);
    }

    private void Stick()
    {

        myBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
