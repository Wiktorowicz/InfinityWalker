using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    public event EventHandler OnGameOver;
    public event EventHandler OnScoreChanged;

    public enum GameState {
        Gameplaying,
        GameOver
    }

    public GameState CurrentGameState => currentGameState;
    public int CurrentScore => Mathf.FloorToInt(currentScore);
    public float CurrentScoreMultiplier => currentScoreMultiplier;

    [Header("Game State")]
    [SerializeField] private GameState startingGameState = GameState.Gameplaying;

    [Header("Score")]
    [SerializeField] private float baseScorePerSecond = 10f;
    [SerializeField] private float multiplierIncreasePerSecond = 0.05f;
    [SerializeField] private float maxMultiplier = 10f;

    private GameState currentGameState;

    private float currentScore;
    private float currentScoreMultiplier = 1f;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start() {
        SetGameState(startingGameState);
    }

    private void Update() {
        if (currentGameState != GameState.Gameplaying) {
            return;
        }

        UpdateScore();

    }

    private void UpdateScore() {
        currentScoreMultiplier += multiplierIncreasePerSecond * Time.deltaTime;
        currentScoreMultiplier = Mathf.Min(currentScoreMultiplier, maxMultiplier);

        currentScore += baseScorePerSecond * currentScoreMultiplier * Time.deltaTime;

        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddBonusScore(int amount) {
        currentScore += amount;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }

    public void ResetScore() {
        currentScore = 0f;
        currentScoreMultiplier = 1f;

        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SetGameState(GameState newGameState) {
        if (currentGameState == newGameState) {
            return;
        }

        currentGameState = newGameState;

        switch (currentGameState) {
            case GameState.Gameplaying:
                Time.timeScale = 1f;
                ResetScore();
                break;

            case GameState.GameOver:
                Time.timeScale = 0f;
                OnGameOver?.Invoke(this, EventArgs.Empty);
                break;
        }
    }

    public void EndGame() {
        SetGameState(GameState.GameOver);
    }
}