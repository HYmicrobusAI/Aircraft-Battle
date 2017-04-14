using UnityEngine;
using System.Collections;

public class settingManager : MonoBehaviour {

    public void enterTheSettingUI()
    {
        //print("works!");
        audio.Play();
        Application.LoadLevel("SettingUI");
    }

}
