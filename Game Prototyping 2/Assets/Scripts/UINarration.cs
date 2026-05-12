using UnityEngine;

public class UINarration : MonoBehaviour
{
    [SerializeField] private GameObject m_textMeshPro;
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private bool m_isImportant;
    private void Start()
    {
        m_playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider collision)
    {
        m_textMeshPro.SetActive(true);
    }
    private void OnTriggerExit(Collider collision)
    {
        m_textMeshPro.SetActive(false);
        if (m_isImportant)
        {
            m_playerController.m_importantEvidence += 1;
            Destroy(gameObject);
        }
    }
}
