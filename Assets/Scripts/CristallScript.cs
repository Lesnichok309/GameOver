using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristallScript : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _dieTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _dieTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * Time.deltaTime*_speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag != collision.gameObject.tag)
        {
            if (collision.TryGetComponent<IDamageble>(out IDamageble iDamage))
            {
                Destroy(gameObject);
                iDamage.TakeDamage(2);
            }
        }


    }
}
