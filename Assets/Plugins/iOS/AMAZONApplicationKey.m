
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
//  AMAZONApplicationKey.m
//


#import "AMAZONApplicationKey.h"

@implementation AMAZONApplicationKey

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
        self.stringValue = [dict objectForKey:@"stringValue"];
    }
     
    return self;
}

#pragma mark - Compares

- (NSUInteger)hash
{
    NSUInteger hashCode = 17;
    NSUInteger prime = 31;
    
    hashCode = prime * hashCode + (self.stringValue == NULL ? 0 : [self.stringValue hash]);

    return hashCode;
}

- (BOOL)isEqual:(id)other
{
    if (other == self) {
        return YES;
    } else if ([other isKindOfClass:[self class]]) {
        return [self compare:(AMAZONApplicationKey*)other] == NSOrderedSame;
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
    
    AMAZONApplicationKey* otherAMAZONApplicationKey = other;
    
    if (otherAMAZONApplicationKey.stringValue != self.stringValue) {
        // Null checks
        if (self.stringValue == NULL) {
            return NSOrderedAscending;
        } else if (otherAMAZONApplicationKey.stringValue == NULL) {
            return NSOrderedDescending;
        }
        // Check with isEqual, which checks with compare if it's overriden
        if (![otherAMAZONApplicationKey.stringValue isEqual:self.stringValue]) {
            NSUInteger selfHash = [self hash];
            NSUInteger otherHash = [otherAMAZONApplicationKey hash];
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
    if(self.stringValue == nil) {
        [returnDictionary setObject:[NSNull null] forKey:@"stringValue"];
    } else {
        [returnDictionary setObject:self.stringValue forKey:@"stringValue"];
    }
    return returnDictionary;
}

@end
