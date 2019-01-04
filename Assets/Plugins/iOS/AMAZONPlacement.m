
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
//  AMAZONPlacement.m
//


#import "AMAZONPlacement.h"

@implementation AMAZONPlacement

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
        self.dock = [AMAZONEnums convertStringToDock:[dict objectForKey:@"dock"]];
        self.horizontalAlign = [AMAZONEnums convertStringToHorizontalAlign:[dict objectForKey:@"horizontalAlign"]];
        self.adFit = [AMAZONEnums convertStringToAdFit:[dict objectForKey:@"adFit"]];
    }
     
    return self;
}

#pragma mark - Compares

- (NSUInteger)hash
{
    NSUInteger hashCode = 17;
    NSUInteger prime = 31;
    
    hashCode = prime * hashCode + self.dock;
    hashCode = prime * hashCode + self.horizontalAlign;
    hashCode = prime * hashCode + self.adFit;

    return hashCode;
}

- (BOOL)isEqual:(id)other
{
    if (other == self) {
        return YES;
    } else if ([other isKindOfClass:[self class]]) {
        return [self compare:(AMAZONPlacement*)other] == NSOrderedSame;
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
    
    AMAZONPlacement* otherAMAZONPlacement = other;
    
    if (otherAMAZONPlacement.dock != self.dock) {
        // Null checks
        if (self.dock < otherAMAZONPlacement.dock) {
            return NSOrderedAscending;
        } else if (self.dock > otherAMAZONPlacement.dock) {
            return NSOrderedDescending;
        }
    }
    
    if (otherAMAZONPlacement.horizontalAlign != self.horizontalAlign) {
        // Null checks
        if (self.horizontalAlign < otherAMAZONPlacement.horizontalAlign) {
            return NSOrderedAscending;
        } else if (self.horizontalAlign > otherAMAZONPlacement.horizontalAlign) {
            return NSOrderedDescending;
        }
    }
    
    if (otherAMAZONPlacement.adFit != self.adFit) {
        // Null checks
        if (self.adFit < otherAMAZONPlacement.adFit) {
            return NSOrderedAscending;
        } else if (self.adFit > otherAMAZONPlacement.adFit) {
            return NSOrderedDescending;
        }
    }
    
    return NSOrderedSame;
}

- (NSDictionary *)dictionaryValue {
    NSMutableDictionary* returnDictionary = [[NSMutableDictionary alloc] init];
    [returnDictionary setObject:[AMAZONEnums convertDockToString:self.dock] forKey:@"dock"];
    [returnDictionary setObject:[AMAZONEnums convertHorizontalAlignToString:self.horizontalAlign] forKey:@"horizontalAlign"];
    [returnDictionary setObject:[AMAZONEnums convertAdFitToString:self.adFit] forKey:@"adFit"];
    return returnDictionary;
}

@end
