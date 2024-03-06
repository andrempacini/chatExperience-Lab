using System;
using Dapper.Contrib.Extensions;

namespace Models {
    [Table("features")]
    public class Feature {
        [Key]
        public int FeatureID {get; set;}
        public string FeatureName {get; set;}
        public string FeatureText {get; set;}
    }
}