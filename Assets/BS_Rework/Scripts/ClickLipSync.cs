using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClickLipSync : MonoBehaviour, IPointerDownHandler
{
    public AudioSource audioSource;
    public AudioClip clip;

    public Animator Juice_mouth;

    public string triggerWord;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(Juice_mouth.GetComponentInChildren<Animator>().name);
        Juice_mouth.GetComponentInChildren<Animator>().SetTrigger(triggerWord);
        audioSource.clip = clip;
        audioSource.Play();
    }
}
