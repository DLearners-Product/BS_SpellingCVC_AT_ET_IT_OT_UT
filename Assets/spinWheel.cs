using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class spinWheel : MonoBehaviour
{
    public GameObject wheel;
    public AudioSource audioSource;
    public AudioClip[] audios;

    public AnimationClip[] spinAnimation;
    [SerializeField] private TextMeshProUGUI clickedText;
    [SerializeField] private TextMeshProUGUI spinText;
    public GameObject wordPanel;
    public GameObject textTableBlocker;
    int count;

    public void Spin()
    {
        StartCoroutine(playSpinAnimation());
        count = Random.Range(0,5);

    }

    public void clickedTextSetter()
    {
        GameObject currentObject = EventSystem.current.currentSelectedGameObject;
        clickedText.text = currentObject.name;
        textTableBlocker.SetActive(true);
        Debug.Log(currentObject.name);
    }

    private void WordPanelEnable()
    {
        wordPanel.SetActive(true);
    }

    private void WordPanelTextClear()
    {
        clickedText.text = " ";
        spinText.text = " ";
    }

    IEnumerator playSpinAnimation()
    {
        switch (count)
        {
            case 0:
                wheel.GetComponent<Animator>().Play("wheel_anim_1");
                yield return new WaitForSeconds(spinAnimation[0].length);
                // audioSource.clip = audios[0];
                // audioSource.Play();
                spinText.text = "et";
                yield return new WaitForSeconds(1.5f);
                WordPanelEnable();
                yield return new WaitForSeconds(1.5f);
                wordPanel.SetActive(false);
                WordPanelTextClear();
                textTableBlocker.SetActive(false);
                break;

            case 1:
                wheel.GetComponent<Animator>().Play("wheel_anim_2");
                yield return new WaitForSeconds(spinAnimation[1].length);
                // audioSource.clip = audios[1];
                // audioSource.Play();
                spinText.text = "at";
                yield return new WaitForSeconds(1.5f);
                WordPanelEnable();
                yield return new WaitForSeconds(1.5f);
                wordPanel.SetActive(false);
                WordPanelTextClear();
                textTableBlocker.SetActive(false);
                break;

            case 2:
                wheel.GetComponent<Animator>().Play("wheel_anim_3");
                yield return new WaitForSeconds(spinAnimation[2].length);
                // audioSource.clip = audios[2];
                // audioSource.Play();
                spinText.text = "ut";
                yield return new WaitForSeconds(1.5f);
                WordPanelEnable();
                yield return new WaitForSeconds(1.5f);
                wordPanel.SetActive(false);
                WordPanelTextClear();
                textTableBlocker.SetActive(false);
                break;

            case 3:
                wheel.GetComponent<Animator>().Play("wheel_anim_4");
                yield return new WaitForSeconds(spinAnimation[3].length);
                // audioSource.clip = audios[3];
                // audioSource.Play();
                spinText.text = "ot";
                yield return new WaitForSeconds(1.5f);
                WordPanelEnable();
                yield return new WaitForSeconds(1.5f);
                wordPanel.SetActive(false);
                WordPanelTextClear();
                textTableBlocker.SetActive(false);
                break;

            case 4:
                wheel.GetComponent<Animator>().Play("wheel_anim_5");
                yield return new WaitForSeconds(spinAnimation[4].length);
                // audioSource.clip = audios[4];
                // audioSource.Play();
                spinText.text = "it";
                yield return new WaitForSeconds(1.5f);
                WordPanelEnable();
                yield return new WaitForSeconds(1.5f);
                wordPanel.SetActive(false);
                WordPanelTextClear();
                textTableBlocker.SetActive(false);
                break;
        }
    }

}