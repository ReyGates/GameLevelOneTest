using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : BaseManager<GameManager>
{
    public enum GameStateEnum
    {
        Idle,
        Playing
    }

    public GameStateEnum GameState = GameStateEnum.Idle;

    public InputField MainInputField;

    private TouchScreenKeyboard _keyboard;

    private void Start()
    {
        MainInputField.onValueChanged.AddListener(UpdateInput);
        //StartGame();
    }

    public void StartGame()
    {
        GameState = GameStateEnum.Playing;

        SpawnManager.Instance.StartSpawn();
        GUIManager.Instance.StartGui();
        ScoreManager.Instance.ResetScore();
    }

    public void GameOver()
    {
        GameState = GameStateEnum.Idle;

        SpawnManager.Instance.StopSpawn();
        GUIManager.Instance.StopGui();
    }

    private void Update()
    {
        if (GameState == GameStateEnum.Playing)
        {
            if (!MainInputField.isFocused)
                MainInputField.Select();
        }
        else
        {
            if(_keyboard != null)
                _keyboard.active = false;
        }
    }

    private void UpdateInput(string text)
    {
        if (text == "")
            return;

        GUIManager.Instance.AddPop(text);
        AudioManager.Instance.PlayTypeClip();

        Player.Instance.CheckInput(text);

        MainInputField.text = "";
    }

    private void OnGUI()
    {
#if UNITY_ANDROID
        if(GameState == GameStateEnum.Playing)
            _keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
#endif
    }
}