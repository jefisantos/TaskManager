using System;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "T�tulo � obrigat�rio.")]
        [MaxLength(100, ErrorMessage = "T�tulo n�o pode exceder 100 caracteres.")]
        public string Titulo { get; set; }

        [MaxLength(500, ErrorMessage = "Descri��o n�o pode exceder 500 caracteres.")]
        public string Descricao { get; set; }

        [Required]
        public string Status { get; set; } // Pendente, Em Progresso, Conclu�da
        public DateTime Datacriacao { get; set; } = DateTime.Now;
    }
}