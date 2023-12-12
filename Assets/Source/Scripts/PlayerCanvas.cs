using Mirror;
using UnityEngine;

public class PlayerCanvas : NetworkBehaviour
{
    [SerializeField] private GameObject _canvas;
    
    private void Start()
    {
        if (isLocalPlayer)
            _canvas.SetActive(true);
    }
}