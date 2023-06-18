using UnityEngine;
using Zenject;

public class EnemyBind : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEnemyData>()
           .FromInstance(new EnemyData())
           .AsCached();
       
    }
}