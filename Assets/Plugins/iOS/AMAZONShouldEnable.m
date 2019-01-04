
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
//  AMAZONShouldEnable.m
//


#import "AMAZONShouldEnable.h"

@implementation AMAZONShouldEnable

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
        self.booleanValue = [[dict objectForKey:@"booleanValue"] boolValue];
    }
     
    return self;
}

#pragma mark - Compares

- (NSUInteger)hash
{
    NSUInteger hashCode = 17;
    NSUInteger prime = 31;
    
    hashCode = prime * hashCode + self.booleanValue;

    return hashCode;
}

- (BOOL)isEqual:(id)other
{
    if (other == self) {
        return YES;
    } else if ([other isKindOfClass:[self class]]) {
        return [self compare:(AMAZONShouldEnable*)other] == NSOrderedSame;
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
    
    AMAZONShouldEnable* otherAMAZONShouldEnable = other;
    
    if (otherAMAZONShouldEnable.booleanValue != self.booleanValue) {
        // Null checks
        if (self.booleanValue < otherAMAZONShouldEnable.booleanValue) {
            return NSOrderedAscending;
        } else if (self.booleanValue > otherAMAZONShouldEnable.booleanValue) {
            return NSOrderedDescending;
        }
    }
    
    return NSOrderedSame;
}

- (NSDictionary *)dictionaryValue {
    NSMutableDictionary* returnDictionary = [[NSMutableDictionary alloc] init];
    [returnDictionary setObject:[NSNumber numberWithBool:self.booleanValue] forKey:@"booleanValue"];
    return returnDictionary;
}

@end
