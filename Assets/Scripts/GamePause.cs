using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {

    void OnMouseUpAsButton()    //注意要给物体添加碰撞器（box collider）
    {
        //print("OnMouseUpAsButton works!");
        gameManager._instance.transformGameState();
        audio.Play();
    }

}
