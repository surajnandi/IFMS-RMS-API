using RMS.Dal.Enums;
using System.ComponentModel.DataAnnotations;

namespace RMS.Helpers
{
    public class ServiceResponse<T>
    {
        public T? Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public string Message { get; set; }
        public ICollection<ValidationResult> ValidationResults { get; set; }
    }
}
