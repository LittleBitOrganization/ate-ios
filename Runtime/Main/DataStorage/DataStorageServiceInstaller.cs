using LittleBit.Modules.CoreModule;
using LittleBit.Modules.StorageModule;
using Zenject;

namespace DataStorage
{
    public class DataStorageServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IDataStorageService>()
                .FromSubContainerResolve()
                .ByMethod(BindByMethod)
                .AsSingle()
                .NonLazy();
        }

        private void BindByMethod(DiContainer container)
        {
            container
                .Bind<IDataStorageService>()
                .To<DataStorageService>()
                .AsSingle()
                .NonLazy();
            
            container
                .Bind<IDataInfo>()
                .To<InfoDataStorageService>()
                .FromResource("DataInfoReadonly")
                .AsSingle()
                .NonLazy();
            
            container.Resolve<IDataStorageService>();
        }
    }
}