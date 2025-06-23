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
    private AudioSource audioSource;
    public GameObject loseob; 
    public float movespeed;
    public float jumpspeed;
    public bool iswin = false;
    private bool isgrounded = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iswin)
        {
            audioSource.Stop();
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(move * movespeed, rb.velocity.y);
            if (iswin)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(move * movespeed / 2, rb.velocity.y);
            if (iswin)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
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
        if ((collision.CompareTag("rode") || collision.CompareTag("police")) && !iswin)
        {
            loseob.SetActive(true);
            audioSource.Stop();
            GameObject.Find("win").GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            movespeed = 0;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
