using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Complete;
public class DoubleDamage : MonoBehaviour, IGiveBuff
{
    [SerializeField] private float Damage;

    public void GiveBuff(GameObject player)
    {
        TankShooting tankShooting = player.GetComponent<TankShooting>();

        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
