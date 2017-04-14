/*
 * 控制背景移动
 */

using UnityEngine;
using System.Collections;

public class backgroundTransform : MonoBehaviour {

    public static float moveSpeed = 2.0f;

	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);  //让当前物体(此处为bg)的坐标向下移动
        Vector3 position = this.transform.position;
        if (position.y < -8.52f)
        {
            this.transform.position =new Vector3(position.x,position.y + 8.52f*2,position.z);
        }
	}
}
