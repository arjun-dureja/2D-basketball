
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
 *
 CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and
 * limitations under the License.
 */

//
//  AMAZONAmazonMobileAdsImpl.m
//

#import <AmazonAd/AmazonAdRegistration.h>
#import <AmazonAd/AmazonAdOptions.h>
#import <AmazonAd/AmazonAdError.h>
#import "AMAZONAmazonMobileAdsImpl.h"
#import "AMAZONAmazonMobileAdsObjectiveCController.h"
#import "AMAZONAdViewWrapper.h"
#import "AMAZONInterstitialAdWrapper.h"
#import "AMAZONInterstitialAdCache.h"

@interface AMAZONAmazonMobileAdsImpl ()

@property (nonatomic, strong) NSMutableDictionary *floatingAdsCache;
@property (nonatomic, weak) AMAZONAdViewWrapper *topAd;
@property (nonatomic, weak) AMAZONAdViewWrapper *bottomAd;
@property (nonatomic, strong) AMAZONInterstitialAdCache *interstitialAdsCache;
@property (nonatomic, strong) NSMutableArray *readyToLoadInterstitialAdsCache;
@property (nonatomic, strong) NSMutableArray *loadedInterstitialAdsCache;
@property (nonatomic) float amazonAdCenterYOffset;

@property (nonatomic) BOOL isTestRequest;
@property (nonatomic) BOOL usesGeoLocation;

@end

@implementation AMAZONAmazonMobileAdsImpl

@synthesize controller = _controller;

- (instancetype)init {
    if (self = [super init]) {
    }
    return self;
}

- (void)setApplicationKey:(AMAZONApplicationKey *)applicationKey error:(NSError *__autoreleasing *)errorPtr
{
    if (applicationKey == (id)[NSNull null] || applicationKey.stringValue == (id)[NSNull null] || applicationKey.stringValue.length == 0) {
        NSLog(@"Application key cannot be null");
        return;
    }
    [[AmazonAdRegistration sharedRegistration] setAppKey:applicationKey.stringValue];
    self.floatingAdsCache = [NSMutableDictionary dictionary];
    self.interstitialAdsCache = [[AMAZONInterstitialAdCache alloc] init];
    self.readyToLoadInterstitialAdsCache = [NSMutableArray array];
    self.loadedInterstitialAdsCache = [NSMutableArray array];
    
    self.amazonAdCenterYOffset = 0.0;
    
    if ([[UIDevice currentDevice] userInterfaceIdiom] == UIUserInterfaceIdiomPhone) {
        self.amazonAdCenterYOffset = 25.0;
    } else {
        if (UIInterfaceOrientationIsPortrait([[UIApplication sharedApplication] statusBarOrientation])) {
            self.amazonAdCenterYOffset = 45.0;
        } else {
            self.amazonAdCenterYOffset = 25.0;
        }
    }
    return;
}

- (void)registerApplicationWithError:(NSError *__autoreleasing *)errorPtr
{
    return;
}

- (void)enableLogging:(AMAZONShouldEnable *)shouldEnable error:(NSError *__autoreleasing *)errorPtr
{
    if (!shouldEnable || shouldEnable == (id)[NSNull null]) {
        NSLog(@"ShouldEnable cannot be null");
        return;
    }
    [[AmazonAdRegistration sharedRegistration] setLogging:shouldEnable.booleanValue];
    
    return;
}

- (void)enableTesting:(AMAZONShouldEnable *)shouldEnable error:(NSError *__autoreleasing *)errorPtr
{
    if (!shouldEnable || shouldEnable == (id)[NSNull null]) {
        NSLog(@"ShouldEnable cannot be null");
        return;
    }
    self.isTestRequest = shouldEnable.booleanValue;
    
    return;
}

- (void)enableGeoLocation:(AMAZONShouldEnable *)shouldEnable error:(NSError *__autoreleasing *)errorPtr
{
    if (!shouldEnable || shouldEnable == (id)[NSNull null]) {
        NSLog(@"ShouldEnable cannot be null");
        return;
    }
    self.usesGeoLocation = shouldEnable.booleanValue;
    
    return;
}

- (AMAZONAd *)createFloatingBannerAd:(AMAZONPlacement *)placement error:(NSError *__autoreleasing *)errorPtr
{
    if (!placement || placement == (id)[NSNull null]) {
        NSLog(@"Placement cannot be null");
        return nil;
    }
    // TODO: sync operation implementation here, replace the return statement
    UIViewController *viewController = [self.controller currentViewController];
    
    AMAZONAdViewWrapper *wrappedAd = [[AMAZONAdViewWrapper alloc] initWithParentView:self.view];
    
    AmazonAdView *amazonAdView = wrappedAd.sdkAd;
    AMAZONAd * ret = wrappedAd.pluginAd;
    wrappedAd.dockLocation = placement.dock;
    
    if(ret == nil || amazonAdView == nil) {
        if(errorPtr) {
            NSString* domain = @"com.amazon.AmazonMobileAds.ErrorDomain";
            NSUInteger errorCode = createFloatingBannerAdError;
            NSMutableDictionary* userInfo = [NSMutableDictionary dictionary];
            [userInfo setObject:@"An error occured in CreateFloatingBannerAd" forKey:NSLocalizedDescriptionKey];
            *errorPtr = [[NSError alloc] initWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    
    if (placement.adFit == FIT_SCREEN_WIDTH) {
        CGFloat scaleFactor = viewController.view.bounds.size.width / amazonAdView.frame.size.width;
        amazonAdView.transform = CGAffineTransformScale(CGAffineTransformIdentity, scaleFactor, scaleFactor);
    }
    
    CGFloat adX = 0.0;
    if (placement.horizontalAlign == CENTER)
        adX = (viewController.view.bounds.size.width - amazonAdView.frame.size.width)/2;
    else if (placement.horizontalAlign == LEFT)
        adX = 0.0;
    else
        adX = viewController.view.bounds.size.width - amazonAdView.frame.size.width;
    
    CGFloat adY = (placement.dock == TOP) ? 20 : viewController.view.bounds.size.height - amazonAdView.frame.size.height;
    
    amazonAdView.frame = CGRectMake(adX, adY, amazonAdView.frame.size.width, amazonAdView.frame.size.height);
    
    amazonAdView.delegate = self;
    
    [self.floatingAdsCache setObject:wrappedAd forKey:[NSNumber numberWithLong:ret.identifier]];
    
    return ret;
}

- (AMAZONLoadingStarted *)loadAndShowFloatingBannerAd:(AMAZONAd *)ad error:(NSError *__autoreleasing *)errorPtr
{
    if (!ad || ad == (id)[NSNull null]) {
        NSLog(@"Ad cannot be null");
        return nil;
    }
    AMAZONLoadingStarted * ret = [[AMAZONLoadingStarted alloc] init];
    if(ret == nil) {
        if(errorPtr) {
            NSString* domain = @"com.amazon.AmazonMobileAds.ErrorDomain";
            NSUInteger errorCode = loadAndShowFloatingBannerAdError;
            NSMutableDictionary* userInfo = [NSMutableDictionary dictionary];
            // TODO: change the following setObject parameter to a more appropriate error; this is the message that is passed up to the API layer
            [userInfo setObject:@"An error occured in LoadAndShowFloatingBannerAd" forKey:NSLocalizedDescriptionKey];
            *errorPtr = [[NSError alloc] initWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    
    AMAZONAdViewWrapper * wrappedAd = [self.floatingAdsCache objectForKey:[NSNumber numberWithLong:ad.identifier]];
    
    if (wrappedAd != nil) {
        if (wrappedAd.dockLocation == TOP) {
            if (self.topAd && self.topAd != wrappedAd) {
                [self closeFloatingBannerAd:self.topAd.pluginAd error:errorPtr];
            }
            self.topAd = wrappedAd;
        } else {
            if (self.bottomAd && self.bottomAd != wrappedAd) {
                [self closeFloatingBannerAd:self.bottomAd.pluginAd error:errorPtr];
            }
            self.bottomAd = wrappedAd;
        }
        AmazonAdView *currAdView = wrappedAd.sdkAd;
        
        AmazonAdOptions *options = [AmazonAdOptions options];
        
        NSString *slotParameter = [self.controller getCrossPlatformTool];
        slotParameter = [slotParameter stringByAppendingString:@"AMZN"];
        
        [options setAdvancedOption:slotParameter forKey:@"slot"];
        
        options.isTestRequest = self.isTestRequest;
        options.usesGeoLocation = self.usesGeoLocation;
        
        // Animate sliding Amazon Ad view off the scree with a 500 ms duration
        [UIView animateWithDuration:0.6
                         animations:^{
                             if (currAdView.frame.origin.y <= 21)
                                 currAdView.center = CGPointMake(currAdView.center.x, - self.amazonAdCenterYOffset);
                             else
                                 currAdView.center = CGPointMake(currAdView.center.x, self.view.bounds.size.height + self.amazonAdCenterYOffset);
                         }
         ];
        
        // Load an amazon ad with the given options
        [currAdView loadAd:options];
        ret.booleanValue = YES;
    } else {
        ret.booleanValue = NO;
    }
    
    return ret;
}

- (AMAZONAd *)createInterstitialAdWithError:(NSError *__autoreleasing *)errorPtr
{
    AMAZONInterstitialAdWrapper *adWrapper = [[AMAZONInterstitialAdWrapper alloc] init];
    
    adWrapper.sdkAd.delegate = self;
    
    //Adding ads to the "created" cache at index 0 to create a queue behavior.
    //NSMutableArray shifts all other items 1 position.
    [self.readyToLoadInterstitialAdsCache insertObject:adWrapper atIndex: 0];
    [self.interstitialAdsCache insertAdWrapper:adWrapper];
    
    if(adWrapper.pluginAd == nil || adWrapper.sdkAd == nil) {
        if(errorPtr) {
            NSString* domain = @"com.amazon.AmazonMobileAds.ErrorDomain";
            NSUInteger errorCode = createInterstitialAdError;
            NSMutableDictionary* userInfo = [NSMutableDictionary dictionary];
            // TODO: change the following setObject parameter to a more appropriate error; this is the message that is passed up to the API layer
            [userInfo setObject:@"An error occured in CreateInterstitialAd" forKey:NSLocalizedDescriptionKey];
            *errorPtr = [[NSError alloc] initWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    return adWrapper.pluginAd;
}

- (AMAZONLoadingStarted *)loadInterstitialAdWithError:(NSError *__autoreleasing *)errorPtr
{
    AMAZONLoadingStarted * ret = [[AMAZONLoadingStarted alloc] init];
    if(ret == nil) {
        if(errorPtr) {
            NSString* domain = @"com.amazon.AmazonMobileAds.ErrorDomain";
            NSUInteger errorCode = loadInterstitialAdError;
            NSMutableDictionary* userInfo = [NSMutableDictionary dictionary];
            // TODO: change the following setObject parameter to a more appropriate error; this is the message that is passed up to the API layer
            [userInfo setObject:@"An error occured in LoadInterstitialAd" forKey:NSLocalizedDescriptionKey];
            *errorPtr = [[NSError alloc] initWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    //Getting the last object to create a Queue behavior.
    AMAZONInterstitialAdWrapper *adWrapper = [self.readyToLoadInterstitialAdsCache lastObject];
    if (adWrapper != nil) {
        [self.readyToLoadInterstitialAdsCache removeLastObject];
        
        AmazonAdOptions *options = [AmazonAdOptions options];
        
        // Set the slot to <CPT name>AMZN
        NSString *slotParameter = [self.controller getCrossPlatformTool];
        slotParameter = [slotParameter stringByAppendingString:@"AMZN"];
        [options setAdvancedOption:slotParameter forKey:@"slot"];
        
        options.isTestRequest = self.isTestRequest;
        options.usesGeoLocation = self.usesGeoLocation;
        
        [adWrapper.sdkAd load:options];
        ret.booleanValue = YES;
        //The loaded ad is moved to the loadedCache on the adDidLoad callback
    } else {
        ret.booleanValue = NO;
    }
    return ret;
}

- (AMAZONAdShown *)showInterstitialAdWithError:(NSError *__autoreleasing *)errorPtr
{
    UIViewController *viewController = [self.controller currentViewController];
    AMAZONAdShown * ret = [[AMAZONAdShown alloc] init];
    if(ret == nil) {
        if(errorPtr) {
            NSString* domain = @"com.amazon.AmazonMobileAds.ErrorDomain";
            NSUInteger errorCode = showInterstitialAdError;
            NSMutableDictionary* userInfo = [NSMutableDictionary dictionary];
            // TODO: change the following setObject parameter to a more appropriate error; this is the message that is passed up to the API layer
            [userInfo setObject:@"An error occured in ShowInterstitialAd" forKey:NSLocalizedDescriptionKey];
            *errorPtr = [[NSError alloc] initWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    
    NSError *isAdReadyError;
    AMAZONIsReady *isReady = [self isInterstitialAdReadyWithError:&isAdReadyError];
    if (isReady.booleanValue) {
        AMAZONInterstitialAdWrapper *adWrapper = [self.loadedInterstitialAdsCache lastObject];
        [self.loadedInterstitialAdsCache removeLastObject];
        [adWrapper.sdkAd presentFromViewController:viewController];
        ret.booleanValue = YES;
    } else {
        ret.booleanValue = NO;
    }
    return ret;
}

- (void)closeFloatingBannerAd:(AMAZONAd *)ad error:(NSError *__autoreleasing *)errorPtr
{
    if (!ad || ad == (id)[NSNull null]) {
        NSLog(@"Ad cannot be null");
        return;
    }
    AMAZONAdViewWrapper *adWrapper = [self.floatingAdsCache objectForKey:[NSNumber numberWithLong:ad.identifier]];
    if(adWrapper != nil)
    {
        if (adWrapper.dockLocation == TOP && adWrapper == self.topAd) {
            self.topAd = nil;
        } else if (adWrapper == self.bottomAd) {
            self.bottomAd = nil;
        }
        [adWrapper.sdkAd removeFromSuperview];
    }
    return;
}

- (AMAZONIsReady *)isInterstitialAdReadyWithError:(NSError *__autoreleasing *)errorPtr
{
    AMAZONIsReady * ret = [[AMAZONIsReady alloc] init];
    if(ret == nil) {
        if(errorPtr) {
            NSString* domain = @"com.amazon.AmazonMobileAds.ErrorDomain";
            NSUInteger errorCode = isInterstitialAdReadyError;
            NSMutableDictionary* userInfo = [NSMutableDictionary dictionary];
            // TODO: change the following setObject parameter to a more appropriate error; this is the message that is passed up to the API layer
            [userInfo setObject:@"An error occured in IsInterstitialAdReady" forKey:NSLocalizedDescriptionKey];
            *errorPtr = [[NSError alloc] initWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    ret.booleanValue = (self.loadedInterstitialAdsCache != nil && self.loadedInterstitialAdsCache.count > 0);
    return ret;
}

- (AMAZONIsEqual *)areAdsEqual:(AMAZONAdPair *)adPair error:(NSError *__autoreleasing *)errorPtr
{
    if (!adPair || !adPair.adOne || !adPair.adTwo ||
            adPair == (id)[NSNull null] || adPair.adOne == (id)[NSNull null] || adPair.adTwo == (id)[NSNull null]) {
        NSLog(@"AdPair cannot be null or contain null properties");
        return nil;
    }
    AMAZONIsEqual * ret = [[AMAZONIsEqual alloc] init];
    if(ret == nil) {
        if(errorPtr) {
            NSString* domain = @"com.amazon.AmazonMobileAds.ErrorDomain";
            NSUInteger errorCode = areAdsEqualError;
            NSMutableDictionary* userInfo = [NSMutableDictionary dictionary];
            // TODO: change the following setObject parameter to a more appropriate error; this is the message that is passed up to the API layer
            [userInfo setObject:@"An error occured in AreAdsEqual" forKey:NSLocalizedDescriptionKey];
            *errorPtr = [[NSError alloc] initWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    ret.booleanValue = false;

    AMAZONAd *ad1 = adPair.adOne;
    AMAZONAd *ad2 = adPair.adTwo;
    
    if(ad1 != nil)
    {
        ret.booleanValue = [ad1 isEqual:ad2];
    }
    return ret;
}

#pragma mark AmazonAdViewDelegate

- (UIViewController *)viewControllerForPresentingModalView
{
    return [self.controller currentViewController];
}

- (void)adViewDidLoad:(AmazonAdView *)view
{
    UIViewController *viewController = [self.controller currentViewController];
    [viewController.view addSubview:view];
    
    // Animate sliding Amazon Ad view into the scree from bottom with a 500 ms duration
    [UIView animateWithDuration:0.6
                     animations:^{
                         if (view.frame.origin.y <= 21)
                             view.center = CGPointMake(view.center.x, 20.0 + self.amazonAdCenterYOffset);
                         else
                             view.center = CGPointMake(view.center.x, self.view.bounds.size.height - self.amazonAdCenterYOffset);
                     }
     ];
    
    AMAZONAdViewWrapper *adWrapper = [self.floatingAdsCache objectForKey: [NSNumber numberWithInteger: view.tag]];
    if(adWrapper == nil)
    {
        NSLog(@"Error firing Ad Loaded event, Ad object not found for identifier %ld", (long)view.tag);
    }
    else
    {
        [self.controller fireAdLoaded: adWrapper.pluginAd];
        NSLog(@"Ad loaded");
    }
}

- (void)adViewDidCollapse:(AmazonAdView *)view
{
    AMAZONAdViewWrapper *adWrapper = [self.floatingAdsCache objectForKey: [NSNumber numberWithInteger: view.tag]];
    if(adWrapper == nil)
    {
         NSLog(@"Error firing AdCollapsed event, Ad object not found for identifier %ld", (long)view.tag);
    }
    else
    {
        [self.controller fireAdCollapsed: adWrapper.pluginAd];
        NSLog(@"Ad has collapsed");
    }
}

- (void)adViewDidFailToLoad:(AmazonAdView *)view withError:(AmazonAdError *)error
{
    NSLog(@"Ad Failed to load. Error code %d: %@", error.errorCode, error.errorDescription);
    AMAZONAdViewWrapper *adWrapper = [self.floatingAdsCache objectForKey: [NSNumber numberWithInteger: view.tag]];
    if(adWrapper == nil)
    {
        NSLog(@"Error firing AdFailedToLoad event, Ad object not found for identifier %ld", (long)view.tag);
    }
    else
    {
        [self.controller fireAdFailedToLoad: adWrapper.pluginAd];
        NSLog(@"Ad has failed to load");
    }
}

- (void)adViewWillExpand:(AmazonAdView *)view
{
    AMAZONAdViewWrapper *adWrapper = [self.floatingAdsCache objectForKey: [NSNumber numberWithInteger: view.tag]];
    if(adWrapper == nil)
    {
        NSLog(@"Error firing AdExpanded event, Ad object not found for identifier %ld", (long)view.tag);
    }
    else
    {
        [self.controller fireAdExpanded: adWrapper.pluginAd];
         NSLog(@"Ad will expand");
    }
}

- (void)adViewWillResize:(AmazonAdView *)view toFrame:(CGRect)frame
{
    AMAZONAdViewWrapper *adWrapper = [self.floatingAdsCache objectForKey: [NSNumber numberWithInteger: view.tag]];
    if(adWrapper == nil)
    {
        NSLog(@"Error firing AdResized event, Ad object not found for identifier %ld", (long)view.tag);
    }
    else
    {
        //TODO must verify if origin means top-right or top-left corner and if a conversion is needed.
        AMAZONAdPosition *position = [[AMAZONAdPosition alloc] init];
        position.xCoordinate = frame.origin.x;
        position.yCoordinate = frame.origin.y;
        position.width = frame.size.width;
        position.height = frame.size.height;
        position.ad = adWrapper.pluginAd;
        [self.controller fireAdResized: position];
         NSLog(@"Ad will resize");
    }
}

#pragma mark - AmazonAdInterstitialDelegate

- (void)interstitialDidLoad:(AmazonAdInterstitial *)interstitial
{
    AMAZONInterstitialAdWrapper *adWrapper = [self.interstitialAdsCache getAdWrapperForAd:interstitial];
    if(adWrapper)
    {
        //Inserting the ad at the start to create a queue behavior
        [self.loadedInterstitialAdsCache insertObject:adWrapper atIndex:0];
        //Ad only removed from the created ads cache if the ad was succesfully loaded
        [self.controller fireAdLoaded: adWrapper.pluginAd];
        NSLog(@"Interstitial loaded.");
    }
    else
    {
        NSLog(@"Error firing interstitialDidLoad event, Ad object not found in created ads cache");
    }
}

- (void)interstitialDidFailToLoad:(AmazonAdInterstitial *)interstitial withError:(AmazonAdError *)error
{
    AMAZONInterstitialAdWrapper *adWrapper = [self.interstitialAdsCache getAdWrapperForAd:interstitial];
    if(adWrapper)
    {
        [self.controller fireAdFailedToLoad:adWrapper.pluginAd];
        NSLog(@"Interstitial failed to load.");
        [self.readyToLoadInterstitialAdsCache insertObject:adWrapper atIndex:0];
    }
    else
    {
        NSLog(@"Error firing interstitialDidFailToLoad event, Ad object not found in loaded ads cache");
    }
}

- (void)interstitialWillPresent:(AmazonAdInterstitial *)interstitial
{
    //This event is not used by the plugins framework, keeping for logging purposes.
    NSLog(@"Interstitial will be presented.");
}

- (void)interstitialDidPresent:(AmazonAdInterstitial *)interstitial
{
    //This event is not used by the plugins framework, keeping for logging purposes.
    NSLog(@"Interstitial has been presented.");
}

- (void)interstitialWillDismiss:(AmazonAdInterstitial *)interstitial
{
    //This event is not used by the plugins framework, keeping for logging purposes.
    NSLog(@"Interstitial will be dismissed.");
}

- (void)interstitialDidDismiss:(AmazonAdInterstitial *)interstitial
{
    AMAZONInterstitialAdWrapper *adWrapper = [self.interstitialAdsCache getAdWrapperForAd:interstitial];
    if(adWrapper)
    {
        [self.controller fireAdDismissed:adWrapper.pluginAd];
        [self.readyToLoadInterstitialAdsCache insertObject:adWrapper atIndex:0];
        NSLog(@"Interstitial has been dismissed.");
    }
    else
    {
        NSLog(@"Error firing interstitialDidDismiss event, Ad object not found in loaded ads cache");
    }
}

@end
