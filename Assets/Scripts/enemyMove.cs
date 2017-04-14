using UnityEngine;
using System.Collections;

public enum EnemyType
{
    SmallEnemy,
    MiddleEnemy,
    BigEnemy
}

public class enemyMove : MonoBehaviour {

    public float enemySpeed = 2f;
    public float dis_destroy = -8.5f;
    public float hp = 1f;
    public float score = 100f;

    public EnemyType type = EnemyType.SmallEnemy;
    public bool isDeath = false;

    public Sprite[] explosionSprites;
    private float timer = 0;  //敌机死亡的时间控制
    public int explorsionAnimationFrame = 10;
    private SpriteRenderer render;

    public float hitTimer=0.2f;  //碰撞播放的时间
    private float resetHitTime;  //打击一次的话，进行重置；

    public Sprite[] hitSprite;

    //设置音乐
    public GameObject UsedBombMusic;
    //public GameObject EnemyDieMusic;


    void Start()
    {
        render = this.GetComponent<SpriteRenderer>();

        resetHitTime = hitTimer;
        hitTimer = 0;
    }


	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
        if(transform.position.y <= dis_destroy)
        {
            Destroy(this.gameObject);
        }

        if (isDeath)   //当敌机死掉的时候，就播放死亡的动画 
        {
            timer += Time.deltaTime;
            int frameIndex = (int)(timer / (1f / explorsionAnimationFrame));
            //print(frameIndex);
            if (frameIndex >= explosionSprites.Length)
            {
                Destroy(this.gameObject);
            }
            else
            {
                render.sprite = explosionSprites[frameIndex];
            }
        }
        else 
        {
            if(type==EnemyType.MiddleEnemy||type==EnemyType.BigEnemy)
            {
                if (hitTimer >= 0)    //表示当前需要播放动画
                {
                    hitTimer -= Time.deltaTime;
                    int frameIndex = (int)((resetHitTime - hitTimer) / (1f / explorsionAnimationFrame));
                    frameIndex %= 2;
                    render.sprite = hitSprite[frameIndex];
                }
            }
        }

        if(BombManager._instance.count>0&&Input.GetKeyDown(KeyCode.Space))
        {
            UsedBombMusic.audio.Play();
            toDie();
        }
	}

    public void BeHit()    //敌机每被子弹击中一次，就调用一次该函数
    {
        hp -= 1;
        if (hp < 0)
        {
            if (!isDeath)  //当hp为0且当前敌机还未死亡的时候
            {
                toDie();
            }
        }
        else
        {
            hitTimer = resetHitTime;
        }
    }

    public void toDie()
    {
        audio.Play();
        isDeath = true;
        gameManager._instance.score += score;
        
    }
}
