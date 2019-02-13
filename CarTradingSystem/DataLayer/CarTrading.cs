namespace CarTradingSystem.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using CarTradingSystem.Models;
    public class CarTrading : DbContext
    {

        public CarTrading()
            : base("name=CarTrading")
        {
            Database.SetInitializer(new CarTradingContextDBInitilizer());
        }
        public virtual DbSet<AdminAccount> AdminAcount { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<BodyType> BodyType { get; set; }
        public virtual DbSet<CarImage> CarImage { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<SeaPort> SeaPort { get; set; }
        public virtual DbSet<OrderInvoice> OrderInvoice { get; set; }
        public virtual DbSet<BestSellingCar> BestSellingCar { get; set; }
        public virtual DbSet<LatestCar> LatestCar { get; set; }
        public virtual DbSet<EmailInformation> EmailInfo { get; set; }
        public virtual DbSet<BankAccountInformation> BankAccountInfo { get; set; }
        public virtual DbSet<BankPay> BankPays { get; set; }
        public virtual DbSet<ComfortAndConvenience> ComportAndConvenience { get; set; }
        public virtual DbSet<ModelComportConvenienceRelation> ModelComportConvenienceRelation { get; set; }
        public virtual DbSet<InstrumentationAndCommunication> InstrumentationAndCommunication { get; set; }
        public virtual DbSet<ModelInstrumentationAndCommunicationRelation> ModelInstrumentationAndCommunicationRelation { get; set; }
        public virtual DbSet<SafetyAndSecurity> SafetyAndSecurity { get; set; }
        public virtual DbSet<ModelSafetyAndSecurityRelation> ModelSafetyAndSecurityRelation { get; set; }

    }

    public class CarTradingContextDBInitilizer : DropCreateDatabaseIfModelChanges<CarTrading>
    {
        protected override void Seed(CarTrading context)
        {
            for (int i = 0; i < 5; i++)
            {
                context.Company.Add(new Company
                {
                    CompanyName = "Company" + i,
                    Country = "Country" + i,
                    Address = "Address" + i
                });
            }
            context.SaveChanges();

            for (int i = 0; i < 15; i++)
            {
                context.Brand.Add(new Brand
                {
                    BrandName = "Brand" + i,
                    CompanyID = i % 5 + 1,

                });
            }
            context.SaveChanges();
            context.AdminAcount.Add(new AdminAccount
            {
                ContactNumber = "01721555983",
                Email = "kaiumcse11@gmail.com",
                Name = "Md. Kaium",
                Password = "555983",
                UserName = "kaium"
            });
            context.SaveChanges();

            #region
            List<string> countryseaport = new List<string>();
            countryseaport.Add("Australia-Adelaide-AU PAE");
            countryseaport.Add("Australia-Brisbane-AU BNE");
            countryseaport.Add("Australia-Cairns-AU CNS");
            countryseaport.Add("Australia-Darwin-AU DRW");
            countryseaport.Add("Australia-Devonport-AU DPO");
            countryseaport.Add("Australia-Fremantle-AU FRE");
            countryseaport.Add("Australia-Geelong-AU GEX");
            countryseaport.Add("Australia-Hobart-AU HBA");
            countryseaport.Add("Australia-Mackay-AU MKY");
            countryseaport.Add("Australia-Melbourne-AU MEL");
            countryseaport.Add("Australia-Sydney-AU SYD");
            countryseaport.Add("Australia-Townsville-AU TSV");


            countryseaport.Add("Bahrain-Mina Salman-BH MIN");
            countryseaport.Add("Bahrain-Sitra-BH SIT");


            countryseaport.Add("Bangladesh-Chittagong-BD CGP");
            countryseaport.Add("Bangladesh-Mongla-BD MGL");


            countryseaport.Add("Cyprus-Akrotiri-CY AKT");
            countryseaport.Add("Cyprus-Famagusta-CY FMG");
            countryseaport.Add("Cyprus-Larnaca-CY LAT");
            countryseaport.Add("Cyprus-Limassol-CY LMS");
            countryseaport.Add("Cyprus-Paphos-CY PFO");
            countryseaport.Add("Cyprus-Vassiliko-CY VAS");

            countryseaport.Add("Egypt-Alexandria-EG EDK");
            countryseaport.Add("Egypt-Damietta-EG DAM");
            countryseaport.Add("Egypt-Port Said-EG PSD");
            countryseaport.Add("Egypt-Suez (Al Suweis)-EG");

            countryseaport.Add("Iran-Abadan-IR ABD");
            countryseaport.Add("Iran-Bandar Abbas-IR BND");
            countryseaport.Add("Iran-Bandar Anzali-IR BAZ");
            countryseaport.Add("Iran-Bandar Mahshahr-IR MRX");
            countryseaport.Add("Iran-Bushehr-IR BUZ");
            countryseaport.Add("Iran-Imam Khomeini-IR BKM");
            countryseaport.Add("Iran-Khorramshahr-IR KHO");
            countryseaport.Add("Iran-Lavan-IR LVP");
            countryseaport.Add("Iran-Sirri Island-IR SXI");

            countryseaport.Add("Iraq-Basra-IQ BSR");
            countryseaport.Add("Iraq-Khor al Zubair-IQ KAZ");
            countryseaport.Add("Iraq-Umm Qasr-IQ KAZ");

            countryseaport.Add("Jordan-Aqaba (El Akaba)-JO AQJ");

            countryseaport.Add("Kuwait-Mina al Ahmadi-KW MEA");
            countryseaport.Add("Kuwait-Mina Saud-KW MIS");
            countryseaport.Add("Kuwait-Shuwaikh-KW SWK");

            countryseaport.Add("Myanmar-Bassein-MM BSX");
            countryseaport.Add("Myanmar-Moulmein-MM MNU");
            countryseaport.Add("Myanmar-Yangon-MM RGN");


            countryseaport.Add("Pakistan-Karachi-PK KHI");
            countryseaport.Add("Pakistan-Muhammad Bin Qasim - PK BQM");

            countryseaport.Add("Quatar-Doha-QA DOH");
            countryseaport.Add("Quatar-Halul Island-QA HAL");
            countryseaport.Add("Quatar-Ras Laffan-QA RLF");
            countryseaport.Add("Quatar-Umm Said (Mesaieed)-QA UMS");

            countryseaport.Add("Saudi Arabia-Dammam-SA DMN");
            countryseaport.Add("Saudi Arabia-Dhuba-SA DHU");
            countryseaport.Add("Saudi Arabia-Gizan-SA GIZ");
            countryseaport.Add("Saudi Arabia-Jeddah-SA JED");
            countryseaport.Add("Saudi Arabia-Jubail-SA JUB");
            countryseaport.Add("Saudi Arabia-Rabigh-SA RAB");
            countryseaport.Add("Saudi Arabia-Ras al Mishab-SA RAM");
            countryseaport.Add("Saudi Arabia-Ras Tanura-SA RTA");
            countryseaport.Add("Saudi Arabia-Yanbu-SA YNB");

            countryseaport.Add("Srilanka-Colombo-LK CMB");
            countryseaport.Add("Srilanka-Jaffna-LK JAF");
            countryseaport.Add("Srilanka-Trincomalee-LK TRR");

            countryseaport.Add("Syria-Baniyas-SY BAN");

            countryseaport.Add("Turkey-Dikili-TR DIK");
            countryseaport.Add("Turkey-Gemlik-TR GEM");
            countryseaport.Add("Turkey-Hopa, Artvin-TR HOP");
            countryseaport.Add("Turkey-Iskenderun, Hatay-TR ISK");
            countryseaport.Add("Turkey-Istanbul-TR IST");
            countryseaport.Add("Turkey-Trabzon-TR TZX");

            countryseaport.Add("Unitated Arab Emirates-Ajman-AE AJM");
            countryseaport.Add("Unitated Arab Emirates-Das Island-AE DAS");
            countryseaport.Add("Unitated Arab Emirates-Dubai (Port Rashid)-AE DXB");
            countryseaport.Add("Unitated Arab Emirates-Fujairah-AE FJR");
            countryseaport.Add("Unitated Arab Emirates-Jebel Dhanna/Ruwais-AE JEA");
            countryseaport.Add("Unitated Arab Emirates-Khor Fakkan-AE KLF");
            countryseaport.Add("Unitated Arab Emirates-Mina Saqr-AE MSA");
            countryseaport.Add("Unitated Arab Emirates-Mina Zayed-AE MZD");



            for (int i = 0; i < countryseaport.Count; i++)
            {
                Char delimiter = '-';
                string[] split = countryseaport[i].Split(delimiter);

                string countryname = split[0];
                string seaportname = split[1];
                string seaportcode = split[2];

                var country = CarTradingDBAccess.IsCountryExist(countryname);

                if (country == false)
                {
                    Country newentry = new Country();
                    newentry.CountryName = countryname;

                    CarTradingDBAccess.AddCountry(newentry);
                }
                var countryinfo = CarTradingDBAccess.GetCountryInfoByCountryName(countryname);

                if (countryinfo != null)
                {
                    SeaPort seaportnew = new SeaPort();
                    seaportnew.CountryID = countryinfo.CountryID;
                    seaportnew.SerPortName = seaportname;
                    seaportnew.SerPortCode = seaportcode;
                    CarTradingDBAccess.AddSeaPort(seaportnew);

                }

            }

            Country newentryco = new Country();
            newentryco.CountryName = "Other";

            CarTradingDBAccess.AddCountry(newentryco);
            #endregion

           



        }
    }
}

