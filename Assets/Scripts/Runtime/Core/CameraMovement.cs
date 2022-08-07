using UnityEngine;
using UnityEngine.InputSystem;

namespace HuntroxGames
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] InputAction moveAction;

        private void Start()
        {
            moveAction.Enable();
        }

        private void Update()
        {
            var x = moveAction.ReadValue<Vector2>().x * speed * Time.deltaTime;
            var z = moveAction.ReadValue<Vector2>().y * speed * Time.deltaTime;
            transform.Translate(x, 0, z);
        }
    }
}
