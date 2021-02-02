using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Available { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}
