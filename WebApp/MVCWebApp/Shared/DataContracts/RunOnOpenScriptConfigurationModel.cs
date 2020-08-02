using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataContracts
{
    public class RunOnOpenScriptConfigurationModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public int OriginalX { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int OriginalY { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int NewX { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int NewY { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string EffectName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string FileName { get; set; }
    }
}
