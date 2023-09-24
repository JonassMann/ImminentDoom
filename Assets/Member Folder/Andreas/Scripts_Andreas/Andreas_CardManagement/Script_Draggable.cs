using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Script_Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum Type
    {
        Etos,
        Patos,
        Logos,
        Kairos
    }

    GameObject placeholder = null;

    public Type typeOfRhetorical = Type.Etos;

    [HideInInspector]
    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent; // Save the parent
        Debug.Log("OnBeginDrag");

        // Create a placeholder object and set the size to the same as the object we are dragging (so the layout doesn't change when we drag the object)
        placeholder = new GameObject(); // Create a placeholder object
        placeholder.transform.SetParent(this.transform.parent); // Set the placeholder parent to the parent of the object we are dragging
        LayoutElement le = placeholder.AddComponent<LayoutElement>(); // Add a layout element to the placeholder so it has the same size as the object we are dragging
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth; // Set the width to the width of the object we are dragging
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight; // Set the height to the height of the object we are dragging
        le.flexibleHeight = 0; // Set the flexible height to 0 so it doesn't mess up the layout
        le.flexibleWidth = 0; // Set the flexible width to 0 so it doesn't mess up the layout

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex()); // Set the placeholder to the same index as the object we are dragging (so it doesn't mess up the layout)

        parentToReturnTo = this.transform.parent; // Set the parent to the canvas
        placeholderParent = parentToReturnTo; // Set the placeholder parent to the parent of the object we are dragging

        this.transform.SetParent(this.transform.parent.parent); // Set the parent to the canvas

        GetComponent<CanvasGroup>().blocksRaycasts = false; // Make the object transparent for raycasts (so we can hit raycasts on other objects behind it)
    }

    public void OnDrag(PointerEventData eventData)
    {
       // Debug.Log("OnDrag");
        this.transform.position = eventData.position;

        if(placeholder.transform.parent != placeholderParent) // If the placeholder parent is not the same as the parent of the object we are dragging
        {
            placeholder.transform.SetParent(placeholderParent); // Set the placeholder parent to the parent of the object we are dragging
        }

        int newSiblingIndex = placeholderParent.childCount; // Set the new sibling index to the number of children in the parent

        for (int i = 0; i < placeholderParent.childCount; i++) // Loop through all the children of the parent
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x) // If the x position of the object we are dragging is less than the x position of the child we are checking
            {
                newSiblingIndex = i; // Set the new sibling index to the index of the child we are checking

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex) // If the placeholder index is less than the new sibling index
                {
                    newSiblingIndex--; // Decrease the new sibling index by 1
                }
                break; // Break out of the loop
            }
        }
        placeholder.transform.SetSiblingIndex(newSiblingIndex); // Set the placeholder index to the new sibling index
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        this.transform.SetParent(parentToReturnTo); // Set the parent back to the saved parent  
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex()); // Set the index back to the saved index
        GetComponent<CanvasGroup>().blocksRaycasts = true; // Make the object non transparent for raycasts (so we can hit raycasts on it again)

        Destroy(placeholder); // Destroy the placeholder object

        GetComponent<CanvasGroup>().blocksRaycasts = true; // Make the object non transparent for raycasts (so we can hit raycasts on it again)

    }
}
