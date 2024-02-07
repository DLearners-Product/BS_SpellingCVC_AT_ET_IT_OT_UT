using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragMe : MonoBehaviour
{
    public bool B_matched;
    public AudioSource audioSource;
    GameObject otherGameObject;
    private void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (this.transform.parent.gameObject.name == "vowels")
        {
            if (other.gameObject.name == "Pos")
            {
                B_matched = true;
                otherGameObject = other.gameObject;
            }
        }

        if (this.transform.parent.gameObject.transform.parent.gameObject.name == "Words")
        {
            if (this.gameObject.name == other.gameObject.tag)
            {
                B_matched = true;
                otherGameObject = other.gameObject;
            }
        }

        if (this.transform.parent.gameObject.name == "Options")
        {
            if (this.gameObject.name == other.gameObject.tag)
            {
                B_matched = true;
                otherGameObject = other.gameObject;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (this.transform.parent.gameObject.name == "vowels")
        {
            if (other.gameObject.name == "Pos")
            {
                B_matched = false;
                otherGameObject = null;
            }
        }

        if (this.transform.parent.gameObject.transform.parent.gameObject.name == "Words")
        {
            if (this.gameObject.name == other.gameObject.tag)
            {
                B_matched = false;
                otherGameObject = null;
            }
        }

            if (this.transform.parent.gameObject.name == "Options")
        {
            if (this.gameObject.name == other.gameObject.tag)
            {
                B_matched = false;
                otherGameObject = null;
            }
        }
    }

    public void unscramable_words_slide()
    {
        if (otherGameObject != null)
        {
            Debug.Log("other gameobject" + otherGameObject);
            otherGameObject.GetComponent<Image>().enabled = true;
        }
    }

    public void displayVowels()
    {
        if (otherGameObject != null)
        {
            for(int i=0; i< otherGameObject.transform.childCount; i++)
            {
                otherGameObject.transform.GetChild(i).gameObject.SetActive(false);
            }

            audioSource.clip = otherGameObject.transform.Find(this.gameObject.name).GetComponent<AudioSource>().clip;
            audioSource.Play();

            otherGameObject.transform.Find(this.gameObject.name).gameObject.SetActive(true);

            for (int i = 0; i < otherGameObject.transform.childCount; i++)
            {
                otherGameObject.transform.parent.Find("Images").gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }

            for (int i = 0; i < otherGameObject.transform.childCount; i++)
            {
                if(otherGameObject.transform.parent.Find("Images").gameObject.transform.GetChild(i).tag == this.gameObject.name)
                {
                    otherGameObject.transform.parent.Find("Images").gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }

    public void wordPuzzle()
    {
        Debug.Log("Correct Answer");
    }
}