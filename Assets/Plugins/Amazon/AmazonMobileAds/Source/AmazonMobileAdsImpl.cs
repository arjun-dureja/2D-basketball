
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


#if UNITY_EDITOR || UNITY_IPHONE || UNITY_ANDROID
    #define UNITY_PLATFORM
#endif

#if __ANDROID__
using Android.App;
#endif
#if UNITY_PLATFORM
using UnityEngine;
#endif
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using com.amazon.mas.cpt.ads.json;

namespace com.amazon.mas.cpt.ads 
{
    /// <summary> Provides a lazy-initialized singleton implementation of IAmazonMobileAds. </summary> 

#if UNITY_PLATFORM
    public abstract partial class AmazonMobileAdsImpl : MonoBehaviour, IAmazonMobileAds
#else
    public abstract partial class AmazonMobileAdsImpl : IAmazonMobileAds
#endif
    {
        protected delegate void CallbackDelegate(string jsonMessage);
        static AmazonLogger logger;
        static readonly Dictionary<string, IDelegator> callbackDictionary = new Dictionary<string, IDelegator>();
        static readonly System.Object callbackLock = new System.Object();
        static readonly Dictionary<string, List<IDelegator>> eventListeners = new Dictionary<string, List<IDelegator>>();
        static readonly System.Object eventLock = new System.Object();
        
        private AmazonMobileAdsImpl() {}
        
        public static IAmazonMobileAds Instance {
            get
            { 
                return Builder.instance; 
            }
        }

        private class Builder
        {
            // A static constructor tells the C# compiler not to mark type as beforefieldinit, and thus lazy load this class
            static Builder() {}

            internal static readonly IAmazonMobileAds instance =
#if UNITY_EDITOR
                new AmazonMobileAdsUnityEditor();
#elif UNITY_ANDROID
                AmazonMobileAdsUnityAndroid.Instance;
#elif UNITY_IPHONE
                AmazonMobileAdsUnityIPhone.Instance;
#elif __ANDROID__
                AmazonMobileAdsAndroid.Instance;
#elif __IOS__
                new AmazonMobileAdsIOS();
#else
                new AmazonMobileAdsDefault();
#endif
        }
#if __IOS__
        [ObjCRuntime.MonoPInvokeCallbackAttribute (typeof (CallbackDelegate))]
#endif
        public static void callback(string jsonMessage) 
        {
            Dictionary<string, object> message = null;
            try 
            {
                logger.Debug ("Executing callback");
                message = Json.Deserialize(jsonMessage) as Dictionary<string, object>;
                string callerId = message["callerId"] as string;
                Dictionary<string, object> response = message["response"] as Dictionary<string, object>;
                callbackCaller(response, callerId);
            }
            catch (KeyNotFoundException e)
            {
                logger.Debug("callerId not found in callback");
                throw new AmazonException("Internal Error: Unknown callback id", e);
            }
            catch (AmazonException e)
            {
                logger.Debug("Async call threw exception: " + e.ToString());
            }
        }

        private static void callbackCaller(Dictionary<string, object> response, string callerId)
        {
            IDelegator delegator = null;

            try
            {
                Jsonable.CheckForErrors(response);
                
                lock(AmazonMobileAdsImpl.callbackLock)
                {
                    delegator = AmazonMobileAdsImpl.callbackDictionary[callerId];
                    AmazonMobileAdsImpl.callbackDictionary.Remove(callerId);
                
                    delegator.ExecuteSuccess(response);
                }
            }
            catch (AmazonException e)
            {
                 lock(AmazonMobileAdsImpl.callbackLock)
                 {
                    if (delegator == null) {
                        delegator = AmazonMobileAdsImpl.callbackDictionary[callerId];                        
                    }
                    AmazonMobileAdsImpl.callbackDictionary.Remove(callerId);                 
                    
                    delegator.ExecuteError(e);
                 }
            }
        }

#if __IOS__
        [ObjCRuntime.MonoPInvokeCallbackAttribute (typeof (CallbackDelegate))]
#endif
        public static void FireEvent(string jsonMessage)
        {
            try
            {
                logger.Debug("eventReceived");
                Dictionary<string, object> jsonDict = Json.Deserialize(jsonMessage) as Dictionary<string, object>;
                string eventId = jsonDict["eventId"] as string;
                Dictionary<string, object> response = null;
                
                if(jsonDict.ContainsKey("response"))
                {
                    response = jsonDict["response"] as Dictionary<string, object>;
                    Jsonable.CheckForErrors(response);
                }

                lock(eventLock)
                {
                    foreach (var delegator in eventListeners[eventId])
                    {
                        if(response != null)
                        {
                            delegator.ExecuteSuccess(response);
                        }
                        else
                        {
                            delegator.ExecuteSuccess();
                        }
                    }
                }
            }
            catch (AmazonException e)
            {
                logger.Debug("Event call threw exception: " + e.ToString());
            }
        }
        // AmazonMobileAds API
        public abstract void SetApplicationKey(ApplicationKey applicationKey);
        public abstract void RegisterApplication();
        public abstract void EnableLogging(ShouldEnable shouldEnable);
        public abstract void EnableTesting(ShouldEnable shouldEnable);
        public abstract void EnableGeoLocation(ShouldEnable shouldEnable);
        public abstract Ad CreateFloatingBannerAd(Placement placement);
        public abstract Ad CreateInterstitialAd();
        public abstract LoadingStarted LoadAndShowFloatingBannerAd(Ad ad);
        public abstract LoadingStarted LoadInterstitialAd();
        public abstract AdShown ShowInterstitialAd();
        public abstract void CloseFloatingBannerAd(Ad ad);
        public abstract IsReady IsInterstitialAdReady();
        public abstract IsEqual AreAdsEqual(AdPair adPair);
        public abstract void UnityFireEvent(string jsonMessage);
        // Event API
        public abstract void AddAdCollapsedListener (AdCollapsedDelegate responseDelegate);
        public abstract void RemoveAdCollapsedListener (AdCollapsedDelegate responseDelegate);
        public abstract void AddAdDismissedListener (AdDismissedDelegate responseDelegate);
        public abstract void RemoveAdDismissedListener (AdDismissedDelegate responseDelegate);
        public abstract void AddAdExpandedListener (AdExpandedDelegate responseDelegate);
        public abstract void RemoveAdExpandedListener (AdExpandedDelegate responseDelegate);
        public abstract void AddAdFailedToLoadListener (AdFailedToLoadDelegate responseDelegate);
        public abstract void RemoveAdFailedToLoadListener (AdFailedToLoadDelegate responseDelegate);
        public abstract void AddAdLoadedListener (AdLoadedDelegate responseDelegate);
        public abstract void RemoveAdLoadedListener (AdLoadedDelegate responseDelegate);
        public abstract void AddAdResizedListener (AdResizedDelegate responseDelegate);
        public abstract void RemoveAdResizedListener (AdResizedDelegate responseDelegate);

#if __ANDROID__
        public abstract void SetCurrentAndroidActivity(Activity activity);
#endif
    }
}

