using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : BaseManager<SpawnManager>
{
    public Transform EnemyParent;

    public Enemy EnemyPrefab;
    public List<Enemy> EnemyList;

    public Transform SpawnPointTransform;
    public Vector3 SpawnPointPosition;
    public float SpawnPointSizeX = 1;

    public Vector2 SpawnPerSec = new Vector2(2, 3);

    public void StartSpawn()
    {
        StartCoroutine(SpawnerEnumerator());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
        ClearEnemy();
    }


    //GC Needed
    //Not safe
    List<Enemy> tempList = new List<Enemy>();

    public List<Enemy> GetEnemyList()
    {
        tempList.Clear();

        foreach(var enemy in EnemyList)
        {
            if(enemy.Text != "")
            {
                tempList.Add(enemy);
            }
        }

        return tempList;
    }

    private void ClearEnemy()
    {
        Utility.ClearList(ref EnemyList);
    }

    private void UpdateSpawnPoint()
    {
        if(SpawnPointTransform != null)
        {
            SpawnPointPosition = SpawnPointTransform.position;
        }
    }

    IEnumerator SpawnerEnumerator()
    {
        while (true)
        {
            float respawnTime = Random.Range(SpawnPerSec.x, SpawnPerSec.y) - (ScoreManager.Instance.Score/10f);
            respawnTime = respawnTime <= 0.5f ? 0.5f : respawnTime;

            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }

    private void OnDrawGizmos()
    {
        UpdateSpawnPoint();

        Vector3 gizmosPosition = SpawnPointPosition;
        gizmosPosition.y += 0.5f;

        Gizmos.color = Color.red;
        Gizmos.DrawCube(gizmosPosition, new Vector3(SpawnPointSizeX, 1, 1));
        Gizmos.color = Color.white;
    }

    private void SpawnEnemy()
    {
        Enemy newEnemy = Utility.GetItem(ref EnemyList, EnemyPrefab, EnemyParent);
        newEnemy.OnExplode = () => { ScoreManager.Instance.AddScore(1); };

        Vector3 pos = SpawnPointPosition;
        pos.x = Random.Range(-SpawnPointSizeX + 1f, SpawnPointSizeX - 1f);

        newEnemy.transform.position = pos;
        newEnemy.Execute(Utility.GetRandomText());
        GUIManager.Instance.GetEnemyText().Execute(newEnemy);
    }
}