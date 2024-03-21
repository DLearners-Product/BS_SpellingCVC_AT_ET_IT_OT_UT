using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro_cvc : MonoBehaviour
{
    public static intro_cvc OBJ_intro_cvc;
    public GameObject G_selectedObject; // selected object
    public GameObject[] GA_Objects, GA_Images; // objects to drag
    Vector2[] VEC2_StartPos; // set the start pos
    public GameObject G_final;
    private int count;

    public AudioSource audioSource;

    void Start()
    {
        OBJ_intro_cvc = this;
        count =  1;
    }

    public void THI_Dropping()
    {
        bool droppedSuccessfully = false;
        for (int i = 0; i<GA_Objects.Length; i++)
        {
            if(GA_Objects[i].activeSelf)
            {
                droppedSuccessfully = true;
                break;
            }
        }
        if (droppedSuccessfully)
        {
            count++;
        }
        for (int i = 0; i < GA_Objects.Length; i++)
        {
            GA_Objects[i].SetActive(false);
            if (GA_Objects[i].name==G_selectedObject.name)
            {
                GA_Objects[i].SetActive(true);
                Debug.Log(count);
            }

        }
        if(count == 5)
        {
            G_final.SetActive(true);
        }
    }

}