using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TMP_Text txtName;
    public TMP_Text txtSentence;
    bool isCoroutineRunning = false;
    Queue<string> sentences = new Queue<string>();
    string currentText;

    public Animator anim;
    public void Begin(Dialogue info) {
        anim.SetBool("isOpen", true);
        txtName.text = info.name;
        foreach(var sentence in info.sentences){
            sentences.Enqueue(sentence);
        }

        Next();
    }

    public void Next() {
        if(isCoroutineRunning) {
            StopAllCoroutines();
            txtSentence.text = currentText;
            isCoroutineRunning = false;
            return;
        }

        if(sentences.Count == 0){
            End();
            return;
        }

        //txtSentence.text = sentences.Dequeue();
        txtSentence.text = string.Empty;
        currentText = sentences.Dequeue();
        StartCoroutine(TypeSentence(currentText));
    }

    IEnumerator TypeSentence(string sentence) {
        isCoroutineRunning = true;
        foreach(var letter in sentence) {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
        isCoroutineRunning = false;
    }

    private void End() {
        anim.SetBool("isOpen", false);
        txtSentence.text = string.Empty;
    }

}
 