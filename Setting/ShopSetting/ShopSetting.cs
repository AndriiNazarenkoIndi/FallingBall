using UnityEngine;

[CreateAssetMenu(fileName = "ShopSetting", menuName = "Settings/ShopSetting")]
public class ShopSetting : ScriptableObject
{
    [SerializeField] private int _extraLifePrice = 100;

    public int ExtraLifePrice => _extraLifePrice;
}