using UnityEngine;
using System.Collections;

public class bulluts : MonoBehaviour {

    public GameObject bullut;
    public float rate = 0.2f;


    public void fire()
    {
        GameObject.Instantiate(bullut,transform.position, Quaternion.identity);
    }

    public void openFire()
    {
        InvokeRepeating("fire", 0.1f, rate);   //1秒后开始调用fire  之后每rate时间后调用一次
    }

    public void stopFire()
    {
        CancelInvoke("fire");
    }


}
