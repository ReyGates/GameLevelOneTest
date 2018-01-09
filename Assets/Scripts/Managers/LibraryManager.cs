using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class LibraryManager : BaseManager<LibraryManager> {
    public WordLibrary WordLibrary = new WordLibrary();

    private IEnumerator Start()
    {
        Debug.Log("Initializing");

        string path;
        path = Path.Combine(Application.streamingAssetsPath, "words_dictionary.json");

        string json = "";

        if (path.Contains("://"))
        {
            UnityWebRequest www = UnityWebRequest.Get(path);
            yield return www.SendWebRequest();
            json = www.downloadHandler.text;
        }
        else
            json = System.IO.File.ReadAllText(path);

        WordLibrary = JsonUtility.FromJson<WordLibrary>(json);

        Debug.Log("Initialized");
    }
}
