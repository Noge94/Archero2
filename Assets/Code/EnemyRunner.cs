using UnityEngine;

namespace Code
{
    public class EnemyRunner : Enemy
    {     
        public float speed;

        private void Move(Vector3 distance){
            Vector3 movement = distance / distance.magnitude * speed * Time.deltaTime;
            if (distance.magnitude < movement.magnitude)
            {
                movement = distance;
            }
            transform.position += movement; 
        }

        void Update(){
        
            Vector3 distance = SearchPlayer();
            if (distance.magnitude != 0) {
                Move(distance);
            }
        }

    }
}