using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerAY : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerY;
    
    // Start is called before the first frame update
    void Start()
    {
        playerY = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        playerY.y = player.transform.position.y;
        gameObject.transform.position = playerY;
    }
}
