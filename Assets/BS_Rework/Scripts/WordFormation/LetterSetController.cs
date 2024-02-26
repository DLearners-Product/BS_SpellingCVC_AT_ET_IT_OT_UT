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
    [SerializeField] private List<AudioClip> middleAudioclips;
    [SerializeField] private GameObject transition;

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
    private IEnumerator SlotAndArrowSwapRoutine()
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
                lettercount = 0;
                StartCoroutine(CombineLettersAndReplaceRoutine());
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

    private IEnumerator CombineLettersRoutine()
    {
        yield return new WaitForSeconds(1.0f); // Adjust the delay as needed
        middleLetters[middleLettersIndex].SetActive(true);
        leftLetters[leftLettersIndex].SetActive(false);
        rightLetters[rightLettersIndex].SetActive(false);
        Debug.Log("middle letter display");
        leftSlot.SetActive(false);
        rightSlot.SetActive(false);
        leftLettersIndex++;
        rightLettersIndex++;
    }
    private IEnumerator ReplaceLettersRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        if (leftLettersIndex < leftLetters.Count && rightLettersIndex < rightLetters.Count)
        {
            middleLetters[middleLettersIndex].SetActive(false);
            yield return StartCoroutine(SlotAndArrowSwapRoutine());
            middleLettersIndex++;
            leftLetters[leftLettersIndex].SetActive(true);
            rightLetters[rightLettersIndex].SetActive(true);
        }
        else if (leftLettersIndex < leftLetters.Count)
        {
            leftLetters[leftLettersIndex].SetActive(true);
        }
        else if (rightLettersIndex < rightLetters.Count)
        {
            rightLetters[rightLettersIndex].SetActive(true);
        }
        else
        {
            middleLetters[middleLettersIndex].SetActive(true);
            yield break;
        }

        yield return StartCoroutine(ArrowAndSlotSwapRoutine());
    }
    private IEnumerator CombineLettersAndReplaceRoutine()
    {
        yield return StartCoroutine(CombineLettersRoutine());
        yield return StartCoroutine(ReplaceLettersRoutine());
    }


}