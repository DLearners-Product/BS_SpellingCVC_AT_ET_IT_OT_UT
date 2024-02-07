using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begining_sound_intro : MonoBehaviour
{
    public GameObject[] answers;
    public int count;
    public AnimationClip AC_Page;
    public GameObject paper;
    // Start is called before the first frame update
    void Start()
    {
        paper.SetActive(false);
        count = 0;
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].SetActive(false);
        }
        answers[count].SetActive(true);
    }

    // Update is called once per frame
    public void selectobject(int number)
    {
        count = number;
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].SetActive(false);
        }
        paper.SetActive(true);
        paper.GetComponent<Animator>().Play("turnpaper");
        Invoke("changeanswer", AC_Page.length);
        
    }
    public void changeanswer()
    {
        paper.SetActive(false);
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].SetActive(false);
        }
        answers[count].SetActive(true);
    }
}
