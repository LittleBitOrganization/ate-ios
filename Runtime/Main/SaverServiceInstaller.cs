using LittleBit.Modules.CoreModule;
using LittleBit.Modules.SaveModule;
using Zenject;

namespace ATE
{
    public class SaverServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ILifecycle>()
                .To<Lifecycle>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<ISaverService>()
                .To<SaverService>()
                .AsSingle()
                .NonLazy();
        }
    }
}