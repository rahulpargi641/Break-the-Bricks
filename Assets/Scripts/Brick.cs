using UnityEngine;
using TMPro;

public class Brick : MonoBehaviour
{
    [SerializeField] TextMeshPro m_BreakPointNo;

    private int m_BreakPoint;

    private void Awake()
    {
        int.TryParse(m_BreakPointNo.text, out m_BreakPoint);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball)
            Hit();
    }

    private void Hit()
    {
        m_BreakPoint--;
        m_BreakPointNo.text = m_BreakPoint.ToString();

        if(m_BreakPoint == 0)
            gameObject.SetActive(false);

        FindObjectOfType<GameManager>().CheckIfLevelComplete();
    }
}
