using Mirror;
using TMPro;
using UnityEngine;

public class Connection : MonoBehaviour
{
    private const string LocalHost = "localhost";
   
    [SerializeField] private TMP_InputField _ip;
    [SerializeField] private NetworkManager _networkManager;

    public void Connect()
    {
        SetAddress();
      
        _networkManager.StartClient();
    }

    public void Host()
    {
        _networkManager.StartHost();
    }

    private void SetAddress()
    {
        string address = _ip.text;

        if (string.IsNullOrEmpty(address))
            address = LocalHost;
      
        _networkManager.networkAddress = address;
    }
}