using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    [SerializeField] private GameObject GameDirector;

    // Start is called before the first frame update
    void Start()
    {
        GameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("down") & GameDirector.GetComponent<GameDirector>().isTimeUp == false)
        {
            transform.Translate(0, -0.01f, 0);
        }
        if(Input.GetKey("up") & GameDirector.GetComponent<GameDirector>().isTimeUp == false)
        {
            transform.Translate(0, 0.01f, 0);
        }
        if(Input.GetKeyDown("space") & GameDirector.GetComponent<GameDirector>().isTimeUp == false)
        {
            Instantiate(BulletPrefab,transform.position, Quaternion.identity);
        }

    }
}
