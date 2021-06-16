using System.Collections;
using UnityEngine;

namespace MobileGame.Views
{
    public class CarView : MonoBehaviour
    {
        private const float ACCELERATION_SPEED = 6f;
        private Vector3 _deltaMove = new Vector3(2, 0, 0);
        private Vector3 _startPosition;

        public void Accelerate()
        {
            _startPosition = transform.position;
            var newPosition = _startPosition + _deltaMove;
            StartCoroutine(AccelerateCoroutine(newPosition, ACCELERATION_SPEED));
        }

        private IEnumerator AccelerateCoroutine(Vector3 targetPosition, float speed)
        {
            while (transform.position.x < targetPosition.x)
            {
                transform.position += Time.deltaTime * speed * Vector3.right;
                yield return null;
            }
            
            while (transform.position.x > _startPosition.x)
            {
                transform.position -= Time.deltaTime * speed * Vector3.right;
                yield return null;
            }

        }
    }
}