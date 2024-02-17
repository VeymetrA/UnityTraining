using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;


public class TriangleAnimation : MonoBehaviour
{
    public Animator animator;
    public GameObject triangle;
    public GameObject canvas;
    public TMP_Text canvasText1;
    public TMP_Text canvasText2;

    public void StopAnimation()
    {
        animator.SetBool("DoAnimation", false);
        triangle.transform.localScale += new Vector3(3, 3, 3) * Time.deltaTime;
        canvasText1.enabled = false;
        canvasText2.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        canvasText1.enabled = false;
        canvasText2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Invoke(nameof(StopAnimation), 2.95f);
            animator.SetBool("DoAnimation", true);
            canvasText1.enabled = true;
            canvasText2.enabled = false;
        }
    }
}
