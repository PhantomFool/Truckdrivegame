using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class win : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject player;
    public GameObject loseob;
    public Sprite happyman;
    private float distancefromplayer;
    public float activationdistance = 100;

    void Update()
    {
        distancefromplayer = Vector2.Distance(player.transform.position, transform.position);
        if (distancefromplayer >= activationdistance)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void DestroyAllWithTag()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("police");
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<Player>().iswin = true;
            DestroyAllWithTag();
            Destroy(loseob);
            gameObject.GetComponent<AudioSource>().Stop();
            GameObject.Find("backgroumd and music").GetComponent<AudioSource>().Stop();
            winScreen.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = happyman;
            player.GetComponent<BoxCollider2D>().size = new Vector2(2.528341f, 3.51f);
        }
    }
}
