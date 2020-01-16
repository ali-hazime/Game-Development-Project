using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{

    public Transform Player;

    private void LateUpdate()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, -10);

    }


}
