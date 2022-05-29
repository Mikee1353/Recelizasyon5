using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightN : MonoBehaviour
{
    [SerializeField] Transform startPos;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            transform.Translate(new Vector2(-3, 0) * Time.deltaTime);
        }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("BumN"))
        {
            transform.position = pos;
            Debug.Log("orospuçlcu");
        }
    }
}
