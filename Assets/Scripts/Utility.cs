using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class Utility
{
    public static string GetRandomText()
    {
        string text = LibraryManager.Instance.WordLibrary.Words[Random.Range(0, LibraryManager.Instance.WordLibrary.Words.Count)].Text;

        bool same = true;

        while(same)
        {
            if (text == "")
            {
                same = false;
            }
            else
            {
                if (SpawnManager.Instance.GetEnemyList().Count > 1)
                {
                    foreach (var enemy in SpawnManager.Instance.GetEnemyList())
                    {
                        if (enemy.Text != "")
                        {
                            if (enemy.Text[0] == text[0])
                            {
                                same = true;
                                text = LibraryManager.Instance.WordLibrary.Words[Random.Range(0, LibraryManager.Instance.WordLibrary.Words.Count)].Text;

                                break;
                            }
                            else
                            {
                                same = false;
                            }
                        }
                    }
                }
                else
                {
                    same = false;
                    break;
                }
            }
        }

        return text;
    }

    public static void ClearList<T>(ref List<T> list) where T : MonoBehaviour
    {
        for (int i = 0; i < list.Count; i++)
        {
            Object.Destroy(list[i].gameObject);
        }

        list.Clear();
    }

    //REDUCE MEMORY USAGE
    public static T GetItem<T>(ref List<T> itemList, T prefab, Transform parent) where T : MonoBehaviour
    {
        foreach (var item in itemList)
        {
            if (!item.gameObject.activeInHierarchy)
                return item;
        }

        T newItem = Object.Instantiate(prefab, parent);
        newItem.transform.localPosition = Vector3.zero;
        itemList.Add(newItem);

        return newItem;
    }
}
