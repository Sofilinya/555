using UnityEngine;
using TMPro;

public class GameStateChanger : MonoBehaviour
{
    public int PlayersCount = 2;                     // ���������� �������

    public PlayerChipsCreator PlayersChipsCreator;   // ������ �������� �����
    public PlayersTurnChanger PlayersTurnChanger;    // ������ ����� ���� �������
    public PlayerChipsMover PlayersChipsMover;       // ������ ����������� �����
    public GameField GameField;                      // ������ �������� ����


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
        //SetScreens(true);                               // ���������� ����� ����
    }

    // ����� ��� ���������� ����
    private void EndGame()
    {
        //SetScreens(false);    // ���������� ����� ����� ����
    }

    // ����� ��� ����������� �� ������
    public void RestartGame()
    {
        PlayersChipsCreator.Clear();      // ������� ����� �������
        StartGame();                      // �������� ����� ����
    }

    // ����� ��� ��������� ��������� ������� �������

    public void DoPlayerTurn(int steps)
    {
        int currentPlayerId = PlayersTurnChanger.GetCurrentPlayerId();      // �������� ����� �������� ������
        PlayersChipsMover.MoveChip(currentPlayerId, steps);                 // ������� ����� �������� ������ �� �������� ����� �����

        // ���������, ������ �� ����� ������
        bool isPlayerFinished = PlayersChipsMover.CheckPlayerFinished(currentPlayerId);
        if (isPlayerFinished)
        {                 // ���� ����� �� ������
            //SetWinText(currentPlayerId);          // ������������� ������� � ������
            EndGame();                            // ��������� � ������ ����� ����
        }
        else
        {
            PlayersTurnChanger.MovePlayerTurn();  // ������� ��� ���������� ������
        }
    }
}