
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
//  AMAZONAdPair.m
//


#import "AMAZONAdPair.h"

@implementation AMAZONAdPair

#pragma mark - Lifecycle

- (instancetype)init
{
    self = [super init];
    return self;
}

- (instancetype)initWithDictionary:(NSMutableDictionary *)dict
{
    self = [super init];
    if(self) {
        self.adOne = [[AMAZONAd alloc] initWithDictionary:[dict objectForKey:@"adOne"]];
        self.adTwo = [[AMAZONAd alloc] initWithDictionary:[dict objectForKey:@"adTwo"]];
    }
     
    return self;
}

#pragma mark - Compares

- (NSUInteger)hash
{
    NSUInteger hashCode = 17;
    NSUInteger prime = 31;
    
    hashCode = prime * hashCode + (self.adOne == NULL ? 0 : [self.adOne hash]);
    hashCode = prime * hashCode + (self.adTwo == NULL ? 0 : [self.adTwo hash]);

    return hashCode;
}

- (BOOL)isEqual:(id)other
{
    if (other == self) {
        return YES;
    } else if ([other isKindOfClass:[self class]]) {
        return [self compare:(AMAZONAdPair*)other] == NSOrderedSame;
    } else {
        return NO;
    }
}

- (NSComparisonResult)compare:(id)other
{
    if (other == NULL) {
        return NSOrderedDescending;
    }
    if (other == self) {
        return NSOrderedSame;
    }
    
    AMAZONAdPair* otherAMAZONAdPair = other;
    
    if (otherAMAZONAdPair.adOne != self.adOne) {
        // Null checks
        if (self.adOne == NULL) {
            return NSOrderedAscending;
        } else if (otherAMAZONAdPair.adOne == NULL) {
            return NSOrderedDescending;
        }
        // Check with isEqual, which checks with compare if it's overriden
        if (![otherAMAZONAdPair.adOne isEqual:self.adOne]) {
            NSUInteger selfHash = [self hash];
            NSUInteger otherHash = [otherAMAZONAdPair hash];
            if(selfHash < otherHash) {
                return NSOrderedAscending;
            } else if(selfHash > otherHash) {
                return NSOrderedDescending;
            }
        }
    }
    
    if (otherAMAZONAdPair.adTwo != self.adTwo) {
        // Null checks
        if (self.adTwo == NULL) {
            return NSOrderedAscending;
        } else if (otherAMAZONAdPair.adTwo == NULL) {
            return NSOrderedDescending;
        }
        // Check with isEqual, which checks with compare if it's overriden
        if (![otherAMAZONAdPair.adTwo isEqual:self.adTwo]) {
            NSUInteger selfHash = [self hash];
            NSUInteger otherHash = [otherAMAZONAdPair hash];
            if(selfHash < otherHash) {
                return NSOrderedAscending;
            } else if(selfHash > otherHash) {
                return NSOrderedDescending;
            }
        }
    }
    
    return NSOrderedSame;
}

- (NSDictionary *)dictionaryValue {
    NSMutableDictionary* returnDictionary = [[NSMutableDictionary alloc] init];
    if(self.adOne == nil) {
        [returnDictionary setObject:[NSNull null] forKey:@"adOne"];
    } else {
        [returnDictionary setObject:[self.adOne dictionaryValue] forKey:@"adOne"];
    }
    if(self.adTwo == nil) {
        [returnDictionary setObject:[NSNull null] forKey:@"adTwo"];
    } else {
        [returnDictionary setObject:[self.adTwo dictionaryValue] forKey:@"adTwo"];
    }
    return returnDictionary;
}

@end
