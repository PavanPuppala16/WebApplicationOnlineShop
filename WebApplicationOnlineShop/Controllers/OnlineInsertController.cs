using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System.Data;
using System.Security.Claims;
using WebApplicationOnlineShop.Models;
using WebApplicationOnlineShop.NewFolder;

namespace WebApplicationOnlineShop.Controllers
{
    public class OnlineInsertController : Controller
    {
        private readonly DataBasedbContext _context;
        public OnlineInsertController(DataBasedbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        [HttpPost]
        public IActionResult Login(Ecommerce obj)
        {
            
                if (string.IsNullOrEmpty(obj.EmailID) && string.IsNullOrEmpty(obj.Password))
                {
                    return RedirectToAction("Login");
                }
                ClaimsIdentity identity = null;
                bool isAuthentic = false;
                if (obj.EmailID == "pavanpuppala1616@gmail.com" && obj.Password == "12345")
                {
                    identity = new ClaimsIdentity(new[]
                        {
                        new Claim(ClaimTypes.Name,obj.EmailID),
                        new Claim(ClaimTypes.Role,"Admin")
                        },
                         CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthentic = true;
                }
                if (obj.EmailID != "pavanpuppala1616@gmail.com" && obj.Password != "12345")
                {
                    identity = new ClaimsIdentity(new[]
                        {
                        new Claim(ClaimTypes.Name,obj.EmailID),
                        new Claim(ClaimTypes.Role,"Guest")
                        },
                         CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthentic = true;
                }
                if (isAuthentic)
                {
                    var principals = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principals);
                    return RedirectToAction("Index", "Ecommerce");
                }
                return View();
            

}
            [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Ecommerce_logics_el.Insertdata(obj);
                if (res)
                {
                    ViewBag.Message = "Your Data Inserted Sucessfully..!!";
                }
                else
                {
                    ViewBag.Message = "Data Insertion Failed";
                }
                return View(obj);
            }
            else
            {
                return View(obj);
            }
        }
      

        public IActionResult Upload(List<IFormFile> PostedFiles, Upload obj)
        {
            foreach (IFormFile PostedFile in PostedFiles)
            {
                string fileName = Path.GetFileName(PostedFile.FileName);
                string type = PostedFile.ContentType;
                byte[] bytes = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    PostedFile.CopyTo(ms);
                    bytes = ms.ToArray();
                }
                var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
                string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
                using (SqlConnection con = new SqlConnection(dbconnectionstr))
                {
                    SqlCommand cmd = new SqlCommand("sp_upload", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Product_Name", obj.Product_Name);
                    cmd.Parameters.AddWithValue("@Description", obj.Description);
                    cmd.Parameters.AddWithValue("@Name", fileName);
                    cmd.Parameters.AddWithValue("@ContentType", type);
                    cmd.Parameters.AddWithValue("@Data", bytes);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return View();
        }



        public IActionResult Index()
        {
            return View(Ecommerce_logics_el.GetALlDataDummy());
        }



        public IActionResult Cart()
        {
            return View(Ecommerce_logics_el.GetALlDataDummy());
        }



        public IActionResult Layout()
        {
            return View();
        }
    }
}
