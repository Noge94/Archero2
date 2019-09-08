using UnityEngine;

namespace Code
{
    public class InputController : MonoBehaviour
    {
        public static InputController instance;
        public Vector3 stick = Vector3.zero;

        private bool attacking = false;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance);
            }
        }
        
        void Update()
        {
            stick = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                stick.y += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                stick.y -= 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                stick.x += 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                stick.x -= 1;
            }

            if (stick.magnitude != 0)
            {
                StopAttacking();
                stick = stick / stick.magnitude;
            }
            else
            {
                StartAttacking();
            }
        }

        private void StopAttacking()
        {
            if (!attacking)
            {
                return;
            }
            else
            {
                attacking = false;
                Debug.Log("Stop attacking uwu");
            }
        }

        private void StartAttacking()
        {
            if (attacking)
            {
                return;
            }
            else
            {
                attacking = true;
                Debug.Log("I attack now hehehe");
            }
        }
    }
}