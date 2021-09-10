using UnityEngine;

public class RotateHand : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RotateToMouse();
        }
        else
        {
            transform.Rotate(0, 0, Time.deltaTime * 30);
        }
    }

    private void RotateToMouse()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var angle = Mathf.Atan2(mouseWorldPos.y, mouseWorldPos.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
