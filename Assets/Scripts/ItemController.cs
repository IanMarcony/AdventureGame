using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private SpriteRenderer  spriteRenderer;
    private BoxCollider2D boxCollider2D;
    public GameObject collected;

    public int point;

    private GameController gameController;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        collected.SetActive(false);
        gameController = FindObjectOfType<GameController>() as GameController;
    }

    public void colectItem(){
        boxCollider2D.enabled = false;
        spriteRenderer.enabled = false;
        collected.SetActive(true);
        gameController.addScore(point);
        Destroy(gameObject, 0.35f);
    }
}
