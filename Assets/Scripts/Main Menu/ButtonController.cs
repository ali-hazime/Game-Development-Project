using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void startGame() 
    {
        SceneManager.LoadScene("GameSelectPage");
    }

    //This will be changed once the start of the game is updated
    public void grassLand()
    {
        SceneManager.LoadScene("GrassLands");
    }
}
