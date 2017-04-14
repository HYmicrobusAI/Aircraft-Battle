using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemy0Perfab;
    public GameObject enemy1Perfab;
    public GameObject enemy2Perfab;
    public GameObject award0Perfab;
    public GameObject award1Perfab;

    public float enemy0Rate = 0.5f; //每0.5秒生成一次
    public float enemy1Rate = 1f;
    public float enemy2Rate = 2f;
    public float award0Rate = 2f;
    public float award1Rate = 2f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateEnemy0", 5, enemy0Rate);
        InvokeRepeating("CreateEnemy1", 10, enemy1Rate);
        InvokeRepeating("CreateEnemy2", 15, enemy2Rate);
        InvokeRepeating("CreateAward0", 30, award0Rate);
        InvokeRepeating("CreateAward1", 35, award1Rate);
	}

    public void CreateEnemy0()
    {
        float x = Random.Range(-2.16f,2.16f);
        GameObject.Instantiate(enemy0Perfab,new Vector3(x,transform.position.y,0),Quaternion.identity);
    }

    public void CreateEnemy1()
    {
        float x = Random.Range(-2.04f, 2.04f);
        GameObject.Instantiate(enemy1Perfab, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }

    public void CreateEnemy2()
    {
        float x = Random.Range(-1.555f, 1.555f);
        GameObject.Instantiate(enemy2Perfab, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }

    public void CreateAward0()
    {
        audio.Play();
        float x = Random.Range(-2.115f, 2.115f);
        GameObject.Instantiate(award0Perfab, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }

    public void CreateAward1()
    {
        audio.Play();
        float x = Random.Range(-2.10f, 2.10f);
        GameObject.Instantiate(award1Perfab, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
}
