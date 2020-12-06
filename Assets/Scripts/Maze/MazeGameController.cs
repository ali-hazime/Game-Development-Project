using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MazeConstructor))]

public class MazeGameController : MonoBehaviour
{
    public GameObject Player;
    private MazeConstructor generator;

    private bool goalReached;

    // Use this for initialization
    void Start()
    {
        generator = GetComponent<MazeConstructor>();
        StartNewGame();
    }

    private void StartNewGame()
    {
        Player.transform.position = new Vector3(185, 225, 0);
        generator.GenerateMaze(39, 47);
    }

}
