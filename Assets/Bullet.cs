using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speedX = 0.01f;

    // Start is called before the first frame update
    void Start()
    {

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
    //’e‚ª“G‚É‚ ‚½‚é‚Æ“G‚Æ’e‚ªÁ–Å‚·‚é
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
