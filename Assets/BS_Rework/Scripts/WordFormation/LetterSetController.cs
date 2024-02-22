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
    // [SerializeField] private AudioClip[] fullLetterClips;
    // [SerializeField] private AudioClip combinedLetterClip;
    private int leftLettersIndex,rightLettersIndex, middleLettersIndex;
    private int letterindex;
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
        yield return new WaitForSeconds(1f);
        arrow.gameObject.SetActive(false);
        leftSlot.SetActive(true);
        rightSlot.SetActive(true);
    }

    private void OnEnable()
    {
        ImageDropSlot.onDropInSlot += LetterDrag;
    }

    private void OnDisable()
    {
        ImageDropSlot.onDropInSlot -= LetterDrag;
    }

    private  void LetterDrag(GameObject drag, GameObject drop, bool validate)
    {
        if (drag.tag == drop.tag)
        {
            // Debug.Log("Correct Answer");
            drag.transform.SetParent(drop.transform);
            drag.transform.position = drop.transform.position;
            drag.GetComponent<ImageDragandDrop>().resetPositionOnDrop = false;
            drag.GetComponent<ImageDragandDrop>().canDrag = false;
            lettercount++;
            Debug.Log(lettercount);
            if(lettercount == 2)
            {
                Debug.Log("LetterDropped");
                leftSlot.SetActive(false);
                rightSlot.SetActive(false);
                Invoke("MiddleletterDisplay", 1f);
            }
        }
        else
        {
            // Debug.Log("Wrong Answer");
            LetterDragReset(drag);
        }
    }

    private void LetterDragReset(GameObject drag)
    {
        drag.GetComponent<ImageDragandDrop>().resetPositionOnDrop = true;
        drag.GetComponent<ImageDragandDrop>().canDrag = true;
    }

    private void MiddleletterDisplay()
    {
        if(middleLettersIndex < middleLetters.Count)
        {
            middleLetters[middleLettersIndex].SetActive(true);
            middleLettersIndex++;
        }
    }


}
