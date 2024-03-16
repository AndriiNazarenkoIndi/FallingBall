using System;
using UnityEngine;

public class RandomSetMaterial : MonoBehaviour
{
    [Header("Basic Material")]
    [SerializeField] private Material _standartPlatformMaterial;
    [SerializeField] private Material _standartDangerSegmentMaterial;
    [SerializeField] private Material _standartCylinderMaterial;

    [Header("Platforms Materials")]
    [SerializeField] private Material[] _platformsMaterials;

    [Header("Danger Segment Materials")]
    [SerializeField] private Material[] _dangerSegmentMaterial;

    [Header("Cylinder Materials")]
    [SerializeField] private Material[] _cylinderMaterialMaterial;

    private int _randomArrayElementNumber;

    //Перевизначення розміру масивів матеріалів при зміні кількості у будь-якому
    private void OnValidate()
    {
        Array.Resize(ref _dangerSegmentMaterial, _platformsMaterials.Length);
        Array.Resize(ref _cylinderMaterialMaterial, _platformsMaterials.Length);
    }

    private void Awake()
    {
        RandomSettingMaterial();
    }

    private void RandomSettingMaterial()
    {
        _randomArrayElementNumber = UnityEngine.Random.Range(0, _platformsMaterials.Length);

        SetColor(_platformsMaterials[_randomArrayElementNumber], 
                 _dangerSegmentMaterial[_randomArrayElementNumber], 
                 _cylinderMaterialMaterial[_randomArrayElementNumber]);
    }

    private void SetColor(Material platform, Material dangerSegment, Material cylinder)
    {
        _standartPlatformMaterial.color = platform.color;
        _standartDangerSegmentMaterial.color = dangerSegment.color;
        _standartCylinderMaterial.color = cylinder.color;
    }
}