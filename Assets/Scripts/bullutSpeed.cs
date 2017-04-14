using UnityEngine;
using System.Collections;

public class bullutSpeed : MonoBehaviour {

    public float speed = 2f;
    public float dis_destroy = 2f;
	
	// Update is called once per frame
	void Update () {
        speed = ButtonManagerSetting.BullutSpeed;   //在开挂模式里的子弹速度，默认为2f 

        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > dis_destroy)
        {
            Destroy(this.gameObject);
        }
	}
    


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Enemy")
        {
            if (!other.GetComponent<enemyMove>().isDeath)   //当敌机还未死亡的时候，才进行调用sendMessage
            {
                other.gameObject.SendMessage("BeHit");   //调用gameobject中，名为“BeHit”的方法（实质是gameobject是自己调用的）
                Destroy(this.gameObject);
            }

           
        }
    }
}
