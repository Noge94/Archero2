using UnityEngine;

namespace Code
{
    public class Enemy : MonoBehaviour
    {
        public IMovementBehaviour _movementBehaviour;
        public IAttackBehaviour _AttackBehaviour;
        
    }
}