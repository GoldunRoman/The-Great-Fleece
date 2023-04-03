//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.CloudSave.Internal.Http;



namespace Unity.Services.CloudSave.Internal.Models
{
    /// <summary>
    /// Single error in the Batch Basic Error Response.
    /// </summary>
    [Preserve]
    [DataContract(Name = "batch-basic-error-body")]
    internal class BatchBasicErrorBody
    {
        /// <summary>
        /// Single error in the Batch Basic Error Response.
        /// </summary>
        /// <param name="messages">messages param</param>
        /// <param name="key">key param</param>
        [Preserve]
        public BatchBasicErrorBody(List<string> messages, string key)
        {
            Messages = messages;
            Key = key;
        }

        /// <summary>
        /// 
        /// </summary>
        [Preserve]
        [DataMember(Name = "messages", IsRequired = true, EmitDefaultValue = true)]
        public List<string> Messages{ get; }
        /// <summary>
        /// 
        /// </summary>
        [Preserve]
        [DataMember(Name = "key", IsRequired = true, EmitDefaultValue = true)]
        public string Key{ get; }
    
    }
}

