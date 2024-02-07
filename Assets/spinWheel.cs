using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spinWheel : MonoBehaviour
{
    public GameObject wheel;
    public AudioSource audioSource;
    public AudioClip[] audios;

    public AnimationClip[] spinAnimation;

    int count;

    public void Spin()
    {
        if (count == 5)
        {
            Debug.Log("Game Over");
            count = 0;
        }
        StartCoroutine(playSpinAnimation());
        count++;

    }

    IEnumerator playSpinAnimation()
    {
        switch (count)
        {
            case 0:
                wheel.GetComponent<Animator>().Play("wheel_anim_1");
                yield return new WaitForSeconds(spinAnimation[0].length);
                audioSource.clip = audios[0];
                audioSource.Play();
                break;

            case 1:
                wheel.GetComponent<Animator>().Play("wheel_anim_2");
                yield return new WaitForSeconds(spinAnimation[1].length);
                audioSource.clip = audios[1];
                audioSource.Play();
                break;

            case 2:
                wheel.GetComponent<Animator>().Play("wheel_anim_3");
                yield return new WaitForSeconds(spinAnimation[2].length);
                audioSource.clip = audios[2];
                audioSource.Play();
                break;

            case 3:
                wheel.GetComponent<Animator>().Play("wheel_anim_4");
                yield return new WaitForSeconds(spinAnimation[3].length);
                audioSource.clip = audios[3];
                audioSource.Play();
                break;

            case 4:
                wheel.GetComponent<Animator>().Play("wheel_anim_5");
                yield return new WaitForSeconds(spinAnimation[4].length);
                audioSource.clip = audios[4];
                audioSource.Play();
                break;
        }
    }

}