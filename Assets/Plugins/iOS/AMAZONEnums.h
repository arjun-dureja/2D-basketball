
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
//  AMAZONEnums.h
//


#import <Foundation/Foundation.h>

@interface AMAZONEnums : NSObject

typedef enum {
    FLOATING,
    INTERSTITIAL
} AMAZONAdType;

typedef enum {
    TOP,
    BOTTOM
} AMAZONDock;

typedef enum {
    LEFT,
    CENTER,
    RIGHT
} AMAZONHorizontalAlign;

typedef enum {
    FIT_SCREEN_WIDTH,
    FIT_AD_SIZE
} AMAZONAdFit;


+ (AMAZONAdType)convertStringToAdType:(NSString *)adTypeAsString;
+ (NSString *)convertAdTypeToString:(AMAZONAdType)adType;
+ (AMAZONDock)convertStringToDock:(NSString *)dockAsString;
+ (NSString *)convertDockToString:(AMAZONDock)dock;
+ (AMAZONHorizontalAlign)convertStringToHorizontalAlign:(NSString *)horizontalAlignAsString;
+ (NSString *)convertHorizontalAlignToString:(AMAZONHorizontalAlign)horizontalAlign;
+ (AMAZONAdFit)convertStringToAdFit:(NSString *)adFitAsString;
+ (NSString *)convertAdFitToString:(AMAZONAdFit)adFit;

@end
