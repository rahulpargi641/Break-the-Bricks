using UnityEngine;

public class PopUpTextController : MonoBehaviour
{
    [SerializeField] GameObject m_InstructionTextGO;
 
    public void HideInstructionText()
    {
        m_InstructionTextGO.SetActive(false);
    }
}
