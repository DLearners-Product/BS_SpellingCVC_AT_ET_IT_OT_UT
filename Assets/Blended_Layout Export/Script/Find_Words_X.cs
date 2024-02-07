using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Find_Words_X : MonoBehaviour
{
    public GameObject G_Selected;
    public GameObject G_Blur_Screen, G_Final_Screen;
    public GameObject[] GA_Blur_Names;
    public AudioSource AS_Wrong;
    public Material Greyscale;

    public GameObject GA_Circles;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        G_Blur_Screen.SetActive(false);
        G_Final_Screen.SetActive(false);
        for (int i = 0; i < GA_Blur_Names.Length; i++)
        {
            GA_Blur_Names[i].SetActive(false);
        }
    }

    public void BUT_Clicking()
    {
        G_Selected = EventSystem.current.currentSelectedGameObject;
        if(G_Selected.tag=="answer")
        {
            
            G_Selected.transform.GetChild(0).GetComponent<Image>().material = Greyscale;
            G_Selected.GetComponent<Button>().enabled = false;
            for(int i=0; i<GA_Blur_Names.Length;i++)
            {
                GA_Blur_Names[i].SetActive(false);
            }
            if (G_Selected.name=="box")
            {
                GA_Blur_Names[0].SetActive(true);
            }
            if (G_Selected.name == "xray")
            {
                GA_Blur_Names[1].SetActive(true);
            }
            if (G_Selected.name == "fox")
            {
                GA_Blur_Names[2].SetActive(true);
            }
            if (G_Selected.name == "fix")
            {
                GA_Blur_Names[3].SetActive(true);
            }
            if (G_Selected.name == "ox")
            {
                GA_Blur_Names[4].SetActive(true);
            }
            THI_OnBlur();
        }
        else
        {
            AS_Wrong.Play();
        }
    }
    public void THI_OnBlur()
    {
        count++;
        G_Blur_Screen.SetActive(true);
        G_Blur_Screen.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = G_Selected.transform.GetChild(0).GetComponent<Image>().sprite;
        G_Blur_Screen.transform.GetChild(0).gameObject.GetComponent<Animator>().runtimeAnimatorController = G_Selected.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController;
        Invoke("THI_OffBlur", 180f * Time.deltaTime);
    }
    public void THI_OffBlur()
    {
        G_Blur_Screen.SetActive(false);
        
        if(count==5)
        {
            GA_Circles.SetActive(false);
            G_Final_Screen.SetActive(true);
        }
    }
}
