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

            int height = Screen.height;
            float unitHeight = height / _numOfDivide;
            
            int randGreen = Random.Range(0, _numOfDivide);
            float greenPosY = randGreen *unitHeight + 1/2.0f * unitHeight;
            
            int randRed = Random.Range(0, _numOfDivide);
            while (randGreen == randRed)
            {
                randRed = Random.Range(0, _numOfDivide); // Greenと重ならなくなるまで再抽選
            }
            float redPosY = randRed * unitHeight + 1/2.0f * unitHeight;
            
            var greenVector = new Vector3(4/5.0f * Screen.width, greenPosY, 0);
            Vector2 greenScreenPosY =  Camera.main.ScreenToWorldPoint(greenVector);  
            var redVector = new Vector3( 4/5.0f * Screen.width, redPosY, 0);
            Vector2 redScreenPosY =  Camera.main.ScreenToWorldPoint(redVector);
            
            
            Debug.Log($"greenScreenPosY = {greenScreenPosY}");
            Debug.Log($"redScreenPosY = {redScreenPosY}");
            Instantiate(Enemy_Green, greenScreenPosY, Quaternion.identity);
            Instantiate(Enemy_Red, redScreenPosY, Quaternion.identity);
            
            
            //  Instantiate(Enemy_Red, new Vector3(7, 3,0), Quaternion.identity);
            //  
            // var half = Screen.height / 2;
            // Vector3 vector = new Vector3(7, half, 0);
            // Vector2 screenVector = Camera.main.ScreenToWorldPoint(vector);
            // Instantiate(Enemy_Green,screenVector , Quaternion.identity);

            // float greenPy = Random.Range(-3.7f, 3.7f);
            // int roundedGreenPy = (int)Math.Floor(greenPy);
            // Debug.Log($"py��{roundedGreenPy}");
            // float redPy = Random.Range(-3.7f, 3.7f);
            // int roundedRedPy = (int)Math.Floor(redPy);
            // Debug.Log($"py��{roundedRedPy}");
            // //float py = Random.Range(-3.7f, 3.7f);
            // //Math.Floor(py);
            // //Debug.Log($"py��{py}");
            // Vector3 greenVector = new Vector3(7, greenPy, 0);
            // Vector3 redVector = new Vector3(7, redPy, 0);
            // if (greenPy!=redPy)
            // {
            //     Instantiate(Enemy_Green, greenVector, Quaternion.identity);
            // }
            // Instantiate(Enemy_Red, redVector, Quaternion.identity);
        }
    }
}

