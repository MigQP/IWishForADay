using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeedChanger : MonoBehaviour
{

    private Animator flowersAnimator;
    //Value from the slider, and it converts to speed level
    float m_MySliderValue;



    // Start is called before the first frame update
    void Awake()
    {
        flowersAnimator = GetComponent<Animator>();
    }


    public void SetNewAnimatorSpeed (float speed)
    {
        flowersAnimator.speed = speed;
    }


    public void StopAnimator()
    {
        flowersAnimator.enabled = false;
    }
    public void StartAnimator()
    {
        flowersAnimator.enabled = true;
        flowersAnimator.speed = 0.8f;
    }


    public void AcitvateNextOnRandomTime (GameObject phrase)
    {
        StartCoroutine(Fade(phrase));
    }

    public void ActivateRepeat(GameObject phrase)
    {
        if (TextManager.instance.count == TextManager.instance.max - 1)
        {
            AcitvateNextOnRandomTime(TextManager.instance.antePenultimaFrase);
        }

        else
        {
            StartCoroutine(Fade(phrase));
        }
    }

    IEnumerator Fade(GameObject gameObject)
    {

        yield return new WaitForSeconds(Random.Range(2, 4));

        gameObject.SetActive(true);
    }
}
