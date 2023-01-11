using LittleBit.Modules.CoreModule;
using LittleBit.Modules.SaveModule;
using Zenject;

namespace DataStorage
{
    public class SaveServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IDataSaver>()
                //.To<JsonDotNetSaver>()
                .To<JsonDataSaver>()
                .AsSingle()
                .Lazy();
            
            Container
                .Bind<ISaveService>()
                .To<SaveService>()
                .AsSingle()
                .NonLazy();
        }
    }
}