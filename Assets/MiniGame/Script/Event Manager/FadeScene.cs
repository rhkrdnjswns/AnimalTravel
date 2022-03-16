using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeScene : MonoBehaviour
{
    float duration = 10f;
    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(SetColor());       
    }
    IEnumerator SetColor()
    {
        float progress = 0;
        float increment = 0.01f / duration;
        while (progress < 1)
        {
            image.color = Color.Lerp(image.color, Color.clear, progress);
            progress += increment;
            yield return new WaitForSeconds(0.02f);
        }
        transform.gameObject.SetActive(false);
        yield return null;
    }
}
