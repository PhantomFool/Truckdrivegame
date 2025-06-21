using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poilcescript : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    public float movespeed;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, movespeed * Time.deltaTime);
    }
}
