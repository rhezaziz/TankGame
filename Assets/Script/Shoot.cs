using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float moveForce;
    public GameObject bullet;
    public Transform gun;
    public float shootRate;
    public float shootForce;
    public int bulletCount;
    
    private float m_shootRateTimeStamp;
    private int maxBullet;
    private bool buffDamage;
    private float damageBullet;


    
    private void OnEnable()
    {
        maxBullet = GetComponent<Player>()._profil.magazine;

        bulletCount = maxBullet;

        damageBullet = GetComponent<Player>()._profil.Damage;

        UIPlayer.instance.updateInfo("Bullet", bulletCount);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && getCountBullet() != 0)
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                GameObject go = (GameObject)Instantiate(
                bullet, gun.position, gun.rotation);
                go.GetComponent<Bullet>().damage = damageBullet;

                go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);
                m_shootRateTimeStamp = Time.time + shootRate;

                setCountBullet(-1);
                UIPlayer.instance.updateInfo("Bullet", bulletCount);
            }
            
        }
    }

    public int setCountBullet(int value)
    {
        bulletCount += value;

        if (bulletCount >= maxBullet)
        {
            bulletCount = maxBullet;
        }
        else if (bulletCount <= 0)
        {
            bulletCount = 0;
        }
        UIPlayer.instance.updateInfo("Bullet", bulletCount);
        return bulletCount;
    }

    public int getCountBullet()
    {
        return bulletCount;
    }

    public void doubleDamage()
    {
        buffDamage = true;
        damageBullet *= 2;
        StartCoroutine(timerBuff());
    }

    IEnumerator timerBuff(float timer = 5f)
    {
        while (bulletCount != 0 && buffDamage)
        {
            //Dagame
            
            yield return new WaitForSeconds(timer);

            buffDamage = false;
        }
        damageBullet = GetComponent<Player>()._profil.Damage;
        buffDamage = false;
    }
}
