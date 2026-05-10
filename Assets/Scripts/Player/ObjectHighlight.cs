using UnityEngine;

public class ObjectHighlight : MonoBehaviour
{
    Color _startcolor;
    [SerializeField] Renderer _renderer;

    void OnMouseEnter()
    {
        Debug.Log("Highlighting " + this.gameObject);
        _startcolor = _renderer.material.color;
        _renderer.material.color = Color.red;
    }

    void OnMouseExit()
    {
        _renderer.material.color = _startcolor;
    }
}
