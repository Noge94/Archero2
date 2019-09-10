using UnityEngine;

namespace Code
{
    public class EnemyKitter : Enemy
    {    
        
        private const float DODGE_COOLDOWN = 1;
        private const float DODGE_DURATION = 0.05f;
        public float speed;

        public bool attacking = true;
        public int dodgeDirection = 0;
        
        private float timeCounter = 0;
        

        private void Move(Vector3 distance){
            Vector3 movement = distance / distance.magnitude * speed * Time.deltaTime;
            movement = Dodge(movement, dodgeDirection);
            if (distance.magnitude < 5)
            {
               movement = Retreat(movement, distance);
            } else {
                if (distance.magnitude > 10)
                {
                    movement = Approach(movement, distance);
                }
            }
            transform.position += movement;
        }

        private Vector3 Dodge(Vector3 movement, int direction){
            float intermediate = movement.x;
            if (direction == 0){
                movement.x = movement.y;
                movement.y = -intermediate;
            } else {
                movement.x = -movement.y;
                movement.y = intermediate;
            }
            
            return movement;
        }

        private Vector3 Retreat(Vector3 movement, Vector3 distance){
            
            Vector3 direction = distance.normalized;
            movement = -direction * 0.6f + movement * 0.4f; 

            return movement;
        }

        private Vector3 Approach(Vector3 movement, Vector3 distance){
            
            Vector3 direction = distance.normalized;
            movement = direction * 0.5f + movement * 0.5f; 

            return movement;
        }

        void Update(){
            timeCounter += Time.deltaTime;
            //check entity state
            if (attacking == true)
            {
                //check time until dodging state
                if (timeCounter > DODGE_COOLDOWN)
                {
                    attacking = false;
                    timeCounter = 0;
                    dodgeDirection = Random.Range(0,2);
                    Debug.Log("Bad guy: I'll naruto run away from your bullets!");
                }    
            } else {
                Move(SearchPlayer());
                //check time until dodge ends
                if (timeCounter > DODGE_DURATION)
                {
                    attacking = true;
                    timeCounter = 0;
                    Debug.Log("Bad guy: U ded *pew* *pew*");
                }
            }
        }

    }
}