using UnityEngine;
using System.Collections;

public class dieMusic : MonoBehaviour {

    public static dieMusic _instance;

    void Awake()
    {
        _instance = this;
    }

    public void OpenMusic()
    {
        audio.Play();
    }

}
