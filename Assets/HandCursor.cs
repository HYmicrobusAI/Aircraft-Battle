using UnityEngine;
using System.Collections;
public class HandCursor : MonoBehaviour
{
    public Texture mouseTexture;  //自己想要的鼠标图片
    // Use this for initialization
    void Start()
    {
        Screen.showCursor = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        Vector3 mousePos = Input.mousePosition;
        GUI.DrawTexture(new Rect(mousePos.x, Screen.height - mousePos.y, mouseTexture.width, mouseTexture.height), mouseTexture);
    }
}