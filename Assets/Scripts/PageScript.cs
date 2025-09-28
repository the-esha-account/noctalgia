using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageScript : MonoBehaviour
{
    public string prizeName;
    public Sprite prizeImage;
    public bool isCollected;
    public int pageIndex;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.GetComponent<PlayerScript>() != null) 
        {
            Collect();
        }
    }
    
    public void Collect() 
    {
        isCollected = true;
        CollectionManagerScript.Instance.AddCollectedPrize(this);
        PlayerPrefs.SetInt("Page_" + pageIndex, 1); 
        PlayerPrefs.Save();
        Destroy(gameObject);
    }
}

