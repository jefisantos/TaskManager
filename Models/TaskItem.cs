using System;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Título não pode exceder 100 caracteres.")]
        public string Titulo { get; set; }

        [MaxLength(500, ErrorMessage = "Descrição não pode exceder 500 caracteres.")]
        public string Descricao { get; set; }

        [Required]
        public string Status { get; set; } // Pendente, Em Progresso, Concluída
        public DateTime Datacriacao { get; set; } = DateTime.Now;
    }
}