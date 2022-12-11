using UnityEngine;
using Zenject;

public class DiInnstaller : MonoInstaller
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Artillery artillery;
    public override void InstallBindings()
    { 
        BindBulleFactory();
        BindArtillery();
        
    }

    private void BindBulleFactory()
    {
        Container
            .BindFactory<Vector3, Bullet, Bullet.Factory>()
            .FromComponentInNewPrefab(bullet)
            .AsSingle();
    }

    private void BindArtillery()
    {
        var artilleryOnScene = Container.InstantiatePrefabForComponent<Artillery>(artillery);

        Container
            .Bind<Artillery>()
            .FromInstance(artilleryOnScene)
            .AsSingle();
    }
}