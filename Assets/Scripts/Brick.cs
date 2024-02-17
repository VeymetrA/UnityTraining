using UnityEditor.Timeline.Actions;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

namespace Assets.Scripts
{
    public class Brick : MonoBehaviour
    {
        public Animator animator;
        public Bunny bunny;
        public SpriteRenderer spriteRenderer;
        public Color color;
        public GameObject brick;
        public float curveTime;



        private void Fall()
        {
            animator.SetBool("StartRun", true);
        }

        // Use this for initialization
        void Start()
        {
            bunny.OnAnimationEvent += Fall;
        }

        // Update is called once per frame
        void Update()
        {
            //    transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime);
            //    spriteRenderer.color = Color.Lerp(spriteRenderer.color, color, Time.deltaTime);
            //    //spriteRenderer.flipX = true;

            //    //if ()
            //    //{
            //    //    color = new Color(Random.value, Random.value, Random.value);
            //    //    //spriteRenderer.color = color;
            //    //}
        }
    }
}