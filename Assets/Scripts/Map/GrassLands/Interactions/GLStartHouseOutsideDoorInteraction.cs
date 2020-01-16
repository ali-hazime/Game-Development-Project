using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLStartHouseOutsideDoorInteraction : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.position = new Vector3(-107.5f, -68.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
