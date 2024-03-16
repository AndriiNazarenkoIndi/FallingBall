using UnityEngine;
using Zenject;

public class InputSystemInstaler : MonoInstaller
{
    public override void InstallBindings()
    {
        SwitchInputSystem();
    }

    private void SwitchInputSystem()
    {
        switch (SystemInfo.deviceType)
        {
            case DeviceType.Handheld:
                SetMobileInputSystem();
                break;
            default:
                SetMobileInputSystem();
                break;
        }
    }

    private void SetMobileInputSystem()
    {
        Container.Bind<IInput>().To<MobileInputSystem>().FromNew().AsSingle();
    }

    //Не передбачає застосування (додано в тестовому режимі)
    private void SetDesktopInputSystem()
    {
        Container.Bind<IInput>().To<DesktopInputSystem>().FromNew().AsSingle();
    }
}