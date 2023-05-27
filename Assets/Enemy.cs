using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameDirector _director;
    // Start is called before the first frame update
    void Start()
    {
        _director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_director.isGameOver)return;
        if(_director.isShowStory)return;
        
        transform.Translate(-0.001f,0,0);
        
        if(transform.position.x<-10.0f)
        {
            Destroy(gameObject);
        }
    }
}
