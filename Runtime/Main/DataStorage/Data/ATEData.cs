using System;
using LittleBit.Modules.CoreModule;

namespace DataStorage
{
    [Serializable]
    public class ATEData : Data
    {
        public bool AdvertiserTrackingEnabled;

        public ATEData()
        {
            AdvertiserTrackingEnabled = false;
        }
    }
}