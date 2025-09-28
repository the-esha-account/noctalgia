using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerScript : MonoBehaviour
{
    public static PlayerManagerScript instance;
    [SerializeField] public Transform respawnPoint;
    [SerializeField] private GameObject playerPrefab;
                     public GameObject currentPlayer;

    private void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
        if(instance == null) 
        {
            instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayerRespawn() 
    {
        if(currentPlayer == null) 
        {
            currentPlayer = Instantiate(playerPrefab, respawnPoint.position, transform.rotation);
        }
    }
}
