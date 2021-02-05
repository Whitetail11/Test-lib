using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public ICollection<BookDTO> Books { get; set; }
    }
}
