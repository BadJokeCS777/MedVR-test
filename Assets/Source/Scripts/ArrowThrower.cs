using Mirror;
using UnityEngine;

public class ArrowThrower : NetworkBehaviour
{
   [SerializeField] private Arrow _arrowPrefab;
   [SerializeField] private Transform _throwPoint;

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
         CmdThrow();
   }

   [Command]
   private void CmdThrow()
   {
      Arrow arrow = Instantiate(_arrowPrefab, _throwPoint.position, _throwPoint.rotation);
      NetworkServer.Spawn(arrow.gameObject);
   }
}