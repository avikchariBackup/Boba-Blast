using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SequenceAnimator : MonoBehaviour
{
    public float timeBetweenMove;
    List <Animator> _animators;
    // Animations on Start function depending on scene.
    void Awake()
    {
    }
    //Below are any animations triggered by UnityEvents or MM Feedbacks

    void Start()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());

        if (gameObject.tag == "TextBounce")
        {
            StartTextBounceAnimation();
        }

        else if (gameObject.tag == "TextJumpIn")
        {
            StartTextJumpInAnimation();
        }
    }

    public void StartTextBounceAnimation()
    {
        StartCoroutine(StartTextBounce());
    }

    public void StartTextJumpInAnimation()
    {
        StartCoroutine(StartTextJumpIn());
    }

    //The coroutines achieving a sequential animation
    IEnumerator StartTextBounce()
    {
        while (true)
        {
            foreach(var animator in _animators)
            {
                animator.SetTrigger("StartTextBounce");
                yield return new WaitForSeconds(timeBetweenMove);
            }
        }
    }

    IEnumerator StartTextJumpIn()
    {
        while (true)
        {
            foreach(var animator in _animators)
            {
                animator.SetTrigger("StartTextJumpIn");
                yield return new WaitForSeconds(timeBetweenMove);
            }
        }
    }
}

    
