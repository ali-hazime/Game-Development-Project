using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActivation : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>().transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 12f)
        {
            this.GetComponent<Animator>().enabled = true;
        }
        else
        {
            this.GetComponent<Animator>().enabled = false;
        }
    }
}
