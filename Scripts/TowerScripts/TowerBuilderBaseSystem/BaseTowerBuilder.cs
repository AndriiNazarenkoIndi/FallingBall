using UnityEngine;

public abstract class BaseTowerBuilder
{
    private Transform _spawnPoint;
    private StepCalculate _stepCalculate;
    private Vector3 _nextPosition;
    private Vector3 _position;
    private float _spawnStep;
    private Quaternion _fixedRotate = Quaternion.Euler(0, 0, 0);

    public BaseTowerBuilder(GameObject basisPlatform, Transform spawnPoint)
    {
        InitStepCalculate(basisPlatform, out _spawnStep);
        _spawnPoint = spawnPoint;
    }

    private void InitStepCalculate(GameObject basisPlatform, out float spawnStep)
    {
        _stepCalculate = new StepCalculate(basisPlatform);
        _stepCalculate.CalculateSpawnStep(out spawnStep);
    }

    protected virtual void SpawnTowerLevel(Platform platform, Vector3 spawnPosition, Quaternion rotate, Transform parent)
    {
        Object.Instantiate(platform, spawnPosition, rotate, parent);
    }

    protected virtual void SpawnStartFinishLevel(Platform platform, Vector3 spawnPosition, Transform parent)
    {
        SpawnTowerLevel(platform, spawnPosition, _fixedRotate, parent);
    }

    protected virtual void SpawnDeletePlatform(DeleteObject deletePlatform, Vector3 spawnPosition)
    {
        Object.Instantiate(deletePlatform, spawnPosition, Quaternion.identity);
    }

    protected virtual void SetSpawnPosition(out Vector3 position)
    {
        position = _spawnPoint.transform.position;
        _nextPosition = position;
    }

    protected virtual void SetNextSpawnPosition(out Vector3 nextSpawnPosition)
    {
        _nextPosition.y -= _spawnStep;
        nextSpawnPosition = SetNewPosition(_spawnPoint.position.x, _nextPosition.y, _spawnPoint.position.z);
    }

    private Vector3 SetNewPosition(float positionX, float positionY, float positionZ)
    {
        _position.x = positionX;
        _position.y = positionY;
        _position.z = positionZ;
        return _position;
    }
}