using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewDialogueScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public AudioSource audSrc;
    private string currentDia;
    public AudioClip one;
    public AudioClip two;
    public AudioClip three;
    public float musicCounter = 1;

    private int index;
    void Start()
    {
        textComponent.text = string.Empty;
        audSrc = GetComponent<AudioSource>();
        StartDialogue();

        audSrc.clip = one;
        audSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            musicCounter++;

            if (textComponent.text == lines[index])
            {
                NextLine();
            }

            if (musicCounter == 2)
            {
                audSrc.Stop();
                audSrc.clip = two;
                audSrc.Play();
            }
            else if (musicCounter == 3)
            {
                audSrc.Stop();
                audSrc.clip = three;
                audSrc.Play();
            }
            else if (musicCounter > 3)
            {
                audSrc.Stop();
            }
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ChangeDia(AudioClip music)
    {
        audSrc.Stop();
        audSrc.clip = music;
        audSrc.Play();
    }
}
