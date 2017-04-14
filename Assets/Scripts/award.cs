using UnityEngine;
using System.Collections;

public class award : MonoBehaviour {

    public int type = 2;
    public float awardSpeed = 1.5f;
    public float dis_destroy = -8.0f;
    
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * awardSpeed * Time.deltaTime);

        if(transform.position.y <= dis_destroy)
        {
            Destroy(this.gameObject);
        }
	}


}
