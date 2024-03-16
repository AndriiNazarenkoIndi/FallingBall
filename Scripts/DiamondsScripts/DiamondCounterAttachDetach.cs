using UnityEngine;

public class DiamondCounterAttachDetach : MonoBehaviour 
{
    [SerializeField] private DiamondsCounter _diamondsCounter;

    private ShopManager _shopManager;
    private EventAttacherDetacher _eventAttacherDetacher = new EventAttacherDetacher();

    private void Start()
    {
        _shopManager = _diamondsCounter.GetShopManager;
        AttachEvents();
    }

    private void AttachEvents()
    {
        _eventAttacherDetacher.AttachDetach(_shopManager, () => _shopManager.BuyExtraLifeEvent += _diamondsCounter.DiamondScoreSub);
    }

    private void DetachEvents()
    {
        _eventAttacherDetacher.AttachDetach(_shopManager, () => _shopManager.BuyExtraLifeEvent -= _diamondsCounter.DiamondScoreSub);
    }

    private void OnDestroy()
    {
        DetachEvents();
    }
}