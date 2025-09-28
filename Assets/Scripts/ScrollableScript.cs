using UnityEngine;
using UnityEngine.UI;

public class ScrolllableScript : MonoBehaviour
{
    public RectTransform content;
    public float minScrollX;
    public float maxScrollX;

    private ScrollRect scrollRect;

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    private void Update()
    {
        float clampedX = Mathf.Clamp(content.anchoredPosition.x, minScrollX, maxScrollX);
        content.anchoredPosition = new Vector2(clampedX, content.anchoredPosition.y);
    }
}