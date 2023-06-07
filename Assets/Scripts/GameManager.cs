using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Brick[] m_Bricks;
    private PopUpTextController m_PopUpTextController;

    bool b_InstructionTextActive = true;
    public int m_CurrentLevel;
 
    private void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded; // Subscribing to the event 'sceneLoaded'
    }

    private void Update()
    {
        if (b_InstructionTextActive && Input.GetMouseButtonDown(0))
        {
            m_PopUpTextController.HideInstructionText();
            b_InstructionTextActive = false;
        }
    }

    private void LoadLevel(int level)
    {
        m_CurrentLevel = level;

        if (level > 3)
        { SceneManager.LoadScene("Lobby"); }
        else
        {
            SceneManager.LoadScene("Level" + level);
            b_InstructionTextActive = true;
        }
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        m_Bricks = FindObjectsOfType<Brick>();
        m_PopUpTextController = FindObjectOfType<PopUpTextController>();
    }

    public void CheckIfLevelComplete()
    {
        if( ClearedBricks())
        {
            LoadLevel(m_CurrentLevel + 1);
        }
    }

    private bool ClearedBricks()
    {
        for(int i = 0; i<m_Bricks.Length; i++)
        {
            if(m_Bricks[i].gameObject.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
}
