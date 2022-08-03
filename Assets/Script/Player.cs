using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 

public class Player : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D rb2d;

    public float puntaje;
    public TextMeshProUGUI textPuntaje;

   
    


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }


    void FixedUpdate()
    {

        textPuntaje.text = "Coin:" + puntaje;

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
        }

        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (Input.GetKey("space") && CheckGround.isgrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            puntaje++;
            Destroy(collision.gameObject);
        }
    }
}
