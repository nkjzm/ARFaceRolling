using UnityEngine;

public class CameraTrailer : MonoBehaviour
{
    [SerializeField]
    Transform target;

    private void Update()
    {
        transform.position = new Vector3(target.position.x, 0, -10);
    }
}
