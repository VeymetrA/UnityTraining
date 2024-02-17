using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;



namespace Assets.Scripts
{
    public class Snail : MonoBehaviour
    {
        public Animator animator;
        public int jumpHeight = 5;
        public int mushroomCount = 0;
        public TextMeshProUGUI textMeshProUGUI;
        public Rigidbody2D rigidBody;
        public int movementSensitivity;
        public SpriteRenderer spriteRenderer;


        // Use this for initialization
        void Start()
        {
            textMeshProUGUI.text = "Go pick some mushrooms!";
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 velocity = rigidBody.velocity;

            if (Input.GetKey(KeyCode.A))
            {
                //rigidBody.velocity = Vector3.left * movementSensitivity;
                velocity.x = -movementSensitivity;
                animator.SetBool("Move", true);
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                velocity.x = 0;
                animator.SetBool("Move", false);

            }

            if (Input.GetKey(KeyCode.D))
            {
                velocity.x = movementSensitivity;
                animator.SetBool("Move", true);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                velocity.x = 0;
                animator.SetBool("Move", false);
            }

            rigidBody.velocity = velocity;

            if (Input.GetKey(KeyCode.W))
            {
                rigidBody.gravityScale -= 0.6f * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                rigidBody.gravityScale += 1 * Time.deltaTime;  
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidBody.AddForce(Vector3.up * jumpHeight * 0.5f, ForceMode2D.Impulse);
            }

            while (Input.GetKey(KeyCode.R))
            {
                //extra feature
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Obstacle")
            {
                spriteRenderer.flipY = true;
                Thread.Sleep(1000);            }

            if (collision.transform.tag == "Mushroom")
            {
                mushroomCount++;
                textMeshProUGUI.text = $"Mushroom count = {mushroomCount}";
                rigidBody.transform.position = new Vector3(-8f, 5f, 0f);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Obstacle")
            {
                spriteRenderer.flipY = true;
                Thread.Sleep(1000);
                SceneManager.LoadScene("_SnailPicksMushroom");
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene("_SnailPicksMushroom");
        }
    }
}