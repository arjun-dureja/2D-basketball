//
//  AMAZONInterstitialAdWrapper.m
//  AmazonMobileAdsSDK
//
//  Created by Garcia Toral, Victor on 8/28/15.
//
//

#import <Foundation/Foundation.h>
#import "AMAZONInterstitialAdWrapper.h"
#import "AMAZONCommon.h"

@implementation AMAZONInterstitialAdWrapper

@synthesize sdkAd = _sdkAd;
@synthesize pluginAd = _pluginAd;

- (instancetype)init
{
    self = [super init];
    if (self)
    {
        self.sdkAd = [AmazonAdInterstitial amazonAdInterstitial];
        self.pluginAd = [[AMAZONAd alloc] init];
        self.pluginAd.adType = INTERSTITIAL;
        self.pluginAd.identifier = [AMAZONCommon nextAdIdentifier];
    }
    return self;
}

//Making the isEqual comparrison only with the sdkAd
//In this way we are able to find the index for the whole
//wrapper using the indexOfObject method. This is needed
//on the callbacks to retreive the pluginAd and fire plugin events.
- (BOOL)isEqual:(id)other {
    return [self.sdkAd isEqual:other];
}

//The hash method should always be overloaded too while
//overloading isEquals.
-(NSUInteger)hash {
    return [self.sdkAd hash];
}

@end
