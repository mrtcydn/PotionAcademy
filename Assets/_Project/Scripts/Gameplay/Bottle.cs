using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] private int capacity = 4;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSelected(bool isSelected)
    {
        spriteRenderer.color = isSelected ? Color.green : Color.white;
    }
}
