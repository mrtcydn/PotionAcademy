using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] GameObject winPanel;

    private void Awake()
    {
        winPanel.SetActive(false);
    }

    private void OnEnable()
    {
        levelManager.LevelCompleted += ShowWinPanel;
    }

    private void OnDisable()
    {
        levelManager.LevelCompleted -= ShowWinPanel;
    }

    private void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void OnNextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
