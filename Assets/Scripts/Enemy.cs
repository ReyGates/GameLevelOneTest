using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityAction OnExplode;
    public UnityAction<string> OnTextChanged;

    [SerializeField]
    private string _text = "none";
    public string Text
    {
        get
        {
            return _text;
        }

        set
        {
            _text = value;

            if(OnTextChanged != null)
                OnTextChanged(_text);
        }
    }

    public float Speed = 1;

    private bool _executed = false;

    public void Execute(string text)
    {
        Speed = 1f;
        Speed += (ScoreManager.Instance.Score / 10f);

        gameObject.SetActive(true);

        Text = text;
        _executed = true;
    }

    private void Update()
    {
        if (_executed)
        {
            if (_text != "")
            {
                Movement();
            }
            else
            {
                Explode();
            }
        }
    }

    private void Explode()
    {
        gameObject.SetActive(false);

        Player.CurrentEnemy = null;

        if (OnExplode != null)
            OnExplode();
    }

    private void Movement()
    {
        Vector3 newPos = transform.position;
        newPos.z += (transform.forward.z * Speed);

        transform.position = Vector3.Lerp(transform.position,  newPos, Time.deltaTime);
    }
}
