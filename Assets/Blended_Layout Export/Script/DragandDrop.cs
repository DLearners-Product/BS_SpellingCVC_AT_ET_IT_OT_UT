using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DragandDrop : MonoBehaviour
{
    public bool B_drag;
    public GameObject G_C_pos;
    public Vector2 C_initial;

    public GameObject G_fill,G_dash;
    public Vector2 pos_initial;
    public bool B_corret,B_callonce;
    public AudioSource wrong;
    public AudioSource empty;
    public AudioClip[] clips;

    public GameObject G_ans_BG, G_final_screen;
    public GameObject[] G_Img_answers;
    public GameObject[] G_questions;
    public int count;

    //public GameObject optionPanel; 
    public GameObject G_Options; 

    private void Start()
    {
        G_final_screen.SetActive(false);
        G_ans_BG.SetActive(false);
        for (int i = 0; i < G_questions.Length; i++)
        {
            G_questions[i].SetActive(false);
            G_Img_answers[i].SetActive(false);
        }
        G_dash.SetActive(true);
        G_questions[count].SetActive(true);
        C_initial = G_C_pos.transform.position;
        pos_initial = this.transform.position;
        count = 0;
        B_callonce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (B_drag)
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousepos);
        }
        if(!B_drag && !B_corret)
        {
            transform.position = pos_initial;
        }
    }

    void OnMouseDown()
    {
        B_drag = true;
    }
    void OnMouseUp()
    {
        B_drag = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("collide");
        if (collision.gameObject.tag == this.tag)
        { 
            //Debug.Log()
            B_corret = true;
            Debug.Log("ans");
            if (!B_drag && B_corret)
            {
                this.transform.position = G_fill.transform.position;
                this.transform.localScale = new Vector3 (2, 2, 0);
               
                G_dash.SetActive(false);

                this.GetComponent<DragandDrop>().enabled = false;
                G_Options.SetActive(false);
                if (B_callonce)
                {
                    playanim();
                    B_callonce = false;
                }
            }
        }
        else
        {
            wrong.Play();
            B_corret = false;
            if (!B_drag)
            {
                this.transform.position = pos_initial;
                Debug.Log("wrong anser intial posQ");
            }
        }
    }
    public void playanim()
    {
        empty.clip = clips[count];
        empty.Play();
        for (int i = 0; i < G_Img_answers.Length; i++)
        {
            G_Img_answers[i].SetActive(false);
        }
        G_ans_BG.SetActive(true);
        G_Img_answers[count].SetActive(true);
        Invoke("changequestion",1.2f);
    }
    public void changequestion()
    {
        if (count < 5)
        {
            count++;
            G_ans_BG.SetActive(false);
            for (int i = 0; i < G_questions.Length; i++)
            {
                G_Img_answers[i].SetActive(false);
                G_questions[i].SetActive(false);
            }
            G_questions[count].SetActive(true);
            G_Options.SetActive(true);
            G_dash.SetActive(true);
            G_C_pos.transform.position = C_initial;
            G_C_pos.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            G_C_pos.GetComponent<DragandDrop>().enabled = true;
            B_callonce = true;
        }
        
        if (count == 5)
        {
            G_C_pos.SetActive(false);
            G_final_screen.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        B_corret = false;
        this.transform.position = pos_initial;
    }
}
