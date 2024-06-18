using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gluten_free_br.Model
{
    [Table("recipes")]
    public class Recipe
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
        
        [Column("text")]
        public string Text { get; set; }
    }
}