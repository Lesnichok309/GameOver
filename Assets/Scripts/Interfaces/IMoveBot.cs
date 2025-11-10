using UnityEngine;
public interface IMoveBot
{
    public Transform MoveTarget { set; }
    public float DifAngle { set; }
    public float Speed { get; set; }
    public void Move();
    public void RotateToTarget();
}
