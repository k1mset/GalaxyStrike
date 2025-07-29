using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;

    int score = 0;

    public void ModifyScore(int amt)
    {
        score += amt;
        scoreboardText.text = score.ToString();
    }
}
