using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour, IGiveBuff
{
    public void GiveBuff(GameObject player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        movement.buffSpeed();

        gameObject.SetActive(false);
    }
}
