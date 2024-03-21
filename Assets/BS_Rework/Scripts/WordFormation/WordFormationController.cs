using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class WordFormationController : MonoBehaviour
{
    public GameObject[] letterSetsHolder;
    public AudioSource activitySource;
    public int letterSetChildIndex;
    [SerializeField] private GameObject transitionEffect;
    [SerializeField] private DotNavigation _dotnavigator;
    public GameObject G_final;

    private void Start() 
    {
        letterSetChildIndex = 0;
    }


   public IEnumerator LetterSetSwitchRoutine()
   {
        transitionEffect.SetActive(true);
        yield return new WaitForSeconds(2f);
        if(letterSetChildIndex < letterSetsHolder.Length-1)
        {
            letterSetsHolder[letterSetChildIndex].gameObject.SetActive(false);
            letterSetChildIndex++;
            transitionEffect.SetActive(false);
            letterSetsHolder[letterSetChildIndex].gameObject.SetActive(true);
            _dotnavigator.OnClickNextButton();
        }
        else
        {
            G_final.SetActive(true);
        }
        
   }


}
