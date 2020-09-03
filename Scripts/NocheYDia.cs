using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NocheYDia : MonoBehaviour
{
    private Light luz;
    public float velocidad = 10;
    private GameObject sol, luna;

    // Start is called before the first frame update
    void Start()
    {
        sol = GameObject.Find("Sol");
        luna = GameObject.Find("Luna");
        luz = GetComponent<Light>();
        StartCoroutine(SubeLuz());
        
    }
    private IEnumerator SubeLuz()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            //sol.transform.Translate(Vector3.up * velocidad*5 * Time.deltaTime);
            sol.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, sol.GetComponent<SpriteRenderer>().color.a - velocidad * Time.deltaTime);
            luna.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, luna.GetComponent<SpriteRenderer>().color.a + velocidad * Time.deltaTime);
            luz.intensity = luz.intensity - (velocidad * Time.deltaTime);
            
            if (luz.intensity <= 0.3f)
            {
                //sol.SetActive(false);
                //luna.SetActive(true);
                StartCoroutine(BajaLuz());
                break;
            }
                
        }
    }
    private IEnumerator BajaLuz()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            // sol.transform.Translate(Vector3.right * velocidad * 15 * Time.deltaTime);
            sol.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, sol.GetComponent<SpriteRenderer>().color.a + velocidad * Time.deltaTime);
            luna.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, luna.GetComponent<SpriteRenderer>().color.a - velocidad * Time.deltaTime);
            luz.intensity = luz.intensity + (velocidad * Time.deltaTime);
            
            if (luz.intensity >=1.4f)
            {
                //sol.SetActive(true);
                //luna.SetActive(false);
                StartCoroutine(SubeLuz());
                break;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
