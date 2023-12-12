using System;
using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
#if !UNITY_ANDROID
   private const string Horizontal = nameof(Horizontal);
   private const string Vertical = nameof(Vertical);
   private const string Heel = nameof(Heel);
#endif
   
   private const float DeadZone = 0.01f;
   
   [SerializeField] private float _speed;
   [SerializeField] private float _lookSensitivity;
   [SerializeField] private Head _head;
   [SerializeField] private HeelLock _heelLock;
   [SerializeField] private MoveButton _moveButton;

   private void Start()
   {
      if (isLocalPlayer)
         _head.DisableRenderer();
   }

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
      
      if (_moveButton.IsPressed)
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
      Vector3 forward = _head.Forward;
      forward.y = 0f;
      transform.Translate(_speed * Time.deltaTime * forward.normalized);
   }
}