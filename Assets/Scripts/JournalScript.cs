using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalScript : MonoBehaviour
{
    public TextMeshProUGUI journalTextField;
    private string[] texts = new string[]
    {
        "<b>Noctalgia:</b> 'sky grief'-term coined by astronomers detailing the sorrow they feel over the loss of the night skies.\n\n<b>Light pollution:</b> brightening of the night sky caused by street lights and other man-made sources, which has a disruptive effect on natural cycles and inhibits the observation of stars and planets. (Oxford Languages definition)",
        "Glare from artificial lights can also impact wetland habitats that are home to amphibians such as frogs and toads, whose nighttime croaking is part of the breeding ritual. Artificial lights disrupt this nocturnal activity, interfering with reproduction and reducing populations.\n\nSea turtles live in the ocean but hatch at night on the beach. Hatchlings find the sea by detecting the bright horizon over the ocean. Artificial lights draw them away from the ocean. In Florida alone, millions of hatchlings die this way every year.\nMany insects are drawn to light, but artificial lights can create a fatal attraction.",
        "Light pollution can be reversed through education, awareness, and action! Energy-efficient outdoor lighting fixtures, shielding lights, installing light timers and motion sensors and using responsible practices are simple measures that can go a long way.\n\nAdditionally, raising awareness is important, whether it be encouraging neighbors or local businesses to adopt responsible lighting practices or joining dark sky initiatives. By understanding the value of dark skies, we can protect our ecosystems, and also enhance our lives-restoring and establishing many communities for current and future generations.",
        "The night sky has long been a source of wonder and inspiration, yet modern lighting has hidden the stars from most of us. Observatories and amateur stargazers alike struggle against the haze of urban glow. But it's not just aesthetics-- our connection to the cosmos has cultural and psychological importance. Communities that preserve dark skies report improved mental well-being and a renewed sense of place.\n\nSimple actions like switching off unnecessary lights, using downward-facing fixtures, and advocating for dark sky preserves can help restore this lost connection to the universe."
    };

    private List<int> unlockedPages = new List<int>();
    private int currentIndex = 0;

    public void button1()
    {
        if (unlockedPages.Count == 0) 
        {
            return;
        }
        currentIndex++;
        if (currentIndex >= unlockedPages.Count) 
        {
            currentIndex = unlockedPages.Count - 1;
        }
        journalTextField.text = texts[unlockedPages[currentIndex]];
    }

    public void button2()
    {
        if (unlockedPages.Count == 0)
        {
            return;
        }
        currentIndex--;
         if (currentIndex < 0)
         {
            currentIndex = 0;
         }
         journalTextField.text = texts[unlockedPages[currentIndex]];
    }

    private void Start() 
    {
        //DEBUG: Reset all PlayerPrefs (for testing)
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
        unlockedPages.Clear();
        for (int i = 0; i < texts.Length; i++)
        {
            if (PlayerPrefs.GetInt("Page_" + i, 0) == 1)
            {
                unlockedPages.Add(i);
            }
        }
        if (unlockedPages.Count > 0)
        {
            currentIndex = 0;
            journalTextField.text = texts[unlockedPages[currentIndex]];
        }
        else
        {
            journalTextField.text = "No pages collected yet.";
        }
    }
}
