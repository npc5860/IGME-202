using UnityEngine;

public class CreateClockNumbers : MonoBehaviour
{
    [SerializeField]
    private TextMesh _clockNumberPrefab;

    private void Start()
    {
        for (var i = 1; i <= 12; i++)
        {
            var angle = (90 + (i * -30)) * Mathf.Deg2Rad;
            const float radius = 3.3f;
            var x = Mathf.Cos(angle) * radius;
            var y = Mathf.Sin(angle) * radius;

            var clockNumber = Instantiate(_clockNumberPrefab, new Vector3(x, y), Quaternion.identity);
            clockNumber.text = i.ToString();
        }
    }
}
