using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationOnlineShop.Models
{
    public class Models {

    }

    public class Product
    {
        public int Id { get; set; }
        public string P_Name { get; set; }

         public int Price { get; set; }
        public string Image { get; set; }
    }

    public class ProjectModel
    {
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Image { get; set; }
        public int Product_Price { get; set; }

        public int Product_Qulaity { get; set; }
    }
    public class Ecommerce
    {
        [Required(ErrorMessage = "Enter Email id in correct format")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Invalid email")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Enter in correct password")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Password { get; set; }
    }
    public class Register
    {
        public int UserId { get; set; }



        [Required(ErrorMessage = "Enter in alphabets")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Enter in alphabets")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Enter Email id in correct format")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Invalid email")]
        public string EmailId { get; set; }



        [Required(ErrorMessage = "Enter in correct password")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Password { get; set; }



        public string Gender { get; set; }



//[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        public string Role { get; set; }

        public DateTime InsertionDate { get; set; }
    }
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
    public class Upload
    {
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }



    public class Uploads
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
    }
    }
