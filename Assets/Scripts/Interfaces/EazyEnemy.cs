using UnityEngine;

public class EazyEnemy : BaseEnemy
{
    void FixedUpdate()
    {
        RotateToTarget();
        Move();
    }
    public override void Move()
    {
        transform.Translate(Vector2.right * Time.deltaTime * Speed);
    }
    public override void RotateToTarget()
    {
        Vector2 direction = Vector2.zero;
        if (target != null)
        {
            direction = target.position - transform.position;
        }
        else
        {
            Debug.LogError("Lose target", transform);
            this.enabled = false;
        }

        float Angle = Vector2.SignedAngle(Vector2.right, direction);
        transform.eulerAngles = new Vector3(0, 0, Angle + difAngle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag != collision.gameObject.tag)
        {
            if (collision.gameObject.TryGetComponent<IDamageble>(out IDamageble playerDamage))
            {
                playerDamage.TakeDamage(1);
                Die();
            }
        }
    }
}
