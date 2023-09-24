using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Script_DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
        if (eventData.pointerDrag == null) // If we are not dragging anything, return
        {
            return;
        }
        Script_Draggable d = eventData.pointerDrag.GetComponent<Script_Draggable>();
        if (d != null)
        {
            d.placeholderParent = this.transform; // Set the parent to the drop zone
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        if (eventData.pointerDrag == null) // If we are not dragging anything, return
        {
            return;
        }
        Script_Draggable d = eventData.pointerDrag.GetComponent<Script_Draggable>();
        if (d != null && d.placeholderParent==this.transform)
        {
            d.placeholderParent = d.parentToReturnTo; // Set the parent to the placeholder parent   
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Script_Draggable d = eventData.pointerDrag.GetComponent<Script_Draggable>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform; // Set the parent to the drop zone
        }
    }
}
