
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
//  AMAZONAdPosition.m
//


#import "AMAZONAdPosition.h"

@implementation AMAZONAdPosition

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
        self.ad = [[AMAZONAd alloc] initWithDictionary:[dict objectForKey:@"ad"]];
        self.xCoordinate = [[dict objectForKey:@"xCoordinate"] integerValue];
        self.yCoordinate = [[dict objectForKey:@"yCoordinate"] integerValue];
        self.width = [[dict objectForKey:@"width"] integerValue];
        self.height = [[dict objectForKey:@"height"] integerValue];
    }
     
    return self;
}

#pragma mark - Compares

- (NSUInteger)hash
{
    NSUInteger hashCode = 17;
    NSUInteger prime = 31;
    
    hashCode = prime * hashCode + (self.ad == NULL ? 0 : [self.ad hash]);
    hashCode = prime * hashCode + self.xCoordinate;
    hashCode = prime * hashCode + self.yCoordinate;
    hashCode = prime * hashCode + self.width;
    hashCode = prime * hashCode + self.height;

    return hashCode;
}

- (BOOL)isEqual:(id)other
{
    if (other == self) {
        return YES;
    } else if ([other isKindOfClass:[self class]]) {
        return [self compare:(AMAZONAdPosition*)other] == NSOrderedSame;
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
    
    AMAZONAdPosition* otherAMAZONAdPosition = other;
    
    if (otherAMAZONAdPosition.ad != self.ad) {
        // Null checks
        if (self.ad == NULL) {
            return NSOrderedAscending;
        } else if (otherAMAZONAdPosition.ad == NULL) {
            return NSOrderedDescending;
        }
        // Check with isEqual, which checks with compare if it's overriden
        if (![otherAMAZONAdPosition.ad isEqual:self.ad]) {
            NSUInteger selfHash = [self hash];
            NSUInteger otherHash = [otherAMAZONAdPosition hash];
            if(selfHash < otherHash) {
                return NSOrderedAscending;
            } else if(selfHash > otherHash) {
                return NSOrderedDescending;
            }
        }
    }
    
    if (otherAMAZONAdPosition.xCoordinate != self.xCoordinate) {
        // Null checks
        if (self.xCoordinate < otherAMAZONAdPosition.xCoordinate) {
            return NSOrderedAscending;
        } else if (self.xCoordinate > otherAMAZONAdPosition.xCoordinate) {
            return NSOrderedDescending;
        }
    }
    
    if (otherAMAZONAdPosition.yCoordinate != self.yCoordinate) {
        // Null checks
        if (self.yCoordinate < otherAMAZONAdPosition.yCoordinate) {
            return NSOrderedAscending;
        } else if (self.yCoordinate > otherAMAZONAdPosition.yCoordinate) {
            return NSOrderedDescending;
        }
    }
    
    if (otherAMAZONAdPosition.width != self.width) {
        // Null checks
        if (self.width < otherAMAZONAdPosition.width) {
            return NSOrderedAscending;
        } else if (self.width > otherAMAZONAdPosition.width) {
            return NSOrderedDescending;
        }
    }
    
    if (otherAMAZONAdPosition.height != self.height) {
        // Null checks
        if (self.height < otherAMAZONAdPosition.height) {
            return NSOrderedAscending;
        } else if (self.height > otherAMAZONAdPosition.height) {
            return NSOrderedDescending;
        }
    }
    
    return NSOrderedSame;
}

- (NSDictionary *)dictionaryValue {
    NSMutableDictionary* returnDictionary = [[NSMutableDictionary alloc] init];
    if(self.ad == nil) {
        [returnDictionary setObject:[NSNull null] forKey:@"ad"];
    } else {
        [returnDictionary setObject:[self.ad dictionaryValue] forKey:@"ad"];
    }
    [returnDictionary setObject:[NSNumber numberWithInt:self.xCoordinate] forKey:@"xCoordinate"];
    [returnDictionary setObject:[NSNumber numberWithInt:self.yCoordinate] forKey:@"yCoordinate"];
    [returnDictionary setObject:[NSNumber numberWithInt:self.width] forKey:@"width"];
    [returnDictionary setObject:[NSNumber numberWithInt:self.height] forKey:@"height"];
    return returnDictionary;
}

@end
