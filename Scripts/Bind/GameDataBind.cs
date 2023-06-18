using UnityEngine;
using Zenject;

public class GameDataBind : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IGameData>()
           .FromInstance(new GameData())
           .AsCached();
    }
}