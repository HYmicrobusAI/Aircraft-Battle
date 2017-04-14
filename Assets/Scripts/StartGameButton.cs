using UnityEngine;
using System.Collections;

public class StartGameButton : MonoBehaviour {

    public void StartGame()
    {
        audio.Play();
        hero._GameTimer = 0f;
        Application.LoadLevel("startGame");
    }
}
