
/*
 * Copyright 2015 Amazon.com,
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
 *
 CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and
 * limitations under the License.
 */


//
//  AMAZONAdViewWrapper.m
//  AmazonMobileAdsSDK
//

#import <Foundation/Foundation.h>
#import <AmazonAd/AmazonAdOptions.h>
#import "AMAZONAdViewWrapper.h"
#import "AMAZONCommon.h"

@implementation AMAZONAdViewWrapper

@synthesize sdkAd = _sdkAd;
@synthesize pluginAd = _pluginAd;

- (instancetype)initWithParentView:(UIView *)parentView
{
    self = [super init];
    if (self)
    {
        self.sdkAd = [self createSdkAd:parentView];
        self.pluginAd = [[AMAZONAd alloc] init];
        
        if(self.pluginAd != nil && self.sdkAd != nil){
            NSUInteger newId = [AMAZONCommon nextAdIdentifier];
            self.sdkAd.tag = newId;
            self.pluginAd.identifier = newId;
            self.pluginAd.adType = FLOATING;
        }
    }
    return self;
}

- (AmazonAdView *)createSdkAd:(UIView *)parentView
{
    AmazonAdView *amazonAdView = nil;
    UIUserInterfaceIdiom userInterfaceIdiom = [[UIDevice currentDevice] userInterfaceIdiom];
    UIInterfaceOrientation interfaceOrientation = [[UIApplication sharedApplication] statusBarOrientation];
    
    // IMPORTANT: Create the AmazonAd view for requesting an ad of appropriate size based on the current device and orientation if necessary
    if (userInterfaceIdiom != UIUserInterfaceIdiomPhone) {
        if (UIInterfaceOrientationIsPortrait(interfaceOrientation)) {
            // Create the Amazon Ad view of size 728x90 for iPad while in portrait mode
            amazonAdView = [AmazonAdView amazonAdViewWithAdSize:AmazonAdSize_728x90];
            
            // Reposition and resize the Amazon Ad view to center at bottom
            [amazonAdView setCenter:CGPointMake(parentView.bounds.size.width / 2.0, parentView.bounds.size.height - 45.0)];
        } else {
            // Create the Amazon Ad view of size 1024x50 for iPad while in landscape mode
            amazonAdView = [AmazonAdView amazonAdViewWithAdSize:AmazonAdSize_1024x50];
            
            // Reposition and resize the Amazon Ad view to center at bottom
            [amazonAdView setCenter:CGPointMake(parentView.bounds.size.width / 2.0, parentView.bounds.size.height - 25.0)];
        }
    }
    else{
        amazonAdView = [AmazonAdView amazonAdViewWithAdSize:AmazonAdSize_320x50];
    }   
    return amazonAdView;
}

@end
