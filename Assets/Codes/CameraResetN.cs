using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResetN : MonoBehaviour
{
    bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (active)
            {
                this.gameObject.SetActive(false);
                active = false;
            }
            else
            {
                this.gameObject.SetActive(true);
                active = true;
            }
        } 
       
    }
}
