using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject director;
    float speedX = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        this.director = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position+ new Vector3(speedX, 0, 0);
        
        if(transform.position.x>10.0f)
        {
            Destroy(gameObject);
        }
    }

    //弾が敵にあたると敵と弾が消滅する
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        this.director.GetComponent<GameDirector>().hitEnemy(collision);
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
