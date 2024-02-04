using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;

    public GameObject menu;
    public GameObject playBtns;
    public Button dialogue;

    public void Trigger() {
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(info);
    }

    public void MenuOn() {
        menu.SetActive(true);
        playBtns.SetActive(false);
        dialogue.GetComponent<Button>().interactable = false;
    }

    public void MenuBack() {
        menu.SetActive(false);
        playBtns.SetActive(true);
        dialogue.GetComponent<Button>().interactable = true;
    }

    public void MenuMain() {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
