using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManagerScript : MonoBehaviour
{
    public static CollectionManagerScript Instance;

    private List<PageScript> collectedPrizes = new List<PageScript>();
    private List<Sprite> collectedPrizeImages = new List<Sprite>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCollectedPrize(PageScript prize)
    {
        collectedPrizes.Add(prize);
        collectedPrizeImages.Add(prize.prizeImage); 
    }

    public List<PageScript> GetCollectedPrizes()
    {
        return collectedPrizes;
    }

    public string GetPrizeNameAtIndex(int index)
    {
        if (index >= 0 && index < collectedPrizes.Count) 
        {
            return collectedPrizes[index].prizeName.ToString();
        }
        else
        {
            return "invalid";
        }
    }
}