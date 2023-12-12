using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public Vector3 Forward => transform.forward;
   
    public void DisableRenderer()
    {
        _renderer.enabled = false;
    }

    public void Rotate(Vector3 rotation)
    {
        transform.Rotate(rotation);
    }
}