using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main_Odd_Ones : MonoBehaviour
{
    public GameObject[] GA_Questions;
    public GameObject G_selected, G_final_screen,G_blur;
    public Animator Anim_boy;
    public AnimationClip AC_blow,AC_brust;
    public GameObject G_boy;
    public GameObject[] G_Blur_Images;

    public AudioSource wrong;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        G_blur.SetActive(false);
        G_boy.SetActive(true);
        G_final_screen.SetActive(false);
        count = -1;
        Anim_boy.Play("blow bubble");
        for(int i=0;i<GA_Questions.Length;i++)
        {
            GA_Questions[i].SetActive(false);
        }
        Invoke("changequestion", AC_blow.length);
    }

    public void onclicking()
    {
        G_selected = EventSystem.current.currentSelectedGameObject;
        if (G_selected.tag == "answer")
        {
            Anim_boy.Play("burst bubble");
            GA_Questions[count].SetActive(false);
            Invoke("onblur", AC_brust.length);
        }
        else
        {
            wrong.Play();
        }
    }

    public void onblur()
    {
        //G_boy.SetActive(false);
        G_blur.SetActive(true);
        for(int i=0;i<G_Blur_Images.Length;i++)
        {
            G_Blur_Images[i].SetActive(false);
        }
        G_Blur_Images[count].SetActive(true);
       // G_blur.transform.GetChild(0).GetComponent<Image>().sprite = G_selected.GetComponent<Image>().sprite;
       // G_blur.transform.GetChild(0).gameObject.GetComponent<Animator>().runtimeAnimatorController = G_selected.GetComponent<Animator>().runtimeAnimatorController;
        Invoke("offquestion", 100f * Time.deltaTime);
    }
    public void offquestion()
    {
        G_blur.SetActive(false);
        //G_boy.SetActive(true);
       if(count<4)
       {
            Anim_boy.Play("blow bubble");
            Invoke("changequestion", AC_blow.length);
       }
        
        if (count == 4)
        {

            G_boy.SetActive(false);
            G_final_screen.SetActive(true);
        }
    }
    public void changequestion()
    {
        if (count < 4)
        {
            count++;
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            GA_Questions[count].SetActive(true);
        }
        
    }
}
