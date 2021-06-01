using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WPF.Model
{
    public class TrackRecord
    {
        public TrackRecord()
        {

        }
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public string Temperature { get; set; }

        public int EntityId { get; set; }
        public Entity Entity { get; set; }

    }
}
