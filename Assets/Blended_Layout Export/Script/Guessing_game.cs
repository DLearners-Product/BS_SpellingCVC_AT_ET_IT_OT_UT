using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Guessing_game : MonoBehaviour
{
    public GameObject G_Selected;
    public GameObject[] GA_Questions;
    //public GameObject[] GA_Answers;
    public GameObject Blur;
    public GameObject[] GA_Blur_Names;
    public int count;
    public GameObject G_finalscreen;
    public GameObject G_Question;

    public AudioSource AS_Wrong;
    // Start is called before the first frame update
    void Start()
    {
        G_Question.SetActive(true);
        Blur.SetActive(false);
        G_finalscreen.SetActive(false);
        count = 0;
        for(int i=0;i<GA_Questions.Length;i++)
        {
            GA_Questions[i].SetActive(false);
         //   GA_Answers[i].SetActive(true);
        }
        GA_Questions[count].SetActive(true);
    }

  public void BUT_OnClicking()
  {
        G_Selected = EventSystem.current.currentSelectedGameObject;
        if (G_Selected.tag == "answer")
        {
            for (int i = 0; i < GA_Blur_Names.Length; i++)
            {
                GA_Blur_Names[i].SetActive(false);
            }

            if (G_Selected.name == "quit")
            {
                GA_Blur_Names[0].SetActive(true);
                G_Selected.SetActive(false);
                THI_OnBlur();
            }
            if (G_Selected.name == "quilt")
            {
                GA_Blur_Names[1].SetActive(true);
                G_Selected.SetActive(false);
                THI_OnBlur();
            }
            if (G_Selected.name == "quartet")
            {
                GA_Blur_Names[2].SetActive(true);
                G_Selected.SetActive(false);
                THI_OnBlur();
            }

            if (G_Selected.name == "quiz")
            {
                GA_Blur_Names[3].SetActive(true);
                G_Selected.SetActive(false);
                THI_OnBlur();
            }
            if (G_Selected.name == "queen")
            {
                GA_Blur_Names[4].SetActive(true);
                G_Selected.SetActive(false);
                THI_OnBlur();
            }
        }
        else
        {
            AS_Wrong.Play();
        }
       
  }
    public void THI_OnBlur()
    {
        count++;
        Blur.SetActive(true);
        Invoke("THI_OffBlur", 120f*Time.deltaTime);
    }
    public void THI_OffBlur()
    {
        Blur.SetActive(false);
        if (count <= 4)
        {
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            GA_Questions[count].SetActive(true);
        }
        if(count==5)
        {
            G_Question.SetActive(false);
            G_finalscreen.SetActive(true);
        }

    }
}
