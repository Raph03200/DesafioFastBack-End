using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DesafioFast.models
{
    public class PresencaModel
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public required int WorkshopId { get; set; }

        public List<int> ColaboradorIds { get; set; } = new List<int>();
    }
}