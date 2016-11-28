using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fast_Math_exe {
    //Holds A Record
    public class Record {
        public Record(List<decimal> problemTimes, decimal totalTime, decimal averageTime, string holder, DateTime date, decimal score) {
            this.problemTimes = problemTimes;
            this.totalTime = totalTime;
            this.averageTime = averageTime;
            this.holder = holder;
            this.date = String.Format("{0:d} {0:t}", date);
            this.score = score;
        }
        public List<decimal> problemTimes { get; }
        public decimal totalTime { get; }
        public decimal averageTime { get; }
        public string holder { get; }
        public string date { get; }
        public decimal score { get; }
    }
}
