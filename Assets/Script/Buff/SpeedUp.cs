using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour, IGiveBuff
{

    public Vector3 position;
    private void OnEnable()
    {
        position = this.transform.position;
    }
    public void GiveBuff(GameObject player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        movement.buffSpeed();

       
        SpawnManager.instance.spawnObject.Remove(position);

        SpawnManager.instance.startCountSpawnBuff();


        gameObject.SetActive(false);
    }
}
