using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Azure.Starter.Core.Models
{
    public class SampleModel : ITrackable
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; } = DateTime.Now;
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<string> Features { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public interface ITrackable
    {
        DateTime Created { get; set; }
        DateTime LastUpdated { get; set; }
    }
}