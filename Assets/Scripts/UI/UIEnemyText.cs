using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyText : MonoBehaviour
{
    public Text EnemyText;
    public Transform Target;

    public void Execute(Enemy enemy)
    {
        enemy.OnTextChanged = delegate (string text)
        {
            EnemyText.color = Player.CurrentEnemy == enemy ? Color.red : Color.black;
            EnemyText.text = text;
        };

        transform.position = new Vector3(0, -1000, 0);

        EnemyText.text = enemy.Text;
        Target = enemy.transform;

        gameObject.SetActive(true);
    }

    private void Update()
    {
        if(Target != null)
        {
            if (Target.gameObject.activeSelf)
            {
                UpdateMovement();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void UpdateMovement()
    {
        if(Camera.main != null)
            transform.position = Camera.main.WorldToScreenPoint(Target.position);
    }
}
