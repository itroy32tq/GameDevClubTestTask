using PoketZone;
using UnityEngine;

namespace Script.StateMachine
{
    [CreateAssetMenu(fileName = "EnemyStateSeek", menuName = "State/EnemyState/EnemyStateSeek")]
    public class EnemyStateSeek : EnemyState
    {
        [SerializeField, Range(1.5f, 10f)] private float _attackDistance;

        private Vector2 _direction;
        public override void Update()
        {
            _direction = Enemy.GetDistanceToTarget();

            if (!IsCanAttack())
            {
                Enemy.MakeMove(_direction.normalized);
            }
            else
            {
                NeedTransition = true;
                TargetState = AvailableTransitions[0];
            }
        }
        public override void Exit()
        {
            base.Exit();
            Enemy.MakeMove(Vector2.zero);
        }
        private bool IsCanAttack()
        {
            return _direction.SqrMagnitude() <= _attackDistance * _attackDistance;
        }
    }
}