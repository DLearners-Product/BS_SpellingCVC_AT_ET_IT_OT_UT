using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LetterFamilyActivity : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] questionClips;
    public AudioClip correctAnsAudClip;
    public AudioClip wrongAudClip;
    public GameObject answerParent, answerImageParent;
    public Sprite[] answerSprites;
    public GameObject answerImage;
    public TextMeshProUGUI counterText;
    public GameObject G_final;
    private int index,count;
    private int correct_count;
    private string wordFamilyName;
    private GameObject selectedGameObject;
    [SerializeField] private Animator ballAnimator, ballAnimator_1;

#region QA
    private int qIndex, q1Index;
    public GameObject questionGO;
    public GameObject[] optionsGO;
    public Dictionary<string, Component> additionalFields;
    Component question;
    Component[] options;
    Component[] answers;
#endregion


    private void Start() 
    {
        index = 0;
        count = 1;
        correct_count = 0;
        counterText.text = count + "/8";
        audioSource.clip = questionClips[index];
        answerParent.SetActive(false);
#region DataSetter
        Main_Blended.OBJ_main_blended.levelno = 7;
        QAManager.instance.UpdateActivityQuestion();
        qIndex = 0;
        q1Index = 0;
        GetData(qIndex);
        GetAdditionalData();
        AssignData();
#endregion
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
            // Debug.Log("correct answer");
            ScoreManager.instance.RightAnswer(q1Index, questionID: question.id, answerID: GetOptionID(selectedGameObject.name));
            q1Index++;
            answerParent.SetActive(false);
            ballAnimator.SetTrigger("correct_trigger");
            audioSource.clip = correctAnsAudClip;
            audioSource.Play();
            StartCoroutine(AnswerImageDisplayRoutine());
            correct_count++;
            Invoke("QuestionSwitch", 2.5f);
        }
        else
        {
            // Debug.Log("wrong answer");
            ScoreManager.instance.WrongAnswer(q1Index, questionID: question.id, answerID: GetOptionID(selectedGameObject.name));
            ballAnimator_1.SetTrigger("wrong_trigger");
            audioSource.clip = wrongAudClip;
            audioSource.Play();
        }
    }

    private IEnumerator AnswerImageDisplayRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        answerImageParent.SetActive(true);
        Debug.Log("this image index " + index);
        answerImage.GetComponent<Image>().sprite = answerSprites[index];
        yield return new WaitForSeconds(1.0f);
        answerImageParent.SetActive(false);
        yield return new WaitForSeconds(1.0f);
    }

    private void QuestionSwitch()
    {
         if(index >= questionClips.Length -1 && correct_count == 8)
        {
            FinalScreenShow();
        }
        else
        {
            index ++;
            count++;
            if(qIndex < questionClips.Length-1)
            {
                qIndex++;
                GetData(qIndex);
            }
            counterText.text = count + "/8";
            audioSource.clip = questionClips[index];
        }
    }

    private void FinalScreenShow()
    {
        
        G_final.SetActive(true);
        BlendedOperations.instance.NotifyActivityCompleted();
                
    }

#region QA
    int GetOptionID(string selectedOption)
    {
        for (int i = 0; i < options.Length; i++)
        {
            if (options[i].text == selectedOption)
            {
                return options[i].id;
            }
        }
        return -1;
    }


    bool CheckOptionIsAns(Component option)
    {
        for (int i = 0; i < answers.Length; i++)
        {
            if (option.text == answers[i].text) { return true; }
        }
        return false;
    }

    void GetData(int questionIndex)
    {
        //Debug.Log(">>>>>"+ qIndex);
        question = QAManager.instance.GetQuestionAt(0, questionIndex);
        //if(question != null){
        options = QAManager.instance.GetOption(0, questionIndex);
        answers = QAManager.instance.GetAnswer(0, questionIndex);
        // }
    }

    void GetAdditionalData()
    {
        additionalFields = QAManager.instance.GetAdditionalField(0);
    }

    void AssignData()
    {
        // Custom code
        for (int i = 0; i < optionsGO.Length; i++)
        {
            optionsGO[i].GetComponent<Image>().sprite = options[i]._sprite;
            optionsGO[i].tag = "Untagged";
            Debug.Log(optionsGO[i].name, optionsGO[i]);
            if (CheckOptionIsAns(options[i]))
            {
                optionsGO[i].tag = "answer";
            }
        }
        // answerCount.text = "/"+answers.Length;
    }
#endregion

}
