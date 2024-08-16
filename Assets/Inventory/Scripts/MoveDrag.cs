using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveDrag : MonoBehaviour, IDragHandler,IEndDragHandler
{
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //originalPosition = rectTransform.anchoredPosition;
    }


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
}
