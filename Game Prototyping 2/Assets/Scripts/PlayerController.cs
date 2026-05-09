using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_rb;
    private PlayerInput m_playerInput;
    private CharacterController m_cc; //im too lazy to write all that everytime

    [SerializeField] private Transform m_camTransform;
    [SerializeField] private float m_camAngle;
  
    private Vector2 m_input;
    private Vector3 m_move;

    private Vector3 m_playerVelocity;

    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_rotateSpeed;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_playerInput = GetComponent<PlayerInput>();
        m_cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool groundedPlayer = m_cc.isGrounded;

        if (groundedPlayer)
        {
            if (m_playerVelocity.y < -2f)
                m_playerVelocity.y = -2f;
        }

        m_move = new Vector3(m_input.x, 0, m_input.y);
        m_move = Vector3.ClampMagnitude(m_move, 1f);
        m_move = m_camTransform.TransformDirection(m_move);

        if (m_move != Vector3.zero)
            transform.forward = m_move;

        m_playerVelocity.y += -9.8f * Time.deltaTime;

        m_cc.Move((m_move * m_moveSpeed) * Time.deltaTime + Vector3.up * m_playerVelocity.y);
        transform.rotation = Quaternion.Euler(0, m_camTransform.rotation.eulerAngles.y, 0);

    }

    public void Handle_Move(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            m_input = ctx.ReadValue<Vector2>();
            Debug.Log(ctx.ReadValue<Vector2>());
        }
        if (ctx.canceled)
        {
            m_input = ctx.ReadValue<Vector2>();
            Debug.Log(ctx.ReadValue<Vector2>());
        }
    }
}
