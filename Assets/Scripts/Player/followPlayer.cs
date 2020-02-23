using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{

    private Transform player;
    private void Start()
    {
        player = FindObjectOfType<PlayerChar>().transform;
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + 0.01f, player.position.y, -10);
    }


}
