#import <Foundation/Foundation.h>
#import <FBAudienceNetwork/FBAdSettings.h>

extern "C"
{
    void FBAdSettingsBridgeSetAdvertiserTrackingEnabled(bool advertiserTrackingEnabled)
    {
        [FBAdSettings setAdvertiserTrackingEnabled:advertiserTrackingEnabled];
    }
}