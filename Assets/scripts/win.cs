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
            winScreen.SetActive(true);
            player.GetComponent<SpriteRenderer>().sprite = happyman;
        }
    }
}
