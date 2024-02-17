using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bunny : MonoBehaviour
    {
        public Animator animator;
        public Action OnAnimationEvent;
        public void AnimationEvent()
        {
            OnAnimationEvent?.Invoke();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetBool("StartRun", true);
            }
        }
    }
}