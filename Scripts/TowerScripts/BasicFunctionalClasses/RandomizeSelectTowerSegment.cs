using UnityEngine;

public class RandomizeSelectTowerSegment
{
    private Platform[] _platforms;
    private int _countPlatform;

    public RandomizeSelectTowerSegment(Platform[] platforms)
    {
        _platforms = platforms;
        _countPlatform = _platforms.Length;
    }

    public Platform ReturnRandomPlatform()
    {
        return _platforms[Random.Range(0, _countPlatform)];
    }
}