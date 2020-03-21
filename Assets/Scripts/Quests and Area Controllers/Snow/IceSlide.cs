using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSlide : MonoBehaviour
{
    [SerializeField] PlayerChar player;
    public AreaEffector2D areaEffector;

    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }

    private void Update()
    {
        if (player.facingUp)
        {
            areaEffector.forceAngle = 90;
            areaEffector.forceMagnitude = 350;
        }

        if (player.facingDown)
        {
            areaEffector.forceAngle = 90;
            areaEffector.forceMagnitude = -350;
        }

        if (player.facingRight)
        {
            areaEffector.forceAngle = 0;
            areaEffector.forceMagnitude = 350;
        }

        if (player.facingLeft)
        {
            areaEffector.forceAngle = 0;
            areaEffector.forceMagnitude = -350;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!player.collidingWithWall)
            {
                player.lockInput = true;
            }
            else
            {
                player.lockInput = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.lockInput = false;
        }
    }

}
