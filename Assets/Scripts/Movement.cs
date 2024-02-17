using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float jumpHeight = 5f;
    public int triangleCount = 0;
    public TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI.text = "No triangles so far";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 10 * Time.deltaTime;
            //rigidBody.velocity = Vector3.left * 5;
            //rigidBody.AddForce(Vector3.left * 0.5f, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 10 * Time.deltaTime;
            //rigidBody.velocity = Vector3.right * 5;
            //rigidBody.AddForce(Vector3.right * 0.5f, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += Vector3.up * 5 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += Vector3.down * 5 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //GameObject obj = collision.gameObject;
            //SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            //spriteRenderer.color = Color.red;

            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (collision.transform.tag == "Triangle")
        {
            Destroy(collision.gameObject);
            triangleCount++;
            textMeshProUGUI.text = $"Triangle count = {triangleCount}";
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
