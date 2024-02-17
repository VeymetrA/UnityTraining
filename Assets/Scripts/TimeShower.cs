using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;


public class TimeShower : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI.text = "";
        StartCoroutine(Test());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Time.timeScale /= 1.2f;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Time.timeScale *= 1.2f;
        }


        time += Time.deltaTime;
        int minutes = (int)(time / 60);
        float seconds = (time % 60);
        textMeshProUGUI.text = $"{minutes} : {seconds.ToString("F0")}";
    }

    public IEnumerator Test()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(2);
        Debug.Log("2 seconds passed");

        int delay = 10;
        while (delay > 0)
        {
            yield return new WaitForSeconds(1.5f); 
            delay--;
        }
        Debug.Log("Coroutine finished");
    }
}
