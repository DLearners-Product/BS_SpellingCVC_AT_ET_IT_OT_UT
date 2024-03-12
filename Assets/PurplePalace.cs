using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PurplePalace : MonoBehaviour
{
    public GameObject[] AllSlots;

    public GameObject selectedGameobject_1, selectedGameobject_2;

    public string selectedSlotName;

    public int selectionCount;

    public AnimationClip slot_close_anim, slot_open_anim, intro_anim;

    public AudioSource audioSource;
    public AudioClip oopsAudio;
    public AudioClip slotfiip;
    public AudioClip flipaudio;

    int correctAnswerCount;

    private void Start()
    {
        correctAnswerCount = 0;

        selectionCount = 1 ;
        for (int i = 0; i < AllSlots.Length; i++)
        {
            AllSlots[i].SetActive(false);
            AllSlots[i].GetComponent<Button>().enabled = false;
            AllSlots[i].GetComponent<ClickAudio>().enabled = false;
        }
        StartCoroutine(ShowSlots());
    }

    IEnumerator ShowSlots()
    {
        yield return new WaitForSeconds(intro_anim.length);

        for (int i = 0; i < AllSlots.Length; i++)
        {
            AllSlots[i].SetActive(true);
            AllSlots[i].GetComponent<Button>().enabled = false;
            AllSlots[i].GetComponent<Animator>().Play("purple_slot_anim");
        }

        yield return new WaitForSeconds(5f);
        for (int i = 0; i < AllSlots.Length; i++)
        {
            AllSlots[i].SetActive(true);
            audioSource.PlayOneShot(slotfiip);
            AllSlots[i].GetComponent<Animator>().Play("purple_slot_close_anim");
            yield return new WaitForSeconds(.19f);
        }
        for (int i = 0; i < AllSlots.Length; i++)
        {
            AllSlots[i].GetComponent<Button>().enabled = true;
        }
    }

    public void clickMe()
    {
        audioSource.PlayOneShot(flipaudio);

        //selectionCount++;
        if (selectionCount == 1)
        {
            selectedGameobject_1 = EventSystem.current.currentSelectedGameObject;
            selectedGameobject_1.GetComponent<Button>().enabled = false;
            selectedGameobject_1.GetComponent<Animator>().Play("purple_slot_anim");

            selectionCount++;
        }
        else if (selectionCount == 2)
        {

            selectedGameobject_2 = EventSystem.current.currentSelectedGameObject;
            selectedGameobject_2.GetComponent<Button>().enabled = false;
            selectedGameobject_2.GetComponent<Animator>().Play("purple_slot_anim");
            StartCoroutine(CheckAnswer());

        }
    }

    IEnumerator CheckAnswer()
    {
        for (int i = 0; i < AllSlots.Length; i++)
        {
            AllSlots[i].GetComponent<Button>().enabled = false;
        }

        if (selectedGameobject_1.tag == selectedGameobject_2.tag)
        {
            audioSource.PlayOneShot(selectedGameobject_1.GetComponent<AudioSource>().clip);

            Debug.Log("Found match");

            yield return new WaitForSeconds(slot_open_anim.length + .5f);

            selectedGameobject_1.transform.Find("piece").GetComponent<Image>().color = new Color32(124, 255, 0, 255);
            selectedGameobject_2.transform.Find("piece").GetComponent<Image>().color = new Color32(124, 255, 0, 255);

            yield return new WaitForSeconds(0.5f);

            selectedGameobject_1.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            selectedGameobject_2.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            yield return new WaitForSeconds(0.5f);

            selectedGameobject_1.transform.Find("piece").GetComponent<Image>().color = new Color32(124, 255, 0, 255);
            selectedGameobject_2.transform.Find("piece").GetComponent<Image>().color = new Color32(124, 255, 0, 255);

            yield return new WaitForSeconds(0.5f);

            selectedGameobject_1.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            selectedGameobject_2.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            yield return new WaitForSeconds(0.5f);

            selectedGameobject_1.transform.Find("piece").GetComponent<Image>().color = new Color32(124, 255, 0, 255);
            selectedGameobject_2.transform.Find("piece").GetComponent<Image>().color = new Color32(124, 255, 0, 255);

            yield return new WaitForSeconds(0.5f);

            selectedGameobject_1.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            selectedGameobject_2.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            yield return new WaitForSeconds(0.5f);
            selectedGameobject_1.GetComponent<Button>().interactable = false;
            selectedGameobject_2.GetComponent<Button>().interactable = false;


            for (int i = 0; i < AllSlots.Length; i++)
            {
                AllSlots[i].GetComponent<Button>().enabled = true;
            }


            if (correctAnswerCount == 5)
            {
                Debug.Log("Game Over");
                for (int i = 0; i < AllSlots.Length; i++)
                {
                    AllSlots[i].SetActive(true);
                    AllSlots[i].tag = "Untagged";
                    AllSlots[i].GetComponent<ClickAudio>().enabled = true;
                    AllSlots[i].GetComponent<Button>().enabled = false;
                    AllSlots[i].GetComponent<Animator>().Play("purple_slot_anim");
                }
            }
            else
            {
                correctAnswerCount++;
            }
        }
        else
        {
            yield return new WaitForSeconds(.1f);
            audioSource.PlayOneShot(oopsAudio);

            Debug.Log("Wrong answer");

            yield return new WaitForSeconds(slot_open_anim.length + .5f);

            selectedGameobject_1.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            selectedGameobject_2.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 0, 0, 255);

            yield return new WaitForSeconds(0.5f);

            selectedGameobject_1.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            selectedGameobject_2.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            yield return new WaitForSeconds(0.5f);

            selectedGameobject_1.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            selectedGameobject_2.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 0, 0, 255);

            yield return new WaitForSeconds(0.5f);

            selectedGameobject_1.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            selectedGameobject_2.transform.Find("piece").GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            yield return new WaitForSeconds(0.5f);

            selectedGameobject_1.GetComponent<Animator>().Play("purple_slot_close_anim");
            selectedGameobject_2.GetComponent<Animator>().Play("purple_slot_close_anim");

            yield return new WaitForSeconds(slot_close_anim.length);

            for (int i = 0; i < AllSlots.Length; i++)
            {
                AllSlots[i].GetComponent<Button>().enabled = true;
            }

        }

        selectionCount = 1;
    }
}