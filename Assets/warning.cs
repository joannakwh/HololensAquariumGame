using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Joanna Ho 
/// 
/// This class shows up warning message when monsters spawn
/// Author: Joanna Ho
/// Date: April 01, 2019
/// 
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class warning : MonoBehaviour {
    private const float seconds = 30f;
    private float timeLeft;
    // public AudioSource audioWarning;

    public warning() { }

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Image>().enabled = this.gameObject.GetComponent<Image>().enabled = false;
        timeLeft = seconds;
       // audioWarning = GameObject.Find("WarningSound").GetComponent<AudioSource>();
       // audioWarning.Play(0);
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = seconds;
            flashWarning();
        }
    }

    public void flashWarning()
    {
        
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        
        //yield return new WaitForSeconds(audioWarning.clip.length);

        this.gameObject.GetComponent<Image>().enabled = this.gameObject.GetComponent<Image>().enabled = true;

        //Wait for 1 seconds
        yield return new WaitForSeconds(1);

        this.gameObject.GetComponent<Image>().enabled = this.gameObject.GetComponent<Image>().enabled = false;

        yield return new WaitForSeconds(0.3f);

        this.gameObject.GetComponent<Image>().enabled = this.gameObject.GetComponent<Image>().enabled = true;

        //Wait for 1 seconds
        yield return new WaitForSeconds(1);

        this.gameObject.GetComponent<Image>().enabled = this.gameObject.GetComponent<Image>().enabled = false;

        yield return new WaitForSeconds(0.3f);

        this.gameObject.GetComponent<Image>().enabled = this.gameObject.GetComponent<Image>().enabled = true;

        //Wait for 1 seconds
        yield return new WaitForSeconds(1);

        this.gameObject.GetComponent<Image>().enabled = this.gameObject.GetComponent<Image>().enabled = false;
    }

}
