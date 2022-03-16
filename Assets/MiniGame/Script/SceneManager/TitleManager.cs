using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private Image start;
    [SerializeField] private Text startText;
    private bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Co_SetColor());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart) return;
        #region /**테스트 코드**/
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.LoadMainScene();
        }
#endif
        #endregion

        if (Input.touchCount > 0)
        {
            GameManager.Instance.LoadMainScene();
        }
    }
    IEnumerator Co_SetColor()
    {
        yield return new WaitForSeconds(2f);
        start.DOColor(new Color(0, 0, 0, 0.5f), 1f);
        while (true)
        {
            startText.DOColor(Color.white, 1f);
            yield return new WaitForSeconds(1f);
            isStart = true;
            startText.DOColor(Color.clear, 1f);
            yield return new WaitForSeconds(1f);
        }

    }
}
