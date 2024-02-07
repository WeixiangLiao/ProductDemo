using ProductDemo.Server.Domain.Entities;

namespace ProductDemo.Server.Persistence
;
public static class SeedData
{

    public static void SeedBuyerData(this ProductModuleDbContext dbContext)
    {
        List<Buyer> buyers = new List<Buyer>
            {
                new Buyer { Name = "John Doe", Email = "john.doe@example.com" },
    new Buyer {  Name = "Jane Smith", Email = "jane.smith@example.com" },
    new Buyer { Name = "Michael Johnson", Email = "michael.johnson@example.com" },
    new Buyer { Name = "Emily Brown", Email = "emily.brown@example.com" },
    new Buyer { Name = "William Taylor", Email = "william.taylor@example.com" },
    new Buyer { Name = "Emma Wilson", Email = "emma.wilson@example.com" },
    new Buyer { Name = "James Martinez", Email = "james.martinez@example.com" },
    new Buyer { Name = "Olivia Anderson", Email = "olivia.anderson@example.com" },
    new Buyer { Name = "Benjamin Thomas", Email = "benjamin.thomas@example.com" },
    new Buyer { Name = "Sophia Jackson", Email = "sophia.jackson@example.com" }
        };
        dbContext.AddRange(buyers);
        dbContext.SaveChanges();

    }

    public static void SeedProductData(this ProductModuleDbContext dbContext)
    {
        List<Product> products = new List<Product>
        {
   
            new Product { SKU = "IPH12BLK128GB", Title = "iPhone 12 Black 128GB", Description = "Apple iPhone 12 in Black color with 128GB storage capacity" },  
            new Product { SKU = "SAMS21ULTRA256GB", Title = "Samsung Galaxy S21 Ultra 256GB", Description = "Samsung Galaxy S21 Ultra smartphone with 256GB storage" },
            new Product { SKU = "MACBPRO2021SPACE", Title = "MacBook Pro 2021 Space Gray", Description = "Apple MacBook Pro 2021 model in Space Gray color" },
   
            new Product { SKU = "HPENVYX36015TCH", Title = "HP Envy x360 15t Touch", Description = "HP Envy x360 15t convertible laptop with touch display" },
   
            new Product { SKU = "SONYTV65IN4KUHD", Title = "Sony 65-inch 4K UHD Smart TV", Description = "Sony 65-inch smart TV with 4K Ultra HD resolution" },
    
            new Product { SKU = "BOSENC700BLKHP", Title = "Bose Noise Cancelling Headphones 700 Black", Description = "Bose Noise Cancelling Headphones 700 in Black color" },
    
            new Product { SKU = "GOOGNESTHELLO", Title = "Google Nest Hello Video Doorbell", Description = "Google Nest Hello video doorbell for home security" },
    
            new Product { SKU = "AMZKFIREHD10TAB", Title = "Amazon Kindle Fire HD 10 Tablet", Description = "Amazon Kindle Fire HD 10 tablet with 10.1-inch display" },
    
            new Product { SKU = "DELLXPS139700HDC", Title = "Dell XPS 13 9700 with Core i7", Description = "Dell XPS 13 9700 laptop with Intel Core i7 processor" },
    
            new Product { SKU = "CANONEOSRPKIT", Title = "Canon EOS RP Mirrorless Camera Kit", Description = "Canon EOS RP mirrorless camera with kit lens included" },
   
            new Product { SKU = "SAMSUNG55IN4KSUHD", Title = "Samsung 55-inch 4K Smart UHD TV", Description = "Samsung 55-inch smart TV with 4K UHD resolution" },
    
            new Product { SKU = "APPLEAIRPODS2", Title = "Apple AirPods 2nd Generation", Description = "Apple AirPods wireless earbuds with charging case" },
   
            new Product { SKU = "FITBITCHARGE4BLK", Title = "Fitbit Charge 4 Fitness Tracker Black", Description = "Fitbit Charge 4 fitness tracker in Black color" },
   
            new Product { SKU = "LGGRAM14INLAP", Title = "LG Gram 14-inch Laptop", Description = "LG Gram 14-inch ultra-lightweight laptop" },
   
            new Product { SKU = "BOSESLREVOLVEPLUS", Title = "Bose SoundLink Revolve+ Speaker", Description = "Bose SoundLink Revolve+ portable Bluetooth speaker" },
  
            new Product { SKU = "SONYWH1000XM4BLK", Title = "Sony WH-1000XM4 Wireless Headphones Black", Description = "Sony WH-1000XM4 wireless headphones in Black color" },
  
            new Product { SKU = "APPLEWATCHSER6GPS", Title = "Apple Watch Series 6 GPS", Description = "Apple Watch Series 6 with GPS tracking functionality" },
  
            new Product { SKU = "LENOVOYOGAC94014IN", Title = "Lenovo Yoga C940 14-inch Laptop", Description = "Lenovo Yoga C940 14-inch convertible laptop" },
   
            new Product { SKU = "MICROSOFTSURFACEBOOK3", Title = "Microsoft Surface Book 3", Description = "Microsoft Surface Book 3 laptop with detachable screen" },
   
            new Product { SKU = "ROKUULTRASTREAMER", Title = "Roku Ultra Streaming Player", Description = "Roku Ultra streaming media player with 4K HDR support" },
  
            new Product { SKU = "GOOGLEPIXEL5A5G", Title = "Google Pixel 5a 5G", Description = "Google Pixel 5a 5G smartphone with 6.34-inch display" }
        };
        var buyers = dbContext.Buyers.ToList();
        Random random = new Random();
        foreach (var product in products) { 
            var buyerIndex = random.Next(0, buyers.Count);
            product.BuyerId = buyers[buyerIndex].Id;
            product.Active = random.Next(2) == 0;
        }

        dbContext.AddRange(products);
        dbContext.SaveChanges();
    }
}

