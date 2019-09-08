using UnityEngine;

namespace Code
{
    public class Enemy : MonoBehaviour
    {
        public IMovementBehaviour _movementBehaviour;
        public IAttackBehaviour _AttackBehaviour;
        
        protected Vector3 SearchPlayer(){
            Vector3 distance = Player.instance.transform.position - transform.position;
            distance.z = 0;

            return distance;
        }
    }
}