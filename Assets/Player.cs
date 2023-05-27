using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    [SerializeField] private GameObject GameDirector;
    GameDirector _gameDirector;

    float playerPosXRation = 1 / 10.0f;
    int currentGridYIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        
        transform.position = GridPosition.GridPosByIndex(playerPosXRation, GridPosition.numOfDivide / 2); // 最初は真ん中あたりにいることにする
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameDirector.isGameOver)
        {
            if (!_gameDirector.isTimeUp)
            {
                // if (Input.GetKey("down") & _gameDirector.isTimeUp == false)
                // {
                //     transform.Translate(0, -0.01f, 0);
                // }
                //
                // if (Input.GetKey("up") & _gameDirector.isTimeUp == false)
                // {
                //     transform.Translate(0, 0.01f, 0);
                // }
                //
                // if (Input.GetKeyDown("space") & _gameDirector.isTimeUp == false)
                // {
                //     Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                // }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if(currentGridYIndex <= 0) return;
                    currentGridYIndex--;
                    transform.position = GridPosition.GridPosByIndex(playerPosXRation, currentGridYIndex);
                }
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if(currentGridYIndex >= GridPosition.numOfDivide-1 ) return;
                    currentGridYIndex++;
                    transform.position = GridPosition.GridPosByIndex(playerPosXRation, currentGridYIndex);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    var waveManager = FindObjectOfType<WaveManager>();
                    waveManager.IncrementCount();
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {   var waveManager = FindObjectOfType<WaveManager>();
                waveManager.Reset();
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
