
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
//  AMAZONAmazonMobileAdsImplStub.h
//


#import <Foundation/Foundation.h>
#import "AMAZONAmazonMobileAds.h"

typedef enum AMAZONAmazonMobileAdsErrorCodes : NSUInteger {
    setApplicationKeyError = 0,
    registerApplicationError = 1,
    enableLoggingError = 2,
    enableTestingError = 3,
    enableGeoLocationError = 4,
    createFloatingBannerAdError = 5,
    createInterstitialAdError = 6,
    loadAndShowFloatingBannerAdError = 7,
    loadInterstitialAdError = 8,
    showInterstitialAdError = 9,
    closeFloatingBannerAdError = 10,
    isInterstitialAdReadyError = 11,
    areAdsEqualError = 12,
} AMAZONAmazonMobileAdsErrorCodes;

@interface AMAZONAmazonMobileAdsImplStub : NSObject <AMAZONAmazonMobileAds>

@end

