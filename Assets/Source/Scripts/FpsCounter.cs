using Mirror;
using TMPro;
using UnityEngine;

public class FpsCounter : NetworkBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Update()
    {
        if (isLocalPlayer)
            _text.text = "FPS: " + (1f / Time.deltaTime).ToString("0");
    }
}