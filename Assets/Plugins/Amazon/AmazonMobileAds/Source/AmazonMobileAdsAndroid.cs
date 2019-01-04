
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
using Android.Runtime;
#endif
using System.Runtime.InteropServices;

namespace com.amazon.mas.cpt.ads
{
    public abstract partial class AmazonMobileAdsImpl
    {
#if __ANDROID__
        private class AmazonMobileAdsAndroid : AmazonMobileAdsDelegatesBase
        {
            private static AmazonMobileAdsAndroid instance;
            private static JValue androidActivity;
            
            private AmazonMobileAdsAndroid()
            {
            }
            
            public static AmazonMobileAdsAndroid Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new AmazonMobileAdsAndroid();
                        Java.Lang.JavaSystem.LoadLibrary("AmazonMobileAdsBridge");
                        instance.Start();
                    }
                    
                    return instance;
                }
            }
            
            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeRegisterCallback(CallbackDelegate callback);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeRegisterEventListener(CallbackDelegate callback);


            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeInit();

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeSetApplicationKeyJson(string jsonMessage);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeRegisterApplicationJson(string jsonMessage);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeEnableLoggingJson(string jsonMessage);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeEnableTestingJson(string jsonMessage);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeEnableGeoLocationJson(string jsonMessage);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeCreateFloatingBannerAdJson(string jsonMessage);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeCreateInterstitialAdJson(string jsonMessage);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeLoadAndShowFloatingBannerAdJson(string jsonMessage);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeLoadInterstitialAdJson(string jsonMessage);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeShowInterstitialAdJson(string jsonMessage);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeCloseFloatingBannerAdJson(string jsonMessage);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeIsInterstitialAdReadyJson(string jsonMessage);

            [DllImport ("AmazonMobileAdsBridge")]
            private static extern string nativeAreAdsEqualJson(string jsonMessage);


            protected override void NativeInit()
            {
                AmazonMobileAdsAndroid.nativeInit();
            }

            protected override void NativeRegisterCallback(CallbackDelegate callback)
            {
                AmazonMobileAdsAndroid.nativeRegisterCallback(callback);
            }

            protected override void NativeRegisterEventListener(CallbackDelegate callback)
            {
                AmazonMobileAdsAndroid.nativeRegisterEventListener(callback);
            }

            protected override void NativeRegisterCrossPlatformTool(string crossPlatformTool)
            {
            }

            protected override string NativeSetApplicationKeyJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeSetApplicationKeyJson(jsonMessage);
            }

            protected override string NativeRegisterApplicationJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeRegisterApplicationJson(jsonMessage);
            }

            protected override string NativeEnableLoggingJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeEnableLoggingJson(jsonMessage);
            }

            protected override string NativeEnableTestingJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeEnableTestingJson(jsonMessage);
            }

            protected override string NativeEnableGeoLocationJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeEnableGeoLocationJson(jsonMessage);
            }

            protected override string NativeCreateFloatingBannerAdJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeCreateFloatingBannerAdJson(jsonMessage);
            }

            protected override string NativeCreateInterstitialAdJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeCreateInterstitialAdJson(jsonMessage);
            }

            protected override string NativeLoadAndShowFloatingBannerAdJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeLoadAndShowFloatingBannerAdJson(jsonMessage);
            }

            protected override string NativeLoadInterstitialAdJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeLoadInterstitialAdJson(jsonMessage);
            }

            protected override string NativeShowInterstitialAdJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeShowInterstitialAdJson(jsonMessage);
            }

            protected override string NativeCloseFloatingBannerAdJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeCloseFloatingBannerAdJson(jsonMessage);
            }

            protected override string NativeIsInterstitialAdReadyJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeIsInterstitialAdReadyJson(jsonMessage);
            }

            protected override string NativeAreAdsEqualJson(string jsonMessage)
            {
                return AmazonMobileAdsAndroid.nativeAreAdsEqualJson(jsonMessage);
            }

            
            [DllImport ("AmazonMobileAdsBridge")]
            private static extern void nativeSetCurrentAndroidActivity(JValue activity);
            
            public override void SetCurrentAndroidActivity(Activity activity)
            {
                Start();
                AmazonMobileAdsAndroid.androidActivity = new JValue(activity);
                AmazonMobileAdsAndroid.nativeSetCurrentAndroidActivity(androidActivity);
            }
        }
#endif
    }
}

