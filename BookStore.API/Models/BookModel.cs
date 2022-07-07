using System.ComponentModel.DataAnnotations; // Data Annotations is used for model validataions.

namespace BookStore.API.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please add Title of the book also")] // You can also add customised error message.
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}

// By using these validation attributes we dont need to do validations explictly(typically in controller).