
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
using System.Collections.Generic;
using System.Diagnostics;
using com.amazon.mas.cpt.ads.json;

namespace com.amazon.mas.cpt.ads 
{
    public abstract partial class AmazonMobileAdsImpl
    {
        private abstract class AmazonMobileAdsBase : AmazonMobileAdsImpl
        {
            static readonly System.Object startLock = new System.Object();
            static volatile bool startCalled = false;
        
            protected void Start () 
            {
                if(startCalled) 
                {
                    return;
                }
            
                lock(startLock)
                {
                    if(startCalled == false)
                    {
                        Init();
                        RegisterCallback();
                        RegisterEventListener();
                        RegisterCrossPlatformTool();
                        startCalled = true;
                    }
                }
            }

            protected abstract void Init();
            protected abstract void RegisterCallback();
            protected abstract void RegisterEventListener();
            protected abstract void RegisterCrossPlatformTool();
            
            public AmazonMobileAdsBase()
            {
                logger = new AmazonLogger(this.GetType().Name);
            }

            public override void UnityFireEvent(string jsonMessage)
            {
                AmazonMobileAdsImpl.FireEvent(jsonMessage);
            }
            public override void SetApplicationKey(ApplicationKey applicationKey)
            {
                Start();
                                Jsonable.CheckForErrors(Json.Deserialize(SetApplicationKeyJson(applicationKey.ToJson())) as Dictionary<string, object>);
            }

            private string SetApplicationKeyJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeSetApplicationKeyJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeSetApplicationKeyJson(string jsonMessage);

            public override void RegisterApplication()
            {
                Start();
                                Jsonable.CheckForErrors(Json.Deserialize(RegisterApplicationJson("{}")) as Dictionary<string, object>);
            }

            private string RegisterApplicationJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeRegisterApplicationJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeRegisterApplicationJson(string jsonMessage);

            public override void EnableLogging(ShouldEnable shouldEnable)
            {
                Start();
                                Jsonable.CheckForErrors(Json.Deserialize(EnableLoggingJson(shouldEnable.ToJson())) as Dictionary<string, object>);
            }

            private string EnableLoggingJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeEnableLoggingJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeEnableLoggingJson(string jsonMessage);

            public override void EnableTesting(ShouldEnable shouldEnable)
            {
                Start();
                                Jsonable.CheckForErrors(Json.Deserialize(EnableTestingJson(shouldEnable.ToJson())) as Dictionary<string, object>);
            }

            private string EnableTestingJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeEnableTestingJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeEnableTestingJson(string jsonMessage);

            public override void EnableGeoLocation(ShouldEnable shouldEnable)
            {
                Start();
                                Jsonable.CheckForErrors(Json.Deserialize(EnableGeoLocationJson(shouldEnable.ToJson())) as Dictionary<string, object>);
            }

            private string EnableGeoLocationJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeEnableGeoLocationJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeEnableGeoLocationJson(string jsonMessage);

            public override Ad CreateFloatingBannerAd(Placement placement)
            {
                Start();
                return Ad.CreateFromJson(CreateFloatingBannerAdJson(placement.ToJson()));
            }

            private string CreateFloatingBannerAdJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeCreateFloatingBannerAdJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeCreateFloatingBannerAdJson(string jsonMessage);

            public override Ad CreateInterstitialAd()
            {
                Start();
                return Ad.CreateFromJson(CreateInterstitialAdJson("{}"));
            }

            private string CreateInterstitialAdJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeCreateInterstitialAdJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeCreateInterstitialAdJson(string jsonMessage);

            public override LoadingStarted LoadAndShowFloatingBannerAd(Ad ad)
            {
                Start();
                return LoadingStarted.CreateFromJson(LoadAndShowFloatingBannerAdJson(ad.ToJson()));
            }

            private string LoadAndShowFloatingBannerAdJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeLoadAndShowFloatingBannerAdJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeLoadAndShowFloatingBannerAdJson(string jsonMessage);

            public override LoadingStarted LoadInterstitialAd()
            {
                Start();
                return LoadingStarted.CreateFromJson(LoadInterstitialAdJson("{}"));
            }

            private string LoadInterstitialAdJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeLoadInterstitialAdJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeLoadInterstitialAdJson(string jsonMessage);

            public override AdShown ShowInterstitialAd()
            {
                Start();
                return AdShown.CreateFromJson(ShowInterstitialAdJson("{}"));
            }

            private string ShowInterstitialAdJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeShowInterstitialAdJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeShowInterstitialAdJson(string jsonMessage);

            public override void CloseFloatingBannerAd(Ad ad)
            {
                Start();
                                Jsonable.CheckForErrors(Json.Deserialize(CloseFloatingBannerAdJson(ad.ToJson())) as Dictionary<string, object>);
            }

            private string CloseFloatingBannerAdJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeCloseFloatingBannerAdJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeCloseFloatingBannerAdJson(string jsonMessage);

            public override IsReady IsInterstitialAdReady()
            {
                Start();
                return IsReady.CreateFromJson(IsInterstitialAdReadyJson("{}"));
            }

            private string IsInterstitialAdReadyJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeIsInterstitialAdReadyJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeIsInterstitialAdReadyJson(string jsonMessage);

            public override IsEqual AreAdsEqual(AdPair adPair)
            {
                Start();
                return IsEqual.CreateFromJson(AreAdsEqualJson(adPair.ToJson()));
            }

            private string AreAdsEqualJson(string jsonMessage)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string result = NativeAreAdsEqualJson(jsonMessage);

                stopwatch.Stop();
                logger.Debug(string.Format("Successfully called native code in {0} ms", stopwatch.ElapsedMilliseconds));

                return result;
            }
        
            protected abstract string NativeAreAdsEqualJson(string jsonMessage);


            public override void AddAdCollapsedListener(AdCollapsedDelegate responseDelegate)
            {
                Start();
                string eventId = "adCollapsed";
                lock(eventLock)
                {
                    if (eventListeners.ContainsKey(eventId))
                    {
                        eventListeners[eventId].Add(new AdCollapsedDelegator (responseDelegate));
                    }
                    else 
                    {
                        var list = new List<IDelegator>();
                        list.Add(new AdCollapsedDelegator(responseDelegate));
                        eventListeners.Add(eventId, list);
                    }
                }
            }
            
            public override void RemoveAdCollapsedListener(AdCollapsedDelegate responseDelegate)
            {
                Start();
                string eventId = "adCollapsed";
                lock(eventLock)
                {
                    if (eventListeners.ContainsKey(eventId))
                    {
                        foreach(AdCollapsedDelegator delegator in eventListeners[eventId])
                        {
                            if(delegator.responseDelegate == responseDelegate)
                            {
                                eventListeners[eventId].Remove(delegator);
                                return;
                            }
                        }
                    }
                }
            }
            public override void AddAdDismissedListener(AdDismissedDelegate responseDelegate)
            {
                Start();
                string eventId = "adDismissed";
                lock(eventLock)
                {
                    if (eventListeners.ContainsKey(eventId))
                    {
                        eventListeners[eventId].Add(new AdDismissedDelegator (responseDelegate));
                    }
                    else 
                    {
                        var list = new List<IDelegator>();
                        list.Add(new AdDismissedDelegator(responseDelegate));
                        eventListeners.Add(eventId, list);
                    }
                }
            }
            
            public override void RemoveAdDismissedListener(AdDismissedDelegate responseDelegate)
            {
                Start();
                string eventId = "adDismissed";
                lock(eventLock)
                {
                    if (eventListeners.ContainsKey(eventId))
                    {
                        foreach(AdDismissedDelegator delegator in eventListeners[eventId])
                        {
                            if(delegator.responseDelegate == responseDelegate)
                            {
                                eventListeners[eventId].Remove(delegator);
                                return;
                            }
                        }
                    }
                }
            }
            public override void AddAdExpandedListener(AdExpandedDelegate responseDelegate)
            {
                Start();
                string eventId = "adExpanded";
                lock(eventLock)
                {
                    if (eventListeners.ContainsKey(eventId))
                    {
                        eventListeners[eventId].Add(new AdExpandedDelegator (responseDelegate));
                    }
                    else 
                    {
                        var list = new List<IDelegator>();
                        list.Add(new AdExpandedDelegator(responseDelegate));
                        eventListeners.Add(eventId, list);
                    }
                }
            }
            
            public override void RemoveAdExpandedListener(AdExpandedDelegate responseDelegate)
            {
                Start();
                string eventId = "adExpanded";
                lock(eventLock)
                {
                    if (eventListeners.ContainsKey(eventId))
                    {
                        foreach(AdExpandedDelegator delegator in eventListeners[eventId])
                        {
                            if(delegator.responseDelegate == responseDelegate)
                            {
                                eventListeners[eventId].Remove(delegator);
                                return;
                            }
                        }
                    }
                }
            }
            public override void AddAdFailedToLoadListener(AdFailedToLoadDelegate responseDelegate)
            {
                Start();
                string eventId = "adFailedToLoad";
                lock(eventLock)
                {
                    if (eventListeners.ContainsKey(eventId))
                    {
                        eventListeners[eventId].Add(new AdFailedToLoadDelegator (responseDelegate));
                    }
                    else 
                    {
                        var list = new List<IDelegator>();
                        list.Add(new AdFailedToLoadDelegator(responseDelegate));
                        eventListeners.Add(eventId, list);
                    }
                }
            }
            
            public override void RemoveAdFailedToLoadListener(AdFailedToLoadDelegate responseDelegate)
            {
                Start();
                string eventId = "adFailedToLoad";
                lock(eventLock)
                {
                    if (eventListeners.ContainsKey(eventId))
                    {
                        foreach(AdFailedToLoadDelegator delegator in eventListeners[eventId])
                        {
                            if(delegator.responseDelegate == responseDelegate)
                            {
                                eventListeners[eventId].Remove(delegator);
                                return;
                            }
                        }
                    }
                }
            }
            public override void AddAdLoadedListener(AdLoadedDelegate responseDelegate)
            {
                Start();
                string eventId = "adLoaded";
                lock(eventLock)
                {
                    if (eventListeners.ContainsKey(eventId))
                    {
                        eventListeners[eventId].Add(new AdLoadedDelegator (responseDelegate));
                    }
                    else 
                    {
                        var list = new List<IDelegator>();
                        list.Add(new AdLoadedDelegator(responseDelegate));
                        eventListeners.Add(eventId, list);
                    }
                }
            }
            
            public override void RemoveAdLoadedListener(AdLoadedDelegate responseDelegate)
            {
                Start();
                string eventId = "adLoaded";
                lock(eventLock)
                {
                    if (eventListeners.ContainsKey(eventId))
                    {
                        foreach(AdLoadedDelegator delegator in eventListeners[eventId])
                        {
                            if(delegator.responseDelegate == responseDelegate)
                            {
                                eventListeners[eventId].Remove(delegator);
                                return;
                            }
                        }
                    }
                }
            }
            public override void AddAdResizedListener(AdResizedDelegate responseDelegate)
            {
                Start();
                string eventId = "adResized";
                lock(eventLock)
                {
                    if (eventListeners.ContainsKey(eventId))
                    {
                        eventListeners[eventId].Add(new AdResizedDelegator (responseDelegate));
                    }
                    else 
                    {
                        var list = new List<IDelegator>();
                        list.Add(new AdResizedDelegator(responseDelegate));
                        eventListeners.Add(eventId, list);
                    }
                }
            }
            
            public override void RemoveAdResizedListener(AdResizedDelegate responseDelegate)
            {
                Start();
                string eventId = "adResized";
                lock(eventLock)
                {
                    if (eventListeners.ContainsKey(eventId))
                    {
                        foreach(AdResizedDelegator delegator in eventListeners[eventId])
                        {
                            if(delegator.responseDelegate == responseDelegate)
                            {
                                eventListeners[eventId].Remove(delegator);
                                return;
                            }
                        }
                    }
                }
            }

#if __ANDROID__
            public override void SetCurrentAndroidActivity(Activity activity)
            {
                // do nothing
            }
#endif
        }
    }
}

