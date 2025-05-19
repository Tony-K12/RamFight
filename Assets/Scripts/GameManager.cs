using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public RamCombat ramA, ramB;
    public GameObject winPanel;
    public TMP_Text winText;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }


    public void DeclareWinner(string winner)
    {
        winPanel.SetActive(true);
        winText.text = $"Winner: {winner}";
    }
}
