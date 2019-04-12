// ===============================
// AUTHOR     : Joanna Ho
// CREATE DATE     : 03/23/2019
// PURPOSE     : This class sets the camera to lock to the interface 
//                  so that when the hololens camera moves around, the interface stays stationary
//
// REFERENCES   : 
// Tutorial on locking camera
// https://www.youtube.com/watch?v=ViZto58MgjM
// ===============================
// Change History:
//
//==================================


using UnityEngine;

public class Billboard : MonoBehaviour {

    public Camera userCamera;

    private void Update()
    {
        transform.LookAt(transform.position 
            + userCamera.transform.rotation * Vector3.back, userCamera.transform.rotation * Vector3.up);
    }
}
