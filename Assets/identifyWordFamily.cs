using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class identifyWordFamily : MonoBehaviour
{
    public GameObject[] ObjectSprites;
    public AudioSource audioSource;
    public AudioClip oopsAudio;

    public GameObject buzzer;

    GameObject selectedGameObject;
    int count;

    string value;

    private void Start()
    {
        count = 0;
        DisplayImage();
    }

    public void Next()
    {
        if (count >= ObjectSprites.Length - 1)
        {
            count = 0;
        }
        else
        {
            count++;
        }

        DisplayImage();
    }

    public void Previous()
    {
        if (count <= 0)
        {
            count = ObjectSprites.Length;
        }

        count--;
        DisplayImage();
    }

    void DisplayImage()
    {
        for(int i=0;i< buzzer.transform.childCount; i++)
        {
            buzzer.transform.GetChild(i).GetComponent<Outline>().effectColor = new Color32(255, 255, 255, 255);
        }

        value = ObjectSprites[count].name[1].ToString() + ObjectSprites[count].name[2].ToString();

        for(int i=0; i< ObjectSprites.Length; i++)
        {
            ObjectSprites[i].SetActive(false);
        }
        ObjectSprites[count].SetActive(true);
    }

    public void checkAnswer()
    {
        selectedGameObject = EventSystem.current.currentSelectedGameObject;

        Debug.Log(selectedGameObject.name);
        selectedGameObject.GetComponent<Animator>().Play("button_press_anim");

        StartCoroutine(Answer(selectedGameObject));
    }
    IEnumerator Answer(GameObject selectedGameObject)
    {
        if (value == selectedGameObject.name)
        {
            Debug.Log("Correct Answer");

            selectedGameObject.GetComponent<Outline>().effectColor = new Color32(42, 255, 0, 255);

            PlayAudio();

        }
        else
        {
            audioSource.clip = oopsAudio;
            audioSource.Play();

            Debug.Log("Bad Answer");

            selectedGameObject.GetComponent<Outline>().effectColor = new Color32(255, 0, 0, 255);
            yield return new WaitForSeconds(.2f);
            selectedGameObject.GetComponent<Outline>().effectColor = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(.2f);
            selectedGameObject.GetComponent<Outline>().effectColor = new Color32(255, 0, 0, 255);
            yield return new WaitForSeconds(.2f);
            selectedGameObject.GetComponent<Outline>().effectColor = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(.2f);
            selectedGameObject.GetComponent<Outline>().effectColor = new Color32(255, 0, 0, 255);
            yield return new WaitForSeconds(.2f);
            selectedGameObject.GetComponent<Outline>().effectColor = new Color32(255, 255, 255, 255);
        }
    }

    public void PlayAudio()
    {
        audioSource.clip = ObjectSprites[count].GetComponent<AudioSource>().clip;
        audioSource.Play();
    }

}