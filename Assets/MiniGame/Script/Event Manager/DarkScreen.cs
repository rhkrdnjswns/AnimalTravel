using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkScreen : MonoBehaviour
{
    float duration = 10f;
    private SpriteRenderer sprite;
    private void OnEnable()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(SetColor());
        if(transform.childCount > 0)
        {
            Invoke("ActiveChildForInvoke", 10f);
        }
    }
    IEnumerator SetColor()
    {
        float progress = 0;
        float increment = 0.01f / duration;
        while(progress < 1)
        {
            sprite.color = Color.Lerp(sprite.color, Color.black, progress);
            progress += increment;
            yield return new WaitForSeconds(0.02f);
        }
        yield return null;
    }
    private void ActiveChildForInvoke()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
