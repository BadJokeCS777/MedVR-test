using Mirror;
using TMPro;
using UnityEngine;

public class ObjectsCounter : NetworkBehaviour
{
    private const string ObjectsCount = "Objects count: ";

    [SerializeField] private TMP_Text _text;

    private int _count = 0;

    public static ObjectsCounter Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void Increase()
    {
        _count++;
        _text.text = ObjectsCount + _count;
    }

    public void Decrease()
    {
        _count--;
        _text.text = ObjectsCount + _count;
    }
}