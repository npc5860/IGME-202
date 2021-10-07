using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager : MonoBehaviour
{
    GameObject[] helices;
    [SerializeField] GameObject helixPrefab; //ref to prefab in Assets > Models, set in Inspector
    private Helix helix;  //reference to the script component of the instantiated helixPrefab 
    private const int numHelices = 100;
    private bool randRadius; //true for random radius, false for random center 

    // Start is called before the first frame update
    void Start()
    {
    
        // this part illustrates the use of uniform random choices for each helix's center position, radius, color, and height
                
        helices = new GameObject[numHelices];
        for(int i=0; i < helices.Length; i++)
        {
            helices[i] = Instantiate(helixPrefab, Vector3.zero, Quaternion.identity);
            helices[i].transform.position = new Vector3(Gaussian(0f, 5f), 0f, Gaussian(0f, 5f)); //Exercise 7:  change to Gaussian Distribution
            helix = helices[i].GetComponent<Helix>();
            helix.radius = GetNonUniform(); //Exercise 7:  change to Non-Uniform Distribution
            helix.color = Random.ColorHSV();
            helix.height = Gaussian(75f, 3f);  //Exercise 7:  change to Gaussian
            helix.width = Random.Range(.01f, .1f); // Random.Range(.01f, .1f);  //Exercise 7:  change to Uniform Distribution
            helix.numWinds = (int) GetNonUniform();  //Exercise 7:  change to Non-Uniform Distribution
            helix.cw = Random.Range(0f, 1f) < 0.5f;  //Exercise 7:  change to Uniform Distribution
            helix.GenHelix();
        }

        randRadius = true; 
    }

    float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);
        float gaussValue = Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
                           Mathf.Sin(2.0f * Mathf.PI * val2);
        return mean + stdDev * gaussValue;
    }

    private float GetNonUniform()
    {
        float pick = Random.Range(0f, 1f);
        if (pick < .6f)
        {
            return Random.Range(1f, 4f);
        }
        else if (pick < .9) //and pick >= .6
        {
            return Random.Range(4f, 8f);
        }
        else //pick >= .9
        {
            return Random.Range(8f, 10f);
        }
    }
}
