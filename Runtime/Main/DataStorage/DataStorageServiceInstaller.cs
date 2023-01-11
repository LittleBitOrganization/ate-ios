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
                .To<DataStorageService>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<IDataInfo>()
                .To<InfoDataStorageService>()
                .FromResource("DataInfoReadonly")
                .AsSingle()
                .NonLazy();
        }
    }
}