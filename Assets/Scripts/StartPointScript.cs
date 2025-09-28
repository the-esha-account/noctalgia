using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointScript : MonoBehaviour
{
    private void Awake()
    {
        PlayerManagerScript.instance.respawnPoint = transform;
        PlayerManagerScript.instance.PlayerRespawn();
    }
}
