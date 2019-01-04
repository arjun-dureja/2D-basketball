
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
#if UNITY_PLATFORM
using UnityEngine;
#endif
namespace com.amazon.mas.cpt.ads
{
    public abstract partial class AmazonMobileAdsImpl
    {
#if UNITY_PLATFORM
        private abstract class AmazonMobileAdsUnityBase : AmazonMobileAdsBase
        {
            private const string CrossPlatformTool = "UNITY";
        
            private static AmazonMobileAdsUnityBase instance;
            private static System.Type instanceType;
            private static volatile bool quit = false;
            private static object initLock = new object();

            // A static constructor tells the C# compiler not to mark type as beforefieldinit, and thus lazy load this class
            static AmazonMobileAdsUnityBase() {}

            public static T getInstance<T>() where T : AmazonMobileAdsUnityBase
            {
                if (quit)
                {
                    return null;
                }

                if (instance != null) 
                {
                    return (T) instance;
                }

                lock(initLock)
                {
                    System.Type typeOfT = typeof(T);
                    assertTrue(instance == null || (instance != null && instanceType == typeOfT), "Only 1 instance of 1 subtype of AmazonMobileAdsUnityBase can exist.");
                    if (instance == null)
                    {
                        instanceType = typeOfT;
                        GameObject singleton = new GameObject();
                        instance = singleton.AddComponent<T>();
                        singleton.name = typeOfT.ToString() + "_Singleton";
                        //keep gameObject alive across scenes
                        DontDestroyOnLoad(singleton);
                    }
                    return (T) instance;
                }
            }

            public void OnDestroy()
            {
                quit = true;
            }
            
            private static void assertTrue(bool statement, string errorMessage)
            {
                if (statement == false)
                {
                    throw new AmazonException("FATAL: An internal error occurred", new System.InvalidOperationException(errorMessage));
                }
            }

            protected override void Init()
            {
                NativeInit();
            }
            
            protected override void RegisterCrossPlatformTool()
            {
                NativeRegisterCrossPlatformTool(CrossPlatformTool);
            }
            
            protected abstract void NativeInit();
            protected abstract void NativeRegisterCrossPlatformTool(string crossPlatformTool);
        }
#endif
    }
}

