using UnityEngine;
public interface IMoveBotStrategy
{
    public Transform MoveTarget { set; }
    public float DifAngle { set; }
    public float Speed { get; set; }
    public void Move();
    public void RotateToTarget();

    public void NewInit(float newDifAngle, float newSpeed)
    {
        DifAngle = newDifAngle;
        Speed = newSpeed;
    }

}
