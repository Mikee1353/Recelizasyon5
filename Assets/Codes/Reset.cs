using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    
    public bool camReversed = false;
    public Camera camF;
    public Camera camR;
    public int repeatTime;
    bool KayriwasHere;
    public AudioSource audi;
    public Scene currentScene;
    public string sceneName;

    private void Start()
    {
        audi = GetComponent<AudioSource>();

        Reset[] ResetScripts = FindObjectsOfType<Reset>();
        int i = 0;
        foreach (Reset rs in ResetScripts)
        {
            if (i > 0)
            {
                Destroy(rs.gameObject);
            }
            i++;
        }

        DontDestroyOnLoad(gameObject);

        Debug.Log("Start");


    }
    void Update()
    {
        if (camReversed)
        {
            KayriwasHere = false;
            camR.gameObject.SetActive(true);
            camF.gameObject.SetActive(false);
        }
        else
        {
            camF.gameObject.SetActive(true);
            camR.gameObject.SetActive(false);
        }

        //Restart
        if (Input.GetKeyDown(KeyCode.R))
        {

            camReversed = !camReversed;
            KayriwasHere = true;
            Restart();
            Debug.Log("1 artt?" + repeatTime);
                    
        }

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName.Contains("Enty"))
        {
            audi.Stop();
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
