using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _score;
    public MainScript main;
    // Start is called before the first frame update
    void Start()
    {
        Vector2.MoveTowards(transform.position, new Vector3(0, 0, 0), 1);
    }

    // Update is called once per frame
    
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMoveScript>().lives--;
            GetScore();
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        //EventSystem.SendEnemyDie(_score);
    }

    public void GetScore()
    {
        main.UpScore(_score);
    }

}
