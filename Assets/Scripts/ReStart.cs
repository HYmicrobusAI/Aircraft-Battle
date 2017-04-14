using UnityEngine;
using System.Collections;

public class ReStart : MonoBehaviour {

    public void ReStartGame()
    {
        hero._GameTimer = 0f;
        Application.LoadLevel("startGame");
    }

    public void ReturnHome() 
    {
        Application.LoadLevel("HomeGameUI");
    }
}
