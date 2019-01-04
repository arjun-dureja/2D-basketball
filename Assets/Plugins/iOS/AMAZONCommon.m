//
//  AMAZONCommon.m
//  MobileAdsCPTTestApp
//
//  Created by Crowell, Andrew on 11/17/15.
//  Copyright © 2015 Amazon.com. All rights reserved.
//

#import "AMAZONCommon.h"

@implementation AMAZONCommon

+ (NSUInteger)nextAdIdentifier
{
    static _Atomic NSUInteger adIdentifier = 0;
    return adIdentifier++;
}

@end
