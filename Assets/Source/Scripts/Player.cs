using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
   private const float DeadZone = 0.01f;
   
   [SerializeField] private float _speed;
   [SerializeField] private float _lookSensitivity;
   [SerializeField] private Transform _head;
   [SerializeField] private KeyCode _forwardButton;

   private Vector3 _mousePosition = Vector3.zero;
   
   private void Update()
   {
      if (isLocalPlayer == false)
         return;

      Vector3 newMousePosition = Input.mousePosition;
      Vector3 mouseDelta = _mousePosition - newMousePosition;
      _mousePosition = newMousePosition;

      if (mouseDelta.sqrMagnitude >= DeadZone)
         RotateHead(mouseDelta);

      if (Input.GetKey(_forwardButton))
         Move();
   }

   private void RotateHead(Vector3 mouseDelta)
   {
      Vector3 rotation = new(mouseDelta.y, -mouseDelta.x, 0f);
      _head.Rotate(_lookSensitivity * Time.deltaTime * rotation);
   }

   private void Move()
   {
      Vector3 forward = _head.forward;
      forward.y = 0f;
      transform.Translate(_speed * Time.deltaTime * forward.normalized);
   }
}
