using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Movements;
using UnityEngine;

public class MoveWithTransformDal : IMoverDal
{
    readonly Transform _transform;
    public MoveWithTransformDal(Transform transform)
    {
        _transform = transform;
    }

    public void MoveAction(float value)
    {
        _transform.Translate(value * Vector2.right);
    }
}

public class MoveWithRigidbodyDal : IMoverDal
{
    readonly Rigidbody2D _rigidBody2D;
    public MoveWithRigidbodyDal(Rigidbody2D rigidBody2D)
    {
        _rigidBody2D = rigidBody2D;
    }

    public void MoveAction(float value)
    {
        _rigidBody2D.MovePosition(value * Vector2.right);
    }
}
