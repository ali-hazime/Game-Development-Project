using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTile : MonoBehaviour
{
    [SerializeField] Animator anim;
    public bool brokenTile;
    private PlayerChar player;
    public bool triggerOnce;

    private void Awake()
    {
        if (anim == null)
        {
            anim = this.gameObject.GetComponent<Animator>();
        }

        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
        brokenTile = false;
        triggerOnce = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && triggerOnce)
        {
            QuestTracker.blocksWalked++;
            triggerOnce = false;
            anim.enabled = true;
            StartCoroutine(TileBreak());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (brokenTile)
            {
                player.BurnPlayer(true, 30, 100);
            }
        }
    }

    IEnumerator TileBreak()
    {
        yield return new WaitForSeconds(1f);
        brokenTile = true;
    }
}
