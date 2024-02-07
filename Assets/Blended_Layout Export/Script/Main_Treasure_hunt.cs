using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main_Treasure_hunt : MonoBehaviour
{
    public GameObject[] G_blurnames;
    public GameObject G_Selectedobj;
    public GameObject G_blur_Screen;
    public GameObject G_Final_Screen;
    public Text score;
    public int count;
    public AudioSource AS_Wrong;

    void Start()
    {
        G_blur_Screen.SetActive(false);
        G_Final_Screen.SetActive(false);
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BUT_Clicking()
    {
        for(int i=0;i<G_blurnames.Length;i++)
        {
            G_blurnames[i].SetActive(false);
        }
        G_Selectedobj = EventSystem.current.currentSelectedGameObject;
        if(G_Selectedobj.tag=="answer")
        {
            G_Selectedobj.GetComponent<Button>().enabled = false;
            if (count <= 5)
            {
                if (G_Selectedobj.name == "iguana")
                {
                    count++;
                    G_blurnames[0].SetActive(true);
                    THI_Bluron();
                }
                if (G_Selectedobj.name == "quill")
                {
                    count++;
                    G_blurnames[1].SetActive(true);
                    THI_Bluron();
                }
                if (G_Selectedobj.name == "queen")
                {
                    count++;
                    G_blurnames[2].SetActive(true);
                    THI_Bluron();
                }
                if (G_Selectedobj.name == "inkpot")
                {
                    count++;
                    G_blurnames[3].SetActive(true);
                    THI_Bluron();
                }
                if (G_Selectedobj.name == "igloo")
                {
                    count++;
                    G_blurnames[4].SetActive(true);
                    THI_Bluron();
                }
                if (G_Selectedobj.name == "quiz")
                {
                    count++;
                    G_blurnames[5].SetActive(true);
                    THI_Bluron();
                }
            }
           
        }
        else
        {
            AS_Wrong.Play();
        }
    }
    public void THI_Bluron()
    {
        score.text = "" + count;
        G_blur_Screen.SetActive(true);
        Invoke("THI_Bluroff", 120f * Time.deltaTime);
    }
    public void THI_Bluroff()
    {
        G_blur_Screen.SetActive(false);
        if (count == 6)
        {
            G_Final_Screen.SetActive(true);
        }
    }
}
