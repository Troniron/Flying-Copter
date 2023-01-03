using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{

    [SerializeField]
    private GameObject Quedobg;
    private Renderer Rend;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        Rend = Quedobg.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        Rend.material.mainTextureOffset = offset;
        
    }
}
