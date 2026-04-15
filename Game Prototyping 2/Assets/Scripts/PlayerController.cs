using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private PlayerInput m_playerInput;

    private Vector2 m_input;
    private Vector3 m_move;
    private float m_speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        m_input = m_playerInput.actions.FindAction("Move").ReadValue<Vector2>();
    }

    private void Handle_Move(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {

        }
    }
}
