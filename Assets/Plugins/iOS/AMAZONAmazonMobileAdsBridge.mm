
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
//  AMAZONAmazonMobileAdsBridge.mm
//


#import "AMAZONAmazonMobileAdsBridge.h"
#import "AMAZONAmazonMobileAdsObjectiveCControllerImpl.h"

@implementation AMAZONAmazonMobileAdsBridge

- (instancetype)init
{
    self = [super init];
    if (self) {

    }
    return self;
}

// Converts C style string to NSString
NSString* CreateNSString (const char* string)
{
    if (string)
        return [NSString stringWithUTF8String: string];
    else
        return [NSString stringWithUTF8String: ""];
}

// Helper method to create C string copy
char* MakeStringCopy (const char* string)
{
    if (string == NULL)
        return NULL;
    
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

extern "C" {
    char* gameObjectName;
    char* crossPlatformToolName;
    
    //callback mechanism
    typedef void (*callback_delegate)(const char*);
    static callback_delegate callbackApiMethod;
    static const char* VOID_JSON = "{}";
    
    static char* voidResult() {
        char* result = strdup(VOID_JSON); //memory will be deallocated by managed code
        return result; //no errors
    }
    
    char* nativeRegisterEventListener(callback_delegate callback) {
        [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] setEventApiMethod:callback];
        return voidResult();
    }
    
    char* nativeRegisterCallbackGameObject(char* name) {
        gameObjectName = MakeStringCopy(name);
        [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] setCallbackGameObject:CreateNSString(name)];
        
        return MakeStringCopy(gameObjectName);
    }
    
    char* nativeRegisterCrossPlatformTool(char* name) {
        crossPlatformToolName = MakeStringCopy(name);
        [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] setCrossPlatformTool:CreateNSString(name)];
        
        return voidResult();
    }

    char* nativeSetApplicationKeyJson (const char* applicationKey) {
        NSData* data = [CreateNSString(applicationKey) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] setApplicationKey:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }

    char* nativeRegisterApplicationJson (const char* voidArgument) {
        NSData* data = [CreateNSString(voidArgument) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] registerApplication:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }

    char* nativeEnableLoggingJson (const char* shouldEnable) {
        NSData* data = [CreateNSString(shouldEnable) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] enableLogging:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }

    char* nativeEnableTestingJson (const char* shouldEnable) {
        NSData* data = [CreateNSString(shouldEnable) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] enableTesting:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }

    char* nativeEnableGeoLocationJson (const char* shouldEnable) {
        NSData* data = [CreateNSString(shouldEnable) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] enableGeoLocation:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }

    char* nativeCreateFloatingBannerAdJson (const char* placement) {
        NSData* data = [CreateNSString(placement) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] createFloatingBannerAd:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }

    char* nativeCreateInterstitialAdJson (const char* voidArgument) {
        NSData* data = [CreateNSString(voidArgument) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] createInterstitialAd:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }

    char* nativeLoadAndShowFloatingBannerAdJson (const char* ad) {
        NSData* data = [CreateNSString(ad) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] loadAndShowFloatingBannerAd:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }

    char* nativeLoadInterstitialAdJson (const char* voidArgument) {
        NSData* data = [CreateNSString(voidArgument) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] loadInterstitialAd:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }

    char* nativeShowInterstitialAdJson (const char* voidArgument) {
        NSData* data = [CreateNSString(voidArgument) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] showInterstitialAd:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }

    char* nativeCloseFloatingBannerAdJson (const char* ad) {
        NSData* data = [CreateNSString(ad) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] closeFloatingBannerAd:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }

    char* nativeIsInterstitialAdReadyJson (const char* voidArgument) {
        NSData* data = [CreateNSString(voidArgument) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] isInterstitialAdReady:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }

    char* nativeAreAdsEqualJson (const char* adPair) {
        NSData* data = [CreateNSString(adPair) dataUsingEncoding:NSUTF8StringEncoding];
        NSData* returnJson = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl sharedInstance] areAdsEqual:data];
        
        NSString* returnString = [[NSString alloc] initWithData:returnJson encoding:NSUTF8StringEncoding];
        return MakeStringCopy([returnString UTF8String]);
    }


    const char* nativeRegisterCallback(callback_delegate callback) {
        callbackApiMethod = callback;
        return voidResult();
    }
    
    extern void UnitySendMessage(const char *, const char *, const char *);
}

@end
