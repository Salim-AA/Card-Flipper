using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//this script demonstrates the usage of a SyncVar to synchronize a variable across the network
public class IncrementClickByTwo : NetworkBehaviour
{
    public PlayerManager PlayerManager;

    [SyncVar]
    public int NuumberOfClicks;
    [SyncVar]
    public int DeeckCounter;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    public GameObject HezjoujOne;
    public GameObject HezjoujCardOne;



    /
    public void OnClick()
    {
        
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();

        if (isServer)
        {
            PlayerManager.CmdDealOneCard();
        }
        else
        {
            PlayerManager.CmdDealOneCardEnemy();
        }
        
    }




    public void IncrementClickByTwoClicks()
    {
        //locate the PlayerManager within this client and request the server to run CmdIncrementClick(), passing in this gameobject
        
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
        PlayerManager.CmdIncrementClickByTwo(gameObject);
        
    }

    


    public void GetSpriteCard()
    {
        HezjoujOne = GameObject.Find("HezjoujOne");
        HezjoujCardOne = GameObject.Find("HezjoujCardOne");

        PlayerManager.CmdGetSpriteCardlol();
        CanvasGroup caaag = HezjoujOne.GetComponent<CanvasGroup>();
        caaag.interactable = false;
        caaag.alpha = 0;

    }
    
}