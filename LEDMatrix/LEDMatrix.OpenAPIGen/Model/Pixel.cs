/*
 * LEDMatrix.Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// Pixel
    /// </summary>
    [DataContract(Name = "Pixel")]
    public partial class Pixel : IEquatable<Pixel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pixel" /> class.
        /// </summary>
        /// <param name="position">position.</param>
        /// <param name="color">color.</param>
        public Pixel(Int32Vector2 position = default(Int32Vector2), Color color = default(Color))
        {
            this.Position = position;
            this.Color = color;
        }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [DataMember(Name = "position", EmitDefaultValue = false)]
        public Int32Vector2 Position { get; set; }

        /// <summary>
        /// Gets or Sets Color
        /// </summary>
        [DataMember(Name = "color", EmitDefaultValue = false)]
        public Color Color { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Pixel {\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Pixel);
        }

        /// <summary>
        /// Returns true if Pixel instances are equal
        /// </summary>
        /// <param name="input">Instance of Pixel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Pixel input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Position == input.Position ||
                    (this.Position != null &&
                    this.Position.Equals(input.Position))
                ) && 
                (
                    this.Color == input.Color ||
                    (this.Color != null &&
                    this.Color.Equals(input.Color))
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
                int hashCode = 41;
                if (this.Position != null)
                {
                    hashCode = (hashCode * 59) + this.Position.GetHashCode();
                }
                if (this.Color != null)
                {
                    hashCode = (hashCode * 59) + this.Color.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
