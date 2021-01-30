using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EFBlazorBasics.Data
{
    public class Helper
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        public string Name { get; set; }
    }

    public class Round
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("No")]
        [Required]
        public int No { get; set; }
    }

    public class Activity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Round")]
        [Required]
        public Round Round { get; set; }

        [Column("Helper")]
        public Helper Helper { get; set; }

        [Column("Task")]
        [Required]
        public string Task { get; set; }
    }
}

