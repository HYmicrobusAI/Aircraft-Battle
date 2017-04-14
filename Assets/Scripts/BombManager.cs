using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BombManager : MonoBehaviour {

    public Text bombNumber;
    public GameObject bomb;
    public static BombManager _instance;

    public int count = 0;

    void Awake()
    {
        _instance = this;
        bomb.SetActive(false);   //初始将炸弹图片设置为隐藏的
        bombNumber.gameObject.SetActive(false);  //初始将炸弹数量设置为隐藏的
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(_instance.count>0&&Input.GetKeyDown(KeyCode.Space))
        {
            UsedAbomb();
        }
	}

    public void AddAbomb()
    {
        //当主角吃到一个炸弹的奖励物品后，即显示相应的图标
        count =count + 1 + ButtonManagerSetting.BoomNumber;
        bomb.SetActive(true);
        bombNumber.gameObject.SetActive(true);
        bombNumber.text = "X " + count;
    }

    public void UsedAbomb()
    {
        //当用户使用了炸弹功能后，将屏幕上所有的敌人都消灭并获得相应的分数
        audio.Play();
        count--;   //炸弹数量减1
        bombNumber.text = "X " + count;   //显示当前炸弹数量
        if(count<=0)
        {
            bomb.SetActive(false);
            bombNumber.gameObject.SetActive(false);
        }
    }


}