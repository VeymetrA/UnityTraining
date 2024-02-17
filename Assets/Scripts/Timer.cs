using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{ 
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
        Invoke(nameof(Enable), 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (image.enabled)
        {
            image.fillAmount -= Time.deltaTime * 0.2f;
        }
    }
    public void Enable()
    {
        image.enabled = true;
    }
}
