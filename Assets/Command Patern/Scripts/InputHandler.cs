using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] GameObject player;
    Animator anim;
    Command keySpace, walkFarwardKey, downArrowKey, S_key, R_key, C_key, N_key, keyUP;

    void Start()
    {
        anim = player.GetComponent<Animator>();
        keySpace = new PerformJump();
        walkFarwardKey = new PerformWalk();
        N_key = new DoNothing();
        R_key = new PerformReflesh();
        C_key = new PerformRun();
        S_key = new PerformSlide();
        keyUP = new PerformIdle();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //jump
            keySpace.Execute(anim);
        }

        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        {
            //walk forward or backwards
            walkFarwardKey.Execute(anim);

            //reverse
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            keyUP.Execute(anim);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            N_key.Execute(anim);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            R_key.Execute(anim);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            S_key.Execute(anim);
        }
    }
}
