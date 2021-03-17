using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float movementSpeed = 10f;
    public bool isOnPlatform = true;    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        // mobile touch system 
        if (Input.touchCount > 0 && isOnPlatform)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x < Screen.width / 2)
                        playerRb.velocity = new Vector2(-movementSpeed, 0f);
                        isOnPlatform = false;

                    if (touch.position.x > Screen.width / 2)
                        playerRb.velocity = new Vector2(movementSpeed, 0f);
                        isOnPlatform = false;
                    break;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // For jumping one time
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnPlatform = true;
        }
        // For teleporting character to other side
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            transform.position = new Vector3( 2.8f , transform.position.y, 0);
        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            transform.position = new Vector3( -2.8f, transform.position.y, 0);
        }
    }        
}
