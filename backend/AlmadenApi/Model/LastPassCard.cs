using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlmadenApi.Model
{
    public class LastPassCard
    {
        [Key]
        public int Id { get; set; }

        public string ?Url { get; set; }
        public string ?Name { get; set; }

        // Categorias  
        public int ?PK_FolderId { get; set; }

        public int ?Pk_UserId{get;set;}

        public Folder ?folder {get;set;}
        public string ?UserName { get; set; }
        public string ?Password { get; set; }
        public string ? Notes { get; set; }

        
        public string ?create_at { get; set; }

        public string ? update_at { get; set; }

        
        public LastPassCard()
        {
            create_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            update_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }
        
    }

   
}