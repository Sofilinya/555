using UnityEngine;

public class PlayersChipsMover : MonoBehaviour
{
    // ������ �������� ����
    public GameField GameField;

    // ������ ����� �������
    private PlayerChip[] _playersChips;

    // ������ ������� ������� �����
    private int[] _playersChipsCellsIds;

    public void StartGame(PlayerChip[] playersChips)
    {
        // ����������� ������ ����� �������
        _playersChips = playersChips;

        // ������ ������ ��� �������� ������� ������� �����
        _playersChipsCellsIds = new int[playersChips.Length];

        // �������� ����� ��� ���������� ������� ���� �����
        RefreshChipsPositions();
    }

    public void RefreshChipsPositions()
    {
        // �������� � ����� �� ���� ������ �������
        for (int i = 0; i < _playersChips.Length; i++)
        {
            // �������� ����� ��� ���������� ������� ����� � ������� i
           // RefreshChipPosition(i);
        }
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
