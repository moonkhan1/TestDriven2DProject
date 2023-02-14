using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Movements;
using UnityEngine;

namespace TestDriven.Concretes.Movemenets
{
    public class JumpWithForce : IJumpDal
    {
        readonly Rigidbody2D _rb2D;
        public JumpWithForce(Rigidbody2D rb2D)
        {
            _rb2D = rb2D;
        }

        public void JumpProcess(float value)
        {
            float JumpForceValue = value * Time.deltaTime;
            _rb2D.AddForce(Vector3.up * JumpForceValue);
        }
       


    }

    public class JumpWithVelocity : IJumpDal
    {
        readonly Rigidbody2D _rb2D;
        public JumpWithVelocity(Rigidbody2D rb2D)
        {
           _rb2D = rb2D;
        }

        public void JumpProcess(float value)
        {
            float JumpForceValue = value * Time.deltaTime;
            _rb2D.velocity = Vector3.up * JumpForceValue;
        }
       


    }

    public class JumpWithTransformPos : IJumpDal
    {
        readonly Transform _transform;
        public JumpWithTransformPos(Transform transform)
        {
            _transform = transform;
        }

        public void JumpProcess(float value)
        {
            float JumpForceValue = value * Time.deltaTime;
            _transform.position += Vector3.up * JumpForceValue;
        }
       


    }
}