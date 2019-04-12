using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ChangeColorManager : MonoBehaviour, IInputClickHandler {

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnInputClicked(InputClickedEventData eventData)
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
