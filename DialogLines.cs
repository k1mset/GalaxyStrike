using TMPro;
using UnityEngine;

public class DialogLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextlines;
    [SerializeField] TMP_Text dialogText;

    int currentLine = 0;

    public void NextDialogLine()
    {
        currentLine++;
        dialogText.text = timelineTextlines[currentLine];
    }
}
