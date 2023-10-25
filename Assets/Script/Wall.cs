using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wall : MonoBehaviour, IReceiveHit
{
    // Start is called before the first frame update

    public bool isBreak = false;

    [SerializeField] private float HealthWall = 100;

    public float currentHealth;


    public void Damage(float damage)
    {
        if (isBreak)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
