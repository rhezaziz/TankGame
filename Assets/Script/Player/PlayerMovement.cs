using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;

    InputAction moveAction;

    Rigidbody rb;

    public float m_Speed = 12f;                 // How fast the tank moves forward and back.
    public float m_TurnSpeed = 180f;

    [SerializeField] float Speed;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions.FindAction("Move");

        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        MovePlayer();
        //TurnHorizontal();
        //TurnVertical();
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();

        transform.position += new Vector3(direction.x, 0, direction.y) * Time.deltaTime * Speed;
    }

    public void buffSpeed()
    {
        Speed *= 2;

        StartCoroutine(timerBuff());
    }

    private void TurnVertical()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = direction.x * m_TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, Mathf.Clamp(turn, 180f, -180f), 0f);

        // Apply this rotation to the rigidbody's rotation.
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void TurnHorizontal()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = direction.y * m_TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, Mathf.Clamp(turn, -90f, 90f), 0f);

        // Apply this rotation to the rigidbody's rotation.
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    IEnumerator timerBuff(float timer = 5f)
    {

        yield return new WaitForSeconds(timer);
        Speed = GetComponent<Player>()._profil.speed;
    }
}
