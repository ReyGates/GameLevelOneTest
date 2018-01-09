using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPop : MonoBehaviour
{
    public Text UIText;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Execute(string text)
    {
        gameObject.SetActive(true);

        UIText.text = text;
        _animator.SetTrigger("execute");

        Vector3 pos = transform.localPosition;
        pos.x = Random.Range(-100f, 100f);

        transform.localPosition = pos;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
