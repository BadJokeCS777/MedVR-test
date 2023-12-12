using System.Collections.Generic;
using UnityEngine;

public class CharactersList : MonoBehaviour
{
    private List<Character> _characters;

    public int Count => _characters.Count;
    
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

    public void Add(Character character)
    {
        character.Destroyed += OnDestroyed;
        _characters.Add(character);
    }

    public void DeleteAll()
    {
        foreach (Character character in _characters)
        {
            character.Destroyed -= OnDestroyed;
            character.Destroy();
        }

        _characters = new List<Character>();
    }
    
    private void OnDestroyed(Character character)
    {
        character.Destroyed -= OnDestroyed;
        _characters.Remove(character);
    }
}