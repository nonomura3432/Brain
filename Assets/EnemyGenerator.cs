using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenrator : MonoBehaviour
{
    [SerializeField] private GameObject Enemy_Green;
    [SerializeField] private GameObject Enemy_Red;
    float span = 2.0f;
    float delta = 0;

    int _numOfDivide = 4;
    

    GameDirector _gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        _gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameDirector.isGameOver) return;
        this.delta += Time.deltaTime;
        if (this.delta > this.span & _gameDirector.isTimeUp == false)
        {
            this.delta = 0;

            var greenPos = GridPosition.GridPosByRandom(4 / 5.0f);
            var redPos = GridPosition.GridPosByRandom(4 / 5.0f);
            while (greenPos == redPos)
            {
                redPos = GridPosition.GridPosByRandom(4 / 5.0f);
            }
            Instantiate(Enemy_Green, greenPos, Quaternion.identity);
            Instantiate(Enemy_Red, redPos, Quaternion.identity);
            
            
        }
    }
}

