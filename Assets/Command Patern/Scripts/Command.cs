using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    public abstract void Execute(Animator anim, bool farward);
}

public class PerformIdle : Command
{
    public override void Execute(Animator anim, bool farward)
    {
        anim.SetBool("is_Walking", false);
        anim.SetTrigger("isWaiting");
        

    }
}

public class PerformJump : Command
{
    public override void Execute(Animator anim, bool farward)
    {
        if (farward)
        {
            anim.SetTrigger("isJumping");
        }
        else
        {
            anim.SetTrigger("isJumpingR");
        }

       
    }
}

public class PerformWalk : Command
{
    public override void Execute(Animator anim, bool farward)
    {
        anim.SetBool("is_Walking", true);

    }
}

public class PerformRun : Command
{
    public override void Execute(Animator anim, bool farward)
    {
        if (farward)
        {
            anim.SetTrigger("isRunning");
        }
        else
        {
            anim.SetTrigger("isRunningR");
        }
        
    }
}

public class DoNothing : Command
{
    public override void Execute(Animator anim, bool farward)
    {
       
    }
}

public class PerformReflesh : Command
{
    public override void Execute(Animator anim, bool farward)
    {
        if (farward)
        {
            anim.SetTrigger("isReflesh");
        }
        else
        {
            anim.SetTrigger("isRefleshR");
        }
        
    }
}

public class PerformSlide : Command
{
    public override void Execute(Animator anim, bool farward)
    {
        if (farward)
        {
            anim.SetTrigger("isSliding");
        }
        else
        {
            anim.SetTrigger("isSlidingR");
        }
        
    }
}