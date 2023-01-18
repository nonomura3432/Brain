using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenrator : MonoBehaviour
{
    //public GameObject enemyPrefab as GameObject;
    //private float interval = 2.0f;
    //private float timeElapsed = 0.0f;

    //public GameObject EnemyPrefab;
    [SerializeField] private GameObject EnemyPrefab;
    float span = 2.0f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {

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
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            float py = Random.Range(-3.7f, 3.7f);
            Vector3 vector = new Vector3(7, py, 0);
            Instantiate(EnemyPrefab, vector, Quaternion.identity);

        }
    }
}
