using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float rotateSpeed = 2f;
    public Transform Player;
    private Vector3 lookDir;


    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDir = mousePos - Player.transform.position;
        //lookDir.x = 0f;
        //lookDir.z = 0f;
        lookDir.y = 0f;
       // Vector2 direct = new Vector2(mousePos.x - Player.position.x, mousePos.y - Player.position.y);
        //Player.transform.up = direct;
        Player.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.LookRotation(lookDir), rotateSpeed * Time.deltaTime);
    }
}
