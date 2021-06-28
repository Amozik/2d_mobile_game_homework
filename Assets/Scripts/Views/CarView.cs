using DG.Tweening;
using UnityEngine;

namespace MobileGame.Views
{
    public class CarView : MonoBehaviour
    {
        private const float ACCELERATION_SPEED = .7f;
        private Vector3 _deltaMove = new Vector3(2, 0, 0);
        private Vector3 _startPosition;

        public void Accelerate()
        {
            _startPosition = transform.position;
            var newPosition = _startPosition + _deltaMove;
            transform.DOLocalMove(newPosition, ACCELERATION_SPEED).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutCubic);
        }
    }
}