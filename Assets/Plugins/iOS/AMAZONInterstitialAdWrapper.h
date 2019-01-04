//
//  AMAZONInterstitialAdWrapper.h
//  AmazonMobileAdsSDK
//
//  Copyright (c) 2015 Amazon.com. All rights reserved.
//

#import <AmazonAd/AmazonAdInterstitial.h>
#import "AMAZONAd.h"


@interface AMAZONInterstitialAdWrapper : NSObject

@property (nonatomic, strong)AmazonAdInterstitial *sdkAd;
@property (nonatomic, strong)AMAZONAd *pluginAd;

@end
