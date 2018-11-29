using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    private float speed = 10.0f;
    private int rotateSpeed = 15;
    public GameObject target; 

	// Use this for initialization
    // set target to "Player"
	void Start () {
        target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        rotate();
    }

    //rotates everything around the target
    void rotate()
    {
        //Quaternion rotationMin = Quaternion.Euler(new Vector3(0f, 0f, -50f));
        //Quaternion rotationMax = Quaternion.Euler(new Vector3(0f, 0f, 50f));

        //Quaternion rotation = transform.rotation;

       //Accelerometer input
       float direction = -Input.acceleration.x;

        //Keep rotation.z between 2 values, not working atm
        //rotation.z = Mathf.Clamp(rotation.z, rotationMin.z, rotationMax.z);


        transform.RotateAround(target.transform.position, new Vector3(0,0,direction), rotateSpeed * speed * Time.deltaTime);
            
    }
}
