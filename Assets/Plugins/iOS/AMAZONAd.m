
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
//  AMAZONAd.m
//


#import "AMAZONAd.h"

@implementation AMAZONAd

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
        self.adType = [AMAZONEnums convertStringToAdType:[dict objectForKey:@"adType"]];
        self.identifier = [[dict objectForKey:@"identifier"] longValue];
    }
     
    return self;
}

#pragma mark - Compares

- (NSUInteger)hash
{
    NSUInteger hashCode = 17;
    NSUInteger prime = 31;
    
    hashCode = prime * hashCode + self.adType;
    hashCode = prime * hashCode + self.identifier;

    return hashCode;
}

- (BOOL)isEqual:(id)other
{
    if (other == self) {
        return YES;
    } else if ([other isKindOfClass:[self class]]) {
        return [self compare:(AMAZONAd*)other] == NSOrderedSame;
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
    
    AMAZONAd* otherAMAZONAd = other;
    
    if (otherAMAZONAd.adType != self.adType) {
        // Null checks
        if (self.adType < otherAMAZONAd.adType) {
            return NSOrderedAscending;
        } else if (self.adType > otherAMAZONAd.adType) {
            return NSOrderedDescending;
        }
    }
    
    if (otherAMAZONAd.identifier != self.identifier) {
        // Null checks
        if (self.identifier < otherAMAZONAd.identifier) {
            return NSOrderedAscending;
        } else if (self.identifier > otherAMAZONAd.identifier) {
            return NSOrderedDescending;
        }
    }
    
    return NSOrderedSame;
}

- (NSDictionary *)dictionaryValue {
    NSMutableDictionary* returnDictionary = [[NSMutableDictionary alloc] init];
    [returnDictionary setObject:[AMAZONEnums convertAdTypeToString:self.adType] forKey:@"adType"];
    [returnDictionary setObject:[NSNumber numberWithLong:self.identifier] forKey:@"identifier"];
    return returnDictionary;
}

@end
