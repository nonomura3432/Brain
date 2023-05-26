using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenrator : MonoBehaviour
{
    [SerializeField] private GameObject Enemy_Green;
    [SerializeField] private GameObject Enemy_Red;
    [SerializeField] private GameObject GameDirector;
    float span = 2.0f;
    float delta = 0;
    public float greenScaleX { get; private set; }
    private float greenScaleY; 
    public float redScaleX { get; private set; }
    private float redScaleY;

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
            float py = Random.Range(-3.7f, 3.7f);
            greenScaleX = Random.Range(0.5f, 2f);
            greenScaleY = greenScaleX;
            redScaleX = Random.Range(0.5f, 2f);
            redScaleY = redScaleX;
            Vector3 vector = new Vector3(7, py, 0);
            Enemy_Green.transform.localScale = new Vector3(greenScaleX,greenScaleY, 1);
            Enemy_Red.transform.localScale = new Vector3(redScaleX, redScaleY, 1);
            Debug.Log($"Enemy_Green.transform.localScale‚Í{Enemy_Green.transform.localScale}");
            Debug.Log($"Enemy_Red.transform.localScale‚Í{Enemy_Red.transform.localScale}");
            Instantiate(Enemy_Green, vector, Quaternion.identity);
            Instantiate(Enemy_Red, vector, Quaternion.identity);
        }
    }
}

