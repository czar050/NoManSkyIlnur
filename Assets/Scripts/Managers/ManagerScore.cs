using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ManagerScore : SingletonManager<ManagerScore>
{
    public int _score;
    public TextMeshProUGUI _scoreText;
    public Action<int> OnAddScore;
    public Action<int> OnNewScore;
    public UnityEvent<int> EventAddScore;
    private void Start()
    {
        if (_scoreText == null)
            Debug.LogError("error text");
        else
            _scoreText.text = _score.ToString();
    }

    private void OnEnable()
    {
        OnAddScore += IncreaseScore;
    }
    private void OnDisable()
    {
        OnAddScore -= IncreaseScore;
    }

    public void AddScore(int scoreDelta)
    {
        OnAddScore?.Invoke(scoreDelta);
    }
    public void IncreaseScore(int scoreDelta)
    {
        _score += scoreDelta;
        _scoreText.text = _score.ToString();

        OnNewScore?.Invoke(_score);

        EventAddScore.Invoke(scoreDelta);
    }
}
