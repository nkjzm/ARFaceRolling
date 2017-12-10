using UnityEngine;

namespace Crevasse
{
    public class PlayerTrailer : MonoBehaviour
    {
        [SerializeField]
        Transform target;

        [SerializeField]
        float smoothTime = 0.2f;
        Vector3 velocity = Vector3.zero;

        [SerializeField]
        float xOffset;

        void Update()
        {
            // 追従対象オブジェクトのTransformから、目的地を算出
            var targetPos = transform.position;
            targetPos.x = target.position.x + xOffset;

            // 移動
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        }
    }
}