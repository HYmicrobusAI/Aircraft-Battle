using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AboutAuthor : MonoBehaviour {

    public Image AboutAuthorImage;
    void Start()
    {
        AboutAuthorImage.gameObject.SetActive(false);
    }

    public void openAboutAuthor()
    {
        AboutAuthorImage.gameObject.SetActive(true);
    }
}
