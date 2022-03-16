using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer;
    float fps;
  

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("timer     :" + timer / fps + " seconds");
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = Time.deltaTime * 1000.0f;
        fps = 1.0f / Time.deltaTime;
        string text = string.Format("{0:0√ } ms ({1.0} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}
