using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breaklandscript : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
            audio.Play();
        }
    }
}
