using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeelLock : MonoBehaviour
{
    private const string LockHeel = "lock heel";
    private const string UnlockHeel = "unlock heel";
   
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;
   
    public bool IsLocked { get; private set; }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void Start()
    {
        UpdateButtonText();
    }

    private void OnClick()
    {
        IsLocked = IsLocked == false;

        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        _text.text = IsLocked ? UnlockHeel : LockHeel;
    }
}