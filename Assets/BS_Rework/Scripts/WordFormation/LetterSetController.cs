using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterSetController : MonoBehaviour
{
    [SerializeField] private Image arrow;
    [SerializeField] private List<GameObject> leftLetters;
    [SerializeField] private List<GameObject> rightLetters;
    [SerializeField] private GameObject leftSlot;
    [SerializeField] private GameObject rightSlot;
    [SerializeField] private List<GameObject> middleLetters;
    [SerializeField] private AudioSource activityAS;
    [SerializeField] private AudioClip correctClip;
    [SerializeField] private AudioClip wrongClip;
    [SerializeField] private ParticleSystem slot_1;
    [SerializeField] private ParticleSystem slot_2;

    private int leftLettersIndex, rightLettersIndex, middleLettersIndex;
    private int lettercount = 0;

    private void Start()
    {
        middleLettersIndex = 0;
        leftLettersIndex = 0;
        rightLettersIndex = 0;
        arrow.gameObject.SetActive(true);
        StartCoroutine(ArrowAndSlotSwapRoutine());
    }

    private IEnumerator ArrowAndSlotSwapRoutine()
    {
        Debug.Log("Routine trigger");
        yield return new WaitForSeconds(1.5f);
        arrow.gameObject.SetActive(false);
        leftSlot.SetActive(true);
        rightSlot.SetActive(true);
    }
    private IEnumerator SlotArrowSwapRoutine()
    {
        yield return new WaitForSeconds(0f);
        arrow.gameObject.SetActive(true);
        leftSlot.SetActive(false);
        rightSlot.SetActive(false);    
    }

    private void OnEnable()
    {
        ImageDropSlot.onDropInSlot += LetterDrag;
    }

    private void OnDisable()
    {
        ImageDropSlot.onDropInSlot -= LetterDrag;
    }

    private void LetterDrag(GameObject drag, GameObject drop, bool validate)
    {
        if (drag.tag == drop.tag)
        {
            drag.transform.SetParent(drop.transform);
            drag.transform.position = drop.transform.position;
            drag.GetComponent<ImageDragandDrop>().resetPositionOnDrop = false;
            drag.GetComponent<ImageDragandDrop>().canDrag = false;

            if (drag.tag == "left")
            {
                slot_1.Play();
            }
            else if (drag.tag == "right")
            {
                slot_2.Play();
            }

            lettercount++;
            Debug.Log(lettercount);

            if (lettercount >= 2)
            {
                StartCoroutine(CombineLettersAndReplaceRoutine());
                lettercount = 0;
            }
        }
        else
        {
            LetterDragReset(drag);
        }
    }

    private void LetterDragReset(GameObject drag)
    {
        drag.GetComponent<ImageDragandDrop>().resetPositionOnDrop = true;
        drag.GetComponent<ImageDragandDrop>().canDrag = true;
    }

    private IEnumerator CombineLettersAndReplaceRoutine()
    {
        yield return new WaitForSeconds(1.0f); // Adjust the delay as needed
         middleLetters[middleLettersIndex].SetActive(true);
         Debug.Log("middle letter display");
         leftSlot.SetActive(false);
         rightSlot.SetActive(false);
        
        leftLetters[leftLettersIndex].SetActive(false);
    rightLetters[rightLettersIndex].SetActive(false);

    leftLettersIndex++;
    rightLettersIndex++;

    if (leftLettersIndex < leftLetters.Count && rightLettersIndex < rightLetters.Count)
    {
        middleLetters[middleLettersIndex].SetActive(false);
        StartCoroutine(SlotArrowSwapRoutine());
        middleLettersIndex++;
        leftLetters[leftLettersIndex].SetActive(true);
        rightLetters[rightLettersIndex].SetActive(true);
    }
    else if (leftLettersIndex < leftLetters.Count)
    {
        // Handle the case where there are more letters on the left but not on the right
        leftLetters[leftLettersIndex].SetActive(true);
    }
    else if (rightLettersIndex < rightLetters.Count)
    {
        // Handle the case where there are more letters on the right but not on the left
        rightLetters[rightLettersIndex].SetActive(true);
    }
    else
    {
        // All letters exhausted, handle end game or reset logic
    }

        yield return new WaitForSeconds(1.0f); // Adjust the delay before reactivating slots
        StartCoroutine(ArrowAndSlotSwapRoutine());
         


    }
}