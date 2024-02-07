using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class J_Main_Form_CVC : MonoBehaviour
{
    public GameObject[] GA_options;
    public GameObject[] GA_Dashes;
    public GameObject[] GA_Letters;
    public GameObject G_circle;
    public GameObject[] G_Blur_names;

    public int I_opt_count,I_letter_count;
    public GameObject G_selected, G_final_screen, G_blur;
    public AudioSource AS_wrong;

   // public Animator ANIM_empty;
    // Start is called before the first frame update
    void Start()
    {
        G_circle.SetActive(true);
        G_blur.SetActive(false);
        G_final_screen.SetActive(false);
        I_opt_count = 0;
        I_letter_count = 0;
        for(int i=0;i<GA_options.Length;i++)
        {
            GA_options[i].SetActive(false);
        }
        GA_options[I_opt_count].SetActive(true);
        for (int i = 0; i < GA_Dashes.Length; i++)
        {
            GA_Letters[i].SetActive(false);
            GA_Dashes[i].SetActive(true);
            G_Blur_names[i].SetActive(false);
        }
    }

   public void onclicking()
   {
        G_selected = EventSystem.current.currentSelectedGameObject;
        if(G_selected.tag=="answer")
        {
            G_selected.GetComponent<Button>().enabled = false;
            for (int i = 0; i < GA_Dashes.Length; i++)
            {
                G_Blur_names[i].SetActive(false);
            }
            if (G_selected.name == "jelly")
            {
                I_letter_count++;
                GA_Dashes[0].SetActive(false);
                GA_Letters[0].SetActive(true);
                G_Blur_names[0].SetActive(true);
                onblur();
            }
            if (G_selected.name=="jet")
            {
                I_letter_count++;
                GA_Dashes[1].SetActive(false);
                GA_Letters[1].SetActive(true);
                G_Blur_names[1].SetActive(true);
                onblur();
            }
            if (G_selected.name == "jog")
            {
                I_letter_count++;
                GA_Dashes[2].SetActive(false);
                GA_Letters[2].SetActive(true);
                G_Blur_names[2].SetActive(true);
                onblur();
            }
            if (G_selected.name == "junk food")
            {
                I_letter_count++;
                GA_Dashes[3].SetActive(false);
                GA_Letters[3].SetActive(true);
                G_Blur_names[3].SetActive(true);
                onblur();
            }
            if (G_selected.name == "jump")
            {
                I_letter_count++;
                GA_Dashes[4].SetActive(false);
                GA_Letters[4].SetActive(true);
                G_Blur_names[4].SetActive(true);
                onblur();
            }
        }
        else
        {
            AS_wrong.Play();
        }
   }

    public void onblur()
    {
        G_blur.SetActive(true);
        G_blur.transform.GetChild(0).GetComponent<Image>().sprite = G_selected.GetComponent<Image>().sprite;
        // ANIM_empty = G_selected.GetComponent<Animator>();
       
        G_blur.transform.GetChild(0).gameObject.GetComponent<Animator>().runtimeAnimatorController = G_selected.GetComponent<Animator>().runtimeAnimatorController;
        Invoke("offblur", 120f*Time.deltaTime);
    }

    public void offblur()
    {
        G_blur.SetActive(false);
        if (I_letter_count < 5)
        {
            if (I_letter_count  == 2 )
            {
                Invoke("changeoption", 30f * Time.deltaTime);
            }
            if (I_letter_count == 3)
            {
                Invoke("changeoption", 30f * Time.deltaTime);
            }
        }
        if (I_letter_count == 5)
        {
            for (int i = 0; i < GA_options.Length; i++)
            {
                GA_options[i].SetActive(false);
            }
            G_circle.SetActive(false);
            G_final_screen.SetActive(true);
        }
    }
    public void changeoption()
    {
        if (I_letter_count < 5)
        {
            I_opt_count++;
            for (int i = 0; i < GA_options.Length; i++)
            {
                GA_options[i].SetActive(false);
            }
            GA_options[I_opt_count].SetActive(true);
        }
    }

}
