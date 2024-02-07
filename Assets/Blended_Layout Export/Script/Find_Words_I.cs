using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Find_Words_I : MonoBehaviour
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
            G_Selected.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            G_Selected.GetComponent<Button>().enabled = false;
            for(int i=0; i<GA_Blur_Names.Length;i++)
            {
                GA_Blur_Names[i].SetActive(false);
            }
            if (G_Selected.name=="igloo")
            {
                GA_Blur_Names[0].SetActive(true);
            }
            if (G_Selected.name == "insect")
            {
                GA_Blur_Names[1].SetActive(true);
            }
            if (G_Selected.name == "inkpot")
            {
                GA_Blur_Names[2].SetActive(true);
            }
            if (G_Selected.name == "in")
            {
                GA_Blur_Names[3].SetActive(true);
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
        Invoke(nameof(THI_OffBlur), 180f * Time.deltaTime);
    }
    public void THI_OffBlur()
    {
        G_Blur_Screen.SetActive(false);
        
        if(count==4)
        {
            GA_Circles.SetActive(false);
            G_Final_Screen.SetActive(true);
        }
    }
}
