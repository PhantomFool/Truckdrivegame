using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class guyscript : MonoBehaviour
{
    private Rigidbody2D rv;
    public float movespeeed;
    public float jumpstregh;
    private GameObject currentpoint;
    public GameObject point1;
    public GameObject point2;
    public GameObject police;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        rv = GetComponent<Rigidbody2D>();
        currentpoint = point1;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(currentpoint.transform.position.x, currentpoint.transform.position.y), movespeeed * Time.deltaTime);



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("point") && currentpoint == point1)
        {

            rv.AddForce(Vector2.up * jumpstregh);
            currentpoint = point2;
        }
        else if (collision.CompareTag("point") && currentpoint == point2)
        {
            rv.AddForce(Vector2.up * jumpstregh);
            currentpoint = point1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
            Instantiate(police);
        }
    }
}
