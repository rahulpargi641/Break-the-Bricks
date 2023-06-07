using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField] Button m_StartButton;
    [SerializeField] Button m_QuitButton;

    private void Awake()
    {
        m_StartButton.onClick.AddListener(LoadGame);
        m_QuitButton.onClick.AddListener(QuitGame);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
