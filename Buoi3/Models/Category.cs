namespace Buoi3.Models
{
    public class Category
    { public int Id { get; set; }
        public string? Name { get; set; }
        // co hai cach: 1. them ? sau string de cho phep null, 2. them [Required] tren truong Name kieu: public string Name {get; set} = 
        public string Description { get; set; }
    }
}
