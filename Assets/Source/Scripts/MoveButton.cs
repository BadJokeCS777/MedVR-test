using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   [SerializeField] private Image _targetImage;
   [SerializeField] private Color _defaultColor = Color.white;
   [SerializeField] private Color _pressedColor = Color.grey;
   
   public bool IsPressed { get; private set; }
   
   public void OnPointerDown(PointerEventData eventData)
   {
      UpdateState(true, _pressedColor);
   }

   public void OnPointerUp(PointerEventData eventData)
   {
      UpdateState(false, _defaultColor);
   }

   private void Start()
   {
      UpdateState(false, _defaultColor);
   }

   private void UpdateState(bool isPressed, Color color)
   {
      IsPressed = isPressed;
      _targetImage.color = color;
   }
}