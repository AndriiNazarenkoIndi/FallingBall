using UnityEngine;

public class TowerBuilderSystem : BaseTowerBuilder
{
    private Transform _parent;
    private Vector3 _spawnPosition;
    private Platform _randomPlatform;
    private Quaternion _randomRotate;

    private RandomizeSelectTowerSegment _randomizeSelectTowerSegment;

    public TowerBuilderSystem(GameObject basisPlatform, Transform spawnPoint, Platform[] platforms) : 
        base(basisPlatform, spawnPoint) 
    {
        _parent = spawnPoint;
        _randomizeSelectTowerSegment = new RandomizeSelectTowerSegment(platforms);
    }

    #region Tower level build
    public void StartLevelBuild(Platform platform)
    {
        SetSpawnPosition(out _spawnPosition);
        SpawnStartFinishLevel(platform, _spawnPosition, _parent);
    }

    public void MiddleLevelBuild(int platformCount)
    {
        for (int i = 0; i < platformCount; i++)
        {
            SetNextSpawnPosition(out _spawnPosition);
            RandomSetPlatform();
            RandomPlatformRotate();
            SpawnTowerLevel(_randomPlatform, _spawnPosition, _randomRotate, _parent);
        }
    }

    public void FinishLevelBuild(Platform platform)
    {
        SetNextSpawnPosition(out _spawnPosition);
        SpawnStartFinishLevel(platform, _spawnPosition, _parent);
    }

    public void DeletePlatformSpawn(DeleteObject deletePlatform, float spawnDistance)
    {
        SetDeletePlatformSpawnPosition(spawnDistance);
        SpawnDeletePlatform(deletePlatform, _spawnPosition);
    }

    #endregion

    private void RandomSetPlatform()
    {
        _randomPlatform = _randomizeSelectTowerSegment.ReturnRandomPlatform();
    }

    private void RandomPlatformRotate()
    {
        _randomRotate = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }

    private void SetDeletePlatformSpawnPosition(float spawnDistance)
    {
        SetNextSpawnPosition(out _spawnPosition);
        _spawnPosition.y -= spawnDistance;
    }
}