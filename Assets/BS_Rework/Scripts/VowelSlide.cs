﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VowelSlide : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    private bool handShouldClose = false;
    private bool isHandOpen, isLetterappeared = false;
    [SerializeField] private List<GameObject> letterObjects;
    [SerializeField] private List<GameObject> vowelImages;
    [SerializeField] private List<string> letterDissapearAnimationTriggers;
    [SerializeField] private List<string> letterAppearAnimationTriggers;
    private int letterIndex, imageIndex, animationTriggersIndex;
    private Animator handAnimator;
    private GameObject selectedObject;
    [SerializeField] private GameObject imagePanel;
    private int displayedImageIndex = 0;
    [SerializeField] private AudioClip[] vowelObjectClips;
    [SerializeField] private AudioSource vowelActivitySource;
    [SerializeField] private GameObject G_finalPanel;     

    private void Start()
    {
        handAnimator = hand.GetComponent<Animator>();
        StartCoroutine(HandOpenRoutine());
    }

    void HandOpen()
    {
        if (!isHandOpen)
        {
            handAnimator.SetTrigger("Hand_Open");
        }
        else
        {
            // handAnimator.ResetTrigger("Hand_Close");
            handAnimator.ResetTrigger("Hand_Open");
        }
    }

    private IEnumerator HandOpenRoutine()
    {
        float delay = 0.25f;
        yield return new WaitForSeconds(1f);
        HandOpen();
        isHandOpen = true;
        handShouldClose = false;
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(LettersAppearAnimRoutine(delay));
    }
    void HandClose()
    {
        if (handShouldClose)
        {
            handAnimator.SetTrigger("Hand_Close");
        }
        else
        {
            handAnimator.ResetTrigger("Hand_Close");
        }
    }
    private IEnumerator HandCloseRoutine(float delay)
    {
        yield return new WaitForSeconds(delay + 1f);
        handShouldClose = true;
        isHandOpen = false;
        HandClose();
    }
    void LettersAppearAnimationFunct()
    {
        Animator currentLetterAnimator = letterObjects[letterIndex].GetComponent<Animator>();
        if (!isLetterappeared)
        {
            currentLetterAnimator.SetTrigger(letterAppearAnimationTriggers[animationTriggersIndex]);
            Debug.Log(letterAppearAnimationTriggers[animationTriggersIndex]);
            animationTriggersIndex++;
            letterIndex++;
        }
    }
    private IEnumerator LettersAppearAnimRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Letter Routine");
        while (!isLetterappeared && animationTriggersIndex < letterAppearAnimationTriggers.Count)
        {
            yield return new WaitForSeconds(0.15f);
            LettersAppearAnimationFunct();
        }
        letterIndex = 0;
        animationTriggersIndex = 0;
        Debug.Log("animation trigger Index : " + animationTriggersIndex);
        isLetterappeared = true;
    }
    void LetterDissappearAnimationFunct()
    {
        Animator currentLetterAnimator = letterObjects[letterIndex].GetComponent<Animator>();
        if (isLetterappeared)
        {
            currentLetterAnimator.SetTrigger(letterDissapearAnimationTriggers[animationTriggersIndex]);
            animationTriggersIndex++;
            letterIndex++;
        }
    }
    private IEnumerator LetterDissappearAnimRoutine(float delay)
    {
        yield return new WaitForSeconds (delay);
        Debug.Log("Letter Hide Routine");
        while (isLetterappeared && animationTriggersIndex < letterDissapearAnimationTriggers.Count)
        {
            yield return new WaitForSeconds(0.05f);
            LetterDissappearAnimationFunct();
        }
        letterIndex = 0;
        animationTriggersIndex = 0;
        isLetterappeared = false;
    }

    public void VowelImagesShowAndHideFunction(int index)
    {
        if (selectedObject != EventSystem.current.currentSelectedGameObject)
        {
            displayedImageIndex++;
            Debug.Log("display Index : " + displayedImageIndex);
        }
        StartCoroutine(VowelImagesAppearRoutine(index));
        selectedObject = EventSystem.current.currentSelectedGameObject;
    }

    private IEnumerator VowelImagesAppearRoutine(int index)
    {
        yield return new WaitForSeconds(0f);
        imageIndex = index;
        int clipIndex = imageIndex;
        if (displayedImageIndex <= vowelImages.Count)
        {      
            float handcloseDelay = 0.5f;
            float letterDissapearDelay = 0.5f;
            StartCoroutine(HandCloseRoutine(handcloseDelay));
            StartCoroutine(LetterDissappearAnimRoutine(letterDissapearDelay));
            yield return new WaitForSeconds(letterDissapearDelay + 1f);
            imagePanel.SetActive(true);
            vowelImages[imageIndex].SetActive(true);
            vowelActivitySource.clip = vowelObjectClips[clipIndex];
            vowelActivitySource.Play();
            yield return new WaitForSeconds(1.0f);
            StartCoroutine(VowelImagesDissapearRoutine(index));
            yield return new WaitForSeconds(2.0f);
            StartCoroutine(HandOpenRoutine());
        
        }
        if( displayedImageIndex == vowelImages.Count)
        {
           G_finalPanel.SetActive(true);
           float delay = 0f;
           StartCoroutine(LetterDissappearAnimRoutine(delay));
           yield break;
        }
    }

    private IEnumerator VowelImagesDissapearRoutine(int index)
    {
        yield return new WaitForSeconds (2f);
        vowelImages[imageIndex].SetActive(false);
        imagePanel.GetComponent<Animator>().SetTrigger("PanelTrigger");
        yield return new WaitForSeconds(1.0f);
        imagePanel.SetActive(false);
          
    }


}
