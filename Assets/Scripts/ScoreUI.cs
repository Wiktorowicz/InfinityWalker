using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start() {
        GameManager.Instance.OnScoreChanged += GameManager_OnScoreChanged;

        Hide();
        Show();
        UpdateVisual();
    }

    private void OnDestroy() {
        if (GameManager.Instance != null) {
            GameManager.Instance.OnScoreChanged -= GameManager_OnScoreChanged;
        }
    }

    private void GameManager_OnScoreChanged(object sender, System.EventArgs e) {
        UpdateVisual();
    }

    private void UpdateVisual() {
        scoreText.text = GameManager.Instance.CurrentScore.ToString();
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }
}