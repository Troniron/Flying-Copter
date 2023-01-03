using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcokSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject rock;
    // [SerializeField]
    private float frequency = 0f;
    // Start is called before the first frame update
    void Start()
    {
     //   float frequency;
       
            frequency = 1f;

        /* else
         {
             frequency = 1f;
         }*/
      
        InvokeRepeating("instiateobg", 1, frequency);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void instiateobg()
    {
        Vector3 randompos = new Vector3(transform.position.x, Random.Range(-1, 1), transform.position.z);
        Instantiate(rock, randompos, transform.rotation);
    }
}
