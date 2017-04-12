using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithSociety.Models.ActivityEventModels
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Display(Name = "Event Date (YYYY-MM-DD)")]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }

        [Display(Name = "EventFrom (YYYY-MM-DD HH:MM)")]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }

        [Display(Name = "EventTo (YYYY-MM-DD HH:MM)")]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }

        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public Boolean IsActive { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateFrom > DateTo)
            {
                yield return
                  new ValidationResult(errorMessage: "Ending Time must be later than Starting Time",
                                       memberNames: new[] { "DateFrom" });
            }

            if (DateFrom.Date != DateTo.Date)
            {
                yield return
                  new ValidationResult(errorMessage: "Event must occur on same date",
                                       memberNames: new[] { "DateTo" });
            }
        }
    }
}
