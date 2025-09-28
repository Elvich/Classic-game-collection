using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TicTacToeButton : MonoBehaviour
{
    [SerializeField] private TicTacToe _ticTacToe;
    [SerializeField] private TMP_Text _text;

    [SerializeField] private int _x;
    [SerializeField] private int _y;
    
    void Start()
    {
        NewGame();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) NewGame();
    }

    private void NewGame()
    {
        _text.text = "";
    }

    public void Check()
    {
        string text = _ticTacToe.NextStap(_x, _y);
        if (text == "")  return;
        _text.text = text;
    }
}
