using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movespeed;
    
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
    }
}
