using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    EnemyGenerator enemyGenerator;
    GameObject timerText;
    private GameObject pointText;
    float time = 30.0f;
    private int point = 0;
    public bool isTimeUp { get; private set; }

    private Text scoreText;

    // Kimoti
    KimotiSlider _kimotiSlider;

    public void hitEnemy()
    {
        enemyGenerator = GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>();
        point += (int) (enemyGenerator.scaleX * 10.0f);
        
        // ToDo: Enemyが快楽かストレスかを反映する
        if (true) //とりあえずは常に「快楽」を撃つことにする
        {
            _kimotiSlider.HitKairaku();
        }
        else
        {
            _kimotiSlider.HitSutoresu();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timerText = GameObject.Find("Time");
        pointText = GameObject.Find("Point");
        scoreText = pointText.GetComponent<Text>();
        
        _kimotiSlider = GameObject.Find("KimotiSlider").GetComponent<KimotiSlider>();
    }

    // Update is called once per frame
    void Update()
    {
   
        scoreText.text  = point.ToString() + "point";
        if (0 <= time)
        {
            time -= Time.deltaTime;
            timerText.GetComponent<Text>().text = time.ToString("F1");
        }
        else if (time <= 0)
        {
            isTimeUp = true;
            timerText.GetComponent<Text>().text = "TimeUp!";
        }

    }
}

