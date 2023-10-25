using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayer : MonoBehaviour
{

    public static UIPlayer instance;

    public GameObject parentInfo;

    public TMPro.TMP_Text jmlHealth, jmlBullet, jmlDead;

    private void Awake()
    {
        Debug.Log("Awake");
        instance = this;
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
                jmlHealth.text = Mathf.Abs(value).ToString();
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
