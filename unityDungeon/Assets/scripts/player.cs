using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.Play("bk_rh_right_A", -1, 0);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.Play("hk_side_left_A", -1, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("hp_straight_A", -1, 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.Play("hp_straight_right_A", -1, 0);
        }
    }
}