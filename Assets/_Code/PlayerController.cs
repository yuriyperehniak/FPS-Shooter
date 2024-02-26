using UnityEngine;

namespace _Code
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float jumpForce = 10f;

        public void Update()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
            var rb = GetComponent<Rigidbody>();

            var movement = new Vector3(horizontalInput, 0, verticalInput) * (moveSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                movement *= 2.0f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump(rb);
            }

            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }

        private void Jump(Rigidbody rb)
        {
            if (rb != null)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}