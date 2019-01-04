
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


namespace com.amazon.mas.cpt.ads
{
    public abstract partial class AmazonMobileAdsImpl
    {
        private class AmazonMobileAdsDefault : AmazonMobileAdsBase
        {
            protected override void Init() {}
            protected override void RegisterCallback() {}
            protected override void RegisterEventListener() {}
            protected override void RegisterCrossPlatformTool() {}
            protected override string NativeSetApplicationKeyJson(string jsonMessage)
            {
                return "{}";
            }
            protected override string NativeRegisterApplicationJson(string jsonMessage)
            {
                return "{}";
            }
            protected override string NativeEnableLoggingJson(string jsonMessage)
            {
                return "{}";
            }
            protected override string NativeEnableTestingJson(string jsonMessage)
            {
                return "{}";
            }
            protected override string NativeEnableGeoLocationJson(string jsonMessage)
            {
                return "{}";
            }
            protected override string NativeCreateFloatingBannerAdJson(string jsonMessage)
            {
                return "{}";
            }
            protected override string NativeCreateInterstitialAdJson(string jsonMessage)
            {
                return "{}";
            }
            protected override string NativeLoadAndShowFloatingBannerAdJson(string jsonMessage)
            {
                return "{}";
            }
            protected override string NativeLoadInterstitialAdJson(string jsonMessage)
            {
                return "{}";
            }
            protected override string NativeShowInterstitialAdJson(string jsonMessage)
            {
                return "{}";
            }
            protected override string NativeCloseFloatingBannerAdJson(string jsonMessage)
            {
                return "{}";
            }
            protected override string NativeIsInterstitialAdReadyJson(string jsonMessage)
            {
                return "{}";
            }
            protected override string NativeAreAdsEqualJson(string jsonMessage)
            {
                return "{}";
            }
        }
    }
}
