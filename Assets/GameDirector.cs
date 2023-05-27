using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] KimotiSlider kimotiSlideer;
    [SerializeField] GameObject gameOverTextObj;
    [SerializeField] WaveManager waveManger;
    WaveManager _waveManager;
    [SerializeField] Text storyText;
    
    EnemyGenerator enemyGenerator;
    GameObject timerText;
    private GameObject pointText;
    float time = 2.0f;
    private int point = 0;
    public bool isTimeUp { get; private set; }
    public bool isGameOver { get; private set; }
    public bool isClear { get; private set; }
    public bool isShowStory { get; private set; }
    private Text scoreText;

    public void hitEnemy(Collider2D collision)
    {
        if (collision.CompareTag("Enemy_Green"))
        {
            kimotiSlideer.HitKairaku();
        }
        else if(collision.CompareTag("Enemy_Red"))
        {
            kimotiSlideer.HitSutoresu();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timerText = GameObject.Find("Time");
        pointText = GameObject.Find("Point");
        scoreText = pointText.GetComponent<Text>();

        if (FindObjectOfType<WaveManager>() == null)
        {
             Instantiate(waveManger);
        }

        _waveManager = FindObjectOfType<WaveManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;
        scoreText.text = point.ToString() + "point";
        if (0 <= time)
        {
            time -= Time.deltaTime;
            timerText.GetComponent<Text>().text = time.ToString("F1");
        }
        else if (time <= 0)
        {
            isTimeUp = true;
            timerText.GetComponent<Text>().text = "TimeUp!";
            
            if(!isClear)
            {
                StartCoroutine(ShowTextCoroutine());
            }
        }

    }
    
    IEnumerator ShowTextCoroutine()
    {
        isShowStory = true;
        var content =  _waveManager.waveCount switch
        {
             1 =>"1日目\n　わたしはきみがすきだ。シアワセにしたい。\n 非力なきみがシアワセに生きられるよう、快楽の信号を送りつづけるよ。",
             2 =>  "5日目\n　いとおしいきみがぷかぷかと浮いては沈む。わたしはそれを眺めている。\n あの日を思い出す。きみが施設の屋上から身を乗り出した日。\n 非力なきみがシアワセに生きられるよう、今日も快楽の信号を送り続けるよ。",
             3 =>  "10日目\n　きみはにげた。窓からにげた。身体を奪ってにげてしまった。\n 柔らかな電流も甘い泡粒も優しい手のひらも、もうきみを包んではいない。\n 非力なきみはシアワセには生きられないことを知ってしまった。そして残酷な世界で生きていく。\n >>>GAMECLEAR",
        };
        storyText.text = content;
        yield return new WaitForSeconds(10.0f);
        isShowStory = false;
        SceneManager.LoadScene("SampleScene");
    }

    public  void GameOver()
    {
        gameOverTextObj.SetActive(true);
        isGameOver = true;
    }
}