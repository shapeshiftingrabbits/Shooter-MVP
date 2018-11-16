using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Transform))]
    public class PlayerController : MonoBehaviour
    {

        private float movementSpeed = 10f;
        private float rotationSpeed = 10f;
        private float movementDeadzone = 0.25f;
        private float rotationDeadzone = 0.25f;
        private bool usingMouseAim = false;
        Transform playerTransform;


        // Use this for initialization
        void Start()
        {
            Cursor.visible = false;
            playerTransform = GetComponent<Transform>();
            ResetPosition();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (AxesToVector2("Mouse X", "Mouse Y") != Vector2.zero)
                usingMouseAim = true;
            else if (AxesToVector2("RotateX", "RotateY") != Vector2.zero)
            {
                usingMouseAim = false;
            }

            Vector2 movementInput = AxesToVector2("Horizontal", "Vertical");
            if (movementInput.magnitude >= movementDeadzone)
            {
                if (movementInput.magnitude > 1f)
                {
                    movementInput = movementInput / movementInput.magnitude;
                }

                Move(movementInput);
            }

            if (usingMouseAim)
            {
                Rotate(
                    (Input.mousePosition - Camera.main.WorldToScreenPoint(playerTransform.position)).normalized,
                    Time.deltaTime
                );
            }
            else
            {
                Vector2 rotationInput = AxesToVector2("RotateX", "RotateY");
                if (rotationInput.magnitude >= rotationDeadzone)
                {
                    Rotate(rotationInput, Time.deltaTime);
                }
            }
        }

        Vector2 AxesToVector2(string XAxisName, string YAxisName)
        {
            return new Vector2(Input.GetAxis(XAxisName), Input.GetAxis(YAxisName));
        }

        void Move(Vector2 movementInput)
        {
            Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y) * movementSpeed * Time.deltaTime;

            playerTransform.position = playerTransform.position + movement;
        }

        void Rotate(Vector2 rotationInput, float deltaTime)
        {
            float angle = Mathf.Atan2(rotationInput.x, rotationInput.y) * Mathf.Rad2Deg;

            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, Quaternion.Euler(0f, angle, 0f), deltaTime * rotationSpeed);
        }

        public void ResetPosition()
        {
            playerTransform.position = new Vector3(0f, 0f, 0f);
        }
    }
}