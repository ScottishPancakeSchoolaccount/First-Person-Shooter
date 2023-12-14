using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
  public void Shooter()
    {
        SceneManager.LoadScene("MovementCamera");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void DeathScreen()
    {
        SceneManager.LoadScene("DeathScreen");
    }
}
