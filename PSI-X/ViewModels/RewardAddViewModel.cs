using PSI_X.Models;
using System.Collections.Generic;

namespace PSI_X.ViewModels
{
    public class RewardAddViewModel
    {
        public Rewards reward { get; set; }
        public IEnumerable<Company> companies { get; set; }
    }
}