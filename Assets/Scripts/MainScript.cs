using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainScript : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
