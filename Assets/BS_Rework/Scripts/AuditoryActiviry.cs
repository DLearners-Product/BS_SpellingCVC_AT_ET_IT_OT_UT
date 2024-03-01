using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuditoryActiviry : MonoBehaviour
{
    public GameObject[] questionTexts;
    public AudioSource auditoryAS;
    public AudioClip[] instructionClips;
    private int q_count;
    public Button SpeakerButton;
    public Button nextButton;
    public Button backButton;
    public GameObject G_final;

    private void Start() 
    {
        q_count = 0;
        auditoryAS.clip = instructionClips[q_count];
        questionTexts[q_count].SetActive(true);
    }

    public void OnSpeakerClick()
    {
        auditoryAS.clip = instructionClips[q_count];
        auditoryAS.Play();
    }

    public void NextButtonClick()
    {
        if(q_count >= instructionClips.Length -1)
        {
            G_final.SetActive(true);
        }
        else
        {
            q_count ++;
            auditoryAS.clip = instructionClips[q_count];
        }
    }

    public void BackButtonWork()
    {
        if(q_count <= 0)
        {
            q_count = 0;
            auditoryAS.clip = instructionClips[q_count];
        }
        else
        {
            q_count --;
            auditoryAS.clip = instructionClips[q_count];
        }
    }
    
}
