
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


using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using com.amazon.mas.cpt.ads.json;


namespace com.amazon.mas.cpt.ads
{
    public sealed class AdPosition : Jsonable
    {
        private static AmazonLogger logger = new AmazonLogger("Pi");

        public Ad Ad{get;set;}
        public int XCoordinate{get;set;}
                public int YCoordinate{get;set;}
                public int Width{get;set;}
                public int Height{get;set;}
        
        public string ToJson()
        {
            try
            {
                Dictionary<string, object> toJson = this.GetObjectDictionary();
                return Json.Serialize(toJson);
            }
            catch(System.ApplicationException ex)
            {
                throw new AmazonException("Error encountered while Jsoning", ex);
            }
        }

        public override Dictionary<string, object> GetObjectDictionary() 
        {
            try 
            {
                Dictionary<string, object> objectDictionary = new Dictionary<string, object>();
                
                objectDictionary.Add("ad", (Ad != null) ? Ad.GetObjectDictionary() : null);
                objectDictionary.Add("xCoordinate", XCoordinate);
                objectDictionary.Add("yCoordinate", YCoordinate);
                objectDictionary.Add("width", Width);
                objectDictionary.Add("height", Height);
                return objectDictionary;
            } 
            catch(System.ApplicationException ex) 
            {
                throw new AmazonException("Error encountered while getting object dictionary", ex);
            }
        }

        public static AdPosition CreateFromDictionary(Dictionary<string, object> jsonMap) 
        {
            try 
            {
                if (jsonMap == null)
                {
                    return null;
                }

                var request = new AdPosition();
                
                
                if(jsonMap.ContainsKey("ad")) 
                {
                    request.Ad = Ad.CreateFromDictionary(jsonMap["ad"] as Dictionary<string, object>); 
                }
                
                if(jsonMap.ContainsKey("xCoordinate")) 
                {
                    request.XCoordinate = System.Convert.ToInt32(jsonMap["xCoordinate"]);
                }
                
                if(jsonMap.ContainsKey("yCoordinate")) 
                {
                    request.YCoordinate = System.Convert.ToInt32(jsonMap["yCoordinate"]);
                }
                
                if(jsonMap.ContainsKey("width")) 
                {
                    request.Width = System.Convert.ToInt32(jsonMap["width"]);
                }
                
                if(jsonMap.ContainsKey("height")) 
                {
                    request.Height = System.Convert.ToInt32(jsonMap["height"]);
                }

                return request;
            } 
            catch (System.ApplicationException ex) 
            {
                throw new AmazonException("Error encountered while creating Object from dicionary", ex);
            }
        }

        public static AdPosition CreateFromJson(string jsonMessage)
        {
            try 
            {
                Dictionary<string, object> jsonMap = Json.Deserialize(jsonMessage) as Dictionary<string, object>;
                Jsonable.CheckForErrors(jsonMap);
                return CreateFromDictionary(jsonMap);
            }
            catch(System.ApplicationException ex)
            {
                throw new AmazonException("Error encountered while UnJsoning", ex);
            }
        }
        

        public static Dictionary<string, AdPosition> MapFromJson(Dictionary<string, object> jsonMap)
        {
            Dictionary<string, AdPosition> result = new Dictionary<string, AdPosition>();
            foreach (var entry in jsonMap)
            {
                AdPosition value = CreateFromDictionary(entry.Value as Dictionary<string, object>);
                result.Add(entry.Key, value);
            }
            return result;
        }
        
        public static List<AdPosition> ListFromJson(List<object> array)
        {
            List<AdPosition> result = new List<AdPosition>();
            foreach (var e in array)
            {
                result.Add(CreateFromDictionary(e as Dictionary<string, object>));
            }
            return result;
        }
    }
}
