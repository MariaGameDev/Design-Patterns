using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] GameObject player;
    Animator anim;
    Command keySpace, walkFarwardKey, downArrowKey, backwardsKey, R_key, C_key, N_key, keyUP;
    List<Command> oldCommands = new List<Command>();
    Coroutine replayCoroutine;
    bool shouldStartReplay, isReplaying;

    float speed = 2.0f;
    float rotationSpeed = 100.0f;

    float translation, rotation;

    void Start()
    {
        anim = player.GetComponent<Animator>();
        Camera.main.GetComponent<CameraFollow360>().player = player.transform;
        keySpace = new PerformJump();
        walkFarwardKey = new PerformWalk();
        N_key = new DoNothing();
        R_key = new PerformReflesh();
        C_key = new PerformRun();
        backwardsKey = new PerformWalk();
        keyUP = new PerformIdle();


    }

    
    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed;
        rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

       // InputHandleUpdate();
       // InputHandleUpdate();
         if (!isReplaying)
         {
            InputHandleUpdate();
         }
         StartReplaying();
    }

    void InputHandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //jump
            keySpace.Execute(anim, true);
            oldCommands.Add(keySpace);

        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {

           
            walkFarwardKey.Execute(anim, true);
            oldCommands.Add(walkFarwardKey);

        }



        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            walkFarwardKey.Execute(anim, false);
            oldCommands.Add(walkFarwardKey);


        }

        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)|| Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            keyUP.Execute(anim, true);
            oldCommands.Add(keyUP);
        }

    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //jump
            keySpace.Execute(anim,true);
            oldCommands.Add(keySpace);
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            //walk forward or backwards
            walkFarwardKey.Execute(anim, true);
            oldCommands.Add(walkFarwardKey);
            //reverse
        }



        else if (Input.GetKeyDown(KeyCode.N))
        {
            N_key.Execute(anim, true);
            oldCommands.Add(N_key);
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            R_key.Execute(anim, true);
            oldCommands.Add(R_key);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            backwardsKey.Execute(anim, true);
            oldCommands.Add(backwardsKey);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            shouldStartReplay = true;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            UndoLastCommand();
        }
    }

    void UndoLastCommand()
    {
        if (oldCommands.Count > 0)
        {
            Command cmd = oldCommands[oldCommands.Count - 1];
            cmd.Execute(anim, false);
            oldCommands.RemoveAt(oldCommands.Count - 1);
        }
        
    }

    void StartReplaying()
    {
        if (shouldStartReplay && oldCommands.Count > 0)
        {
            shouldStartReplay = false;
            if (replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }

            replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    IEnumerator ReplayCommands()
    {
        isReplaying = true;
        for (int i = 0; i < oldCommands.Count; i++)
        {
            oldCommands[i].Execute(anim, true);
            yield return new WaitForSeconds(1f);
        }
        isReplaying = false;
    }
}
