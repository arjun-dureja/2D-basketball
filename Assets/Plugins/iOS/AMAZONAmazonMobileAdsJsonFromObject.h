
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
//  AMAZONAmazonMobileAdsJsonFromObject.h
//


#import <Foundation/Foundation.h>

@class AMAZONAd;
@class AMAZONLoadingStarted;
@class AMAZONAdShown;
@class AMAZONIsReady;
@class AMAZONIsEqual;
@class AMAZONAdPosition;

@interface AMAZONAmazonMobileAdsJsonFromObject : NSObject

+ (NSData *)jsonFromAd:(AMAZONAd *)ad error:(NSError *__autoreleasing *)errorPtr;
+ (NSData *)jsonFromLoadingStarted:(AMAZONLoadingStarted *)loadingStarted error:(NSError *__autoreleasing *)errorPtr;
+ (NSData *)jsonFromAdShown:(AMAZONAdShown *)adShown error:(NSError *__autoreleasing *)errorPtr;
+ (NSData *)jsonFromIsReady:(AMAZONIsReady *)isReady error:(NSError *__autoreleasing *)errorPtr;
+ (NSData *)jsonFromIsEqual:(AMAZONIsEqual *)isEqual error:(NSError *__autoreleasing *)errorPtr;
+ (NSData *)jsonFromVoid;
+ (NSData *)jsonFromError:(NSError *)error;
+ (NSData *)jsonFromFutureError:(NSError *)error uuid:(NSString *)uuid;
+ (NSData *)jsonFromEventError:(NSError *)error eventId:(NSString *)eventId;
+ (NSData *)jsonFromEventNoOutput:(NSString *)eventId;
+ (NSData *)jsonFromAdEvent:(AMAZONAd *)aMAZONAd eventId:(NSString *)eventId error:(NSError *__autoreleasing *)errorPtr;
+ (NSData *)jsonFromAdPositionEvent:(AMAZONAdPosition *)aMAZONAdPosition eventId:(NSString *)eventId error:(NSError *__autoreleasing *)errorPtr;

@end

