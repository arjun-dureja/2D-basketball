
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
//  AMAZONAmazonMobileAdsObjectFromJson.h
//


#import <Foundation/Foundation.h>
@class AMAZONApplicationKey;
@class AMAZONShouldEnable;
@class AMAZONPlacement;
@class AMAZONAd;
@class AMAZONAdPair;

@interface AMAZONAmazonMobileAdsObjectFromJson : NSObject

+ (AMAZONApplicationKey *)applicationKeyFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr;
+ (AMAZONShouldEnable *)shouldEnableFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr;
            // Already processed: ShouldEnable
            // Already processed: ShouldEnable
+ (AMAZONPlacement *)placementFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr;
+ (AMAZONAd *)adFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr;
            // Already processed: Ad
+ (AMAZONAdPair *)adPairFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr;

@end

