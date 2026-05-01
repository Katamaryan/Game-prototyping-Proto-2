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
    [SerializeField] private CinemachineOrbitalFollow m_orbital;
    [SerializeField] private float m_camAngle;
  
    private Vector2 m_input;
    private Vector3 m_move;
    
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_rotateSpeed;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_playerInput = GetComponent<PlayerInput>();
        m_orbital = GameObject.Find("ThirdPersonCamera").GetComponent<CinemachineOrbitalFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        //m_rb.MovePosition();

        Vector3 moveDirection = m_camTransform.forward.normalized * m_input + m_camTransform.right.normalized * m_input;
        moveDirection = transform.TransformDirection(moveDirection);
 




        m_rb.rotation = Quaternion.Euler(0, m_camTransform.rotation.eulerAngles.y, 0);
        if (m_input == Vector2.up)
        {
            
            m_rb.MovePosition(m_rb.position += transform.forward * (moveDirection.magnitude * m_moveSpeed * Time.deltaTime));

        }

        else if (m_input == Vector2.right)
        {
            m_rb.MovePosition(m_rb.position += transform.right * (moveDirection.magnitude * m_moveSpeed * Time.deltaTime));
        }

        else if (m_input == Vector2.down)
        {
            m_rb.MovePosition(m_rb.position += -transform.forward * (moveDirection.magnitude * m_moveSpeed * Time.deltaTime));
        }

        else if (m_input == Vector2.left)
        {
            m_rb.MovePosition(m_rb.position += -transform.right * (moveDirection.magnitude * m_moveSpeed * Time.deltaTime));
        }



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
