using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField] float _speed;
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed * Input.GetAxis("Horizontal"),Space.World);
        transform.Translate(Vector2.up * Time.deltaTime * _speed * Input.GetAxis("Vertical"),Space.World);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0,255),0, Random.Range(0, 255));
    }
}
