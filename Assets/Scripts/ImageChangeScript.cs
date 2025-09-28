using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChangeScript : MonoBehaviour
{
    public Image unclickedImage;
    public Image clickedImage;
    private bool isClicked = false;

    private void Start()
    {
        unclickedImage.gameObject.SetActive(!isClicked);
        clickedImage.gameObject.SetActive(isClicked);
    }

    public void OnButtonClick()
    {
        isClicked = !isClicked;
        unclickedImage.gameObject.SetActive(!isClicked);
        clickedImage.gameObject.SetActive(isClicked);
    }

}
