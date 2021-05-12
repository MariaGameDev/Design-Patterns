using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    public abstract void Execute(Animator anim);
}

public class PerformIdle : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isWaiting");
        anim.SetBool("isWalking", false);
    }
}

public class PerformJump : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isJumping");
    }
}

public class PerformWalk : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isWalking");
    }
}

public class PerformRun : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isRunning");
    }
}

public class DoNothing : Command
{
    public override void Execute(Animator anim)
    {
       
    }
}

public class PerformReflesh : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isReflesh");
    }
}

public class PerformSlide : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isSliding");
    }
}