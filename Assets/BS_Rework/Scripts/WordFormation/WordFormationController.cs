using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WordFormationController : MonoBehaviour
{
    public GameObject[] letterSetsHolder;
    public AudioSource activitySource;
    private int letterSetChildIndex;

    private void Start() 
    {
        letterSetChildIndex = 0;
    }


   private void LetterSetSwitchFunction()
   {
        if(letterSetChildIndex < letterSetsHolder.Length -1)
        {
            letterSetsHolder[letterSetChildIndex].gameObject.SetActive(false);
            letterSetChildIndex ++;
            letterSetsHolder[letterSetChildIndex].gameObject.SetActive(true);
        }
   }


}
