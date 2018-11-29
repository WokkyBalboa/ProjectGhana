using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Rigidbody2D rigid;
    private float jumpForce = 6.0f;
    private float force = 10.0f;
    private float gravity = -1.0f;
    private bool grounded = false;
    private int i;
    private GameObject StartPos;
    private string restart = "SampleScene";

    public int diamonds;
    public int lives = 3;
    public int dead = 0;

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        Movement();
        Jump();
        StartPos = GameObject.Find("PlayerStart");

        
    }

    //jump if grounded is true
    void Jump()
    {
        
        if (Input.touchCount > 0 && grounded == true)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            grounded = false;
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);

        //Debug.DrawRay(transform.position, Vector2.down, Color.green);

        if (hitInfo.collider != null)
        {
            grounded = true;
        }
    }

    void Movement()
    {
    Vector3 dir = new Vector3(Input.acceleration.x, gravity, 0.0f);
        Physics2D.gravity = dir * force;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //on collision with an "launchpad object" launch player in the air
        for (i = 0; i < 10; i++)
        {
            if (col.gameObject.name == "launchPad" + i)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpForce * 3);
            }
        }
        i = 0;

        //on collision while lives aren't 0 with a Hazards_Tilemap respawn at start.
        if (col.gameObject.name == "Hazards_Tilemap" && lives != dead)
        {
            lives--;
            transform.position = StartPos.transform.position;
        }
        
        //on collision while lives are 0 with a Hazards_Tilemap reset map
        if (col.gameObject.name == "Hazards_Tilemap" && lives == dead)
        {
            SceneManager.LoadScene(restart);
        }

        //reached end, restart map
        if (col.gameObject.name == "PlayerEnd")
        {
            SceneManager.LoadScene(restart);
        }

    }


}
