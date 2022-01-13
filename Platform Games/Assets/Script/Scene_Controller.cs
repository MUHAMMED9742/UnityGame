using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Controller : MonoBehaviour
{
   public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public  void Beginning_Level()
    {
        SceneManager.LoadScene(0);
    }
   public void Restart_Level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
