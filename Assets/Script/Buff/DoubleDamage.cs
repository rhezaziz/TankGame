using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Complete;
public class DoubleDamage : MonoBehaviour, IGiveBuff
{
    [SerializeField] private float Damage;

    public Vector3 position;
    private void OnEnable()
    {
        position = this.transform.position;
    }
    public void GiveBuff(GameObject player)
    {
        Shoot tankShooting = player.GetComponent<Shoot>();

        tankShooting.doubleDamage();

        SpawnManager.instance.spawnObject.Remove(position);

        SpawnManager.instance.startCountSpawnBuff();

        gameObject.SetActive(false);
    }

}
