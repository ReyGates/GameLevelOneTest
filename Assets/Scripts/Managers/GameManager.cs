using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseManager<GameManager>
{
    private TouchScreenKeyboard _keyboard;
    private string _typedText;

    private void Update()
    {
        
    }

    private void OnGUI()
    {
#if UNITY_ANDROID
        _keyboard = TouchScreenKeyboard.Open(_typedText, TouchScreenKeyboardType.Default);
#endif
    }
}