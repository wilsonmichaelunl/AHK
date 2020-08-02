using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataContracts
{
    public class PresetScriptConfigurationModel
    {
        [Required]
        public int OriginalX { get; set; }
        [Required]
        public int OriginalY { get; set; }
        [Required]
        public int NewX { get; set; }
        [Required]
        public int NewY { get; set; }
        [Required]
        public string EffectName { get; set; }
        [Required]
        public string FileName { get; set; }
    }
}
