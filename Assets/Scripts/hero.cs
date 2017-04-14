/*
 * 实现主角--飞机的动画效果
 * 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hero : MonoBehaviour {

    public bool animation = true;
    public int frameCountPerSeconds = 10; //每帧播放的次数
    public float timer = 0;//计时器
    public Sprite[] sprites;  //hero1和hero2的动画转化   动画是通过帧数来循环播放的
    private SpriteRenderer HeroSpriteRender;

    private bool isMouseDown = false;   //标志位，检查鼠标是否按下
    private Vector3 lastMousePosition = Vector3.zero;  //记录鼠标最后一刻的位置

    //主角死亡的动画处理
    public Sprite[] HeroSprite;
    public float HeroAnimationFrame = 20f;
    public bool isHeroDead = false;
    public float HeroTimer = 0f;

    //奖励物品处理
    public bulluts topGun;    //bulluts为控制子弹发射的脚本
    public bulluts leftGun;
    public bulluts rightGun;

    public float TimeSuperGun = 10f;
    private float resetSuperGunTime;
    private int GunType = 1;   //控制子弹的转化类型，若没有此变量，topGun子弹将以数量不断上升的趋势发射，可能是无限调用openFire导致的

    
    //显示分数
    public Text ScoreText;

    //游戏结束界面设计：显示最高分数和当前分数、游戏结束背景
    public Text highestScore;
    public Text recentScore;
    public Text highestScore_display;
    public Text recentScore_display;
    public Text GameOverText;

    public Image GameOverImage;

    //重新开始和退出游戏按钮
    public Button QuitGame;
    public Button ReStart;

    //设置游戏最高分
    public float HistotyHighestScore;

    //判断当前游戏是否结束，即主角是否死亡
    public static bool isPlayerDeath;

    //显示游戏当前时间
    public Text GameTimer_text;
    public static float _GameTimer = 0f;
    public int count = 0;

    //设置倒计时动画按钮
    public Button number1;
    public Button number2;
    public Button number3;
    public Button StartNode;

    void Awake()
    {
        HistotyHighestScore = PlayerPrefs.GetFloat("HistotyHighestScore", 0);    //将该变量存储与prefab中
        isPlayerDeath = false;

        //初始化倒计时按钮为隐藏
        number1.gameObject.SetActive(false);
        number2.gameObject.SetActive(false);
        number3.gameObject.SetActive(false);
        StartNode.gameObject.SetActive(false);

    }

    public void Start()
    {
        HeroSpriteRender = this.GetComponent<SpriteRenderer>();   //获取该物体（脚本所挂的组件）的组件属性

        resetSuperGunTime = TimeSuperGun;
        TimeSuperGun = 0f;
        topGun.openFire();

        //初始化将所有分数以及部分按钮设置为隐藏的
        highestScore.gameObject.SetActive(false);
        recentScore.gameObject.SetActive(false);
        highestScore_display.gameObject.SetActive(false);
        recentScore_display.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);

        QuitGame.gameObject.SetActive(false);
        ReStart.gameObject.SetActive(false);

        GameOverImage.gameObject.SetActive(false);

    }

	// Update is called once per frame
	void Update () {
        //计算游戏当前运行时间
        _GameTimer += Time.deltaTime;
        string _time = _GameTimer.ToString("#0.00");
        GameTimer_text.text = "Time: " + _time;

        //调用倒计时函数
        CountDown();

        //实现主角游戏动画
        if (animation&&!isHeroDead)  //当需要动画播放的时候，才进行处理
        {
            timer += Time.deltaTime;  //Time.deltaTime指上一帧距离这一帧的时间间隔，每次的值都有可能不一定
                                      //timer表示当前运行的时间
            int frameIndex = (int)(timer / (1f / frameCountPerSeconds));  //该值表示：帧数..1f / frameCountPerSeconds表示每一帧的时间间隔
            //print("frameIndex = " + frameIndex);  //每个frameIndex执行了6次
            int frame = frameIndex % 2;  //将frame的值控制在0，1之间
            HeroSpriteRender.sprite = sprites[frame];
        }

        //对主角死亡的动画进行处理
        if (isHeroDead == true && !ButtonManagerSetting.unbeatable)  //当主角死掉的时候，播放死亡动画
        {
            HeroTimer += Time.deltaTime;
            int HeroFrameIndex = (int)(HeroTimer/(1f/HeroAnimationFrame));
            if (HeroFrameIndex >= HeroSprite.Length)
            {
                Destroy(this.gameObject);   //死亡动画播放完后，立即清除
            }
            else
            {
                HeroSpriteRender.sprite = HeroSprite[HeroFrameIndex];
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            lastMousePosition = Vector3.zero;
        }

        if (isMouseDown && gameManager._instance.gameState == GameState.running)   //当且仅当满足鼠标按下且游戏状态为运行的时候，才能移动主角
        {
            if (lastMousePosition != Vector3.zero)
            {
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;    //将二维坐标通过相机转化为三维坐标，获得鼠标点击的位置
                //print(offset);
                transform.position = transform.position + offset;
                checkPosition();
            }

            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //对奖励物品的处理
        TimeSuperGun -= Time.deltaTime;
        if (TimeSuperGun > 0)
        {
            if(GunType == 1)
                transformToSuperGun();
        }
        else
        {
            if(GunType == 2)
                transformToNormalGun();
        }

        

        //显示分数
        ScoreText.text="Score: "+ gameManager._instance.score;

	}

    public void CountDown()
    {
        //实现动画倒计时
        if (_GameTimer >= 0f && _GameTimer < 1f)
        {
            number3.gameObject.SetActive(true);
        }
        if (_GameTimer >= 1f && _GameTimer < 2f)
        {
            number3.gameObject.SetActive(false);
            number2.gameObject.SetActive(true);
        }
        if (_GameTimer >= 2f && _GameTimer < 3f)
        {
            number2.gameObject.SetActive(false);
            number1.gameObject.SetActive(true);
        }
        if (_GameTimer >= 3f && _GameTimer < 4f)
        {
            number1.gameObject.SetActive(false);
            StartNode.gameObject.SetActive(true);
        }
        else
            StartNode.gameObject.SetActive(false);
    }

    private void  checkPosition()
    {
        //check x [-2.2,2.2]
        //check y [-3.6,3.4]
        Vector3 pos = transform.position;
        float x = pos.x;
        float y = pos.y;

        if(x>2.2f)
        {
            x = 2.2f;
        }
        if (x < -2.2f)
        {
            x = -2.2f;
        }
        if (y > 3.4f)
        {
            y = 3.4f;
        }
        if (y < -3.6f)
        {
            y = -3.6f;
        }
        transform.position = new Vector3(x,y,0);
        //transform.position.x = x;   不能这样对物体的坐标进行赋值，应该new 一个三维变量Vector3

    }

    public void transformToSuperGun()
    {
        GunType = 2;  //子弹类型为得到奖励物品的状态
        topGun.stopFire();
        leftGun.openFire();
        rightGun.openFire();
    }

    public void transformToNormalGun()
    {
        topGun.stopFire();  //先将之前由于奖励物品增加的Fire关掉

        GunType = 1;  //子弹类型为普通状态
        topGun.openFire();
        leftGun.stopFire();
        rightGun.stopFire();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Award")
        {
            audio.Play();
            award GunAward = collider.GetComponent<award>();   //用于判断子弹的类型：type0和type1
            if(GunAward.type==0)   //奖励物品，类型1(子弹变成左右两边发射的)
            {
                TimeSuperGun = resetSuperGunTime + ButtonManagerSetting.AwardTime;
                Destroy(collider.gameObject);
            }
            else if (GunAward.type == 1)  //奖励物品，类型2，炸弹
                {
                    Destroy(collider.gameObject);
                    BombManager._instance.AddAbomb();
                }
        }
        else if (collider.tag == "Enemy")    //当飞机碰撞到敌机的时候，游戏结束，主角销毁
        {
            isHeroDead = true;
            isPlayerDeath = true;
            //Destroy(this.gameObject);  //主角撞到敌机后，即自动销毁

            if(!ButtonManagerSetting.unbeatable)
            {
                recentScore_display.text = " " + gameManager._instance.score;
                if (gameManager._instance.score > HistotyHighestScore)
                    PlayerPrefs.SetFloat("HistotyHighestScore", gameManager._instance.score);

                highestScore_display.text = " " + HistotyHighestScore;

                GameOverImage.gameObject.SetActive(true);    //游戏结束时，显示游戏结束的背景

                highestScore.gameObject.SetActive(true);
                recentScore.gameObject.SetActive(true);
                highestScore_display.gameObject.SetActive(true);
                recentScore_display.gameObject.SetActive(true);
                GameOverText.gameObject.SetActive(true);

                QuitGame.gameObject.SetActive(true);
                ReStart.gameObject.SetActive(true);
            }
        }
    }

}
