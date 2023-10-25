using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("pindahScene", 5f);
    }

    void pindahScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
