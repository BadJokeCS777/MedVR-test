using System.Collections.Generic;
using Mirror;

public class CharactersList : NetworkBehaviour
{
    private List<Character> _characters;
    
    private ObjectsCounter _objectsCounter;

    public static CharactersList Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _characters = new List<Character>();
        Instance = this;
    }

    private void Start()
    {
        _objectsCounter = ObjectsCounter.Instance;
    }

    public void Add(Character character)
    {
        character.Destroyed += OnDestroyed;
        _characters.Add(character);
        
        IncreaseObjectsCount();
    }

    public void DeleteAll()
    {
        foreach (Character character in _characters)
        {
            character.Destroyed -= OnDestroyed;
            character.Destroy();
        
            DecreaseObjectsCount();
        }

        _characters = new List<Character>();
    }
    
    private void OnDestroyed(Character character)
    {
        character.Destroyed -= OnDestroyed;
        _characters.Remove(character);
        
        DecreaseObjectsCount();
    }

    [ClientRpc]
    private void IncreaseObjectsCount()
    {
        _objectsCounter.Increase();
    }

    [ClientRpc]
    private void DecreaseObjectsCount()
    {
        _objectsCounter.Decrease();
    }
}