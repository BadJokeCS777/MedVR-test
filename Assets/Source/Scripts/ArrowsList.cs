using System.Collections.Generic;
using Mirror;

public class ArrowsList : NetworkBehaviour
{
    private readonly List<Arrow> _arrows = new();
    
    private ObjectsCounter _objectsCounter;
    
    private void Start()
    {
        _objectsCounter = ObjectsCounter.Instance;
    }

    public void Add(Arrow arrow)
    {
        arrow.Destroyed += OnDestroyed;
        _arrows.Add(arrow);
        
        IncreaseObjectsCount();
    }
    
    private void OnDestroyed(Arrow arrow)
    {
        arrow.Destroyed -= OnDestroyed;
        _arrows.Remove(arrow);
        
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