using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{
    public Animator sk20_animator;


    public void AlignmentBalk()
    {
        sk20_animator.SetBool("anim", true);
    }
}
