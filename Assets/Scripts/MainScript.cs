using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainScript : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject player;
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
   
}
