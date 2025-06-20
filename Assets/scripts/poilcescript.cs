using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poilcescript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public float movespeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, movespeed * Time.deltaTime);
    }
}
