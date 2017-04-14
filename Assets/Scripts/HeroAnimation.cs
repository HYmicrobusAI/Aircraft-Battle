using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroAnimation : MonoBehaviour {

    public Sprite[] HeroAnimationSprite;
    public int HeroFrameCountPerSeconds = 10; //每帧播放的次数
    public float HeroTimer = 0;//计时器
    public GameObject heroPic;
    private SpriteRenderer heroSpriteRender;
    public bool isAnimation;

    public Button HeroButtonCancel;

	// Use this for initialization
    void Awake()
    {
        isAnimation = false;

    }

	void Start () {
        heroSpriteRender = heroPic.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(isAnimation && HeroTimer>1.5f)
        {
            isAnimation = true;
            HeroButtonCancel.gameObject.SetActive(false);
            HeroTimer += Time.deltaTime;
            int heroFrame = (int)(HeroTimer/(1/HeroFrameCountPerSeconds));
            int FrameIndex = heroFrame % 2;
            heroSpriteRender.sprite = HeroAnimationSprite[FrameIndex];
        }

	}
}
