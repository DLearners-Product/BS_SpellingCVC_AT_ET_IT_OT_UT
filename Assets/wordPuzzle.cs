using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wordPuzzle : MonoBehaviour
{
    Camera thisCamera;
    public GameObject[] AnswerSprites;
    public Sprite[] matchingImage;
    public GameObject OptionImage;
    int count;
    string value;

    public GameObject G_selectedObject; // selected object
    public GameObject[] GA_objects; // objects to drag
    Vector2[] VEC2_StartPos; // set the start pos
    bool B_canChangeObj; // select an object

    public AudioSource audioSource;
    private void Awake()
    {
        thisCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Start()
    {
        B_canChangeObj = true;
        VEC2_StartPos = new Vector2[GA_objects.Length];
        for (int i = 0; i < VEC2_StartPos.Length; i++)
        {
            VEC2_StartPos[i] = GA_objects[i].transform.position;
        }

        DisplayImage();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 worldPoint = thisCamera.ScreenToWorldPoint(Input.mousePosition);
            //RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity);
           /* if (hit.collider != null)
            {
                if (B_canChangeObj)
                {
                    G_selectedObject = hit.collider.gameObject;
                    B_canChangeObj = false;
                }
                G_selectedObject.transform.position = worldPoint;
                B_canChangeObj = false;
            }   */

            if(Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity))
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
            if (G_selectedObject != null)
            {
                B_canChangeObj = true;
                for (int i = 0; i < GA_objects.Length; i++)
                {
                    if (G_selectedObject.name == GA_objects[i].name)
                    {
                        if (GA_objects[i].GetComponent<dragMe>().B_matched == false)
                        {
                            G_selectedObject.transform.position = VEC2_StartPos[i];
                        }
                        else
                        {
                            //G_selectedObject.transform.position = VEC2_StartPos[i];
                            G_selectedObject.transform.position = VEC2_StartPos[i];
                            //GA_objects[i].GetComponent<dragMe>().wordPuzzle();

                            displayAnswerSprite();
                            Debug.Log(GA_objects[i]);
                            GA_objects[i].GetComponent<BoxCollider2D>().enabled = false;
                        }
                    }
                }
            }
        }
    }

    public void Next()
    {
        if (count >= AnswerSprites.Length - 1)
        {
            count = 0;
        }
        else
        {
            count++;
        }

        DisplayImage();
    }

    public void Previous()
    {
        if (count <= 0)
        {
            count = AnswerSprites.Length;
        }

        count--;
        DisplayImage();
    }

    void DisplayImage()
    {
        for (int i = 0; i < GA_objects.Length; i++)
        {
            GA_objects[i].GetComponent<BoxCollider2D>().enabled = true;
        }

            for (int i = 0; i < OptionImage.transform.parent.gameObject.transform.Find("pos").childCount; i++)
        {
            OptionImage.transform.parent.gameObject.transform.Find("pos").GetChild(i).gameObject.SetActive(false);
        }

        OptionImage.transform.parent.gameObject.transform.Find("pos").GetComponent<BoxCollider2D>().enabled = true;

        value = AnswerSprites[count].name[1].ToString() + AnswerSprites[count].name[2].ToString();

        for(int i=0;i< matchingImage.Length; i++)
        {
            if(matchingImage[i].name == value)
            {
                OptionImage.GetComponent<Image>().sprite = matchingImage[i];
                OptionImage.transform.parent.gameObject.transform.Find("pos").gameObject.tag = AnswerSprites[count].name[0].ToString();
            }
        }

        for (int i = 0; i < AnswerSprites.Length; i++)
        {
            AnswerSprites[i].SetActive(false);
        }
        AnswerSprites[count].SetActive(true);
    }

    void displayAnswerSprite()
    {
        Debug.Log("Answer");
        for (int i = 0; i < OptionImage.transform.parent.gameObject.transform.Find("pos").childCount; i++)
        {
            OptionImage.transform.parent.gameObject.transform.Find("pos").GetChild(i).gameObject.SetActive(false);
        }
        for (int i=0; i < OptionImage.transform.parent.gameObject.transform.Find("pos").childCount; i++)
        {
            if(OptionImage.transform.parent.gameObject.transform.Find("pos").GetChild(i).name == G_selectedObject.name)
            {
                OptionImage.transform.parent.gameObject.transform.Find("pos").GetChild(i).gameObject.SetActive(true);

                audioSource.clip = AnswerSprites[count].GetComponent<AudioSource>().clip;
                audioSource.Play();

                OptionImage.transform.parent.gameObject.transform.Find("pos").GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

}
