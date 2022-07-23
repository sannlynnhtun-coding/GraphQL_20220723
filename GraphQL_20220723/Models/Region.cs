using System.ComponentModel.DataAnnotations;

namespace GraphQL_20220723.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        public string RegionDescription { get; set; }
    }
}
