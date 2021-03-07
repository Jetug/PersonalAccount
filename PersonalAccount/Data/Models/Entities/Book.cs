using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Data.Models.Entities
{
    public class Book
    {
        public Book()
        {
        }

        public Book(int id, string name, string author, int price)
        {
            Id = id;
            Name = name;
            Author = author;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }
}
