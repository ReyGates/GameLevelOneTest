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
        UIText.text = text;
        _animator.SetTrigger("execute");
    }
}
