using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class ImageDropSlot: MonoBehaviour, IDropHandler
{
    ImageDragandDrop dragItem;
    public delegate void OnDropInSlotDelegate(GameObject draggedObject, GameObject dropObject, bool validation);
    public static OnDropInSlotDelegate onDropInSlot;
    bool validate = false;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDropCalled...." + eventData.pointerDrag);
        dragItem = eventData.pointerDrag.GetComponent<ImageDragandDrop>();

        onDropInSlot?.Invoke(eventData.pointerDrag, gameObject, validate);
    }

    public void ResetDropedObjectPosition()
    {
        dragItem.ReturnToOriginalPos();
    }
}



