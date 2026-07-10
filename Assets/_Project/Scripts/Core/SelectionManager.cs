using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager : MonoBehaviour
{
    private Bottle selectedBottle;

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
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x,screenPosition.y,Camera.main.nearClipPlane));

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
            Debug.Log($"Hedef seçildi: {clickedBottle.name} (transfer mantığı Hafta 4'te gelecek)");
            selectedBottle.SetSelected(false);
            selectedBottle = null;
        }
    }
}
