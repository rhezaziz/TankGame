using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;

    InputAction moveAction;

    [SerializeField] float Speed;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions.FindAction("Move");
    }


    private void Update()
    {
        MovePlayer();
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

    IEnumerator timerBuff(float timer = 5f)
    {

        yield return new WaitForSeconds(timer);
        Speed = GetComponent<Player>()._profil.speed;
    }
}
