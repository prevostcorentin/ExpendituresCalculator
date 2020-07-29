using System;
using System.Collections.Generic;

namespace HelloMVCWorld.Models
{
    public class Spent
    {
        private List<Spent> _subSpents;
        public Double Amount { get; set; }
        public String Name { get; set; }
    }
}
