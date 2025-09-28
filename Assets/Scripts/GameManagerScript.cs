using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    public int levelNumber;

    private void Start() 
    {
        instance = this;
        levelNumber = SceneManager.GetActiveScene().buildIndex;
    }

    public void SaveLevelInfo() 
    {
        int nextLevelNumber = levelNumber + 1;
        PlayerPrefs.SetInt("Level" + nextLevelNumber + "Unlocked", 1);
        Debug.Log("Level" + nextLevelNumber + "Unlocked");
    }
}
