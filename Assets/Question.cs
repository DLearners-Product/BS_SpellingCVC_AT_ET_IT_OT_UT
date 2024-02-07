using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    GameObject G_selectedObject; // selected object
    public GameObject[] GA_objects; // objects to drag
    Vector2[] VEC2_StartPos; // set the start pos
    bool B_canChangeObj; // select an object

    int optionCount;

    public AudioSource audioSource;
    public AudioClip audioClip;


    void Start()
    {
        /* Drag Script */

        B_canChangeObj = true;
        VEC2_StartPos = new Vector2[GA_objects.Length];
        for (int i = 0; i < VEC2_StartPos.Length; i++)
        {
            VEC2_StartPos[i] = GA_objects[i].transform.position;
        }
        /* Drag Script */


        optionCount = 0;

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                if (B_canChangeObj)
                {
                    G_selectedObject = hit.collider.gameObject;
                    B_canChangeObj = false;
                }
                G_selectedObject.transform.position = worldPoint;
                B_canChangeObj = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            B_canChangeObj = true;
            for (int i = 0; i < GA_objects.Length; i++)
            {
                if (G_selectedObject != null)
                {
                    if (G_selectedObject.name == GA_objects[i].name)
                    {
                        if (GA_objects[i].GetComponent<dragMe>().B_matched == false)
                        {
                            //G_selectedObject.transform.position = VEC2_StartPos[i];
                            GA_objects[i].transform.position = VEC2_StartPos[i];
                        }
                        else
                        {
                            //G_selectedObject.transform.position = VEC2_StartPos[i];
                            GA_objects[i].transform.position = VEC2_StartPos[i];
                            optionCount++;

                            GA_objects[i].GetComponent<dragMe>().unscramable_words_slide();
                            G_selectedObject.SetActive(false);
                            if (optionCount == GA_objects.Length)
                            {
                                StartCoroutine(operation_unscramble());
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator operation_unscramble()
    {
        audioSource.clip = audioClip;
        audioSource.Play();

        yield return new WaitForSeconds(audioClip.length);

        this.transform.parent.transform.parent.gameObject.GetComponent<unscramable_words>().NextQuestion();
        Debug.Log("Next Question");
    }
}