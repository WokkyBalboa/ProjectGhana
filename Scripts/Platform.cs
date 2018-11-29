using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public Transform startTarg;
    public Transform endTarg;
    public float speed = 2.0f;
    private bool moveUp;
    private int delay = 2;

	// Use this for initialization
	void Start () {
        moveUp = true;
        
	}
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(movePlatform());
    }

    // Move the platform from target to target, if it reaches a target it'll wait 2 sec before moving again.
    IEnumerator movePlatform ()
    {
        float step = speed * Time.deltaTime;

        if (transform.position == startTarg.position)
        {
            moveUp = false;
        }
        else if (transform.position == endTarg.position)
        {
            moveUp = true;
        }

            if (moveUp == false)
            {
                yield return new WaitForSeconds(delay);
                transform.position = Vector3.MoveTowards(transform.position, endTarg.position, step);
            }

            else if (moveUp)
            {
                yield return new WaitForSeconds(delay);
                transform.position = Vector3.MoveTowards(transform.position, startTarg.position, step);
            }
      
    }

}
