using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Script_Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector]
    public Transform parentToReturnTo = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent; // Save the parent
        Debug.Log("OnBeginDrag");
        this.transform.SetParent(this.transform.parent.parent); // Set the parent to the canvas

        GetComponent<CanvasGroup>().blocksRaycasts = false; // Make the object transparent for raycasts (so we can hit raycasts on other objects behind it)
    }

    public void OnDrag(PointerEventData eventData)
    {
       // Debug.Log("OnDrag");
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        this.transform.SetParent(parentToReturnTo); // Set the parent back to the saved parent  

        GetComponent<CanvasGroup>().blocksRaycasts = true; // Make the object non transparent for raycasts (so we can hit raycasts on it again)
    }
}
