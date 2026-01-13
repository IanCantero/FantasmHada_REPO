using System.Collections;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    bool isPlayerInRange;
    bool didDialogueStart;
    int lineIndex;

    [SerializeField] float typingSpeed = 0.05f;

    [Header("UI")]
    [SerializeField] GameObject dialogueMark;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TMP_Text dialogueText;

    [Header("Dialogue")]
    [SerializeField, TextArea(4, 6)] string[] dialogueLines;

    public bool CanInteract => isPlayerInRange;

    public void Interact()
    {
        if (!didDialogueStart)
            StartDialogue();
        else if (dialogueText.text == dialogueLines[lineIndex])
            NextLine();
        else
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];
        }
    }

    void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;

        StartCoroutine(ShowLine());
    }

    void NextLine()
    {
        lineIndex++;

        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
