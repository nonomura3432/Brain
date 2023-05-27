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
            float greenPy = Random.Range(-3.7f, 3.7f);
            int roundedGreenPy = (int)Math.Floor(greenPy);
            Debug.Log($"py��{roundedGreenPy}");
            float redPy = Random.Range(-3.7f, 3.7f);
            int roundedRedPy = (int)Math.Floor(redPy);
            Debug.Log($"py��{roundedRedPy}");
            //float py = Random.Range(-3.7f, 3.7f);
            //Math.Floor(py);
            //Debug.Log($"py��{py}");
            Vector3 greenVector = new Vector3(7, greenPy, 0);
            Vector3 redVector = new Vector3(7, redPy, 0);
            if (greenPy!=redPy)
            {
                Instantiate(Enemy_Green, greenVector, Quaternion.identity);
            }
            Instantiate(Enemy_Red, redVector, Quaternion.identity);
        }
    }
}

