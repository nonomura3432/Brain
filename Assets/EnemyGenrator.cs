using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    float span = 2.0f;
    float delta = 0;
    public float scaleX { get; private set; }
    private float scaleY;

    GameDirector _gameDirector;
    

    // Start is called before the first frame update
    void Start()
    {
        _gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    //{
    //    timeElapsed += timeElapsed.deltaTime;
    //    if (timeElapsed >= interval)
    //    {
    //        timeElapsed = 0.0f;
    //        Vector3 randompos = new Vector3(11, randompos.Range(3.7f, -3.7f), 0);
    //        Instantiate(enemyPrefab, randompos, Quternion.identity);
    //    }
    //}

    {
        if(_gameDirector.isGameOver) return;
        this.delta += Time.deltaTime;
        if (this.delta > this.span & _gameDirector.isTimeUp == false)
        {
            this.delta = 0;
            float py = Random.Range(-3.7f, 3.7f);
            scaleX = Random.Range(0.5f, 2f);
            scaleY = scaleX;
            Vector3 vector = new Vector3(7, py, 0);
            EnemyPrefab.transform.localScale = new Vector3(scaleX,scaleY, 1);
            Debug.Log($"EnemyPrefab.transform.localScale��{EnemyPrefab.transform.localScale}");
            Instantiate(EnemyPrefab, vector, Quaternion.identity);

        }
    }
}

