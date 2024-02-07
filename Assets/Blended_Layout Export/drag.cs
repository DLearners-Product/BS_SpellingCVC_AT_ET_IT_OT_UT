using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector2 mousePos;
    public Vector2 initalPos;
    public bool B_matched;
    bool isdrag;
    GameObject otherGameObject;
    
    Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Start()
    {
        initalPos = this.transform.position;
    }


    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePos;
        //Debug.Log("Drag");
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {

       // Debug.Log("End Drag "+ otherGameObject.name);
        if(otherGameObject!=null)
        {
            if (this.transform.parent.gameObject.name == "vowels")
            {
                if (otherGameObject.name == "Pos")
                {
                    intro_cvc.OBJ_intro_cvc.G_selectedObject = this.gameObject;

                    intro_cvc.OBJ_intro_cvc.THI_Dropping();

                    otherGameObject = null;
                    this.transform.position = initalPos;
                }
            }

           
        }
        else
        {
            this.transform.position = initalPos;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Pos")
            otherGameObject = other.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Pos")
            otherGameObject = null; 
    }

   /* private void OnTriggerExit2D(Collider2D other)
    {
        if (this.transform.parent.gameObject.name == "vowels")
        {
            if (other.gameObject.name == "Pos")
            {
                B_matched = false;
                otherGameObject = null;
            }
        }

        if (this.transform.parent.gameObject.transform.parent.gameObject.name == "Words")
        {
            if (this.gameObject.name == other.gameObject.tag)
            {
                B_matched = false;
                otherGameObject = null;
            }
        }

        if (this.transform.parent.gameObject.name == "Options")
        {
            if (this.gameObject.name == other.gameObject.tag)
            {
                B_matched = false;
                otherGameObject = null;
            }
        }
    }*/

}
