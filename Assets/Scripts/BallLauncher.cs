using System.Collections;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_SpawnPos;
    [SerializeField] float m_LaunchDelay = 0.1f;
    [SerializeField] int m_Balls = 100;
    [SerializeField] float m_BallSpeed = 100f;

    private Rigidbody2D m_Rigidbody2D;

    bool b_BallsLaunched = false;
    Vector2 m_BallDirection = new Vector2(5f,5f);

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>(); 
    }


    private void Update()
    {
        if (! b_BallsLaunched && Input.GetMouseButtonDown(0))
            StartCoroutine(LaunchBalls());
    }

    public IEnumerator LaunchBalls()
    {
        b_BallsLaunched = true;

        for(int i = 0; i < m_Balls; i++)
        {
            GameObject ball = Instantiate(m_BallPrefab, m_SpawnPos.position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(m_BallDirection * m_BallSpeed);

            yield return new WaitForSeconds(m_LaunchDelay);
        }
    }

    private void ResetLauncher()
    {
        transform.position = new Vector2(0f, transform.position.y);
        m_Rigidbody2D.velocity = Vector2.zero;
    }
}
