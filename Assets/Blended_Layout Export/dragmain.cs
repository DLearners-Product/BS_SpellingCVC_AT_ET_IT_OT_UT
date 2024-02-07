using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dragmain : MonoBehaviour
{
    public static dragmain OBJ_dragmain;
    public GameObject[] GA_Questions;
    public int I_Qcount,I_Count;
    public GameObject  G_final;
    public AudioSource AS_crt, AS_wrg;

   
    public void Start()
    {
        OBJ_dragmain = this;
        I_Qcount = 0;
        G_final.SetActive(false);
        THI_ShowQuestion();
    }
   
    void THI_ShowQuestion()
    {
       
        for (int i=0;i<GA_Questions.Length;i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[I_Qcount].SetActive(true);
        I_Count = GA_Questions[I_Qcount].transform.GetChild(0).transform.childCount;
        GA_Questions[I_Qcount].transform.GetChild(2).gameObject.SetActive(false);
    }
    public void THI_Correct()
    {
        I_Count--;
        if(I_Count==0)
        {
            GA_Questions[I_Qcount].transform.GetChild(0).gameObject.SetActive(false);
            GA_Questions[I_Qcount].transform.GetChild(1).gameObject.SetActive(false);
            GA_Questions[I_Qcount].transform.GetChild(2).gameObject.SetActive(true);
        }
        AS_crt.Play();
    }
    
    public void THI_wrg()
    {
        AS_wrg.Play();
    }
    
   public void BUT_Next()
    {
        if(I_Qcount<GA_Questions.Length-1)
        {
            I_Qcount++;
            THI_ShowQuestion();
        }
        else
        {
            G_final.SetActive(true);
        }
    }
   

    
}
