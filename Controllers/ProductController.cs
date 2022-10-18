using Microsoft.AspNetCore.Mvc;
using Assignment_12._1.Services;
using Assignment_12._1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment_12._1.Controllers  //Step 6. Add Product Controller in 'Controllers' folder
{
    //Step 7. Add Product folder in 'Views' folder
    //Step 8. Inject service
    public class ProductController : Controller
    {
        private ICRUD ProductRepository;
        private IFileUploadService fileUploadService;   
        public ProductController(ICRUD ProductRepository, IFileUploadService fileUploadService)    //ProductController constructor for dependency injection
        {
            this.ProductRepository = ProductRepository;       //get reference of ProductRepository class
            this.fileUploadService = fileUploadService; 
        } 
        [Authorize (Roles = "Customer")]    //STEP 10. ADD ROLE ATTRIBUTES
        public IActionResult Index()
        {
            //Step 9. write indexmodel and logic in index method (IndexViewModel.cs created in 'Models')
            IndexViewModel model = new IndexViewModel();
            model.Products = ProductRepository.GetProducts();
            return View(model);
            //Step 10. Add index view in Product folder (Index.cshtml) //add new Razor View, name it Index, List, IndexViewModel
        }
        [Authorize (Roles ="Admin")]
        public IActionResult Create()//first time clicking on create new link will return View() //this is get
        {
            Product product = new Product();    //new blank object
            product.Id = ProductRepository.GetMaxId();  
            return View(product);
        }

        [HttpPost]  //this create method is post
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(Product obj, IFormFile file)   //method overload
        {
            if (ModelState.IsValid)
            {
                if(await fileUploadService.UploadFile(file))
                {
                    obj.ImageName = fileUploadService.FileName;
                    ProductRepository.AddProduct(obj);
                    return RedirectToRoute(new { Action = "Index", Controller = "Product" }); //redirect view to see record that was added
                }
                else
                {
                    ViewBag.ErrorMessage = "File upload failed";
                    return View(obj);
                }
                //ViewBag.Message = "Product added successfully!";    //display message on the view
                
            }

            ViewBag.Message = "Error adding product.";
            return View(obj);
        }

        //Step 11. Add Details Action
        [Authorize(Roles = "Customer")]
        public IActionResult Details(int id)
        {
            var prod = ProductRepository.GetProduct(id);
            if(prod == null)
            {
                return NotFound();
            }
            return View(prod);
        }
        
        [HttpGet]   //not required but this is the get method   //HttpGet by default
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var prod = ProductRepository.GetProduct(id);
            return View(prod);  //in the view, pass the model(prod)
        }

        [HttpPost]  //submitting change
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                ProductRepository.UpdateProduct(obj);
                return RedirectToAction("Index"); //redirect user to index page one edit is submitted
            }

            ViewBag.Message = "Error editing product information";  //these 2 lines will be executed if there is an error in data
            return View(obj);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            ProductRepository.DeleteProduct(id);
            return RedirectToAction("Index");   
        }
    }
}
