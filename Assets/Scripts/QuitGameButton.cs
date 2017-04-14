using UnityEngine;
using System.Collections;

public class QuitGameButton : MonoBehaviour {

    public void QuitGame()
    {
        audio.Play();
        Application.Quit();
    }
}
