using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManig : MonoBehaviour
{
    [SerializeField] private GameObject playerprefab;
    [SerializeField] private Transform spawnTransform;

    private PlayerContllor playerContllor;
    public PlayerCam playerCam;

    

    private GameObject player;

    void Start()
    {
        RespawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer();
        }


        //if(player != null) 
        //{
        //    RespawnPlayer();
        //}

    }

    public void RespawnPlayer()
    {
        player = Instantiate(playerprefab,spawnTransform.position,Quaternion.identity);

        playerContllor = player.GetComponent<PlayerContllor>();

        playerCam.playerTransform = player.transform;
        playerCam.SetOffset();
        
    }

}
