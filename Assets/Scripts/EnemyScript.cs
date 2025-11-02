using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float Health { get; private set; } = 1;
    [SerializeField] float _speed;
    [SerializeField] int _score;
    public MainScript main;
    
    
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

    public void GetScore()
    {
        main.UpScore(_score);
    }

    
}
