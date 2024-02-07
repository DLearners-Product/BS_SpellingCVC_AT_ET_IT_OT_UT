using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unscramable_words : MonoBehaviour
{
    public GameObject[] Questions;
    public GameObject Finalscreen;

    public AudioSource audioSource;


    int questionCount;

    private void Start()
    {
        Finalscreen.SetActive(false);
        questionCount = 0;
        NextQuestion();

    }

    public void NextQuestion()
    {
        for (int i = 0; i < Questions.Length; i++)
        {
            Questions[i].SetActive(false);
        }

        if(questionCount == Questions.Length)
        {
            Finalscreen.transform.parent.Find("Next").gameObject.SetActive(false);
            Finalscreen.transform.parent.Find("Speaker").gameObject.SetActive(false);
            Finalscreen.SetActive(true);
        }
        else
        {
            Questions[questionCount].SetActive(true);
            questionCount++;
        }
    }

    public void PlayAudio()
    {
        audioSource.clip = Questions[questionCount - 1].GetComponent<Question>().audioClip;
        audioSource.Play();
    }

}