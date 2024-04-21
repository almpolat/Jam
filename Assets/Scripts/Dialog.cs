using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI dialogText;

    public GameObject dialogCanvas;

    public string[] firstDialog;
    public string[] secondDialog;
    public string[] thirdDialog;
    public string[] fourthDialog;
    public string[] fifthDialog;

    private Queue<Array> dialogs = new Queue<Array>();

    private string[] currentDialog;

    public float textSpeed;
    private int sentenceIndex;

    void Start()
    {
        dialogs.Enqueue(firstDialog);
        dialogs.Enqueue(secondDialog);  
        dialogs.Enqueue(thirdDialog);
        dialogs.Enqueue(fourthDialog);
        dialogs.Enqueue(fifthDialog);
            


        dialogText.text = string.Empty;

        StartDialoge();

        currentDialog = firstDialog;
    }


    void Update()
    {
        //currentDialog = (string[])GetLastItem(dialogs);
      
        if (dialogs != null) { currentDialog = (string[])dialogs.Peek(); }

      
        
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogText.text == currentDialog[sentenceIndex])
            {
                NextSentence();
            }

            else
            {
                StopAllCoroutines();
                dialogText.text = currentDialog[sentenceIndex];

            }

            if(dialogText.text == currentDialog[currentDialog.Length-1]) 
            {
                dialogs.Dequeue();
               
                //currentDialog = secondDialog;
                sentenceIndex = 0;  
            }
        }
    }


    void StartDialoge()
    {
        sentenceIndex = 0;
        //StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentDialog[sentenceIndex].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextSentence()
    {
        if (sentenceIndex < currentDialog.Length - 1)
        {
            //dialogCanvas.SetActive(true);
            sentenceIndex++;
            dialogText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetDialog()
    {
        sentenceIndex = 0;
    }


    static T GetLastItem<T>(Queue<T> queue)
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        // Peek at the last item without removing it
        T lastItem = default(T);
        foreach (T item in queue)
        {
            lastItem = item;
        }

        return lastItem;
    }
}

