using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMainManager : MonoBehaviour
{
    private void Update()
    {
        
    }

    public void LoadPong() {
        SceneManager.LoadScene("Pong");
    }

    public void LoadArkarnoid() {
        SceneManager.LoadScene("Arkanoid");
    }
}
