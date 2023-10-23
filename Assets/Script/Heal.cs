using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Complete;
public class Heal : MonoBehaviour, IGiveBuff
{
    [SerializeField] private float healValue;

    public void GiveBuff(GameObject player)
    {
        //Player profil = player.GetComponent<Player>();
        /*
        float temp = profil.currentHealth + healValue;

        profil.currentHealth = checkHealth(temp, profil._profil.Heath);
        */

        TankHealth tankHealth = player.GetComponent<TankHealth>();

        tankHealth.HealTank(healValue);

        gameObject.SetActive(false);
    }

    /*
    float checkHealth(float value, float maxHealth)
    {
        if(value >= maxHealth)
        {
            return maxHealth;
        }

        return value;
    }
    */
}
