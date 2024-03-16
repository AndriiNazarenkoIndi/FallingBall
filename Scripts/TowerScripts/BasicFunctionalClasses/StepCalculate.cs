using UnityEngine;

public class StepCalculate
{
    private Transform _transformBase;

    public StepCalculate(GameObject baseCore)
    {
        _transformBase = baseCore.GetComponent<Transform>();
    }

    public void CalculateSpawnStep(out float spawnDistance)
    {
        spawnDistance = _transformBase.transform.localScale.y;
    }
}