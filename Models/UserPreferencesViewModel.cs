using System.Collections.Generic;
using Projekti.Models;

namespace Projekti.Models
{
    public class UserPreferencesViewModel
    {
        public List<Zhanre> Genres { get; set; }
        public List<int> SelectedGenreIds { get; set; }
    }
}
