using UnityEngine;
using System.Collections.Generic;

public class Bottle : MonoBehaviour
{
    [SerializeField] private int capacity = 4;

    [Header("Katmanlar")]
    [SerializeField] private List<Color> layers = new List<Color>();

    [Header("Görsel")]
    [SerializeField] private SpriteRenderer segmentPrefab;
    [SerializeField] private Transform layersContainer;
    [SerializeField] private float segmentHeight = 0.25f;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        RefreshVisual();
    }

    public bool IsEmpty => layers.Count == 0;
    public bool IsFull => layers.Count >= capacity;
    public Color TopColor => layers[layers.Count - 1]; 

    public void AddLayer(Color color)
    {
        layers.Add(color);
        RefreshVisual();
    }


    public void SetSelected(bool isSelected)
    {
        spriteRenderer.color = isSelected ? Color.green : Color.white;
    }

    public void RemoveTopLayer()
    {
        layers.RemoveAt(layers.Count - 1);
        RefreshVisual();
    }

    private void RefreshVisual()
    {
        if (layersContainer == null || segmentPrefab == null)
        {
            Debug.LogError($"{name}: Segment Prefab veya Layers Container atanmamış!", this);
            return;
        }

        // Eski segmentleri temizle
        for (int i = layersContainer.childCount - 1; i >= 0; i--)
        {
            Destroy(layersContainer.GetChild(i).gameObject);
        }

        for(int i = 0; i < layers.Count; i++)
        {
            SpriteRenderer segment = Instantiate(segmentPrefab, layersContainer);
            segment.transform.localPosition = new Vector3(0f, i * segmentHeight, 0f);
            segment.color = layers[i];
        }
    }
}
