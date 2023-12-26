using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameStateChanger : MonoBehaviour
{
    public int PlayersCount = 2;                     // ���������� �������

    public PlayerChipsCreator PlayersChipsCreator;   // ������ �������� �����
    public PlayersTurnChanger PlayersTurnChanger;    // ������ ����� ���� �������
    public PlayerChipsMover PlayersChipsMover;       // ������ ����������� �����
    public GameField GameField;                      // ������ �������� ����

    public GameObject GameScreenGO;             // ����� ����
    public Button ThrowButton;              // ������ ������� ������
    public GameObject GameEndScreenGO;          // ����� ����� ����
    public TextMeshProUGUI WinText;                  // ������� � ������

    private void Start()
    {
        FirstStartGame();   // ������ ��������� ��������� ����
    }
    // ����� ��� ������� ������� ���� 
    private void FirstStartGame()
    {
        GameField.FillCellsPositions(); // ��������� ������� ������ �� ������� ����
        StartGame();                    // �������� ����� ���� 
    }

    private void StartGame()
    {
        PlayerChip[] playersChips = PlayersChipsCreator.SpawnPlayersChips(PlayersCount);  // ������ ����� ��� ��������� ����� �������

        PlayersTurnChanger.StartGame(playersChips);     // ������� ������� � ������ ����
        PlayersChipsMover.StartGame(playersChips);      // ����� ��������� ������� ����� �������
        SetScreens(true);                               // ���������� ����� ����
        SetThrowButtonInteractable(true);
    }

    // ����� ��� ���������� ����
    private void EndGame()
    {
        SetScreens(false);    // ���������� ����� ����� ����
    }

    // ����� ��� ����������� �� ������
    public void RestartGame()
    {
        PlayersChipsCreator.Clear();      // ������� ����� �������
        StartGame();                      // �������� ����� ����
    }

    // ����� ��� ��������� ��������� ������� �������
    private void SetScreens(bool inGame)
    {
        GameScreenGO.SetActive(inGame);     // ���� ���� � ��������, ���������� ����� ���� � �������� ����� ����� ����
        GameEndScreenGO.SetActive(!inGame); // ����� �������� ����� ���� � ���������� ����� ����� ���� 
    }

    // ����� ��� ��������� ������� � ������
    private void SetWinText(int playerId)
    {
        WinText.text = $"Player {playerId + 1} WIN!"; // ���������� ����� � ������� ����������� ������
    }

    public void DoPlayerTurn(int steps)
    {
        int currentPlayerId = PlayersTurnChanger.GetCurrentPlayerId();      // �������� ����� �������� ������
        PlayersChipsMover.MoveChip(currentPlayerId, steps);                 // ������� ����� �������� ������ �� �������� ����� �����


        SetThrowButtonInteractable(false);                                  // ��������� ����������� ������� �����

        /*// ���������, ������ �� ����� ������
        bool isPlayerFinished = PlayersChipsMover.CheckPlayerFinished(currentPlayerId);
        if (isPlayerFinished)
        {                 // ���� ����� �� ������
          SetWinText(currentPlayerId);          // ������������� ������� � ������
          EndGame();                            // ��������� � ������ ����� ����
        }
        else
        {
          PlayersTurnChanger.MovePlayerTurn();  // ������� ��� ���������� ������
        }*/
    }

    private void SetThrowButtonInteractable(bool value)
    {
        ThrowButton.interactable = value;     // ��������� ��� ���������� ������ � ����������� �� value
    }

    public void ContinueGameAfterChipAnimation()
    {
        int currentPlayerId = PlayersTurnChanger.GetCurrentPlayerId();                // �������� ����� �������� ������
        bool isPlayerFinished = PlayersChipsMover.CheckPlayerFinished(currentPlayerId); // ����������, ������ �� ����� ������

        // ���� ����� �� ������
        if (isPlayerFinished)
        {
            SetWinText(currentPlayerId);          // ������������� ������� � ������
            EndGame();                            // ��������� � ������ ����� ����
        }
        else
        {
            PlayersTurnChanger.MovePlayerTurn();  // ������� ��� ���������� ������
            SetThrowButtonInteractable(true);     // ��������� ��� ������� �����
        }
    }
}