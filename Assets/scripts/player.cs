using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject loseob; 
    public float movespeed;
    public float jumpspeed;
    public bool iswin = false;
    private bool isgrounded = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(move * movespeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(move * movespeed / 2, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && iswin && isgrounded)
        {
            rb.AddForce(Vector2.up * jumpspeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("rode"))
        {
            isgrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("rode"))
        {
            isgrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("rode") || collision.CompareTag("police"))
        {
            loseob.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            movespeed = 0;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
