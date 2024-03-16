using UnityEngine;

public class TowerAssembler : MonoBehaviour
{
    [SerializeField] private Transform _towerSpawnPoint;
    [SerializeField] private GameObject _base;

    [Header("Platform types")]
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private DeleteObject _deletePlatform;

    [Header("Middle level spawn setting")]
    [SerializeField][Range(1, 50)] private int _middleLevelTowerCount = 15;
    [SerializeField] private Platform[] _platforms;

    private TowerBuilderSystem _towerBuilderSystem;
    private float _deletePlatformSpawnDistance = 50.0f;

    private void Awake()
    {
        InitBuilderSystem();
        TowerBuild();
    }

    private void InitBuilderSystem()
    {
        _towerBuilderSystem = new TowerBuilderSystem(_base, _towerSpawnPoint, _platforms);
    }

    private void TowerBuild()
    {
        _towerBuilderSystem.StartLevelBuild(_spawnPlatform);
        _towerBuilderSystem.MiddleLevelBuild(_middleLevelTowerCount);
        _towerBuilderSystem.FinishLevelBuild(_finishPlatform);
        _towerBuilderSystem.DeletePlatformSpawn(_deletePlatform, _deletePlatformSpawnDistance);
    }
}