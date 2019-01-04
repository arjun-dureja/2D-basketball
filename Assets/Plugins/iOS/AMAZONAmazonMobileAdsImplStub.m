
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
//  AMAZONAmazonMobileAdsImplStub.m
//


#import "AMAZONAmazonMobileAdsImplStub.h"

@implementation AMAZONAmazonMobileAdsImplStub

@synthesize controller = _controller;

- (void)setApplicationKey:(AMAZONApplicationKey *)applicationKey error:(NSError *__autoreleasing *)errorPtr {
    return;
}

- (void)registerApplicationWithError:(NSError *__autoreleasing *)errorPtr {
    return;
}

- (void)enableLogging:(AMAZONShouldEnable *)shouldEnable error:(NSError *__autoreleasing *)errorPtr {
    return;
}

- (void)enableTesting:(AMAZONShouldEnable *)shouldEnable error:(NSError *__autoreleasing *)errorPtr {
    return;
}

- (void)enableGeoLocation:(AMAZONShouldEnable *)shouldEnable error:(NSError *__autoreleasing *)errorPtr {
    return;
}

- (AMAZONAd *)createFloatingBannerAd:(AMAZONPlacement *)placement error:(NSError *__autoreleasing *)errorPtr {
    // TODO: sync operation implementation here, replace the return statement

    AMAZONAd * ret = [[AMAZONAd alloc] init];
    if(ret == nil) {
        if(errorPtr) {
            NSString* domain = @"com.amazon.AmazonMobileAds.ErrorDomain";
            NSUInteger errorCode = createFloatingBannerAdError;
            NSMutableDictionary* userInfo = [NSMutableDictionary dictionary];
            // TODO: change the following setObject parameter to a more appropriate error; this is the message that is passed up to the API layer
            [userInfo setObject:@"An error occured in CreateFloatingBannerAd" forKey:NSLocalizedDescriptionKey];
            *errorPtr = [[NSError alloc] initWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    return ret;
}

- (AMAZONAd *)createInterstitialAdWithError:(NSError *__autoreleasing *)errorPtr {
    // TODO: sync operation implementation here, replace the return statement

    AMAZONAd * ret = [[AMAZONAd alloc] init];
    if(ret == nil) {
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
    return ret;
}

- (AMAZONLoadingStarted *)loadAndShowFloatingBannerAd:(AMAZONAd *)ad error:(NSError *__autoreleasing *)errorPtr {
    // TODO: sync operation implementation here, replace the return statement

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
    return ret;
}

- (AMAZONLoadingStarted *)loadInterstitialAdWithError:(NSError *__autoreleasing *)errorPtr {
    // TODO: sync operation implementation here, replace the return statement

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
    return ret;
}

- (AMAZONAdShown *)showInterstitialAdWithError:(NSError *__autoreleasing *)errorPtr {
    // TODO: sync operation implementation here, replace the return statement

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
    return ret;
}

- (void)closeFloatingBannerAd:(AMAZONAd *)ad error:(NSError *__autoreleasing *)errorPtr {
    return;
}

- (AMAZONIsReady *)isInterstitialAdReadyWithError:(NSError *__autoreleasing *)errorPtr {
    // TODO: sync operation implementation here, replace the return statement

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
    return ret;
}

- (AMAZONIsEqual *)areAdsEqual:(AMAZONAdPair *)adPair error:(NSError *__autoreleasing *)errorPtr {
    // TODO: sync operation implementation here, replace the return statement

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
    return ret;
}

@end

