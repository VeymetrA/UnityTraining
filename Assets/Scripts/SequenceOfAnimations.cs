using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceOfAnimations : MonoBehaviour
{
    public Animator animator;

    public void Run()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("StartRun", true);
        }
    }

    public void Hit()
    {
        if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("StartRun", false);
            animator.SetBool("StartHit", true);
        }
    }
    public void Finish()
    {
        if (Input.GetKey(KeyCode.C))
        {
            animator.SetBool("StartHit", false);
            animator.SetBool("Finish", true);
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Run(); 
        Hit();
        Finish();
    }
}
