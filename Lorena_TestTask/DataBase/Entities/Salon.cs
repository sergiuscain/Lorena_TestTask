using System.ComponentModel.DataAnnotations;

namespace Lorena_TestTask.DataBase.Entities
{
    public class Salon
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Discount { get; set; }

        public bool IsDependence { get; set; }

        [StringLength(124, ErrorMessage = "Описание не может превышать 124 символа.")]
        public string Description { get; set; }

        // Связь с родительским элементом
        public Guid? ParentId { get; set; } // Nullable для корневых элементов
        public Salon Parent { get; set; }

        // Дочерние элементы
        public ICollection<Salon> Children { get; set; } = new List<Salon>();

    }
}
