using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager : MonoBehaviour
{
    private Bottle selectedBottle;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleClick();
        }
    }

    private void HandleClick()
    {
        Vector2 screenPosition = Mouse.current.position.ReadValue();
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x,screenPosition.y, mainCamera.nearClipPlane));

        Collider2D hit = Physics2D.OverlapPoint(worldPosition);

        if (hit == null) return;

        Bottle clickedBottle = hit.GetComponent<Bottle>();

        if (clickedBottle == null) return;

        if(selectedBottle == null)
        {
            selectedBottle = clickedBottle;
            selectedBottle.SetSelected(true);
        }
        else if(selectedBottle == clickedBottle)
        {
            selectedBottle.SetSelected(false);
            selectedBottle = null;
        }
        else
        {
            TryTransfer(selectedBottle, clickedBottle);
            selectedBottle.SetSelected(false);
            selectedBottle = null;
        }
    }

    private void TryTransfer(Bottle source, Bottle target)
    {
        if (source.IsEmpty)
        {
            Debug.Log("Kaynak şişe boş");
            return;
        }

        if (target.IsFull)
        {
            Debug.Log("Hedef dolu");
            return;
        }

        if (!target.IsEmpty && target.TopColor != source.TopColor)
        {
            Debug.Log("Renkler uyuşmuyor");
            return;
        }

        Color movingColor = source.TopColor;
        target.AddLayer(movingColor);
        source.RemoveTopLayer();
        Debug.Log("Transfer başarılı.");
    }
}
