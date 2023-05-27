using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenrator : MonoBehaviour
{
    [SerializeField] private GameObject Enemy_Green;
    [SerializeField] private GameObject Enemy_Red;
    [SerializeField] private GameObject GameDirector;
    float span = 2.0f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span & GameDirector.GetComponent<GameDirector>().isTimeUp == false)
        {
            this.delta = 0;
            float greenPy = Random.Range(-3.7f, 3.7f);
            int roundedGreenPy = (int)Math.Floor(greenPy);
            Debug.Log($"py‚Í{roundedGreenPy}");
            float redPy = Random.Range(-3.7f, 3.7f);
            int roundedRedPy = (int)Math.Floor(redPy);
            Debug.Log($"py‚Í{roundedRedPy}");
            //float py = Random.Range(-3.7f, 3.7f);
            //Math.Floor(py);
            //Debug.Log($"py‚Í{py}");
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

