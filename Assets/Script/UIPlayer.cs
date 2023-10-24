using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayer : MonoBehaviour
{

    public static UIPlayer instance;

    public GameObject parentInfo;

    TMPro.TMP_Text jmlHealth, jmlBullet, jmlDead;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        jmlHealth = parentInfo.transform.Find("Health").GetComponentInChildren<TMPro.TMP_Text>();
        jmlDead = parentInfo.transform.Find("Dead").GetComponentInChildren<TMPro.TMP_Text>();
        jmlBullet = parentInfo.transform.Find("Bullet").GetComponentInChildren<TMPro.TMP_Text>();

    }

    public void startInfo(float Health, float Bullet)
    {
       
        this.jmlBullet.text = Bullet.ToString();
        this.jmlHealth.text = Health.ToString();
    }

    public void updateInfo(string infoValue , float value)
    {
        switch(infoValue)
        {
            case "Health":
                jmlHealth.text = value.ToString();
                break;

            case "Dead":
                jmlDead.text = value.ToString();
                break;

            case "Bullet":
                jmlBullet.text = value.ToString();
                break;

            default:
                break;
        }
    }


}
