using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public float speed = 5f;
    public int lifetime = 5;
  //  private Player player;
    

    // Start is called before the first frame update
    void Start()
    {
       // player = GameObject.Find("Player").GetComponent<Player>();
        Invoke("destroythisobg", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (Player.instance.score > 10)
        {
            speed = 6f;
        }
        if (Player.instance.score > 30)
        {
            speed = 8f;
        }
        if (Player.instance.score > 50)
        {
            speed = 10f;
        }
        if (Player.instance.score > 60)
        {
            speed = 15f;
        }
    }
    void destroythisobg()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.instance.Music();
            //player.Music();
           // Player.score++;
        }
    }
}
