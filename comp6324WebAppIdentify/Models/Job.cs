using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace comp6324WebAppIdentify.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public string deviceID { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> CloseTime { get; set; }
        public Boolean Done { get; set; }

    }

    public class Measurement
    {
        public int MeasurementID { get; set; }
        public string deviceID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime timestamp { get; set; }
        public double brightness { get; set; }
        public double vdd { get; set; }
        public Nullable<int> status { get; set; }

    }

    public class TestSchedule
    {
        [Key]
        public int ScheduleID { get; set; }
        public string deviceID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ScheduleTime { get; set; }
        public Boolean Done { get; set; }

    }
}
