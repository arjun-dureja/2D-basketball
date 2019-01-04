
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
//  AMAZONAmazonMobileAdsObjectiveCControllerImpl.m
//


#import "AMAZONAmazonMobileAdsObjectiveCControllerImpl.h"
#import "AMAZONAmazonMobileAdsJsonFromObject.h"
#import "AMAZONAmazonMobileAdsObjectFromJson.h"
#import "AMAZONAmazonMobileAdsImpl.h"
#import "UIKit/UIKit.h"

@implementation AMAZONAmazonMobileAdsObjectiveCControllerImpl

@synthesize amazonMobileAds = _amazonMobileAds;
@synthesize callbackGameObject = _callbackGameObject;
@synthesize crossPlatformTool = _crossPlatformTool;
@synthesize eventListenerDelegate = _eventListenerDelegate;
@synthesize eventApiMethod = _eventApiMethod;

+ (AMAZONAmazonMobileAdsObjectiveCControllerImpl *)sharedInstance
{
    static AMAZONAmazonMobileAdsObjectiveCControllerImpl* sharedController = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        sharedController = [[AMAZONAmazonMobileAdsObjectiveCControllerImpl alloc] init];
    });
    return sharedController;
}

- (instancetype)init
{
    self = [super init];
    if (self) {
        _amazonMobileAds = [[AMAZONAmazonMobileAdsImpl alloc] init];
        _amazonMobileAds.controller = self;
    }
    return self;
}

- (NSData *)setApplicationKey:(NSData *)jsonMsg {
    // Get the input argument from the JSON
    NSError * objectFromJsonError = nil;
    AMAZONApplicationKey * applicationKey = [AMAZONAmazonMobileAdsObjectFromJson applicationKeyFromJson:jsonMsg error:&objectFromJsonError];
    if(applicationKey == nil && objectFromJsonError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:objectFromJsonError];
    }
    // Pass the input argument into the native function, and return the output
    NSError * nativeFunctionError = nil;
    [self.amazonMobileAds setApplicationKey:applicationKey error:&nativeFunctionError];
    if(nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    return [AMAZONAmazonMobileAdsJsonFromObject jsonFromVoid];
}

- (NSData *)registerApplication:(NSData *)jsonMsg {
    // Call the native function, and return the output
    NSError * nativeFunctionError = nil;
    [self.amazonMobileAds registerApplicationWithError:&nativeFunctionError];
    if(nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    return [AMAZONAmazonMobileAdsJsonFromObject jsonFromVoid];
}

- (NSData *)enableLogging:(NSData *)jsonMsg {
    // Get the input argument from the JSON
    NSError * objectFromJsonError = nil;
    AMAZONShouldEnable * shouldEnable = [AMAZONAmazonMobileAdsObjectFromJson shouldEnableFromJson:jsonMsg error:&objectFromJsonError];
    if(shouldEnable == nil && objectFromJsonError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:objectFromJsonError];
    }
    // Pass the input argument into the native function, and return the output
    NSError * nativeFunctionError = nil;
    [self.amazonMobileAds enableLogging:shouldEnable error:&nativeFunctionError];
    if(nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    return [AMAZONAmazonMobileAdsJsonFromObject jsonFromVoid];
}

- (NSData *)enableTesting:(NSData *)jsonMsg {
    // Get the input argument from the JSON
    NSError * objectFromJsonError = nil;
    AMAZONShouldEnable * shouldEnable = [AMAZONAmazonMobileAdsObjectFromJson shouldEnableFromJson:jsonMsg error:&objectFromJsonError];
    if(shouldEnable == nil && objectFromJsonError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:objectFromJsonError];
    }
    // Pass the input argument into the native function, and return the output
    NSError * nativeFunctionError = nil;
    [self.amazonMobileAds enableTesting:shouldEnable error:&nativeFunctionError];
    if(nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    return [AMAZONAmazonMobileAdsJsonFromObject jsonFromVoid];
}

- (NSData *)enableGeoLocation:(NSData *)jsonMsg {
    // Get the input argument from the JSON
    NSError * objectFromJsonError = nil;
    AMAZONShouldEnable * shouldEnable = [AMAZONAmazonMobileAdsObjectFromJson shouldEnableFromJson:jsonMsg error:&objectFromJsonError];
    if(shouldEnable == nil && objectFromJsonError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:objectFromJsonError];
    }
    // Pass the input argument into the native function, and return the output
    NSError * nativeFunctionError = nil;
    [self.amazonMobileAds enableGeoLocation:shouldEnable error:&nativeFunctionError];
    if(nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    return [AMAZONAmazonMobileAdsJsonFromObject jsonFromVoid];
}

- (NSData *)createFloatingBannerAd:(NSData *)jsonMsg {
    // Get the input argument from the JSON
    NSError * objectFromJsonError = nil;
    AMAZONPlacement * placement = [AMAZONAmazonMobileAdsObjectFromJson placementFromJson:jsonMsg error:&objectFromJsonError];
    if(placement == nil && objectFromJsonError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:objectFromJsonError];
    }
    // Pass the input argument into the native function, and return the output from the native function
    NSError * nativeFunctionError = nil;
    AMAZONAd * returnAd = [self.amazonMobileAds createFloatingBannerAd:placement error:&nativeFunctionError];
    if(returnAd == nil && nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    NSError * jsonFromObjectError = nil;
    NSData * returnData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromAd:returnAd error:&jsonFromObjectError];
    if(returnData == nil && jsonFromObjectError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:jsonFromObjectError];
    }
    return returnData;
}

- (NSData *)createInterstitialAd:(NSData *)jsonMsg {
    // Call the native function, and return the output from the native function
    NSError * nativeFunctionError = nil;
    AMAZONAd * returnAd = [self.amazonMobileAds createInterstitialAdWithError:&nativeFunctionError];
    if(returnAd == nil && nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    NSError * jsonFromObjectError = nil;
    NSData * returnData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromAd:returnAd error:&jsonFromObjectError];
    if(returnData == nil && jsonFromObjectError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:jsonFromObjectError];
    }
    return returnData;
}

- (NSData *)loadAndShowFloatingBannerAd:(NSData *)jsonMsg {
    // Get the input argument from the JSON
    NSError * objectFromJsonError = nil;
    AMAZONAd * ad = [AMAZONAmazonMobileAdsObjectFromJson adFromJson:jsonMsg error:&objectFromJsonError];
    if(ad == nil && objectFromJsonError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:objectFromJsonError];
    }
    // Pass the input argument into the native function, and return the output from the native function
    NSError * nativeFunctionError = nil;
    AMAZONLoadingStarted * returnLoadingStarted = [self.amazonMobileAds loadAndShowFloatingBannerAd:ad error:&nativeFunctionError];
    if(returnLoadingStarted == nil && nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    NSError * jsonFromObjectError = nil;
    NSData * returnData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromLoadingStarted:returnLoadingStarted error:&jsonFromObjectError];
    if(returnData == nil && jsonFromObjectError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:jsonFromObjectError];
    }
    return returnData;
}

- (NSData *)loadInterstitialAd:(NSData *)jsonMsg {
    // Call the native function, and return the output from the native function
    NSError * nativeFunctionError = nil;
    AMAZONLoadingStarted * returnLoadingStarted = [self.amazonMobileAds loadInterstitialAdWithError:&nativeFunctionError];
    if(returnLoadingStarted == nil && nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    NSError * jsonFromObjectError = nil;
    NSData * returnData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromLoadingStarted:returnLoadingStarted error:&jsonFromObjectError];
    if(returnData == nil && jsonFromObjectError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:jsonFromObjectError];
    }
    return returnData;
}

- (NSData *)showInterstitialAd:(NSData *)jsonMsg {
    // Call the native function, and return the output from the native function
    NSError * nativeFunctionError = nil;
    AMAZONAdShown * returnAdShown = [self.amazonMobileAds showInterstitialAdWithError:&nativeFunctionError];
    if(returnAdShown == nil && nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    NSError * jsonFromObjectError = nil;
    NSData * returnData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromAdShown:returnAdShown error:&jsonFromObjectError];
    if(returnData == nil && jsonFromObjectError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:jsonFromObjectError];
    }
    return returnData;
}

- (NSData *)closeFloatingBannerAd:(NSData *)jsonMsg {
    // Get the input argument from the JSON
    NSError * objectFromJsonError = nil;
    AMAZONAd * ad = [AMAZONAmazonMobileAdsObjectFromJson adFromJson:jsonMsg error:&objectFromJsonError];
    if(ad == nil && objectFromJsonError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:objectFromJsonError];
    }
    // Pass the input argument into the native function, and return the output
    NSError * nativeFunctionError = nil;
    [self.amazonMobileAds closeFloatingBannerAd:ad error:&nativeFunctionError];
    if(nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    return [AMAZONAmazonMobileAdsJsonFromObject jsonFromVoid];
}

- (NSData *)isInterstitialAdReady:(NSData *)jsonMsg {
    // Call the native function, and return the output from the native function
    NSError * nativeFunctionError = nil;
    AMAZONIsReady * returnIsReady = [self.amazonMobileAds isInterstitialAdReadyWithError:&nativeFunctionError];
    if(returnIsReady == nil && nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    NSError * jsonFromObjectError = nil;
    NSData * returnData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromIsReady:returnIsReady error:&jsonFromObjectError];
    if(returnData == nil && jsonFromObjectError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:jsonFromObjectError];
    }
    return returnData;
}

- (NSData *)areAdsEqual:(NSData *)jsonMsg {
    // Get the input argument from the JSON
    NSError * objectFromJsonError = nil;
    AMAZONAdPair * adPair = [AMAZONAmazonMobileAdsObjectFromJson adPairFromJson:jsonMsg error:&objectFromJsonError];
    if(adPair == nil && objectFromJsonError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:objectFromJsonError];
    }
    // Pass the input argument into the native function, and return the output from the native function
    NSError * nativeFunctionError = nil;
    AMAZONIsEqual * returnIsEqual = [self.amazonMobileAds areAdsEqual:adPair error:&nativeFunctionError];
    if(returnIsEqual == nil && nativeFunctionError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:nativeFunctionError];
    }
    NSError * jsonFromObjectError = nil;
    NSData * returnData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromIsEqual:returnIsEqual error:&jsonFromObjectError];
    if(returnData == nil && jsonFromObjectError) {
        return [AMAZONAmazonMobileAdsJsonFromObject jsonFromError:jsonFromObjectError];
    }
    return returnData;
}

- (void)fireAdCollapsed:(AMAZONAd *)adObject {
    NSError * jsonFromObjectError = nil;
    NSData* jsonData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromAdEvent:adObject eventId:@"adCollapsed" error:&jsonFromObjectError];
    if(jsonData == nil && jsonFromObjectError) {
        jsonData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromEventError:jsonFromObjectError eventId:@"adCollapsed"];
    }
    NSString* jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    if(self.eventListenerDelegate && [self.eventListenerDelegate respondsToSelector:@selector(fireSDKEvent:)]) {
        [self.eventListenerDelegate fireSDKEvent:jsonString];
    } else {
#ifdef UNITY_VERSION
        UnitySendMessage([self.callbackGameObject UTF8String], "UnityFireEvent", [jsonString UTF8String]);
#else
        if(self.eventApiMethod){
            self.eventApiMethod([jsonString UTF8String]);
        }
#endif
    }
}

- (void)fireAdDismissed:(AMAZONAd *)adObject {
    NSError * jsonFromObjectError = nil;
    NSData* jsonData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromAdEvent:adObject eventId:@"adDismissed" error:&jsonFromObjectError];
    if(jsonData == nil && jsonFromObjectError) {
        jsonData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromEventError:jsonFromObjectError eventId:@"adDismissed"];
    }
    NSString* jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    if(self.eventListenerDelegate && [self.eventListenerDelegate respondsToSelector:@selector(fireSDKEvent:)]) {
        [self.eventListenerDelegate fireSDKEvent:jsonString];
    } else {
#ifdef UNITY_VERSION
        UnitySendMessage([self.callbackGameObject UTF8String], "UnityFireEvent", [jsonString UTF8String]);
#else
        if(self.eventApiMethod){
            self.eventApiMethod([jsonString UTF8String]);
        }
#endif
    }
}

- (void)fireAdExpanded:(AMAZONAd *)adObject {
    NSError * jsonFromObjectError = nil;
    NSData* jsonData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromAdEvent:adObject eventId:@"adExpanded" error:&jsonFromObjectError];
    if(jsonData == nil && jsonFromObjectError) {
        jsonData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromEventError:jsonFromObjectError eventId:@"adExpanded"];
    }
    NSString* jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    if(self.eventListenerDelegate && [self.eventListenerDelegate respondsToSelector:@selector(fireSDKEvent:)]) {
        [self.eventListenerDelegate fireSDKEvent:jsonString];
    } else {
#ifdef UNITY_VERSION
        UnitySendMessage([self.callbackGameObject UTF8String], "UnityFireEvent", [jsonString UTF8String]);
#else
        if(self.eventApiMethod){
            self.eventApiMethod([jsonString UTF8String]);
        }
#endif
    }
}

- (void)fireAdFailedToLoad:(AMAZONAd *)adObject {
    NSError * jsonFromObjectError = nil;
    NSData* jsonData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromAdEvent:adObject eventId:@"adFailedToLoad" error:&jsonFromObjectError];
    if(jsonData == nil && jsonFromObjectError) {
        jsonData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromEventError:jsonFromObjectError eventId:@"adFailedToLoad"];
    }
    NSString* jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    if(self.eventListenerDelegate && [self.eventListenerDelegate respondsToSelector:@selector(fireSDKEvent:)]) {
        [self.eventListenerDelegate fireSDKEvent:jsonString];
    } else {
#ifdef UNITY_VERSION
        UnitySendMessage([self.callbackGameObject UTF8String], "UnityFireEvent", [jsonString UTF8String]);
#else
        if(self.eventApiMethod){
            self.eventApiMethod([jsonString UTF8String]);
        }
#endif
    }
}

- (void)fireAdLoaded:(AMAZONAd *)adObject {
    NSError * jsonFromObjectError = nil;
    NSData* jsonData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromAdEvent:adObject eventId:@"adLoaded" error:&jsonFromObjectError];
    if(jsonData == nil && jsonFromObjectError) {
        jsonData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromEventError:jsonFromObjectError eventId:@"adLoaded"];
    }
    NSString* jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    if(self.eventListenerDelegate && [self.eventListenerDelegate respondsToSelector:@selector(fireSDKEvent:)]) {
        [self.eventListenerDelegate fireSDKEvent:jsonString];
    } else {
#ifdef UNITY_VERSION
        UnitySendMessage([self.callbackGameObject UTF8String], "UnityFireEvent", [jsonString UTF8String]);
#else
        if(self.eventApiMethod){
            self.eventApiMethod([jsonString UTF8String]);
        }
#endif
    }
}

- (void)fireAdResized:(AMAZONAdPosition *)adPosition {
    NSError * jsonFromObjectError = nil;
    NSData* jsonData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromAdPositionEvent:adPosition eventId:@"adResized" error:&jsonFromObjectError];
    if(jsonData == nil && jsonFromObjectError) {
        jsonData = [AMAZONAmazonMobileAdsJsonFromObject jsonFromEventError:jsonFromObjectError eventId:@"adResized"];
    }
    NSString* jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    if(self.eventListenerDelegate && [self.eventListenerDelegate respondsToSelector:@selector(fireSDKEvent:)]) {
        [self.eventListenerDelegate fireSDKEvent:jsonString];
    } else {
#ifdef UNITY_VERSION
        UnitySendMessage([self.callbackGameObject UTF8String], "UnityFireEvent", [jsonString UTF8String]);
#else
        if(self.eventApiMethod){
            self.eventApiMethod([jsonString UTF8String]);
        }
#endif
    }
}


-(UIViewController*) findBestViewController:(UIViewController*) vc {
    if (vc.presentedViewController) {
        // Return presented view controller
        return [self findBestViewController:vc.presentedViewController];
    } else if ([vc isKindOfClass:[UISplitViewController class]]) {
        // Return right hand side
        UISplitViewController* svc = (UISplitViewController*) vc;
        if (svc.viewControllers.count > 0)
            return [self findBestViewController:svc.viewControllers.lastObject];
        else
            return vc;
    } else if ([vc isKindOfClass:[UINavigationController class]]) {
        // Return top view
        UINavigationController* svc = (UINavigationController*) vc;
        if (svc.viewControllers.count > 0)
            return [self findBestViewController:svc.topViewController];
        else
            return vc;
    } else if ([vc isKindOfClass:[UITabBarController class]]) {
        // Return visible view
        UITabBarController* svc = (UITabBarController*) vc;
        if (svc.viewControllers.count > 0)
            return [self findBestViewController:svc.selectedViewController];
        else
            return vc;
    } else {
        // Base case for recursion: No navigable child view controllers
        return vc;
    }
}

-(UIViewController*) currentViewController {
    // Find best view controller
    UIViewController* viewController = [UIApplication sharedApplication].keyWindow.rootViewController;
    return [self findBestViewController:viewController];
}

-(NSString*) getCrossPlatformTool {
    return self.crossPlatformTool;
}
@end

