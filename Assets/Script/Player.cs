using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float currentHealth, currentSpeed, currentDamage;

    public profil _profil;

    void initValueTankPlayer()
    {
        this.currentDamage = _profil.Damage;
        this.currentHealth = _profil.Heath;
        this.currentSpeed = _profil.speed;
    }


    

    void Start()
    {
        initValueTankPlayer();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IGiveBuff>() != null)
        {
            IGiveBuff buff = other.GetComponent<IGiveBuff>();

            buff.GiveBuff(this.gameObject);
        }
    }
}

[System.Serializable]
public class profil
{
    public string namePlayer;
    public float Damage;
    public float Heath;
    public float speed;
    public int magazine;

}