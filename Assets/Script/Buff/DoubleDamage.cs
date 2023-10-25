using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Complete;
public class DoubleDamage : MonoBehaviour, IGiveBuff
{
    [SerializeField] private float Damage;

    public void GiveBuff(GameObject player)
    {
        Shoot tankShooting = player.GetComponent<Shoot>();

        tankShooting.doubleDamage();

        gameObject.SetActive(false);
    }

}
