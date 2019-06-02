using ServiceLayers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayers.Model
{

    public class DbInitializer
    {
        private readonly ApplicationDbContext _db;

        public DbInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Seed()
        {
            // Look for any Product.
            if (!_db.ProductOption.Any())
            {
                IProductOptionService _productOptionService = new ProductOptionService(_db);

                List<ProductOption> productOptions = new List<ProductOption>();
                {
                    ProductOption productOption1 = new ProductOption();
                    {
                        productOption1.CreatedBy = "Sameera";
                        productOption1.CreatedDate = DateTime.Now;
                        productOption1.Name = "Size";
                        productOption1.Option = "Small";
                        productOption1.IsActive = true;
                        _productOptionService.Create(productOption1);
                    }

                    ProductOption productOption2 = new ProductOption();
                    {
                        productOption2.CreatedBy = "Sameera";
                        productOption2.CreatedDate = DateTime.Now;
                        productOption2.Name = "Size";
                        productOption2.Option = "X-Small";
                        productOption2.IsActive = true;
                        _productOptionService.Create(productOption2);
                    }

                    ProductOption productOption3 = new ProductOption();
                    {
                        productOption3.CreatedBy = "Sameera";
                        productOption3.CreatedDate = DateTime.Now;
                        productOption3.Name = "Size";
                        productOption3.Option = "Medium";
                        productOption3.IsActive = true;
                        _productOptionService.Create(productOption3);
                    }

                    ProductOption productOption4 = new ProductOption();
                    {
                        productOption4.CreatedBy = "Sameera";
                        productOption4.CreatedDate = DateTime.Now;
                        productOption4.Name = "Size";
                        productOption4.Option = "Large";
                        productOption4.IsActive = true;
                        _productOptionService.Create(productOption4);
                    }
                }
            }

            if (!_db.ProductCategory.Any())
            {
                IProductCategoryService _productCategoryService = new ProductCategoryService(_db);
                List<ProductCategory> productCategories = new List<ProductCategory>();
                {
                    ProductCategory productCategory1 = new ProductCategory();
                    {
                        productCategory1.CreatedBy = "Sameera";
                        productCategory1.CreatedDate = DateTime.Now;
                        productCategory1.IsActive = true;
                        productCategory1.ProductCategoryName = "Default";
                        _productCategoryService.Create(productCategory1);
                    }
                    ProductCategory productCategory2 = new ProductCategory();
                    {
                        productCategory2.CreatedBy = "Sameera";
                        productCategory2.CreatedDate = DateTime.Now;
                        productCategory2.IsActive = true;
                        productCategory2.ProductCategoryName = "Juice";
                        _productCategoryService.Create(productCategory2);
                    }
                    ProductCategory productCategory3 = new ProductCategory();
                    {
                        productCategory3.CreatedBy = "Sameera";
                        productCategory3.CreatedDate = DateTime.Now;
                        productCategory3.IsActive = true;
                        productCategory3.ProductCategoryName = "Water";
                        _productCategoryService.Create(productCategory3);
                    }
                    ProductCategory productCategory4 = new ProductCategory();
                    {
                        productCategory4.CreatedBy = "Sameera";
                        productCategory4.CreatedDate = DateTime.Now;
                        productCategory4.IsActive = true;
                        productCategory4.ProductCategoryName = "Coffee";
                        _productCategoryService.Create(productCategory4);
                    }
                }
            }

            if (!_db.ProductType.Any())
            {
                List<ProductType> productTypes = new List<ProductType>();
                {
                    IProductTypeService _productTypeService = new ProductTypesService(_db);
                    ProductType productType1 = new ProductType();
                    {
                        productType1.CreatedBy = "Sameera";
                        productType1.CreatedDate = DateTime.Now;
                        productType1.ProductTypeName = "Default Type";
                        _productTypeService.Create(productType1);
                    }

                    ProductType productType2 = new ProductType();
                    {
                        productType2.CreatedBy = "Sameera";
                        productType2.CreatedDate = DateTime.Now;
                        productType2.ProductTypeName = "Convenience products";
                        _productTypeService.Create(productType2);
                    }

                    ProductType productType3 = new ProductType();
                    {
                        productType3.CreatedBy = "Sameera";
                        productType3.CreatedDate = DateTime.Now;
                        productType3.ProductTypeName = "Shopping products";
                        _productTypeService.Create(productType3);

                    }

                    ProductType productType4 = new ProductType();
                    {
                        productType4.CreatedBy = "Sameera";
                        productType4.CreatedDate = DateTime.Now;
                        productType4.ProductTypeName = "Speciality products";
                        _productTypeService.Create(productType4);
                    }

                    ProductType productType5 = new ProductType();
                    {
                        productType5.CreatedBy = "Sameera";
                        productType5.CreatedDate = DateTime.Now;
                        productType5.ProductTypeName = "Unsought products";
                        _productTypeService.Create(productType5);
                    }
                }
            }

            if (!_db.Product.Any())
            {
                IProductService _productService = new ProductService(_db);
                List<Product> product = new List<Product>();
                {
                    Product product1 = new Product();
                    {
                        product1.ProductName = "Test t-shirt";
                        product1.ProductImage = @"\images\ProductImage\default_image.png";
                        product1.Sku = "“Test0001";
                        product1.Variants = "“Test0001_s";
                        product1.ProductTypeIdFk = 1;
                        product1.ProductCategoryIdFk = 1;
                        product1.OnHand = true;
                        product1.Fullfilled = false;
                        product1.Instock = true;
                        product1.CreatedBy = "Sameera";
                        product1.CreatedDate = DateTime.Now;
                        product1.IsActive = true;
                        _productService.Create(product1);
                    }
                    Product product2 = new Product();
                    {
                        product2.ProductName = "Test Soap";
                        product2.ProductImage = @"\images\ProductImage\default_image.png";
                        product2.Sku = "“Test0001";
                        product2.Variants = "“Test0001_m";
                        product2.ProductTypeIdFk = 1;
                        product2.ProductCategoryIdFk = 1;
                        product2.OnHand = true;
                        product2.Fullfilled = false;
                        product2.Instock = true;
                        product2.CreatedBy = "Sameera";
                        product2.CreatedDate = DateTime.Now;
                        product2.IsActive = true;
                        _productService.Create(product2);
                    }

                    Product product3 = new Product();
                    {
                        product3.ProductName = "Test Coffee";
                        product3.ProductImage = @"\images\ProductImage\default_image.png";
                        product3.Sku = "“Test0002";
                        product3.Variants = "“Test0002_m";
                        product3.ProductTypeIdFk = 1;
                        product3.ProductCategoryIdFk = 1;
                        product3.OnHand = true;
                        product3.Fullfilled = false;
                        product3.Instock = true;
                        product3.CreatedBy = "Sameera";
                        product3.CreatedDate = DateTime.Now;
                        product3.IsActive = true;
                        _productService.Create(product3);
                    }
                };
            }

            //if (!_db.User.Any())
            //{
            //    List<User> users = new List<User>();
            //    {
            //        User user1 = new User();
            //        {
            //            user1.FirstName = "Sameera";
            //            user1.LastName = "Akhtar";
            //            user1.Username = "sameera1";
            //            IUserService userService = new UserService(_db);
            //            userService.Create(user1, "sameera1");
            //        }

            //        User user2 = new User();
            //        {
            //            user2.FirstName = "Urooj";
            //            user2.LastName = "Irfat";
            //            user2.Username = "urooj1";
            //            IUserService userService = new UserService(_db);
            //            userService.Create(user2, "sameera1");
            //        }

            //        User user3 = new User();
            //        {
            //            user3.FirstName = "Zehra";
            //            user3.LastName = "Aamir";
            //            user3.Username = "zehra1";
            //            IUserService userService = new UserService(_db);
            //            userService.Create(user3, "sameera1");
            //        }
            //    }
            //}

            if(!_db.Role.Any())
            {
                IRoleService roleService = new RoleService(_db);
                List<Role> roles = new List<Role>();
                {
                    Role role1 = new Role();
                    {
                        role1.CreatedBy = "Seeded";
                        role1.CreatedDate = DateTime.Now;
                        role1.RoleName = "Admin";
                        role1.IsActive = true;
                    }

                    Role role2 = new Role();
                    {
                        role2.CreatedBy = "Seeded";
                        role2.CreatedDate = DateTime.Now;
                        role2.RoleName = "Admin";
                        role2.IsActive = true;
                    }

                    Role role3 = new Role();
                    {
                        role3.CreatedBy = "Seeded";
                        role3.CreatedDate = DateTime.Now;
                        role3.RoleName = "Admin";
                        role3.IsActive = true;
                    }
                }
                
            }

         
        }
    }
}







                //yhan error isliye ara h qk userservice mai parameterless constructor ni h..
                //jtna mje smjh ara h isme yhan srf ek parameter kafi hga..dbcontext ka object
                //tw tm ek new constrctr bna skti ho jsme 3 ki jga ek hi parameter pass ho dbcontext ka..
                //tw ye error chala jaega..but phr thk se testing krna k ye kahin r masla na kare..qk ye service usercontroller se call hui v hai using dependency 
                //injection.. DI ka tmy idea ni hga but dekho ghor se

            //function tw yhan khtm hgya h :o
             //-_-
             //haan tou ye sab function k andr krlein bari meherbani hgi -_-
        
    
