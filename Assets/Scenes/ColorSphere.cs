using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class ColorSphere : MonoBehaviour, IInputClickHandler
{

	// Use this for initialization
	void Start () {
        Debug.Log("Start");
        InputManager.Instance.PushFallbackInputHandler(gameObject);

    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("OnInputClicked");

        RaycastHit hitInfo;
        if (Physics.Raycast(
                Camera.main.transform.position,
                Camera.main.transform.forward,
                out hitInfo,
                100.0f,
                Physics.DefaultRaycastLayers))
        {
            hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));

        }
    }

    private void Tap(UnityEngine.XR.WSA.Input.InteractionSourceKind source, int tapCount, Ray headRay)
    {
        Debug.Log("tap");
    }

    // Update is called once per frame
    void Update () {

    }
}
