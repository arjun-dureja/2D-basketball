
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
//  AMAZONAmazonMobileAdsObjectiveCController.h
//

#import "AMAZONAmazonMobileAds.h"
#import <Foundation/Foundation.h>
#import "UIKit/UIKit.h"
#import "AMAZONAd.h"
#import "AMAZONAdPosition.h"

@protocol AMAZONAmazonMobileAds;

@protocol AMAZONAmazonMobileAdsEventListenerDelegate <NSObject>

@required
- (void)fireSDKEvent:(NSString *)eventJsonString;

@end

typedef void (^futureJson)(NSData* jsonData);
typedef void (*callback_delegate)(const char*);

@protocol AMAZONAmazonMobileAdsObjectiveCController <NSObject>

@property (atomic, strong) id<AMAZONAmazonMobileAds> amazonMobileAds;
@property (atomic, copy) NSString* callbackGameObject;
@property (atomic, copy) NSString* crossPlatformTool;
@property (nonatomic, strong) id eventListenerDelegate;
@property (atomic) callback_delegate eventApiMethod;

+ (id<AMAZONAmazonMobileAdsObjectiveCController>)sharedInstance;

- (NSData *)setApplicationKey:(NSData *)jsonMsg;
- (NSData *)registerApplication:(NSData *)jsonMsg;
- (NSData *)enableLogging:(NSData *)jsonMsg;
- (NSData *)enableTesting:(NSData *)jsonMsg;
- (NSData *)enableGeoLocation:(NSData *)jsonMsg;
- (NSData *)createFloatingBannerAd:(NSData *)jsonMsg;
- (NSData *)createInterstitialAd:(NSData *)jsonMsg;
- (NSData *)loadAndShowFloatingBannerAd:(NSData *)jsonMsg;
- (NSData *)loadInterstitialAd:(NSData *)jsonMsg;
- (NSData *)showInterstitialAd:(NSData *)jsonMsg;
- (NSData *)closeFloatingBannerAd:(NSData *)jsonMsg;
- (NSData *)isInterstitialAdReady:(NSData *)jsonMsg;
- (NSData *)areAdsEqual:(NSData *)jsonMsg;

- (void)fireAdCollapsed:(AMAZONAd *)adObject;
- (void)fireAdDismissed:(AMAZONAd *)adObject;
- (void)fireAdExpanded:(AMAZONAd *)adObject;
- (void)fireAdFailedToLoad:(AMAZONAd *)adObject;
- (void)fireAdLoaded:(AMAZONAd *)adObject;
- (void)fireAdResized:(AMAZONAdPosition *)adPosition;
- (UIViewController *)currentViewController;
- (NSString *)getCrossPlatformTool;

@end
