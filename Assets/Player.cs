using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    [SerializeField] private GameObject GameDirector;
    GameDirector _gameDirector;

    float _playerPosXRation = 1 / 12.0f;
    int _initIndex = 1;
    int _currentGridYIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        _currentGridYIndex = _initIndex;
        transform.position = GridPosition.GridPosByIndex(_playerPosXRation, _currentGridYIndex); // 最初は真ん中あたりにいることにする
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameDirector.isGameOver)
        {
            if (!_gameDirector.isTimeUp)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if(_currentGridYIndex <= 0) return;
                    _currentGridYIndex--;
                    transform.position = GridPosition.GridPosByIndex(_playerPosXRation, _currentGridYIndex);
                }
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if(_currentGridYIndex >= GridPosition.numOfDivide-1 ) return;
                    _currentGridYIndex++;
                    transform.position = GridPosition.GridPosByIndex(_playerPosXRation, _currentGridYIndex);
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
