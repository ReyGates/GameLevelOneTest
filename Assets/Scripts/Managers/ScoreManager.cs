using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : BaseManager<ScoreManager> {
    private int _score;
    public int Score
    {
        get
        {
            return _score;
        }

        private set
        {
            _score = value;
            GUIManager.Instance.ScoreText.text = _score.ToString();
        }
    }

    public void AddScore(int score)
    {
        Score += score;
    }

    public void ResetScore()
    {
        Score = 0;
    }
}
