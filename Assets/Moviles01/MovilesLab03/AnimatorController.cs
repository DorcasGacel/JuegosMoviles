using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;
   // public Animation animation;
    void Start()
    {
        animator = GetComponent<Animator>();
        //animation = GetComponent<Animation>();
    }

    public void ReproducirAnimacion()
    {
        //activar animación .....
        animator.SetTrigger("cat");
        //animation.Play();
    }

    void Update()
    {
        //animator.SetBool("idle", true);
        //animation.Play();
        animator.SetTrigger("cat");
    }
}
