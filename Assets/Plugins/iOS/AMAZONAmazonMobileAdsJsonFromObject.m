
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
//  AMAZONAmazonMobileAdsJsonFromObject.m
//


#import "AMAZONAmazonMobileAdsJsonFromObject.h"
#import "AMAZONAd.h"
#import "AMAZONLoadingStarted.h"
#import "AMAZONAdShown.h"
#import "AMAZONIsReady.h"
#import "AMAZONIsEqual.h"
#import "AMAZONAdPosition.h"

@interface AMAZONAmazonMobileAdsJsonFromObject ()

+ (NSArray *)jsonArrayFromNSArray:(NSArray *)arrayValue;
+ (NSDictionary *)jsonDictionaryFromNSDictionary:(NSDictionary *)dictValue;

@end

@implementation AMAZONAmazonMobileAdsJsonFromObject

+ (NSArray *)jsonArrayFromNSArray:(NSArray *)arrayValue {
    NSMutableArray* returnArray = [NSMutableArray array];
    for (id obj in arrayValue) {
        if([obj respondsToSelector:@selector(dictionaryValue)]) {
            NSDictionary* objDict = [obj performSelector:@selector(dictionaryValue)];
            [returnArray addObject:objDict];
        } else {
            [returnArray addObject:obj];
        }
    }
    return returnArray;
}

+ (NSDictionary *)jsonDictionaryFromNSDictionary:(NSDictionary *)dictValue {
    NSMutableDictionary* returnDictionary = [NSMutableDictionary dictionary];
    for (id key in dictValue) {
        id keyToUse = key;
        id valueToUse = [dictValue objectForKey:key];
        if([keyToUse respondsToSelector:@selector(dictionaryValue)]) {
            NSDictionary* keyDict = [keyToUse performSelector:@selector(dictionaryValue)];
            keyToUse = keyDict;
        }
        if([valueToUse respondsToSelector:@selector(dictionaryValue)]) {
            if([valueToUse respondsToSelector:@selector(dictionaryValue)]) {
                NSDictionary* objDict = [valueToUse performSelector:@selector(dictionaryValue)];
                valueToUse = objDict;
            }
        }
        [returnDictionary setObject:valueToUse forKey:keyToUse];
    }
    return returnDictionary;
}

+ (NSData *)jsonFromVoid {
    NSMutableDictionary* returnDictionary = [[NSMutableDictionary alloc] init];
    NSError *error;
    return [NSJSONSerialization dataWithJSONObject:returnDictionary options:0 error:&error];
}

+ (NSData *)jsonFromError:(NSError *)error {
    NSMutableDictionary* returnDictionary = [[NSMutableDictionary alloc] init];
    [returnDictionary setObject:[error localizedDescription] forKey:@"error"];
    NSError *jsonSerializerError;
    return [NSJSONSerialization dataWithJSONObject:returnDictionary options:0 error:&jsonSerializerError];
}

+ (NSData *)jsonFromFutureError:(NSError *)error uuid:(NSString *)uuid {
    NSMutableDictionary* returnDictionary = [[NSMutableDictionary alloc] init];
    NSMutableDictionary* errorDictionary = [[NSMutableDictionary alloc] init];
    [errorDictionary setObject:[error localizedDescription] forKey:@"error"];
    [returnDictionary setObject:errorDictionary forKey:@"response"];
    [returnDictionary setObject:uuid forKey:@"callerId"];
    NSError *jsonSerializerError;
    return [NSJSONSerialization dataWithJSONObject:returnDictionary options:0 error:&jsonSerializerError];
}

+ (NSData *)jsonFromEventError:(NSError *)error eventId:(NSString *)eventId {
    NSMutableDictionary* returnDictionary = [[NSMutableDictionary alloc] init];
    NSMutableDictionary* errorDictionary = [[NSMutableDictionary alloc] init];
    [errorDictionary setObject:[error localizedDescription] forKey:@"error"];
    [returnDictionary setObject:errorDictionary forKey:@"response"];
    [returnDictionary setObject:eventId forKey:@"eventId"];
    NSError *jsonSerializerError;
    return [NSJSONSerialization dataWithJSONObject:returnDictionary options:0 error:&jsonSerializerError];
}

+ (NSData *)jsonFromEventNoOutput:(NSString *)eventId {
    NSMutableDictionary* returnDictionary = [[NSMutableDictionary alloc] init];
    [returnDictionary setObject:[NSDictionary dictionary] forKey:@"response"];
    [returnDictionary setObject:eventId forKey:@"eventId"];
    NSError *jsonSerializerError;
    return [NSJSONSerialization dataWithJSONObject:returnDictionary options:0 error:&jsonSerializerError];
}

+ (NSData *)jsonFromAd:(AMAZONAd *)ad error:(NSError *__autoreleasing *)errorPtr {
    NSDictionary* ret = [ad dictionaryValue];
    if(![NSJSONSerialization isValidJSONObject:ret]) {
        if(errorPtr) {
            NSString * domain = @"com.amazon.TestingService.ErrorDomain";
            NSUInteger errorCode = 0;
            NSMutableDictionary * userInfo = [NSMutableDictionary dictionary];
            [userInfo setObject:@"An error occured in jsonFromAd: the object passed in is not a valid json serializable object." forKey:NSLocalizedDescriptionKey];
            *errorPtr = [NSError errorWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    return [NSJSONSerialization dataWithJSONObject:ret options:0 error:errorPtr];
}

+ (NSData *)jsonFromLoadingStarted:(AMAZONLoadingStarted *)loadingStarted error:(NSError *__autoreleasing *)errorPtr {
    NSDictionary* ret = [loadingStarted dictionaryValue];
    if(![NSJSONSerialization isValidJSONObject:ret]) {
        if(errorPtr) {
            NSString * domain = @"com.amazon.TestingService.ErrorDomain";
            NSUInteger errorCode = 0;
            NSMutableDictionary * userInfo = [NSMutableDictionary dictionary];
            [userInfo setObject:@"An error occured in jsonFromLoadingStarted: the object passed in is not a valid json serializable object." forKey:NSLocalizedDescriptionKey];
            *errorPtr = [NSError errorWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    return [NSJSONSerialization dataWithJSONObject:ret options:0 error:errorPtr];
}

+ (NSData *)jsonFromAdShown:(AMAZONAdShown *)adShown error:(NSError *__autoreleasing *)errorPtr {
    NSDictionary* ret = [adShown dictionaryValue];
    if(![NSJSONSerialization isValidJSONObject:ret]) {
        if(errorPtr) {
            NSString * domain = @"com.amazon.TestingService.ErrorDomain";
            NSUInteger errorCode = 0;
            NSMutableDictionary * userInfo = [NSMutableDictionary dictionary];
            [userInfo setObject:@"An error occured in jsonFromAdShown: the object passed in is not a valid json serializable object." forKey:NSLocalizedDescriptionKey];
            *errorPtr = [NSError errorWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    return [NSJSONSerialization dataWithJSONObject:ret options:0 error:errorPtr];
}

+ (NSData *)jsonFromIsReady:(AMAZONIsReady *)isReady error:(NSError *__autoreleasing *)errorPtr {
    NSDictionary* ret = [isReady dictionaryValue];
    if(![NSJSONSerialization isValidJSONObject:ret]) {
        if(errorPtr) {
            NSString * domain = @"com.amazon.TestingService.ErrorDomain";
            NSUInteger errorCode = 0;
            NSMutableDictionary * userInfo = [NSMutableDictionary dictionary];
            [userInfo setObject:@"An error occured in jsonFromIsReady: the object passed in is not a valid json serializable object." forKey:NSLocalizedDescriptionKey];
            *errorPtr = [NSError errorWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    return [NSJSONSerialization dataWithJSONObject:ret options:0 error:errorPtr];
}

+ (NSData *)jsonFromIsEqual:(AMAZONIsEqual *)isEqual error:(NSError *__autoreleasing *)errorPtr {
    NSDictionary* ret = [isEqual dictionaryValue];
    if(![NSJSONSerialization isValidJSONObject:ret]) {
        if(errorPtr) {
            NSString * domain = @"com.amazon.TestingService.ErrorDomain";
            NSUInteger errorCode = 0;
            NSMutableDictionary * userInfo = [NSMutableDictionary dictionary];
            [userInfo setObject:@"An error occured in jsonFromIsEqual: the object passed in is not a valid json serializable object." forKey:NSLocalizedDescriptionKey];
            *errorPtr = [NSError errorWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    return [NSJSONSerialization dataWithJSONObject:ret options:0 error:errorPtr];
}

+ (NSData *)jsonFromAdEvent:(AMAZONAd *)ad eventId:(NSString *)eventId error:(NSError *__autoreleasing *)errorPtr {
    NSMutableDictionary* returnDictionary = [NSMutableDictionary dictionary];
    NSDictionary* ret = [ad dictionaryValue];
    if(![NSJSONSerialization isValidJSONObject:ret]) {
        if(errorPtr) {
            NSString * domain = @"com.amazon.TestingService.ErrorDomain";
            NSUInteger errorCode = 0;
            NSMutableDictionary * userInfo = [NSMutableDictionary dictionary];
            [userInfo setObject:@"An error occured in jsonFromAd: the object passed in is not a valid json serializable object." forKey:NSLocalizedDescriptionKey];
            *errorPtr = [NSError errorWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    [returnDictionary setObject:ret forKey:@"response"];
    [returnDictionary setObject:eventId forKey:@"eventId"];
    return [NSJSONSerialization dataWithJSONObject:returnDictionary options:0 error:errorPtr];
}

+ (NSData *)jsonFromAdPositionEvent:(AMAZONAdPosition *)adPosition eventId:(NSString *)eventId error:(NSError *__autoreleasing *)errorPtr {
    NSMutableDictionary* returnDictionary = [NSMutableDictionary dictionary];
    NSDictionary* ret = [adPosition dictionaryValue];
    if(![NSJSONSerialization isValidJSONObject:ret]) {
        if(errorPtr) {
            NSString * domain = @"com.amazon.TestingService.ErrorDomain";
            NSUInteger errorCode = 0;
            NSMutableDictionary * userInfo = [NSMutableDictionary dictionary];
            [userInfo setObject:@"An error occured in jsonFromAdPosition: the object passed in is not a valid json serializable object." forKey:NSLocalizedDescriptionKey];
            *errorPtr = [NSError errorWithDomain:domain code:errorCode userInfo:userInfo];
        }
        return nil;
    }
    [returnDictionary setObject:ret forKey:@"response"];
    [returnDictionary setObject:eventId forKey:@"eventId"];
    return [NSJSONSerialization dataWithJSONObject:returnDictionary options:0 error:errorPtr];
}

@end

