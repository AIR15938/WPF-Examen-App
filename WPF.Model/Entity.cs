using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace WPF.Model
{
    public class Entity
    {

        public Entity()
        {
            TrackRecords = new Collection<TrackRecord>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Remarks { get; set; }

        public ICollection<TrackRecord> TrackRecords { get; set; }
    }
}
