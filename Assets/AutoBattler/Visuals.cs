using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Visuals : MonoBehaviour
{
    public Color color;
    public SpriteRenderer spriteRenderer;
    public bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Random.Range(0, 101);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        if (!waiting)
        {
            waiting = true;
            spriteRenderer.color = Random.ColorHSV();
            color.a = 1;
            yield return new WaitForSeconds(1);
            waiting = false;
        }
    }
}
