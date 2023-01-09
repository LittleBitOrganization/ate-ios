using Zenject;

namespace ATE
{
    public class ATEInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<ATEPopupService>()
                .AsSingle()
                .NonLazy();
        }
    }
}