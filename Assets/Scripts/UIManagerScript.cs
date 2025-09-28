using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI collectedPageText;
    public Image collectedPagesImage;

    void Update()
    {
        if (CollectionManagerScript.Instance != null)
        {
            List<PageScript> collectedPages = CollectionManagerScript.Instance.GetCollectedPrizes();
            if (collectedPages.Count > 0)
            {
                if (collectedPages.Count >= 2) 
                {
                    collectedPagesImage.sprite = collectedPages[1].prizeImage;
                }

            }
        }
    }

}

