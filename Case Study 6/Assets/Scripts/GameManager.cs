using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject earth; 

    public GameObject calipso; //set in the Inspector

    private CalipsoControl _calipsoControl;
    private OctahedronSphere _octahedronSphere;

    // Start is called before the first frame update
    void Start()
    {
        _calipsoControl = calipso.GetComponent<CalipsoControl>();
        _octahedronSphere = earth.GetComponent<OctahedronSphere>();
    }

    // Update is called once per frame
    void Update()
    {
        //Exercise 6 will require the implementation of keyboard event-driven method calls to change +/- the orbital radius in CalipsoControl, 
        //and the timescale in both CalipsoControl and Octahedron Sphere
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _calipsoControl.radius += 10 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _calipsoControl.radius -= 10 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _calipsoControl.timeScale += _calipsoControl.timeScale * 0.5f * Time.deltaTime;
            _octahedronSphere.timeScale += _octahedronSphere.timeScale * 0.5f * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _calipsoControl.timeScale -= _calipsoControl.timeScale * 0.5f * Time.deltaTime;
            _octahedronSphere.timeScale -= _octahedronSphere.timeScale * 0.5f * Time.deltaTime;
        }
    }

    void OnGUI()
    { 
        GUI.color = Color.white;
        GUI.skin.box.fontSize = 20;
        GUI.skin.box.wordWrap = false;
        var y = 10;
        var height = 60;

        //note:  must use (int) or else the float digits flicker

        //Exercise 6 will require that latitude and longitude be computed and displayed 

        int phi = (int) (Mathf.Asin(calipso.transform.position.y / calipso.transform.position.magnitude) * Mathf.Rad2Deg);
        
        GUI.Box(new Rect(10, y, 300, height), "Elevation Angle " + phi);
        y += height;
        
        GUI.Box(new Rect(10, y, 300, height), $"Latitude {Mathf.Abs(phi)} degrees {(phi >= 0 ? "North" : "South")}");
        y += height;

        //NOTE:  we can't use this

        //theta = Mathf.Rad2Deg * Mathf.Atan2(calipso.transform.position.z, calipso.transform.position.x);  // 0 <= theta < 360

        //because it is the earth beneath the satellite that is rotating

        //and we can't we use rotation.y, because it isn't an angle, it is a component of a quaternion 

        int theta = (int)earth.transform.rotation.eulerAngles.y;
        var theta180 = theta > 180 ? theta - 360 : theta;

        GUI.Box(new Rect(10, y, 300, height), "Azimuthal Angle " +  theta180);  // -180 < azimuthal angle <= 180  
        y += height;
        
        GUI.Box(new Rect(10, y, 300, height), $"Longitude {Mathf.Abs(theta180)} degrees {(theta180 >= 0 ? "East" : "West")}");
    }
}