using UnityEngine;

namespace Code
{
    public class Enemy : MonoBehaviour
    {
        public IMovementBehaviour _movementBehaviour;
        public IAttackBehaviour _AttackBehaviour;
        
        public Transform player;

        protected Vector3 SearchPlayer(){
            Vector3 distance = player.position - transform.position;
            distance.z = 0;

            return distance;
        }
    }
}