using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_CameraNew : MonoBehaviour {

	// Use this for initialization
    public Vector3[] cameraRotate = new []{new Vector3(0,0,0), new Vector3(0, 0, -50), new Vector3(0, 90, -50), new Vector3(0, -90, -50)};
    private Transform thisCamera;
    public int cameraNum;
	void Start ()
	{
	    thisCamera = this.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    thisCamera.rotation = Quaternion.Euler(cameraRotate[cameraNum]);
	    if (Input.GetKeyDown(KeyCode.Keypad0))
	    {
	        cameraNum = 0;
	    }
	    if (Input.GetKeyDown(KeyCode.Keypad1))
	    {
	        cameraNum = 1;
	    }
	    if (Input.GetKeyDown(KeyCode.Keypad2))
	    {
	        cameraNum = 2;
	    }
	    if (Input.GetKeyDown(KeyCode.Keypad3))
	    {
	        cameraNum = 3;
	    }

    }

    public void CameraNumber(int num)
    {
        cameraNum = num;
    }
}
