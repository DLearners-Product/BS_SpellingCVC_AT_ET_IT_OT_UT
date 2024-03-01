using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VowelSlide : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    private bool handShouldClose = false;
    private bool isHandOpen, isLetterappeared = false;
    [SerializeField] private List<GameObject> letterObjects;
    [SerializeField] private List<GameObject> vowelImages;
    [SerializeField] private List<string> letterDissapearAnimationTriggers;
    private int letterIndex, imageIndex, animationTriggersIndex;
    private Animator handAnimator;
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
            isHandOpen = false;
        }
    }

    private IEnumerator HandOpenRoutine()
    {
        yield return new WaitForSeconds(1f);
        HandOpen();
        isHandOpen = true;
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(LettersAppearAnimRoutine());
    }
    void HandClose()
    {
        if (handShouldClose)
        {
            handAnimator.SetTrigger("Hand_Close");

            handShouldClose = false;
        }
        else
        {
            handAnimator.ResetTrigger("Hand_Close");
            handAnimator.ResetTrigger("Hand_Open");
        }
    }
    private IEnumerator HandCloseRoutine(float delay)
    {
        yield return new WaitForSeconds(delay + 1f);
        handShouldClose = true;
        HandClose();
    }
    void LettersAppearAnimationFunct()
    {
        Animator currentLetterAnimator = letterObjects[letterIndex].GetComponent<Animator>();
        GameObject currentLetter = letterObjects[letterIndex].gameObject;
        if (!isLetterappeared)
        {
            if (letterIndex <= letterObjects.Count)
            {
                currentLetter.SetActive(true);
                letterIndex++;
                // Debug.Log("Letter index :" + letterIndex);
            }
        }
    }
    private IEnumerator LettersAppearAnimRoutine()
    {
        Debug.Log("Current letter index: " + letterIndex);
        while (!isLetterappeared && letterIndex < letterObjects.Count)
        {
            yield return new WaitForSeconds(0.15f);
            LettersAppearAnimationFunct();
        }
        letterIndex = 0;
        isLetterappeared = true;
    }
    void LetterDissappearAnimationFunct()
    {
        Animator currentLetterAnimator = letterObjects[letterIndex].GetComponent<Animator>();
        GameObject currentLetter = letterObjects[letterIndex].gameObject;
        if (isLetterappeared)
        {

            if (letterIndex <= letterObjects.Count)
            {
                currentLetterAnimator.SetTrigger(letterDissapearAnimationTriggers[animationTriggersIndex]);
                animationTriggersIndex++;
                letterIndex++;
            }
        }
    }
    private IEnumerator LetterDissappearAnimRoutine(float delay)
    {
        yield return new WaitForSeconds (delay);
        while (isLetterappeared && animationTriggersIndex < letterDissapearAnimationTriggers.Count)
        {
            yield return new WaitForSeconds(0.05f);
            LetterDissappearAnimationFunct();
        }
          letterIndex = 0;
          isLetterappeared = false;
    }

    public void VowelImagesShowAndHideFunction(int index)
    {
        StartCoroutine(VowelImagesAppearRoutine(index));
    }

    private IEnumerator VowelImagesAppearRoutine(int index)
    {
        yield return new WaitForSeconds(0f);
        imageIndex = index;
        int clipIndex = imageIndex;
        if (imageIndex < vowelImages.Count)
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
            yield return new WaitForSeconds(1f);
            StartCoroutine(VowelImagesDissapearRoutine(index));
            displayedImageIndex ++;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(HandOpenRoutine());
        }
        if( displayedImageIndex == 5)
        {
            float delay = 2f;
           StartCoroutine(LetterDissappearAnimRoutine(delay));
           StartCoroutine(HandCloseRoutine(delay));
           displayedImageIndex = 0;
           G_finalPanel.SetActive(true);
        }
    }

    private IEnumerator VowelImagesDissapearRoutine(int index)
    {
        yield return new WaitForSeconds (2f);
        vowelImages[imageIndex].SetActive(false);
        imagePanel.GetComponent<Animator>().SetTrigger("PanelTrigger");
        yield return new WaitForSeconds(1f);
        imagePanel.SetActive(false);
    }


}
