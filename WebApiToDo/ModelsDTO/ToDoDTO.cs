using System.ComponentModel.DataAnnotations;

namespace WebApiToDo.ModelsDTO
{
    public class ToDoDTO
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; }
    }
}
