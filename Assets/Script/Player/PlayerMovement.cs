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
    float r;
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
        TurnHorizontal();
        TurnVertical();
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();

        transform.position += new Vector3(direction.x, 0, direction.y) * Time.deltaTime * Speed;

        Debug.Log(direction);
    }

    public void buffSpeed()
    {
        Speed *= 2;

        StartCoroutine(timerBuff());
    }

    private void TurnVertical()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();

        if (direction.y != 0)
        {
            
            float Target = direction.y * 180f;

            if(!(Target < 0))
            {
                Target = 0f;
            }

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Target, ref r, 0.1f);

            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }

    private void TurnHorizontal()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();

        if(direction.x != 0)
        {
           
            float Target = direction.x * 90f;
            
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Target, ref r, 0.1f);

            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

    }

    IEnumerator timerBuff(float timer = 5f)
    {

        yield return new WaitForSeconds(timer);
        Speed = GetComponent<Player>()._profil.speed;
    }
}
