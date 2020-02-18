using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] Sprite[] hitSprites;
    

    [SerializeField] int timesHit;

    //cached reference
    level lev;
    GameStatus gameStatus;

    private void Start()
    {
        lev = FindObjectOfType<level>();
        if (tag == "Breakable")
        {
            lev.CountBreakableBlocks();
        }
        gameStatus = FindObjectOfType<GameStatus>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            int maxHits = hitSprites.Length + 1;
            timesHit++;
            if(timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
       
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("block sprite missing!");
        }
    }

    private void DestroyBlock()
    {
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        lev.BlockDestroyed();
    }
}
