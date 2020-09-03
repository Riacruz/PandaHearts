using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrivacyPolicy : MonoBehaviour
{
    public GameObject privacyES, privacyEN;

    void Start()
    {
        //PlayerPrefs.SetInt("PrivacyPolicy", 0); //debug
        if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            privacyEN.SetActive(false);
            privacyES.SetActive(true);
        }

        if (PlayerPrefs.HasKey("PrivacyPolicy"))
        {
            if (PlayerPrefs.GetInt("PrivacyPolicy") == 1)
            {
                privacyEN.SetActive(false);
                privacyES.SetActive(false);
                SceneManager.LoadScene("MainScene");

            }
        }

    }

    public void OnClickAccept()
    {
        PlayerPrefs.SetInt("PrivacyPolicy", 1);
        GetComponent<AudioSource>().Play();
        Invoke("CargarNivel", GetComponent<AudioSource>().clip.length);
       

    }

    void CargarNivel()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }


}
