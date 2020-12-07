using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Animator animator;
    private CharacterController controller;
    private bool dir = true; // 오른쪽 : true, 왼쪽 false
    public float speed = 5;
    public Slider hpBar;

    private RaycastHit hit;
    float kickDistance = 1.5f;
    float punchDistance = 1f;
    
    private bool knockdown = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.Play("bk_rh_right_A", -1, 0);
            if (Physics.Raycast(transform.position+new Vector3(0,1,0), transform.forward, out hit, kickDistance))
            {
                Debug.Log("히트");
                hit.transform.GetComponent<monster>().monHp -= 100;
            }
            else
            {
                Debug.Log("언히트");
            }
        }

        else if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.Play("hk_side_left_A", -1, 0);
            if (Physics.Raycast(transform.position+new Vector3(0,1,0), transform.forward, out hit, kickDistance))
            {
                Debug.Log("히트");
                hit.transform.GetComponent<monster>().monHp -= 100;
            }
            else
            {
                Debug.Log("언히트");
            }
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("hp_straight_A", -1, 0);
            if (Physics.Raycast(transform.position+new Vector3(0,1,0), transform.forward, out hit, punchDistance))
            {
                Debug.Log("히트");
                hit.transform.GetComponent<monster>().monHp -= 100;
            }
            else
            {
                Debug.Log("언히트");
            }
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.Play("hp_straight_right_A", -1, 0);
            if (Physics.Raycast(transform.position+new Vector3(0,1,0), transform.forward, out hit, punchDistance))
            {
                Debug.Log("히트");
                hit.transform.GetComponent<monster>().monHp -= 100;
            }
            else
            {
                Debug.Log("언히트");
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("walking", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk") && dir)
            {
                animator.Play("Run", -1, 0);
            }
            else
            {
                animator.Play("Walk", -1, 0);
            }

            if (!dir)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                dir = true;
            }
        }

        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (!Input.GetKey(KeyCode.LeftArrow))
                animator.SetBool("walking", false);
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("walking", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk") && !dir)
            {
                animator.Play("Run", -1, 0);
            }
            else
            {
                animator.Play("Walk", -1, 0);
            }

            if (dir)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                dir = false;
            }
        }

        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (!Input.GetKey(KeyCode.RightArrow))
                animator.SetBool("walking", false);
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Jump");
        }

        // move player
        if (animator.GetBool("walking"))
        {
            float speed = this.speed;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                speed *= 2;

            controller.Move(Time.deltaTime * speed * transform.TransformDirection(Vector3.forward));
        }

        //player hp
        if (hpBar.value <= 0f)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && knockdown == false)
            {
                animator.Play("knockdown_A2", -1, 0);
                knockdown = true;
            }

            if (knockdown)
            {
                Destroy(gameObject, 3);
            }
        }
    }
}