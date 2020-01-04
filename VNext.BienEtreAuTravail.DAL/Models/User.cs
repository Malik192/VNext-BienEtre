using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VNext.BienEtreAuTravail.DAL.Models.Database
{
    public class User
    {
       
        public int Id { get; set; }        
        public String Name { get; set; }
    }
    public class Employee 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmployee { get; set; }
        public string Pseudo { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        IList<CommentaireEmp> CommentaireEmployee { get; set; }
        public Employee(string pseudo)
        {
            this.Pseudo = pseudo;
        }
    }
    public class Commentaire 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCommentaire { get; set; }
        public string Description { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        IList<CommentaireEmp> CommentaireEmployee { get; set; }
    }

    internal class CommentaireEmp
    {
        public int IdEmployee { get; set; }
        public Employee Employee { get; set; }
        public int IdCommentaire { get; set; }
        public Commentaire Commentaire { get; set; }
    }
}
