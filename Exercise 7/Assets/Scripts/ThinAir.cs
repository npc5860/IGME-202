using System;
using UnityEngine;

public class ThinAir : MonoBehaviour
{
    private float _altitude;
    private Vector3 _pos;
    private Vector3 _vel;

    private void Start()
    {
        _altitude = 5.5f;
        _pos = new Vector3(0, _altitude, 0);
        _vel = Vector3.zero;
        transform.position = _pos;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            _altitude -= 0.01f;
            _pos = new Vector3(transform.position.x, _altitude, transform.position.z);
        }
        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            _altitude += 0.01f;
            _pos = new Vector3(transform.position.x, _altitude, transform.position.z);
        }

        _pos += _vel * Time.deltaTime;
        transform.position = _pos;
    }

    public void WindVelocity(float windSpeed, float windDirection)
    {
        _vel = new Vector3(Mathf.Sin(windDirection), 0, Mathf.Cos(windDirection)) * windSpeed;
    }
}
