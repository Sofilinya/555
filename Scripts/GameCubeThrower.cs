using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCubeThrower : MonoBehaviour
{
    public GameStateChanger GameStateChanger;  // Скрипт изменения состояния игры
    public GameCube GameCubePrefab;            // Префаб для создания кубика
    public Transform GameCubePoint;            // Точка, где будет появляться кубик

    private GameCube _gameCube;                // Созданный объект кубика

    void Start()
    {
        CreateGameCube();   // Создаём новый кубик при запуске игры
    }

    private void CreateGameCube()
    {
        _gameCube = Instantiate(GameCubePrefab, GameCubePoint.position, GameCubePoint.rotation);    // Создаём новый кубик в указанной позиции и с указанным углом вращения
        _gameCube.HideCube();                                                                       // Скрываем кубик, чтобы его не было видно в начале игры
    }

    public void ThrowCube()
    {
        int cubeValue = _gameCube.ThrowCube();    // Получаем случайное значение броска кубика
        GameStateChanger.DoPlayerTurn(cubeValue); // Вызываем метод изменения состояния игры и передаём значение броска кубика
    }
}
