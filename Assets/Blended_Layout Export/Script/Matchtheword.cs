using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Matchtheword : MonoBehaviour
{
    public GameObject G_Select1, G_Select2;
    public GameObject[] Arrows;

    public bool click;
    public int count, match;
    //public AudioClip AC_correct;
    public AudioSource Wrong;

    // Start is called before the first frame update
    void Start()
    {
        click = true;
        for(int i=0;i<Arrows.Length;i++)
        {
            Arrows[i].SetActive(false);
        }
    }

    public void BUT_OnClicking()
    {
        //G_Select1.GetComponent<Outline>().enabled = false;
        //G_Select2.GetComponent<Outline>().enabled = false;
        if (click)
        {
            count++;
            if (count % 2 == 1)
            {
                G_Select1 = EventSystem.current.currentSelectedGameObject;
                G_Select1.GetComponent<Outline>().enabled = true;
               G_Select1.GetComponent<Button>().interactable = false;
            }
            if (count % 2 == 0)
            {
                G_Select2 = EventSystem.current.currentSelectedGameObject;
                G_Select2.GetComponent<Outline>().enabled = true;
                G_Select2.GetComponent<Button>().interactable = false;
                click = false;
                check();
            }
           
        }
    }
    public void check()
    {
        
        if (G_Select1.tag == G_Select2.tag)
        {
            match++;
            
            // Empty.clip = AC_correct;
            //Empty.Play();
            //correct audio
            if (G_Select1.tag == "1")
            {
                G_Select1.GetComponent<Button>().enabled = false;
                G_Select2.GetComponent<Button>().enabled = false;
                Arrows[0].SetActive(true);
            }
            if (G_Select1.tag == "2")
            {
                G_Select1.GetComponent<Button>().enabled = false;
                G_Select2.GetComponent<Button>().enabled = false;
                Arrows[1].SetActive(true);
            }
            if (G_Select1.tag == "3")
            {
                G_Select1.GetComponent<Button>().enabled = false;
                G_Select2.GetComponent<Button>().enabled = false;
                Arrows[2].SetActive(true);
            }
            if (G_Select1.tag == "4")
            {
                G_Select1.GetComponent<Button>().enabled = false;
                G_Select2.GetComponent<Button>().enabled = false;
                Arrows[3].SetActive(true);
            }
            if (G_Select1.tag == "5")
            {
                G_Select1.GetComponent<Button>().enabled = false;
                G_Select2.GetComponent<Button>().enabled = false;
                Arrows[4].SetActive(true);
            }

            G_Select1.GetComponent<Outline>().enabled = false;
            G_Select2.GetComponent<Outline>().enabled = false;
            click = true;
        }
        else
        {
            Wrong.Play();
           
            G_Select1.GetComponent<Outline>().enabled = false;
            G_Select2.GetComponent<Outline>().enabled = false;
            G_Select1.GetComponent<Button>().interactable = true;
            G_Select2.GetComponent<Button>().interactable = true;
            click = true;
            //wrong audio
        }
        // G_Select1 == null;
        // G_Select2 == null;
        if(match==5)
        {
            click = false;
        }
    }
}
