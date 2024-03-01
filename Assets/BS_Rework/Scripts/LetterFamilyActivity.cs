using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LetterFamilyActivity : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] questionClips;
    public AudioClip correctAnsAudClip;
    public AudioClip wrongAudClip;
    public GameObject answerParent, answerImageParent;
    public Sprite[] answerSprites;
    public GameObject answerImage;
    public Button nextButton;
    public Button backButton;
    public GameObject G_final;
    private int index;
    private string wordFamilyName;
    private GameObject selectedGameObject;
    [SerializeField] private Animator ballAnimator, ballAnimator_1;

    private void Start() 
    {
        index = 0;
        audioSource.clip = questionClips[index];
        answerParent.SetActive(false);
    }

    public void Next()
    {
        if(index >= questionClips.Length -1)
        {
            G_final.SetActive(true);
        }
        else
        {
            index ++;
            audioSource.clip = questionClips[index];
        }
    }
    public void Back()
    {
        if(index <= 0)
        {
            index = 0;
            audioSource.clip = questionClips[index];
        }
        else
        {
            index --;
            audioSource.clip = questionClips[index];
        }
    }
    public void QuestionAudioPlay()
    {
        audioSource.clip = questionClips[index];
        audioSource.Play();
        wordFamilyName = questionClips[index].name[1].ToString() + questionClips[index].name[2].ToString(); // getting the wordfamily name by getting and adding the last 2 chars of audiofiles together.
        answerParent.SetActive(true);
        Debug.Log("This name " + wordFamilyName);
    }

    public void CheckAnswer()
    {
        selectedGameObject = EventSystem.current.currentSelectedGameObject;
        Debug.Log(selectedGameObject.name);
        if(wordFamilyName == selectedGameObject.name)
        {
            Debug.Log("correct answer");
            answerParent.SetActive(false);
            ballAnimator.SetTrigger("correct_trigger");
            audioSource.clip = correctAnsAudClip;
            audioSource.Play();
            StartCoroutine(AnswerImageDisplayRoutine());
        }
        else
        {
            Debug.Log("wrong answer");
            ballAnimator_1.SetTrigger("wrong_trigger");
            audioSource.clip = wrongAudClip;
            audioSource.Play();
        }
    }

    private IEnumerator AnswerImageDisplayRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        answerImageParent.SetActive(true);
        answerImage.GetComponent<Image>().sprite = answerSprites[index];
        yield return new WaitForSeconds(1.0f);
        answerImageParent.SetActive(false);
    }

}
