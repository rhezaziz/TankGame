using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Complete;
public class ReloadBullet : MonoBehaviour, IGiveBuff
{
    public void GiveBuff(GameObject player)
    {
        Shoot tankShooting = player.GetComponent<Shoot>();
        int ammo = player.GetComponent<Player>()._profil.magazine;

        tankShooting.setCountBullet(ammo);

        gameObject.SetActive(false);
    }
}
