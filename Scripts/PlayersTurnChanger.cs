using UnityEngine;
using TMPro;

public class PlayersTurnChanger : MonoBehaviour
{
    // ������� ��� ����������� �������� ������
    public TextMeshProUGUI PlayerText;

    // ������ ����� ���� �������
    private PlayerChip[] _playersChips;

    // ����� �������� ������
    private int _currentPlayerId;

public void StartGame(PlayerChip[] playersChips)
{
    // ����������� ������ ����� �������
    _playersChips = playersChips;

    // �������� ������ ����� ����� -1
    _currentPlayerId = -1;

    // �������� ����� ��� �������� � ���������� ������
    MovePlayerTurn();
}

public int GetCurrentPlayerId()
{
    // �������� ����� �������� ������
    return _currentPlayerId;
}

public void MovePlayerTurn()
{
    // ����������� ����� �������� ������ �� 1
    _currentPlayerId++;

    // ���� ����� ���� ������ ��� ����� ���������� ����� �������
    if(_currentPlayerId >= _playersChips.Length)
    {
        // �������� ����� �������� ������
        _currentPlayerId = 0;
    }
    // �������� ����� ��� ��������� ������� � ������� ������
    SetPlayerText(_currentPlayerId);
}

private void SetPlayerText(int playerId)
{
    // ������� ���������� ����� �������� ������
    PlayerText.text = $"����� {playerId + 1}";
}



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
