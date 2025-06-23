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
    public AudioClip jumpsound;
    public AudioClip driveforwardsound;
    public AudioClip drivebackwardsound;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.RightArrow) && movespeed != 0)
        {
            rb.velocity = new Vector2(move * movespeed * Time.deltaTime, rb.velocity.y);
            audioSource.loop = true;
            audioSource.PlayOneShot(driveforwardsound, 0.45f);
            if (iswin)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && movespeed != 0)
        {
            if (iswin == false)
            {
                rb.velocity = new Vector2((move * movespeed / 2) * Time.deltaTime, rb.velocity.y);
                audioSource.loop = true;
                audioSource.PlayOneShot(drivebackwardsound, 0.45f);
            }

            if (iswin)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                rb.velocity = new Vector2(move * movespeed * Time.deltaTime, rb.velocity.y);
            }
        }

        if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)) && iswin == false)
        {
            audioSource.Stop();
        }else if (iswin)
        {
            drivebackwardsound = null;
            driveforwardsound = null;
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) ) && iswin && isgrounded)
        {
            audioSource.PlayOneShot(jumpsound);
            rb.AddForce(Vector2.up * (jumpspeed * Time.deltaTime));
            
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
            GameObject.Find("backgroumd and music").GetComponent<AudioSource>().Stop();
            GameObject.Find("win").GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            movespeed = 0;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
