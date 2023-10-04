using PoketZone;
using UnityEngine;

namespace Script.StateMachine
{
    [CreateAssetMenu(fileName = "EnemyStateIdle", menuName = "State/EnemyState/EnemyStateIdle")]
    public class EnemyStateIdle : EnemyState
    {
        [SerializeField, Range(0f, 25f)] float visibilityDistance;
        public override void Update()
        {
            if (IsTargetExist() && IsPlayerSight())
            {
                NeedTransition = true;
                TargetState = AvailableTransitions[0];
            }
        }
        private bool IsTargetExist()
        {
            return AvailableTransitions[0] != null && Enemy.Target != null;
        }
        private bool IsPlayerSight()
        {
            return Enemy.GetDistanceToTarget().sqrMagnitude <= visibilityDistance * visibilityDistance;
        }
    }
}