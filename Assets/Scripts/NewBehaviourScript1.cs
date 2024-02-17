using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class NewBehaviourScript1 : MonoBehaviour
    {
        public Color color;
        public SpriteRenderer spriteRenderer;

        public Vector3 endPosition;

        // Use this for initialization
        void Start()
        {
            Random.Range(0, 101);
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime);
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, color, Time.deltaTime);
            //spriteRenderer.flipX = true;

            if (Input.GetKeyDown(KeyCode.C))
            {
                color = new Color(Random.value, Random.value, Random.value);
                //spriteRenderer.color = color;
            }
        }
    }
}