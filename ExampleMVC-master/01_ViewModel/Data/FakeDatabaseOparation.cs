using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01_ViewModel.Data
{
    public class FakeDatabaseOparation
    {

        public static List<Patlangac> patlangacs = new List<Patlangac>
        {
            new Patlangac
            {
                Id=1,
                Name="Yeni Ürün",
                Description=""
            },
            new Patlangac
            {
                Id=2,
                Name="Şok Fiyat",
                Description=""
            },
             new Patlangac
            {
                Id=3,
                Name="En iyi Fiyat",
                Description=""
            }
        };

        public static List<Category> categories = new List<Category>
        {
            new Category
            {
                ID=1,
                Name="Bilgisayar"
            },
            new Category
            {
                ID=2,
                Name="Beyaz Eşya"
            }

        };

        public static List<Product> products = new List<Product>
        {
            new Product
            {
                Id=1,
                Name="Iphonex",
                Desription="Telefon",
                Patlangacs=new List<Patlangac>(),
                Price=2800,
                CategoryID=1,
                Category=categories.First(t=>t.ID==1)
            },
            new Product
            {
                Id=2,
                Name="Sansung",
                Desription="Telefon",
                Patlangacs=new List<Patlangac>(),
                Price=3800,
                CategoryID=2,
                Category=categories.First(t=>t.ID==2)
            }

        };


        public static BannerArea bannerArea = new BannerArea
        {
            Id = 1,
            BanProducts = new List<Product>
            {
                new Product
            {
                Id=2,
                Name="Sansung",
                Desription="Telefon",
                Patlangacs=null,
                Price=3800
            }

            }

        };


        public static Product getProductByID(int id)
        {
            Product product = null;
            foreach (var item in products)
            {
                if (item.Id == id)
                {
                    product = item;
                    break;
                }
            }
            return product;
        }

        public static void addProduct(Product product, List<int> patlangacIds)
        {
            product.Id = products.Last().Id + 1;

            product.Category = categories.First(t => t.ID == product.CategoryID);

            product.Patlangacs = new List<Patlangac>();

            foreach (int patlangacId in patlangacIds)
            {
                //Func<Patlangac,bool>--> ben sana Patlangac verisi veriyim sen bana bool donus yap
                Patlangac patlangac = patlangacs.First(t => t.Id == patlangacId);
                product.Patlangacs.Add(patlangac);
            }





            products.Add(product);

        }


        public static void updateProduct(Product product, List<int> patlangacIds)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == product.Id)
                {

                    products[i] = product;
                    break;
                }

            }

            product.Category = categories.First(y => y.ID == product.CategoryID);
            product.Patlangacs = new List<Patlangac>();


            foreach (int patlangacId in patlangacIds)
            {
                //Func<Patlangac,bool>--> ben sana Patlangac verisi veriyim sen bana bool donus yap
                Patlangac patlangac = patlangacs.First(t => t.Id == patlangacId);
                product.Patlangacs.Add(patlangac);
            }

        }
        public static void deleteProduct(int id)
        {
            Product aranan = null;

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == id)
                {

                    aranan = products[i];
                    break;
                }

            }

            products.Remove(aranan);

        }
    }
}