
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
//  AMAZONAmazonMobileAdsObjectFromJson.m
//


#import "AMAZONAmazonMobileAdsObjectFromJson.h"
#import "AMAZONApplicationKey.h"
#import "AMAZONShouldEnable.h"
#import "AMAZONPlacement.h"
#import "AMAZONAd.h"
#import "AMAZONAdPair.h"

@interface AMAZONAmazonMobileAdsObjectFromJson ()

+ (NSDictionary *)dictionaryWrapperFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr;
+ (NSArray *)arrayWrapperFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr;

@end

@implementation AMAZONAmazonMobileAdsObjectFromJson

+ (NSDictionary *)dictionaryWrapperFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr {
    NSObject *arg = [NSJSONSerialization JSONObjectWithData:jsonData options:0 error:errorPtr];
    return (NSDictionary *)arg;
}

+ (NSArray *)arrayWrapperFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr {
    NSObject *arg = [NSJSONSerialization JSONObjectWithData:jsonData options:0 error:errorPtr];
    return (NSArray *)arg;
}

+ (AMAZONApplicationKey *)applicationKeyFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr {
    NSError * error = nil;
    NSDictionary *dict = [AMAZONAmazonMobileAdsObjectFromJson dictionaryWrapperFromJson:jsonData error:&error];
    if(dict == nil && error) {
        if(errorPtr) {
            *errorPtr = error;
        }
        return nil;
    }
    AMAZONApplicationKey * returnApplicationKey = [[AMAZONApplicationKey alloc] initWithDictionary:dict];
    return returnApplicationKey;
}

+ (AMAZONShouldEnable *)shouldEnableFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr {
    NSError * error = nil;
    NSDictionary *dict = [AMAZONAmazonMobileAdsObjectFromJson dictionaryWrapperFromJson:jsonData error:&error];
    if(dict == nil && error) {
        if(errorPtr) {
            *errorPtr = error;
        }
        return nil;
    }
    AMAZONShouldEnable * returnShouldEnable = [[AMAZONShouldEnable alloc] initWithDictionary:dict];
    return returnShouldEnable;
}

+ (AMAZONPlacement *)placementFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr {
    NSError * error = nil;
    NSDictionary *dict = [AMAZONAmazonMobileAdsObjectFromJson dictionaryWrapperFromJson:jsonData error:&error];
    if(dict == nil && error) {
        if(errorPtr) {
            *errorPtr = error;
        }
        return nil;
    }
    AMAZONPlacement * returnPlacement = [[AMAZONPlacement alloc] initWithDictionary:dict];
    return returnPlacement;
}

+ (AMAZONAd *)adFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr {
    NSError * error = nil;
    NSDictionary *dict = [AMAZONAmazonMobileAdsObjectFromJson dictionaryWrapperFromJson:jsonData error:&error];
    if(dict == nil && error) {
        if(errorPtr) {
            *errorPtr = error;
        }
        return nil;
    }
    AMAZONAd * returnAd = [[AMAZONAd alloc] initWithDictionary:dict];
    return returnAd;
}

+ (AMAZONAdPair *)adPairFromJson:(NSData *)jsonData error:(NSError *__autoreleasing *)errorPtr {
    NSError * error = nil;
    NSDictionary *dict = [AMAZONAmazonMobileAdsObjectFromJson dictionaryWrapperFromJson:jsonData error:&error];
    if(dict == nil && error) {
        if(errorPtr) {
            *errorPtr = error;
        }
        return nil;
    }
    AMAZONAdPair * returnAdPair = [[AMAZONAdPair alloc] initWithDictionary:dict];
    return returnAdPair;
}

@end

