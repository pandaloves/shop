using shop.Entities;
using Microsoft.EntityFrameworkCore;

namespace shop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ShopUser> ShopUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ProductId = 1,
                ProductName = "Joely short dress",
                ProductPrice = 299,
                ProductDescription = "100% polyester. Polyester och andra syntetmaterial tappar mikroplast vid tv�tt, s� vi rekommenderar en tv�ttp�se f�r att skydda alla tyger och plagg fr�n att slitas eller str�ckas ut i tv�ttmaskinen. Det kommer ocks� att begr�nsa mikrofiberl�ckage i tv�ttprocessen, vilket inneb�r att mikroplaster f�rhindras fr�n att tr�nga in i floder och hav.",
                ProductImage = "https://image-resizing.booztcdn.com/ida-sjostedt/istjoelydress_cros_10.webp?has_grey=0&has_webp=0&dpr=2.5&size=w400"
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Sienna hot pink dress",
                ProductPrice = 499,
                ProductDescription = "Skivad tyll formar den h�r uttalande kl�nningen som har en l�tt rynkad livdel med en s�t halsringning (med halkfria remsor), inramad av axelband. Den passande midjan toppar en snurrv�rd skaterkjol som slutar i en flirtig minif�ll. Dold dragkedja/l�s baktill.",
                ProductImage = "https://www.beginningboutique.com/cdn/shop/files/Ella-Light-Pink-Off-Shoulder-Formal-Maxi-Dress-1_750x.jpg?v=1695082651"
            },
            new Product
            {
                ProductId = 3,
                ProductName = "Wide-Leg Dense Silk Trousers",
                ProductPrice = 399,
                ProductDescription = "Ett l�tt tyg tillverkat av premium mullb�rssilkefibrer, d�r en del av dem �r vridna medurs och andra i moturs riktning. Dessa fibrer v�vs sedan till ett sl�ttv�vt tyg.",
                ProductImage = "https://slimages.macysassets.com/is/image/MCY/products/3/optimized/24486773_fpx.tif?op_sharpen=1&wid=700&hei=855&fit=fit,1"
            },
            new Product
            {
                ProductId = 4,
                ProductName = "Green Textured Long Coat",
                ProductPrice = 599,
                ProductDescription = "Oversized dubbelkn�ppt skr�ddarsydd kappa med breda, vassa vadderade axlar. Tillverkad av en borstad ullblandning som �r gjord av �tervunnet tyg.",
                ProductImage = "https://thehouseofrare.com/cdn/shop/files/DUNE-GREEN-CC-01672HERO.jpg?v=1692181253"
            },
            new Product
            {
                ProductId = 5,
                ProductName = "Cottinfab dress",
                ProductPrice = 399,
                ProductDescription = "Gr�na och bl�a etniska motiv tryckt a-line kl�nning Fyrkantig hals Trekvarts, puff�rm Samlad eller veckad detalj Maxi l�ngd i volangf�ll.",
                ProductImage = "https://cottinfab.com/cdn/shop/products/DSS9849B_1.jpg?v=1658397269"
            },
            new Product
            {
                ProductId = 6,
                ProductName = "Cottinfab blue long dress",
                ProductPrice = 599,
                ProductDescription = "Var ditt modiga jag med denna eleganta bl� a-linje kl�nning fr�n huset av Cottinfab. Tillverkad i f�rstklassig viskos f�r superb glans och drapering, den �r vacker.",
                ProductImage = "https://img.tatacliq.com/images/i7/437Wx649H/MP000000011546729_437Wx649H_202112231153021.jpeg"
            },
            new Product
            {
                ProductId = 7,
                ProductName = "Trench Coats for Women",
                ProductPrice = 499,
                ProductDescription = "En trenchcoat �r en viktig reses�llskap och erbjuder en blandning av stil, funktionalitet och anpassningsf�rm�ga. Det �r en p�litlig sk�ld mot v�xlande v�der som h�ller dig torr och bekv�m samtidigt som den ger extra v�rme i kallare klimat.",
                ProductImage = "https://m.media-amazon.com/images/I/51J7wbYdUFL._AC_UY1000_.jpg"
            },
            new Product
            {
                ProductId = 8,
                ProductName = "Pink Solid Dress",
                ProductPrice = 299,
                ProductDescription = "Letar du efter en fantastisk samling kl�nningar? ja, l�gg h�nderna p� den h�r kl�nningen fr�n trend arrest och f� �ven m�jligheten att v�lja mellan lavendelf�rg.",
                ProductImage = "https://www.berrylush.com/cdn/shop/products/BeFunky-design_20_01f99db8-d17c-4f5d-b92b-51a5d1b0fc0b.jpg?v=1628422958"
            },
            new Product
            {
                ProductId = 9,
                ProductName = "Oversize wool coat",
                ProductPrice = 899,
                ProductDescription = "Ullmix tyg. Midi design. Oversize design. Lapel-krage V-ringad krage. L�ng�rmad. Tv� sidfickor. Kn�ppning framtill. Slits baktill. Innerfoder. Office utseende.",
                ProductImage = "https://st.mngbcn.com/rcs/pics/static/T6/fotos/S20/67060448_99.jpg?ts=1699012974202&imwidth=360&imdensity=2"
            },
            new Product
            {
                ProductId = 10,
                ProductName = "Women's Organic V-neck Tshirt",
                ProductPrice = 259,
                ProductDescription = "Att bygga en gr�nare, renare garderob b�rjar med t-shirts som den h�r. V�r Essential Women's V-neck T-shirt �r uppfriskande annorlunda �n eng�ngs-T-shirts, och �r gjord av rej�l och otroligt mjuk organisk peruansk Pima-bomull som kommer att h�lla i �r, ja �r, av entusiastisk anv�ndning. Toppen med v-ringning �r l�tt rundad f�r en mjukare look och precis lagom djup.95 % ekologisk Pima bomull 5 % elastan stretchjersey.",
                ProductImage = "https://www.fairindigo.com/cdn/shop/files/BG_OF_03974_Sage_SS24_1535_720x.jpg?v=1710026423"
            },
            new Product
            {
                ProductId = 11,
                ProductName = "Straight Leg 4-Season Trousers",
                ProductPrice = 730,
                ProductDescription =
         "Ett par 4-s�songsbyxor i klassisk rakbensform med en f�rg som aldrig g�r ur stilen. De rena linjerna �r gjorda f�r att smickra dina kurvor. V�r 4-s�songskollektion �r den ultimata l�sningen f�r m�ngsidig garderob �ret runt.",
                ProductImage =
         "https://lanebryant.scene7.com/is/image/lanebryantProdATG/401208_0000009187?$pdpMainImage$"
            },
             new Product
             {
                 ProductId = 12,
                 ProductName = "Men's Aran Wool Sweater",
                 ProductPrice = 589,
                 ProductDescription =
         "Aran Sweater �r en tidl�s garderob som �r n�dv�ndig och en tr�ja f�r livet. B�rd i �rhundraden av fiskaren fr�n Irland och popul�r av Vogue p� 1950-talet, den h�r robusta tr�jan �r en sann m�ngsysslare.",
                 ProductImage =
         "https://cdn11.bigcommerce.com/s-scgdirr/products/17595/images/92077/C1347_-_Moss_Green__69889.1676391063.560.850.jpg?c=2"
             },
               new Product
               {
                   ProductId = 13,
                   ProductName = "Women Gold SolidCasual Sweater",
                   ProductPrice = 359,
                   ProductDescription =
         "Vi presenterar den lyxiga guldtr�jan fr�n Allen Solly, designad f�r kvinnor som v�rderar mode och komfort lika mycket. Den h�r huvtr�jan �r gjord av mysigt akrylmaterial och lovar en �tsittande passform f�r ultimat komfort.",
                   ProductImage =
         "https://imagescdn.planetfashion.in/img/app/product/6/643576-6434989.jpg?auto=format&w=494.40000000000003"
               },
                    new Product
                    {
                        ProductId = 14,
                        ProductName = "Winter Thick Warm Parka Men Jacket",
                        ProductPrice = 2019,
                        ProductDescription =
         "H�ller dig torr och bekv�m - Den h�r vinterjackan f�r m�n har en tuff vattent�t finish, vilket s�kerst�ller att du f�rblir skyddad och torr. L�t inte v�dret d�mpa ditt hum�r - den h�r vinterjackan f�r m�n �r designad f�r att h�lla dig bekv�m och snygg oavsett vad Moder Natur kastar p� dig.",
                        ProductImage =
         "https://m.media-amazon.com/images/I/71MlHIksisL._AC_SX569_.jpg"
                    },
                    new Product
                    {
                        ProductId = 15,
                        ProductName = "Cotton Casual Shirt",
                        ProductPrice = 299,
                        ProductDescription =
         "Tillverkad av premium bomullstyg som �r mjukt, bekv�mt, andas, h�ller l�nge och slitstarkt �ven efter m�nga tv�ttar.",
                        ProductImage =
         "https://www.oxford.com.pk/cdn/shop/files/Blue_4.jpg?v=1688717022&width=1200",
                    },
       new Product
       {
           ProductId = 16,
           ProductName = "LADIES LONG SLEEVE SHIRT WHITE",
           ProductPrice = 299,
           ProductDescription =
                   "L�ng�rmad volangskjorta f�r damer i vitt har en vit volang p� kragen, muddarna och framsidan av skjortan. Denna fantastiska damskjorta i 100 % bomull med volangkrage �r en vackert skr�ddarsydd elegant skjorta som kan b�ras ensam eller ocks� ser fantastisk ut under v�ra jackor och tr�jor.",
           ProductImage =
                   "https://www.hhequestrian.com.au/wp-content/uploads/2017/05/white-frill-shirt-1024x1536.jpg",
       },
       new Product
       {
           ProductId = 17,
           ProductName = "Women Fit Sports White TShirt",
           ProductPrice = 259,
           ProductDescription =
                   "Utstr�la elegansen med varje outfit n�r du rockar den h�r T-shirten. Tillverkad av tyger av h�gsta kvalitet, den andas utomordentligt och l�mnar en h�rlig chic k�nsla till alla dina outfits!",
           ProductImage =
                   "https://www.globalrepublic.in/cdn/shop/products/1_83e28aa9-a80c-41e6-aed6-f306ab41f5c4_1000x.jpg?v=1591353307",
       },
       new Product
       {
           ProductId = 18,
           ProductName = "WOMEN'S JERSEY SHORT SLEEVE TShirt",
           ProductPrice = 199,
           ProductDescription =
                   "En del av v�r avslappnade kollektion, denna t-shirt i tr�ja f�r kvinnor har rund hals, korta �rmar och en modern, l�sare passform f�r enkel stil. Den h�r t-shirten �r gjord av v�r supermjuka 100 % Airlume-bomull och k�nns fantastisk hela dagen.",
           ProductImage =
                   "https://www.bellacanvas.com/bella/product/hires/64000024511_1.jpg",
       },
       new Product
       {
           ProductId = 19,
           ProductName = "WHITE CROP TOP AND POLKA DOTS SKIRT SET",
           ProductPrice = 1199,
           ProductDescription =
                   "Lyft din stil med v�r White Crop Top och Polka Dots Skirt Set, en perfekt blandning av chic och lekfull. Denna trendiga ensemble kombinerar en skarp vit crop-top med en flirtig prickig kjol, vilket skapar en fr�sch och levande look.",
           ProductImage =
                   "https://www.lavanyathelabel.com/cdn/shop/products/lbl101ks376_4_1000x.jpg?v=1672237893",
       },
       new Product
       {
           ProductId = 20,
           ProductName = "Midi satin skirt",
           ProductPrice = 599,
           ProductDescription =
                   "Fl�dande tyg. Satin. Midi design. Rak design. Res�rband. Kontorsutseende. Sammans�ttning: 96 % polyester, 4 % elastan. Inneh�ller minst 50 % �tervunnet material. Designad i Barcelona.",
           ProductImage =
                   "https://shop.mango.com/assets/rcs/pics/static/T6/fotos/S20/67047149_05_D7.jpg?ts=1712578361673&imwidth=312&imdensity=2",
       },
       new Product
       {
           ProductId = 21,
           ProductName = "BLEKT TSHIRT MED TEXT",
           ProductPrice = 299,
           ProductDescription =
                   "Vid Tshirt. Rund krage. Kort�rmad. Kombinerade tryck i kontrast p� fram- och baksidan. Blekt effekt.",
           ProductImage =
                   "https://static.zara.net/assets/public/2b30/fed2/a2024c86b4da/db613f14747a/06224428433-a1/06224428433-a1.jpg?ts=1709114725351&w=824",
       }
        );

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductQuantity)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                 .Property(e => e.TotalAmount)
                 .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>()
                 .Property(e => e.ProductPrice)
                 .HasColumnType("decimal(18, 2)");

            // one-to-one relationship between ShopUser and Cart
            modelBuilder.Entity<ShopUser>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);

            // one-to-many relationship between ShopUser and Orders
            modelBuilder.Entity<ShopUser>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            // one-to-many relationship between Cart and CartItems
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);

            // one-to-many relationship between Order and OrderItems
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            // many-to-one relationship between CartItem and Product
            //modelBuilder.Entity<CartItem>()
            //    .HasOne(ci => ci.Product)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.ProductId);

            // many-to-one relationship between OrderItem and Product
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            // one-to-one relationship between Order and Payment
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
