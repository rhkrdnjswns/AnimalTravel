using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private bool isA;
    public bool IsA { get => isA; set => isA = value; }
    private List<Transform> childs = new List<Transform>(2);

    [Header("순간이동 비활성화 시간(초 단위)")]
    [SerializeField] private float second = 2f;
    private void Start()
    {
        GetComponentsInChildren<Transform>(childs);
        childs.RemoveAt(0);
    }

    public void Teleportation(Transform obj)
    {
        if (isA)
        {
            obj.position = childs[1].position;
            StartCoroutine(DisabledPortal(childs));
        }
        else
        {
            obj.position = childs[0].position;
            StartCoroutine(DisabledPortal(childs));
        }
    }
    IEnumerator DisabledPortal(List<Transform> childs)
    {
        foreach (var child in childs)
        {
            child.GetComponent<BoxCollider2D>().enabled = false;
        }
        yield return new WaitForSeconds(second);
        foreach (var child in childs)
        {
            child.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
