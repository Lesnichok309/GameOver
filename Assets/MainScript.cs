using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MainScript : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject player;
    [SerializeField] float _pause;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _livesText;
    [SerializeField] GameObject restarBut;
    bool waveflag;
    private int score;
    int Lives;
    [SerializeField] GameObject[] Respawns;
    // Start is called before the first frame update
    void Start()
    {
        EventSystemScript.OnEnemyDie.AddListener(UpScore);
        Lives = player.GetComponent<PlayerMoveScript>().lives;
        Enemy.GetComponent<EnemyScript>().main = gameObject.GetComponent<MainScript>();
        Enemy.GetComponent<RotateToTargetScript>().Target = player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Lives <= 0)
        {
            Destroy(player);
            _livesText.text = "0";
            restarBut.SetActive(true);
        }
        else
        {
            Lives = player.GetComponent<PlayerMoveScript>().lives;
        }
        _livesText.text ="Lives: "+ Lives.ToString();
        //_scoreText.text ="Score: "+ score.ToString();
        if (!waveflag)
        {
            StartCoroutine(WaveAttak());
        }
     
    }

    
    IEnumerator WaveAttak()
    {
        waveflag = true;
        Instantiate(Enemy, Respawns[Random.Range(0, 4)].transform.position, transform.rotation);
        Instantiate(Enemy, Respawns[Random.Range(0, 4)].transform.position, transform.rotation);
        Instantiate(Enemy, Respawns[Random.Range(0, 4)].transform.position, transform.rotation);
        Instantiate(Enemy, Respawns[Random.Range(0, 4)].transform.position, transform.rotation);
        yield return new WaitForSeconds(_pause);
        if (_pause > 0.1f)
        {
            _pause -= 0.05f;
        }
        else
        {
            _pause = 0.1f;
        }
        waveflag = false;
    }

    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void UpScore(int Bonus)
    {        
        score += Bonus;
        new WaitForSeconds(2);
        _scoreText.text = "Score: " + score.ToString();
    }
}
