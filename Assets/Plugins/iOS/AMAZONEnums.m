
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
//  AMAZONEnums.m
//


#import <Foundation/Foundation.h>
#import "AMAZONEnums.h"

@implementation AMAZONEnums

NSDictionary * stringToAdType = nil;
NSDictionary * adTypeToString = nil;
NSDictionary * stringToDock = nil;
NSDictionary * dockToString = nil;
NSDictionary * stringToHorizontalAlign = nil;
NSDictionary * horizontalAlignToString = nil;
NSDictionary * stringToAdFit = nil;
NSDictionary * adFitToString = nil;

+ (void)initialize {
stringToAdType = @{
    @"FLOATING": [NSNumber numberWithInt:(FLOATING)],
    @"INTERSTITIAL": [NSNumber numberWithInt:(INTERSTITIAL)]
};

#if !__has_feature(objc_arc)
[stringToAdType retain];
#endif

adTypeToString = @{
    [NSNumber numberWithInt:(FLOATING)]: @"FLOATING",
    [NSNumber numberWithInt:(INTERSTITIAL)]: @"INTERSTITIAL"
};

#if !__has_feature(objc_arc)
[adTypeToString retain];
#endif

stringToDock = @{
    @"TOP": [NSNumber numberWithInt:(TOP)],
    @"BOTTOM": [NSNumber numberWithInt:(BOTTOM)]
};

#if !__has_feature(objc_arc)
[stringToDock retain];
#endif

dockToString = @{
    [NSNumber numberWithInt:(TOP)]: @"TOP",
    [NSNumber numberWithInt:(BOTTOM)]: @"BOTTOM"
};

#if !__has_feature(objc_arc)
[dockToString retain];
#endif

stringToHorizontalAlign = @{
    @"LEFT": [NSNumber numberWithInt:(LEFT)],
    @"CENTER": [NSNumber numberWithInt:(CENTER)],
    @"RIGHT": [NSNumber numberWithInt:(RIGHT)]
};

#if !__has_feature(objc_arc)
[stringToHorizontalAlign retain];
#endif

horizontalAlignToString = @{
    [NSNumber numberWithInt:(LEFT)]: @"LEFT",
    [NSNumber numberWithInt:(CENTER)]: @"CENTER",
    [NSNumber numberWithInt:(RIGHT)]: @"RIGHT"
};

#if !__has_feature(objc_arc)
[horizontalAlignToString retain];
#endif

stringToAdFit = @{
    @"FIT_SCREEN_WIDTH": [NSNumber numberWithInt:(FIT_SCREEN_WIDTH)],
    @"FIT_AD_SIZE": [NSNumber numberWithInt:(FIT_AD_SIZE)]
};

#if !__has_feature(objc_arc)
[stringToAdFit retain];
#endif

adFitToString = @{
    [NSNumber numberWithInt:(FIT_SCREEN_WIDTH)]: @"FIT_SCREEN_WIDTH",
    [NSNumber numberWithInt:(FIT_AD_SIZE)]: @"FIT_AD_SIZE"
};

#if !__has_feature(objc_arc)
[adFitToString retain];
#endif

}

+ (AMAZONAdType)convertStringToAdType:(NSString *)adTypeAsString{
    return [[stringToAdType objectForKey:(adTypeAsString)] intValue];
}
+ (NSString *)convertAdTypeToString:(AMAZONAdType)adType{
    return [adTypeToString objectForKey:([NSNumber numberWithInt:(adType)])];
}
+ (AMAZONDock)convertStringToDock:(NSString *)dockAsString{
    return [[stringToDock objectForKey:(dockAsString)] intValue];
}
+ (NSString *)convertDockToString:(AMAZONDock)dock{
    return [dockToString objectForKey:([NSNumber numberWithInt:(dock)])];
}
+ (AMAZONHorizontalAlign)convertStringToHorizontalAlign:(NSString *)horizontalAlignAsString{
    return [[stringToHorizontalAlign objectForKey:(horizontalAlignAsString)] intValue];
}
+ (NSString *)convertHorizontalAlignToString:(AMAZONHorizontalAlign)horizontalAlign{
    return [horizontalAlignToString objectForKey:([NSNumber numberWithInt:(horizontalAlign)])];
}
+ (AMAZONAdFit)convertStringToAdFit:(NSString *)adFitAsString{
    return [[stringToAdFit objectForKey:(adFitAsString)] intValue];
}
+ (NSString *)convertAdFitToString:(AMAZONAdFit)adFit{
    return [adFitToString objectForKey:([NSNumber numberWithInt:(adFit)])];
}

@end
