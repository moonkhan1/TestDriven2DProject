using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestDriven.PlayTests.Helpers
{
    public class GroundDisableHelper : MonoBehaviour
{
    [SerializeField] Collider2D _collider2D;

    public void SetDisableCollider()
    {
        _collider2D.enabled = false;
    }
}
}


