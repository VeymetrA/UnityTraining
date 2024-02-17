using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Upwards : MonoBehaviour
{
    public bool movingLeft = false;
    public bool movingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveLeft());
        StartCoroutine(MoveRight());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * 0.4f * Time.deltaTime;
        if (movingLeft)
        {
            transform.position += Vector3.left * 0.6f * Time.deltaTime;
        }
        if (movingRight)
        {
            transform.position += Vector3.right * 0.6f * Time.deltaTime;
        }
    }

    public IEnumerator MoveLeft()
    {
        yield return new WaitForSeconds(5);
        int delay = 5;
        while (delay > 0)
        {
            yield return new WaitForSeconds(1);
            delay--;
        }
        movingLeft = true;
    }

    public IEnumerator MoveRight()
    {
        yield return new WaitForSeconds(10);
        int delay = 10;
        while (delay > 0)
        {
            yield return new WaitForSeconds(1);
            delay--;
        }
        movingLeft = false;
        movingRight = true;
    }
}
