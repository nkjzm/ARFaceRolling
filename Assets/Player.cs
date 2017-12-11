using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

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

    [SerializeField]
    Text label;


    [SerializeField]
    new SpriteRenderer renderer;
    [SerializeField]
    Sprite close, open;

    void Start()
    {
        UnityARSessionNativeInterface.ARFaceAnchorUpdatedEvent += FaceUpdated;
    }

    void FaceUpdated(ARFaceAnchor anchorData)
    {
        Dictionary<string, float> currentBlendShapes = anchorData.blendShapes;
        var power = currentBlendShapes["jawOpen"];
        label.text = "jawOpen(raw): " + power;

        if (power < 0.2f)
        {
            renderer.sprite = close;
        }
        else
        {
            rigid.AddForce(-transform.right * power * movePower);
            renderer.sprite = open;
        }
    }

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
