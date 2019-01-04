
/* 
* Copyright 2014 Amazon.com,
* Inc. or its affiliates. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the
* "License"). You may not use this file except in compliance
* with the License. A copy of the License is located at
*
* http://aws.amazon.com/apache2.0/
*
* or in the "license" file accompanying this file. This file is
* distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
* CONDITIONS OF ANY KIND, either express or implied. See the
* License for the specific language governing permissions and
* limitations under the License.
*/

#if __ANDROID__
using Android.App;
#endif
using System.Collections;

namespace com.amazon.mas.cpt.ads 
{
    public delegate void AdCollapsedDelegate(Ad adObject);
    public delegate void AdDismissedDelegate(Ad adObject);
    public delegate void AdExpandedDelegate(Ad adObject);
    public delegate void AdFailedToLoadDelegate(Ad adObject);
    public delegate void AdLoadedDelegate(Ad adObject);
    public delegate void AdResizedDelegate(AdPosition adPosition);

    public interface IAmazonMobileAds
    {
        // AmazonMobileAds API
        void SetApplicationKey(ApplicationKey applicationKey);
        void RegisterApplication();
        void EnableLogging(ShouldEnable shouldEnable);
        void EnableTesting(ShouldEnable shouldEnable);
        void EnableGeoLocation(ShouldEnable shouldEnable);
        Ad CreateFloatingBannerAd(Placement placement);
        Ad CreateInterstitialAd();
        LoadingStarted LoadAndShowFloatingBannerAd(Ad ad);
        LoadingStarted LoadInterstitialAd();
        AdShown ShowInterstitialAd();
        void CloseFloatingBannerAd(Ad ad);
        IsReady IsInterstitialAdReady();
        IsEqual AreAdsEqual(AdPair adPair);
        void UnityFireEvent(string jsonMessage);

        // Event API
        void AddAdCollapsedListener (AdCollapsedDelegate responseDelegate);
        void RemoveAdCollapsedListener (AdCollapsedDelegate responseDelegate);
        void AddAdDismissedListener (AdDismissedDelegate responseDelegate);
        void RemoveAdDismissedListener (AdDismissedDelegate responseDelegate);
        void AddAdExpandedListener (AdExpandedDelegate responseDelegate);
        void RemoveAdExpandedListener (AdExpandedDelegate responseDelegate);
        void AddAdFailedToLoadListener (AdFailedToLoadDelegate responseDelegate);
        void RemoveAdFailedToLoadListener (AdFailedToLoadDelegate responseDelegate);
        void AddAdLoadedListener (AdLoadedDelegate responseDelegate);
        void RemoveAdLoadedListener (AdLoadedDelegate responseDelegate);
        void AddAdResizedListener (AdResizedDelegate responseDelegate);
        void RemoveAdResizedListener (AdResizedDelegate responseDelegate);
#if __ANDROID__
        void SetCurrentAndroidActivity(Activity activity);
#endif
    }
}

