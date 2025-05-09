/*
 * Calculator API
 *
 * API שמבצע פעולה חשבונית על שני מספרים לפי כותרת Header
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CalculateBody : IEquatable<CalculateBody>
    { 
        /// <summary>
        /// המספר הראשון
        /// </summary>
        /// <value>המספר הראשון</value>
        [Required]

        [DataMember(Name="number1")]
        public decimal? Number1 { get; set; }

        /// <summary>
        /// המספר השני
        /// </summary>
        /// <value>המספר השני</value>
        [Required]

        [DataMember(Name="number2")]
        public decimal? Number2 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CalculateBody {\n");
            sb.Append("  Number1: ").Append(Number1).Append("\n");
            sb.Append("  Number2: ").Append(Number2).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CalculateBody)obj);
        }

        /// <summary>
        /// Returns true if CalculateBody instances are equal
        /// </summary>
        /// <param name="other">Instance of CalculateBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CalculateBody other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Number1 == other.Number1 ||
                    Number1 != null &&
                    Number1.Equals(other.Number1)
                ) && 
                (
                    Number2 == other.Number2 ||
                    Number2 != null &&
                    Number2.Equals(other.Number2)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Number1 != null)
                    hashCode = hashCode * 59 + Number1.GetHashCode();
                    if (Number2 != null)
                    hashCode = hashCode * 59 + Number2.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CalculateBody left, CalculateBody right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CalculateBody left, CalculateBody right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
