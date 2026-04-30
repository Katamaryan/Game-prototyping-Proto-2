using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float m_zoomSpeed;
    [SerializeField] private float m_zoomLerpSpeed; // makes a smoth transition between 2 values
    [SerializeField] private float m_minDistance;
    [SerializeField] private float m_maxDistance;

    [SerializeField] private CinemachineCamera m_cam;
    [SerializeField] private CinemachineOrbitalFollow m_orbital;
    private Vector2 m_scrollDelta;

    private float m_currentZoom;
    private float m_targetZoom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_cam = GetComponent<CinemachineCamera>();
        m_orbital = m_cam.GetComponent<CinemachineOrbitalFollow>();

        m_targetZoom = m_currentZoom = m_orbital.Radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_scrollDelta.y !=0)
        {
            if (m_orbital != null)
            {
                m_targetZoom = Mathf.Clamp(m_orbital.Radius - m_scrollDelta.y * m_zoomSpeed, m_minDistance, m_maxDistance); //Clamp ensures the value is between 2 given values
                m_scrollDelta = Vector2.zero;
            }
        }    

        m_currentZoom = Mathf.Lerp(m_currentZoom, m_targetZoom, m_zoomLerpSpeed * Time.deltaTime);
        if (m_orbital != null) m_orbital.Radius = m_currentZoom;
    }

    public void Handle_ZoomPerformed(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            m_scrollDelta = ctx.ReadValue<Vector2>();
        }
    }


}
