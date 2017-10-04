using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSI_X.Models
{
    public class Rewards
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string RewardName { get; set; }
        public int RequiredPoints { get; set; }
    }
}