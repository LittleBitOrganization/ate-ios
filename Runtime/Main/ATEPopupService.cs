using DataStorage;
using LittleBit.Modules.CoreModule;
using Zenject;

namespace ATE
{
    public class ATEPopupService : IInitializable
    {
        private readonly IDataStorageService _dataStorageService;
        private readonly StorageData<ATEData> _dataWrapper;
        private readonly NativePopupFactory _nativePopupFactory;

        private const string DataKey = "ATE";

        public ATEPopupService(IDataStorageService dataStorageService)
        {
            _dataStorageService = dataStorageService;

            _dataWrapper = _dataStorageService.CreateDataWrapper<ATEData>(this, DataKey);

            _nativePopupFactory = new NativePopupFactory();
        }

        public void Initialize()
        {
            if (!_dataWrapper.Value.AdvertiserTrackingEnabled)
                ShowPopup();
        }

        private void ShowPopup()
        {
            _nativePopupFactory.Create()
                .SetContent("Your data will be used to measure advertising efficiency.")
                .SetTitle("Allow 'App' to track your activity across other companies' apps and websites?")
                .AddPositiveButton("Allow", () => SetAdvertiserTrackingResponse(true))
                .AddNegativeButton("Ask App Not to Track", () => SetAdvertiserTrackingResponse(false))
                .Show();
        }

        private void SetAdvertiserTrackingResponse(bool response)
        {
            _dataWrapper.Value.AdvertiserTrackingEnabled = response;
            _dataWrapper.Save();
        }
    }
}