using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnKey : MonoBehaviour
{
    
    public GameObject respawnPoint;
    public GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        { 
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
