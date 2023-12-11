using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
#if !UNITY_ANDROID
   private const string Horizontal = nameof(Horizontal);
   private const string Vertical = nameof(Vertical);
   private const string Heel = nameof(Heel);
#endif
   
   private const float DeadZone = 0.01f;
   
   [SerializeField] private float _speed;
   [SerializeField] private float _lookSensitivity;
   [SerializeField] private Transform _head;
   [SerializeField] private KeyCode _forwardButton;
   [SerializeField] private HeelLock _heelLock;

   private void Update()
   {
      if (isLocalPlayer == false)
         return;

      Vector3 headRotation;
      
#if !UNITY_ANDROID
      float horizontal = Input.GetAxis(Horizontal);
      float vertical = Input.GetAxis(Vertical);
      float heel = Input.GetAxis(Heel);

      headRotation = new Vector3(-vertical, horizontal, -heel);
#else
      //todo: rotate by android inertial sensors
      
      headRotation = Vector3.zero;
#endif
      
      if (headRotation.sqrMagnitude >= DeadZone)
         RotateHead(headRotation);
      
      if (Input.GetKey(_forwardButton))
         Move();
   }

   private void RotateHead(Vector3 rotation)
   {
      if (_heelLock.IsLocked)
         rotation.z = 0f;
      
      _head.Rotate(_lookSensitivity * Time.deltaTime * rotation);
   }

   private void Move()
   {
      Vector3 forward = _head.forward;
      forward.y = 0f;
      transform.Translate(_speed * Time.deltaTime * forward.normalized);
   }
}