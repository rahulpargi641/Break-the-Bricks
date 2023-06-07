using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D m_Rigidbody2D { get; private set; }

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
