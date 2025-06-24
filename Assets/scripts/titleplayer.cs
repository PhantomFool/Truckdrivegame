using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleplayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movespeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movespeed * Time.deltaTime, rb.velocity.y);
    }
}
