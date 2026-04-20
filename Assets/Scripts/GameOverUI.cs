using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {

    [SerializeField] private Button restartButton;


    private void Awake() {
        restartButton.onClick.AddListener(() => {

            GameManager.Instance.SetGameState(GameManager.GameState.Gameplaying);
            SceneLoader.LoadScene(SceneLoader.Scene.GameScene);
        });


    }

    private void Start() {
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;

        Hide();
    }

    private void GameManager_OnGameOver(object sender, System.EventArgs e) {
        Show();

    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }


}