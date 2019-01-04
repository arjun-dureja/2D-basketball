//
//  AMAZONAdCache.m
//  AmazonMobileAdsSDK
//
//  Copyright (c) 2015 Amazon.com. All rights reserved.
//

#import "AMAZONInterstitialAdCache.h"

@interface AMAZONInterstitialAdCache()

@property (nonatomic, strong) NSMutableDictionary *adCache;

@end

@implementation AMAZONInterstitialAdCache

-(instancetype)init
{
    if (self = [super init])
    {
        _adCache = [NSMutableDictionary dictionary];
    }
    return self;
}

-(void)insertAdWrapper:(AMAZONInterstitialAdWrapper *)adWrapper
{
    NSNumber *key = [self keyForAd:adWrapper.sdkAd];
    if (key)
    {
        [self.adCache setObject:adWrapper forKey:key];
    }
}

-(AMAZONInterstitialAdWrapper *)getAdWrapperForAd:(AmazonAdInterstitial *)sdkAd
{
    NSNumber *key = [self keyForAd:sdkAd];
    return [self.adCache objectForKey:key];
}

-(NSNumber *)keyForAd:(AmazonAdInterstitial *)ad
{
    NSNumber *key = [NSNumber numberWithUnsignedLong:[ad hash]];
    return key;
}

@end
