using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter_Intro : MonoBehaviour
{
    public GameObject[] answers;
    public int count;
    public GameObject G_Blur;
    // Start is called before the first frame update
    void Start()
    {
        G_Blur.SetActive(false);
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
        G_Blur.SetActive(true);
        answers[count].SetActive(true);
        Invoke("offblur", 180f * Time.deltaTime);
    }
    public void offblur()
    {
        G_Blur.SetActive(false);
    }
}
