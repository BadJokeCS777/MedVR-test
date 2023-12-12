using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArrowThrowButton : Graphic, IPointerClickHandler
{
    public event Action Clicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke();
    }
}