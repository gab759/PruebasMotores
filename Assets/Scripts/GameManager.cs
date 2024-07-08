using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action OnReachGoal;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        OnReachGoal += LoadNextLevel;  // Register the event handler
    }

    private void OnDestroy()
    {
        OnReachGoal -= LoadNextLevel;  // Unregister the event handler
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("win");
    }

    public void TriggerGoalReached()
    {
        OnReachGoal?.Invoke();
    }
}