using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public Animator animator;
    private bool animationMove = false;
    private bool animationAttack = false;
    private bool moveFinish = false;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) >= 0.9&&moveFinish==false)
        {
            Debug.Log(moveFinish);
            if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <
                1)
            {
                moveFinish = true;
                Debug.Log("범위안에 들어옴");
            }

            if (animationMove == false)
            {
                animator.Play("Z_Run", -1, 0);
                animationMove = true;
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                animator.Play("Z_Run", -1, 0);
            }
        }

        if (moveFinish)
        {
            if (animationAttack == false)
            {
                animator.Play("Z_Attack", -1, 0);
                animationAttack = true;
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                animator.Play("Z_Attack", -1, 0);
            }
        }
    }
}