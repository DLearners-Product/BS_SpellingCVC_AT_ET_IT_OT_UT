using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class slot_machine : MonoBehaviour
{
    public GameObject[] AllWords;
    public GameObject machine;
    public Sprite slotMachineInitalImage;
    public AnimationClip slot_machine_anim;

    public GameObject collectedItems;

    GameObject selectedGameObject;

    public AudioSource audioSource;
    public AudioClip coinAudio;
    public GameObject G_final;

    int count;

    private void Start()
    {
        count = 0;
        for (int i = 0;i< AllWords.Length; i++)
        {
            AllWords[i].SetActive(false);
        }
        for (int i = 0; i < collectedItems.transform.childCount; i++)
        {
            collectedItems.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void Push()
    {
        selectedGameObject = EventSystem.current.currentSelectedGameObject;
        //selectedGameObject.SetActive(false);
        StartCoroutine(slotMachineAnimation());
    }
    IEnumerator slotMachineAnimation()
    {
        if (count == AllWords.Length)
        {
            Debug.Log("Game OVer");
            G_final.SetActive(true);
            for (int i = 0; i < AllWords.Length; i++)
            {
                AllWords[i].SetActive(false);
            }
            for (int i = 0; i < machine.transform.childCount; i++)
            {
                machine.transform.GetChild(i).gameObject.SetActive(false);
            }
            selectedGameObject.GetComponent<Button>().enabled = false;
            machine.GetComponent<Image>().sprite = slotMachineInitalImage;
        }
        else
        {
            selectedGameObject.GetComponent<Button>().enabled = false;
            machine.GetComponent<Animator>().Play("machine_anim");

            for (int i = 0; i < AllWords.Length; i++)
            {
                AllWords[i].SetActive(false);
            }

            string name = AllWords[count].name[1].ToString() + AllWords[count].name[2].ToString();

            Debug.Log(name);

            for (int i = 0; i < machine.transform.childCount; i++)
            {
                machine.transform.GetChild(i).gameObject.SetActive(false);
            }

            machine.transform.Find(name).gameObject.SetActive(true);

            yield return new WaitForSeconds(slot_machine_anim.length);
            machine.GetComponent<Image>().sprite = slotMachineInitalImage;


            machine.GetComponent<Image>().sprite = slotMachineInitalImage;
            AllWords[count].SetActive(true);
            collectedItems.transform.GetChild(count).gameObject.SetActive(true);

            audioSource.PlayOneShot(coinAudio);

            selectedGameObject.GetComponent<Button>().enabled = true;
            //selectedGameObject.SetActive(true);

            count++;
        }
    }
}