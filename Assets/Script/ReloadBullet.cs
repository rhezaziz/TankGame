using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadBullet : MonoBehaviour, IGiveBuff
{

    public Vector3 position;
    private void OnEnable()
    {
        position = this.transform.position;
    }

    public void GiveBuff(GameObject player)
    {
        Shoot tankShooting = player.GetComponent<Shoot>();
        int ammo = player.GetComponent<Player>()._profil.magazine;

        tankShooting.setCountBullet(ammo);

        SpawnManager.instance.spawnObject.Remove(position);

        SpawnManager.instance.startCountSpawnBullet();

        gameObject.SetActive(false);
    }
}
