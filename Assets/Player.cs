using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    [SerializeField] private GameObject GameDirector;
    GameDirector _gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        _gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameDirector.isGameOver)
        {
            if (Input.GetKey("down") & _gameDirector.isTimeUp == false)
            {
                transform.Translate(0, -0.01f, 0);
            }
            if(Input.GetKey("up") & _gameDirector.isTimeUp == false)
            {
                transform.Translate(0, 0.01f, 0);
            }
            if(Input.GetKeyDown("space") & _gameDirector.isTimeUp == false)
            {
                Instantiate(BulletPrefab,transform.position, Quaternion.identity);
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }


    }
}
