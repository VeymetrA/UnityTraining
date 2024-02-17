using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public AnimationCurve curve;
    public SpriteRenderer spriteRenderer;
    public float curveTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            Color color = spriteRenderer.color;
            color.a = curve.Evaluate(curveTime);
            curveTime += Time.deltaTime;
            spriteRenderer.color = color;
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            curveTime = 0;
        }
    }
}