using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResetR : MonoBehaviour
{
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
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
