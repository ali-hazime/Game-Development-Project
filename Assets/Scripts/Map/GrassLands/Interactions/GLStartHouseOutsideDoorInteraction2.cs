using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GLStartHouseOutsideDoorInteraction2 : MonoBehaviour
{

    //IN TESTING
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("InsideHousePrototype");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
