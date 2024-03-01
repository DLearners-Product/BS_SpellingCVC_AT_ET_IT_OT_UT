using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro_cvc : MonoBehaviour
{
    public static intro_cvc OBJ_intro_cvc;
    public GameObject G_selectedObject; // selected object
    public GameObject[] GA_Objects, GA_Images; // objects to drag
    Vector2[] VEC2_StartPos; // set the start pos

    public AudioSource audioSource;

    void Start()
    {
        OBJ_intro_cvc = this;
    }

    public void THI_Dropping()
    {
        for (int i = 0; i < GA_Objects.Length; i++)
        {
            GA_Objects[i].SetActive(false);
            // GA_Images[i].SetActive(false);
            if (GA_Objects[i].name==G_selectedObject.name)
            {
                GA_Objects[i].SetActive(true);
                // GA_Images[i].SetActive(true);
            }
        }
    }

}