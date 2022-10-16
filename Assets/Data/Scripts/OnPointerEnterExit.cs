using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPointerEnterExit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void PointerEvent();
    public PointerEvent PointerEnterDelegate;
    public PointerEvent PointerExitDelegate;

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnterDelegate?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExitDelegate?.Invoke();
    }
}
