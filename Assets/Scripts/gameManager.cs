using UnityEngine;
using System.Collections;

public enum GameState
{
    running,
    pause
}

public class gameManager : MonoBehaviour {

    public static gameManager _instance;
    public float score = 0f;   //设置当前分数


    //游戏暂停设计
    public GameState gameState = GameState.running;  

    //获取hero组件中的UI控件
    //private GameObject UIControll;

    void Awake()
    {
        _instance = this;
    }



    public void transformGameState()
    {
        if (gameState == GameState.running)
        {
            this.GetComponent<hero>().GameOverImage.gameObject.SetActive(true);
            
            this.GetComponent<hero>().highestScore.gameObject.SetActive(true);
            this.GetComponent<hero>().highestScore_display.gameObject.SetActive(true);
            this.GetComponent<hero>().recentScore.gameObject.SetActive(true);
            this.GetComponent<hero>().recentScore_display.gameObject.SetActive(true);

            this.GetComponent<hero>().highestScore_display.text = " " + this.GetComponent<hero>().HistotyHighestScore;
            this.GetComponent<hero>().recentScore_display.text = " " + gameManager._instance.score;

            //this.GetComponent<hero>().ReStart.gameObject.SetActive(true);
            //this.GetComponent<hero>().QuitGame.gameObject.SetActive(true);
            pauseGame();
        }
        else if (gameState == GameState.pause)
        {
            this.GetComponent<hero>().GameOverImage.gameObject.SetActive(false);

            this.GetComponent<hero>().highestScore.gameObject.SetActive(false);
            this.GetComponent<hero>().highestScore_display.gameObject.SetActive(false);
            this.GetComponent<hero>().recentScore.gameObject.SetActive(false);
            this.GetComponent<hero>().recentScore_display.gameObject.SetActive(false);

            //this.GetComponent<hero>().ReStart.gameObject.SetActive(false);
            //this.GetComponent<hero>().QuitGame.gameObject.SetActive(false);

            continueGame();
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;  //使得Time.delatime = 0
        gameState = GameState.pause;
    }

    public void continueGame()
    {
        Time.timeScale = 1;
        gameState = GameState.running;
    }
}
