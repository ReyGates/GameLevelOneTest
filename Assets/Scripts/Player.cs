using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : BaseManager<Player>
{
    public static Enemy CurrentEnemy;

    public void CheckInput(string text)
    {
        List<Enemy> enemyList = SpawnManager.Instance.GetEnemyList();

        if(CurrentEnemy != null)
            CurrentEnemy = CurrentEnemy.gameObject.activeSelf ? CurrentEnemy : null;

        if(CurrentEnemy == null)
            CurrentEnemy = FindEnemy(enemyList, text);

        if (CurrentEnemy != null)
        {
            if (CurrentEnemy.Text != "")
            {
                if (CurrentEnemy.Text[0] == text[0])
                {
                    CurrentEnemy.Text = CurrentEnemy.Text.Substring(1);
                }
                else
                {
                    CurrentEnemy.Speed += 0.5f;
                }
            }
        }
        else
        {
            foreach(var enemy in enemyList)
            {
                enemy.Speed += 0.25f;
            }
        }
    }

    private Enemy FindEnemy(List<Enemy> enemyList, string text)
    {
        foreach (var enemy in enemyList)
        {
            if (enemy.Text[0] == text[0])
            {
                return enemy;
            }
        }

        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.GetComponent<Enemy>() != null)
            GameManager.Instance.GameOver();
    }
}
