using System;
using UnityEngine;

[Serializable]
public class BaseEnemy : BaseDamageble, IMoveBot
{

    [Header("Move")]
    [SerializeField] protected Transform moveTarget;
    [SerializeField] protected float difAngle;
    [SerializeField] protected float speed;
    public Transform MoveTarget { set { moveTarget = value; } }
    public float DifAngle { set { difAngle = value; } }
    public float Speed { get { return speed; } set { speed = value; } }

    [Header("Score")]
    [SerializeField] protected float dieScore;
    void FixedUpdate()
    {
        RotateToTarget();
        Move();
    }
    public virtual void Move()
    {
        transform.Translate(Vector2.right * Time.deltaTime * Speed);
    }

    public virtual void RotateToTarget()
    {
        Vector2 direction = Vector2.zero;
        if (moveTarget != null)
        {
            direction = moveTarget.position - transform.position;
        }
        else
        {
            Debug.LogError("Lose target", transform);
            this.enabled = false;
        }

        float angle = Vector2.SignedAngle(Vector2.right, direction);
        transform.eulerAngles = new Vector3(0, 0, angle + difAngle);
    }
}
