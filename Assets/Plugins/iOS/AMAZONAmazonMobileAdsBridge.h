
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

//
//  AMAZONAmazonMobileAdsBridge.h
//


#import <Foundation/Foundation.h>

@interface AMAZONAmazonMobileAdsBridge : NSObject
typedef void (*callback_delegate)(const char*);
#ifdef __cplusplus
extern "C" {
#endif
char* nativeRegisterEventListener(callback_delegate callback);
char* nativeRegisterCallbackGameObject(char* name);
char* nativeRegisterCrossPlatformTool(char* name);
char* nativeSetApplicationKeyJson (const char* applicationKey);
char* nativeRegisterApplicationJson (const char* voidArgument);
char* nativeEnableLoggingJson (const char* shouldEnable);
char* nativeEnableTestingJson (const char* shouldEnable);
char* nativeEnableGeoLocationJson (const char* shouldEnable);
char* nativeCreateFloatingBannerAdJson (const char* placement);
char* nativeCreateInterstitialAdJson (const char* voidArgument);
char* nativeLoadAndShowFloatingBannerAdJson (const char* ad);
char* nativeLoadInterstitialAdJson (const char* voidArgument);
char* nativeShowInterstitialAdJson (const char* voidArgument);
char* nativeCloseFloatingBannerAdJson (const char* ad);
char* nativeIsInterstitialAdReadyJson (const char* voidArgument);
char* nativeAreAdsEqualJson (const char* adPair);
const char* nativeRegisterCallback(callback_delegate callback);
#ifdef __cplusplus
}
#endif

@end
