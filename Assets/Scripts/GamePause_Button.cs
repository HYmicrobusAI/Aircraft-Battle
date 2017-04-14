using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class GamePause_Button : MonoBehaviour {

    //设置，当主角死亡时，将暂定按钮隐藏
    public Button pauseButton;

    void Update()
    {
        if (hero.isPlayerDeath)    //当主角死亡后，将暂定按钮隐藏
        {
            pauseButton.gameObject.SetActive(false);
        }
    }

    public void OnMouseUpAsButton()    //注意要给物体添加碰撞器（box collider）,此处为按钮UI，故不需要
    {
        gameManager._instance.transformGameState();
        //audio.Play();

    }
}
