using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class stopscript : MonoBehaviour
{
    private BoxCollider2D box;
    private SpriteResolver spriteResolver;
    public float timer = 0f;
    public float maxtime = 2f;
    public float yellowpausetime = 2f;
    public float redpausetime = 13f;
    public GameObject police;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        spriteResolver = GetComponent<SpriteResolver>();
        box.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxtime)
        {
            spriteResolver.SetCategoryAndLabel("stop", "yellow");
        }
        if (timer >= yellowpausetime)
        {
            spriteResolver.SetCategoryAndLabel("stop", "red");
            box.enabled = true;
        }
        if (timer >= redpausetime)
        {
            spriteResolver.SetCategoryAndLabel("stop", "green'");
            box.enabled = false;
            timer = 0f;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(police);
        }
    }
}
