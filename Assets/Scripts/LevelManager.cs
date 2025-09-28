using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject levelButton;
    [SerializeField] private Transform levelButtonParent;
    [SerializeField] private bool[] levelOpen;
    public List<Vector3> buttonPositions;
    public List<GameObject> levelButtons = new List<GameObject>();
    public int count;

    private void Awake() 
    {
        foreach (Vector3 position in buttonPositions)
        {
            count++;
            string sceneName = "Level " + count;

            GameObject newButton = Instantiate(levelButton, levelButtonParent);
            newButton.transform.localPosition = position;
            Button buttonComponent = newButton.GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => LoadLevel(sceneName));
            buttonComponent.interactable = false;
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = count.ToString();
            levelButtons.Add(newButton);
        }
    }

    private void Update() 
    {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings - 2; i++) 
        {
            bool unlocked = PlayerPrefs.GetInt("Level" + i + "Unlocked") == 1;
            Button buttonComponent = levelButtons[i - 1].GetComponent<Button>();

            if(!unlocked) 
            {
                buttonComponent.interactable = false;
            }
            else 
            {
                buttonComponent.interactable = true;
            }
        }
    }

    private void Start() 
    {
        //DEBUG: Reset all PlayerPrefs (for testing)
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
        PlayerPrefs.SetInt("Level1Unlocked", 1);
        for (int i = 0; i < levelButtons.Count; i++)
        {
            int levelNumber = i + 1;
            bool unlocked = PlayerPrefs.GetInt("Level" + levelNumber + "Unlocked", 0) == 1;
            levelButtons[i].GetComponent<Button>().interactable = unlocked;
        }
    }

    private void AssignLevelBooleans() 
    {
        for(int i = 1; i < SceneManager.sceneCountInBuildSettings - 2; i++) 
        {  
            bool unlocked = PlayerPrefs.GetInt("Level" + i + "Unlocked") == 1;
            if(unlocked) 
            { 
                levelOpen[i] = true;
            }
            else 
            {
                return;
            }
        }
    } 

    public void LoadLevel(string sceneName) => SceneManager.LoadScene(sceneName);
    public void LoadContinueGame() 
    {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++) 
        {
            bool unlocked = PlayerPrefs.GetInt("Level" + i + "Unlocked") == 1;
            if(!unlocked) 
            {
                SceneManager.LoadScene("Level " + (i - 1));
            }
        }
        return;
    }
}
