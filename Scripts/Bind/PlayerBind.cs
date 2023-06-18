using UnityEngine;
using Zenject;

public class PlayerBind : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IUseCase>()
            .FromInstance(new UseCase(new PlayerData()))
            .AsCached();
     

    }
  
}