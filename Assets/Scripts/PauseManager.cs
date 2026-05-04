using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject pausePanel;

    [Header("Buttons")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    [Header("Scenes")]
    [SerializeField] private string gameSceneName;
    [SerializeField] private string menuSceneName;

    private bool isPaused = false;

    private void Start()
    {
        Time.timeScale = 1f;
        isPaused = false;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (resumeButton != null)
            resumeButton.onClick.AddListener(Resume);

        if (restartButton != null)
            restartButton.onClick.AddListener(Restart);

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitToMenu);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
            Resume();
        else
            Pause();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;

        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;

        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    private void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameSceneName);
    }

    private void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}