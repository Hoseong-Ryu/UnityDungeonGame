using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monster : MonoBehaviour
{
    public Animator animator;
    public Slider hpBar;

    public float monHp = 100f;
    
    private bool animationMove = false;
    private bool animationAttack = false;
    private bool moveFinish = false;
    private CharacterController controller;
    private bool knockdown = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        hpBar.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) >= 0.9&&moveFinish==false&&knockdown == false&&
            Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= 8)
        {
            Debug.Log(moveFinish);
            if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < 1)
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

        if (moveFinish &&knockdown == false)
        {
            if (animationAttack == false)
            {
                animator.Play("Z_Attack", -1, 0);
                animationAttack = true;
                hpBar.value -= 0.01f;
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                animator.Play("Z_Attack", -1, 0);
                hpBar.value -= 0.01f;
                // animationAttack = false;
            }
            if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) >= 1.6)
            {
                moveFinish = false;
                animationMove = false;
            }
        }
        if (monHp <= 0f &&knockdown == false)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.2f&&knockdown == false)
            {
                animator.Play("Z_FallingBack", -1, 0);
                knockdown = true;
            }
            if(knockdown)
            {
                Destroy(gameObject.GetComponent<BoxCollider>());
                Destroy(gameObject, 2);
            }
        }
    }

}