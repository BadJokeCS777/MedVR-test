using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawner : NetworkBehaviour
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Button _spawnButton;

    private void OnEnable()
    {
        _spawnButton.onClick.AddListener(CmdSpawn);
    }

    private void OnDisable()
    {
        _spawnButton.onClick.RemoveListener(CmdSpawn);
    }

    [Command]
    private void CmdSpawn()
    {
        Character character = Instantiate(_characterPrefab, _spawnPoint.position, Quaternion.identity);
        NetworkServer.Spawn(character.gameObject);
        CharactersList.Instance.Add(character);
    }
}