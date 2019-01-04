//
//  AMAZONAdCache.h
//  AmazonMobileAdsSDK
//
//  Copyright (c) 2015 Amazon.com. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "AMAZONInterstitialAdWrapper.h"

@interface AMAZONInterstitialAdCache : NSObject

-(void)insertAdWrapper:(AMAZONInterstitialAdWrapper *)adWrapper;
-(AMAZONInterstitialAdWrapper *)getAdWrapperForAd:(AmazonAdInterstitial *)sdkAd;

@end
