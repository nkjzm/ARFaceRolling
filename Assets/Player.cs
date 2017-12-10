using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;

    [SerializeField]
    float movePower;
    [SerializeField]
    float torquePower;

    [SerializeField]
    float maxAngulaerVelocity;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("おしてる" + transform.forward);
            rigid.AddForce(-transform.right * movePower);
        }
        rigid.AddTorque(-torquePower);
        rigid.angularVelocity = Mathf.Max(rigid.angularVelocity, -maxAngulaerVelocity);
    }

    bool GetOnGround()
    {
        var col = Physics2D.OverlapCircle(transform.position - (Vector3.down * 0.1f), 0.1f, 0);
        return col != null;
    }
}
