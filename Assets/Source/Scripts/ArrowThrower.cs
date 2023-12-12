using Mirror;
using UnityEngine;

public class ArrowThrower : NetworkBehaviour
{
   [SerializeField] private Arrow _arrowPrefab;
   [SerializeField] private ArrowsList _list;
   [SerializeField] private Transform _throwPoint;
   [SerializeField] private ArrowThrowButton _throwButton;

   private void OnEnable()
   {
      _throwButton.Clicked += CmdThrow;
   }

   private void OnDisable()
   {
      _throwButton.Clicked -= CmdThrow;
   }

   [Command]
   private void CmdThrow()
   {
      Arrow arrow = Instantiate(_arrowPrefab, _throwPoint.position, _throwPoint.rotation);
      NetworkServer.Spawn(arrow.gameObject);
      _list.Add(arrow);
   }
}