
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

using System.Runtime.InteropServices;

namespace com.amazon.mas.cpt.ads
{
    public abstract partial class AmazonMobileAdsImpl
    {
#if __IOS__
        private class AmazonMobileAdsIOS : AmazonMobileAdsDelegatesBase
        {
            private static AmazonLogger logger = new AmazonLogger("AmazonMobileAdsIOS");

            [DllImport ("__Internal")]
            private static extern string nativeRegisterCallback(CallbackDelegate callback);

            [DllImport ("__Internal")]
            private static extern string nativeRegisterEventListener(CallbackDelegate callback);

            [DllImport ("__Internal")]
            private static extern string nativeRegisterCrossPlatformTool(string crossPlatformTool);

            [DllImport ("__Internal")]
            private static extern string nativeSetApplicationKeyJson(string jsonMessage);

            [DllImport ("__Internal")]
            private static extern string nativeRegisterApplicationJson(string jsonMessage);

            [DllImport ("__Internal")]
            private static extern string nativeEnableLoggingJson(string jsonMessage);

            [DllImport ("__Internal")]
            private static extern string nativeEnableTestingJson(string jsonMessage);

            [DllImport ("__Internal")]
            private static extern string nativeEnableGeoLocationJson(string jsonMessage);

            [DllImport ("__Internal")]
            private static extern string nativeCreateFloatingBannerAdJson(string jsonMessage);

            [DllImport ("__Internal")]
            private static extern string nativeCreateInterstitialAdJson(string jsonMessage);

            [DllImport ("__Internal")]
            private static extern string nativeLoadAndShowFloatingBannerAdJson(string jsonMessage);

            [DllImport ("__Internal")]
            private static extern string nativeLoadInterstitialAdJson(string jsonMessage);

            [DllImport ("__Internal")]
            private static extern string nativeShowInterstitialAdJson(string jsonMessage);

            [DllImport ("__Internal")]
            private static extern string nativeCloseFloatingBannerAdJson(string jsonMessage);

            [DllImport ("__Internal")]
            private static extern string nativeIsInterstitialAdReadyJson(string jsonMessage);

            [DllImport ("__Internal")]
            private static extern string nativeAreAdsEqualJson(string jsonMessage);


            protected override void NativeInit()
            {
                //do nothing
            }

            protected override void NativeRegisterCallback(CallbackDelegate callback)
            {
                AmazonMobileAdsIOS.nativeRegisterCallback(callback);
            }

            protected override void NativeRegisterEventListener(CallbackDelegate callback)
            {
                AmazonMobileAdsIOS.nativeRegisterEventListener(callback);
            }

            protected override void NativeRegisterCrossPlatformTool(string crossPlatformTool)
            {
                AmazonMobileAdsIOS.nativeRegisterCrossPlatformTool(crossPlatformTool);
            }

            protected override string NativeSetApplicationKeyJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeSetApplicationKeyJson(jsonMessage);
            }

            protected override string NativeRegisterApplicationJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeRegisterApplicationJson(jsonMessage);
            }

            protected override string NativeEnableLoggingJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeEnableLoggingJson(jsonMessage);
            }

            protected override string NativeEnableTestingJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeEnableTestingJson(jsonMessage);
            }

            protected override string NativeEnableGeoLocationJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeEnableGeoLocationJson(jsonMessage);
            }

            protected override string NativeCreateFloatingBannerAdJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeCreateFloatingBannerAdJson(jsonMessage);
            }

            protected override string NativeCreateInterstitialAdJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeCreateInterstitialAdJson(jsonMessage);
            }

            protected override string NativeLoadAndShowFloatingBannerAdJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeLoadAndShowFloatingBannerAdJson(jsonMessage);
            }

            protected override string NativeLoadInterstitialAdJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeLoadInterstitialAdJson(jsonMessage);
            }

            protected override string NativeShowInterstitialAdJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeShowInterstitialAdJson(jsonMessage);
            }

            protected override string NativeCloseFloatingBannerAdJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeCloseFloatingBannerAdJson(jsonMessage);
            }

            protected override string NativeIsInterstitialAdReadyJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeIsInterstitialAdReadyJson(jsonMessage);
            }

            protected override string NativeAreAdsEqualJson(string jsonMessage)
            {
                return AmazonMobileAdsIOS.nativeAreAdsEqualJson(jsonMessage);
            }

        }
#endif
    }
}
