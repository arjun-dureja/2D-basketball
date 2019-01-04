
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
//  AMAZONAmazonMobileAds.h
//

#import <Foundation/Foundation.h>
#import "AMAZONApplicationKey.h"
#import "AMAZONShouldEnable.h"
#import "AMAZONAd.h"
#import "AMAZONPlacement.h"
#import "AMAZONLoadingStarted.h"
#import "AMAZONAdShown.h"
#import "AMAZONIsReady.h"
#import "AMAZONIsEqual.h"
#import "AMAZONAdPair.h"

@protocol AMAZONAmazonMobileAdsObjectiveCController;


@protocol AMAZONAmazonMobileAds <NSObject>

@property (atomic, strong) id<AMAZONAmazonMobileAdsObjectiveCController> controller;

- (void)setApplicationKey:(AMAZONApplicationKey *)applicationKey error:(NSError *__autoreleasing *)errorPtr;
- (void)registerApplicationWithError:(NSError *__autoreleasing *)errorPtr;
- (void)enableLogging:(AMAZONShouldEnable *)shouldEnable error:(NSError *__autoreleasing *)errorPtr;
- (void)enableTesting:(AMAZONShouldEnable *)shouldEnable error:(NSError *__autoreleasing *)errorPtr;
- (void)enableGeoLocation:(AMAZONShouldEnable *)shouldEnable error:(NSError *__autoreleasing *)errorPtr;
- (AMAZONAd *)createFloatingBannerAd:(AMAZONPlacement *)placement error:(NSError *__autoreleasing *)errorPtr;
- (AMAZONAd *)createInterstitialAdWithError:(NSError *__autoreleasing *)errorPtr;
- (AMAZONLoadingStarted *)loadAndShowFloatingBannerAd:(AMAZONAd *)ad error:(NSError *__autoreleasing *)errorPtr;
- (AMAZONLoadingStarted *)loadInterstitialAdWithError:(NSError *__autoreleasing *)errorPtr;
- (AMAZONAdShown *)showInterstitialAdWithError:(NSError *__autoreleasing *)errorPtr;
- (void)closeFloatingBannerAd:(AMAZONAd *)ad error:(NSError *__autoreleasing *)errorPtr;
- (AMAZONIsReady *)isInterstitialAdReadyWithError:(NSError *__autoreleasing *)errorPtr;
- (AMAZONIsEqual *)areAdsEqual:(AMAZONAdPair *)adPair error:(NSError *__autoreleasing *)errorPtr;

@end

