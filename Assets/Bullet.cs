using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject player;
    [SerializeField] private GameObject BulletPrefab;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        Vector3 vector = new Vector3(-8f, player.transform.position.y, 0);
        transform.position = new Vector3(-8f, player.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
      
        //transform.Translate(0.03f, Player.transform.position.y, 0);

     
        timer += Time.deltaTime*10;
        
        
        transform.position = new Vector3(timer,0,0);
        
        if(transform.position.x>10.0f)
        {
            Destroy(gameObject);
        }
    }
    //’e‚ª“G‚É‚ ‚½‚é‚Æ“G‚Æ’e‚ªÁ–Å‚·‚é
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
