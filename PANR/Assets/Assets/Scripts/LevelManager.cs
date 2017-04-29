using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Networking;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint1;
    //public GameObject currentCheckpoint2;
    //public GameObject currentCheckpoint3;

    //private PlayerController player;
    private playerScript player;

	// Use this for initialization
	void Start ()
	{
	    player = FindObjectOfType<playerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respawn()
    {
        Debug.Log("Player respawned");
        player.transform.position = currentCheckpoint1.transform.position;
        //player.transform.position = currentCheckpoint2.transform.position;
        //player.transform.position = currentCheckpoint3.transform.position;
    }
}
