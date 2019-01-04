
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
    public sealed class Placement : Jsonable
    {
        private static AmazonLogger logger = new AmazonLogger("Pi");

        public Dock Dock{get;set;}
        public HorizontalAlign HorizontalAlign{get;set;}
        public AdFit AdFit{get;set;}

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
                
                objectDictionary.Add("dock", Dock);
                objectDictionary.Add("horizontalAlign", HorizontalAlign);
                objectDictionary.Add("adFit", AdFit);
                return objectDictionary;
            } 
            catch(System.ApplicationException ex) 
            {
                throw new AmazonException("Error encountered while getting object dictionary", ex);
            }
        }

        public static Placement CreateFromDictionary(Dictionary<string, object> jsonMap) 
        {
            try 
            {
                if (jsonMap == null)
                {
                    return null;
                }

                var request = new Placement();
                
                
                if(jsonMap.ContainsKey("dock")) 
                {
                    request.Dock = (Dock) System.Enum.Parse(typeof(Dock), (string) jsonMap["dock"]);
                }
                
                if(jsonMap.ContainsKey("horizontalAlign")) 
                {
                    request.HorizontalAlign = (HorizontalAlign) System.Enum.Parse(typeof(HorizontalAlign), (string) jsonMap["horizontalAlign"]);
                }
                
                if(jsonMap.ContainsKey("adFit")) 
                {
                    request.AdFit = (AdFit) System.Enum.Parse(typeof(AdFit), (string) jsonMap["adFit"]);
                }

                return request;
            } 
            catch (System.ApplicationException ex) 
            {
                throw new AmazonException("Error encountered while creating Object from dicionary", ex);
            }
        }

        public static Placement CreateFromJson(string jsonMessage)
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
        

        public static Dictionary<string, Placement> MapFromJson(Dictionary<string, object> jsonMap)
        {
            Dictionary<string, Placement> result = new Dictionary<string, Placement>();
            foreach (var entry in jsonMap)
            {
                Placement value = CreateFromDictionary(entry.Value as Dictionary<string, object>);
                result.Add(entry.Key, value);
            }
            return result;
        }
        
        public static List<Placement> ListFromJson(List<object> array)
        {
            List<Placement> result = new List<Placement>();
            foreach (var e in array)
            {
                result.Add(CreateFromDictionary(e as Dictionary<string, object>));
            }
            return result;
        }
    }
}
