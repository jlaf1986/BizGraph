using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Reflection;
using System.Data.Entity;
using FHNWPrototype.Domain.Geographics;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Friendships.States;
using FHNWPrototype.Domain.Publishing.Files;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain.Publishing.Likes;
using FHNWPrototype.Domain.Groups;
using FHNWPrototype.Domain.GroupMemberships.States;
using FHNWPrototype.Domain.Partnerships.States;
using FHNWPrototype.Domain.Alliances;
using FHNWPrototype.Domain.AllianceMemberships.States;
using FHNWPrototype.Domain.Projects;
using FHNWPrototype.Domain.Publishing.Tweets;
using FHNWPrototype.Domain.Bookmarks;
using FHNWPrototype.Infrastructure;
using FHNWPrototype.Infrastructure.Security;
using FHNWPrototype.Domain._Base.Accounts;

namespace FHNWPrototype.Infrastructure.Repositories.EF
{
    //DropCreateDatabaseIfModelChanges<FHNWPrototypeDB>
    //CreateDatabaseIfNotExists<FHNWPrototypeDB>
    public class DBContextInitializer : CreateDatabaseIfNotExists<FHNWPrototypeDB>
    {

        protected override void Seed(FHNWPrototypeDB  context)
        {

            byte[] header_picture_Galliker = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.galliker_header);
            byte[] avatar_picture_Galliker = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.galliker_avatar);

            byte[] header_picture_Emmi = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.emmi_header);
            byte[] avatar_picture_Emmi = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.emmi_avatar);

            byte[] header_picture_Migros = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.migros_header);
            byte[] avatar_picture_Migros = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.migros_avatar);

            byte[] header_picture_SwissPost = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.swisspost_header);
            byte[] avatar_picture_SwissPost = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.swisspost_avatar);

            byte[] header_picture_Marti = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.marti_header);
            byte[] avatar_picture_Marti = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.marti_avatar);

            byte[] header_picture_Nestle = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.nestle_header);
            byte[] avatar_picture_Nestle = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.nestle_avatar);

            byte[] header_picture_Erne = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.erne_header);
            byte[] avatar_picture_Erne = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.erne_avatar);

            byte[] header_picture_Montanstahl = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.montanstahl_header);
            byte[] avatar_picture_Montanstahl = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.montanstahl_avatar);

            byte[] header_picture_SwissGovernment = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.swissgovernment_header);
            byte[] avatar_picture_SwissGovernment = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.swissgovernment_avatar);

            byte[] header_picture_Dhl = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.dhl_header);
            byte[] avatar_picture_Dhl = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.dhl_avatar);

            byte[] header_picture_HewlettPackard = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.hp_header);
            byte[] avatar_picture_HewlettPackard = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.hp_avatar);


            //Olten
            GeoLocation GallikerLocation = new GeoLocation { Latitude = 47.339870, Longitude = 7.901985 };
            //Basel
            GeoLocation EmmiLocation = new GeoLocation { Latitude = 47.548807, Longitude = 7.587820 };
            //Berne
            GeoLocation SwissPostLocation = new GeoLocation { Latitude = 46.948432, Longitude = 7.440461 };
            //Lausanne
            GeoLocation MigrosLocation = new GeoLocation { Latitude = 46.519595, Longitude = 6.632335 };
            //Zurich
            GeoLocation MartiLocation = new GeoLocation { Latitude = 47.377060, Longitude = 8.539550 };
            //Geneva
            GeoLocation NestleLocation = new GeoLocation { Latitude = 46.208358, Longitude = 6.142701 };
            //Niederbipp
            GeoLocation ErneLocation = new GeoLocation { Latitude = 47.271270, Longitude = 7.691270 };
            //Oensingen
            GeoLocation MontanstahlLocation = new GeoLocation { Latitude = 47.290369, Longitude = 7.717394 };
            //Solothurn
            GeoLocation SwissGovernmentLocation = new GeoLocation { Latitude = 47.210542, Longitude = 7.536927 };
            //Oftringen
            GeoLocation DhlLocation = new GeoLocation { Latitude = 47.316540, Longitude = 7.920925 };
            //Lucerne
            GeoLocation HewlettPackardLocation = new GeoLocation { Latitude = 47.049545, Longitude = 8.304375 };


            context.Geolocations.Add(GallikerLocation);
            context.Geolocations.Add(EmmiLocation);
            context.Geolocations.Add(MigrosLocation);
            context.Geolocations.Add(SwissPostLocation);
            context.Geolocations.Add(MartiLocation);
            context.Geolocations.Add(NestleLocation);
            context.Geolocations.Add(ErneLocation);
            context.Geolocations.Add(MontanstahlLocation);
            context.Geolocations.Add(SwissGovernmentLocation);
            context.Geolocations.Add(DhlLocation);
            context.Geolocations.Add(HewlettPackardLocation);

            
            var Galliker = new Organization{ Key= new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1C0"), Name= "Galliker", Description= "We transport food", EmailSuffix= "galliker.ch",  HeaderPicture= header_picture_Galliker, HeadquatersLocation=GallikerLocation };
            var Emmi = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1C1"), Name = "Emmi", Description = "We produce milk", EmailSuffix = "emmi.ch",   HeaderPicture = header_picture_Emmi , HeadquatersLocation=EmmiLocation };
            var Migros = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1C2"), Name = "Migros", Description = "We are the biggest supermarket", EmailSuffix = "migros.ch",   HeaderPicture = header_picture_Migros, HeadquatersLocation=MigrosLocation  };
            var SwissPost = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1C3"), Name = "Swiss Post", Description = "We transport everything in switzerland", EmailSuffix = "swisspost.ch",   HeaderPicture = header_picture_SwissPost, HeadquatersLocation=SwissPostLocation  };
            var Marti = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1C4"), Name = "Marti AG", Description = "We compete against Erne", EmailSuffix = "martiag.ch",   HeaderPicture = header_picture_Marti, HeadquatersLocation=MartiLocation };
            var Nestle = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1C5"), Name = "Nestle", Description = "We produce many food products", EmailSuffix = "nestle.ch",   HeaderPicture = header_picture_Nestle , HeadquatersLocation=NestleLocation };
            var Erne = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1C6"), Name = "Erne", Description = "We are constructors", EmailSuffix = "erne.ch",   HeaderPicture = header_picture_Erne , HeadquatersLocation=ErneLocation };
            var Montanstahl = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1C7"), Name = "Montanstahl", Description = "We produce steel", EmailSuffix = "montanstahl.ch",   HeaderPicture = header_picture_Montanstahl, HeadquatersLocation=MontanstahlLocation  };
            var SwissGovernment = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1C8"), Name = "Swiss Government", Description = "We are the swiss government", EmailSuffix = "admin.ch",  HeaderPicture= header_picture_SwissGovernment , HeadquatersLocation=SwissGovernmentLocation };
            var Dhl = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1C9"), Name = "DHL", Description = "We also transport everything in the world", EmailSuffix = "dhl.ch",   HeaderPicture = header_picture_Dhl , HeadquatersLocation= DhlLocation   };
            var HewlettPackard = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C1"), Name = "Hewlett Packard", Description = "We produce computers", EmailSuffix = "hp.ch",   HeaderPicture = header_picture_HewlettPackard , HeadquatersLocation= HewlettPackardLocation };


          

            context.Organizations.Add(Galliker);
            context.Organizations.Add(Emmi);
            context.Organizations.Add(Migros);
            context.Organizations.Add(SwissPost);
            context.Organizations.Add(Marti);
            context.Organizations.Add(Nestle);
            context.Organizations.Add(Erne);
            context.Organizations.Add(Montanstahl);
            context.Organizations.Add(SwissGovernment);
            context.Organizations.Add(Dhl);
            context.Organizations.Add(HewlettPackard);


            var GallikerAdministratorAccount = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A0"), Name = "Galliker HQ", Description = "Galliker Organization Account", Organization=Galliker, EmailSuffix = "galliker.ch", Email="admin@galliker.ch", AvatarPicture = avatar_picture_Galliker, Location = GallikerLocation };
            var EmmiAdministratorAccount = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A1"), Name = "Emmi HQ", Description = "Emmi Organization Account", Organization = Emmi, EmailSuffix = "emmi.ch", Email = "admin@emmi.ch", AvatarPicture = avatar_picture_Emmi, Location = EmmiLocation };
            var MigrosAdministratorAccount = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A2"), Name = "Migros HQ", Description = "Migros Organization Account", Organization = Migros, EmailSuffix = "migros.ch", Email = "admin@migros.ch", AvatarPicture = avatar_picture_Migros, Location = MigrosLocation };
            var SwissPostAdministratorAccount = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A3"), Name = "SwissPost HQ", Description = "SwissPost Organization Account", Organization = SwissPost, EmailSuffix = "swisspost.ch", Email = "admin@swisspost.ch", AvatarPicture = avatar_picture_SwissPost, Location = SwissPostLocation };
            var MartiAdministratorAccount = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A4"), Name = "Marti HQ", Description = "Marti Organization Account", Organization = Marti, EmailSuffix = "marti.ch", Email = "admin@marti.ch", AvatarPicture = avatar_picture_Marti, Location = MartiLocation };
            var NestleAdministratorAccount = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A5"), Name = "Nestle HQ", Description = "Nestle Organization Account", Organization = Nestle, EmailSuffix = "nestle.ch", Email = "admin@nestle.ch", AvatarPicture = avatar_picture_Nestle, Location = NestleLocation };
            var ErneAdministratorAccount = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A6"), Name = "Erne HQ", Description = "Erne Organization Account", Organization = Erne, EmailSuffix = "erne.ch", Email = "admin@erne.ch", AvatarPicture = avatar_picture_Erne, Location = ErneLocation };
            var MontanstahlAdministratorAccount = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A7"), Name = "Montanstahl HQ", Description = "Montanstahl Organization Account", Organization = Montanstahl, Email = "admin@montanstahl.ch", EmailSuffix = "montanstahl.ch", AvatarPicture = avatar_picture_Montanstahl, Location = MontanstahlLocation };
            var SwissGovernmentAdministratorAccount = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A8"), Name = "Swiss Government HQ", Description = "Swiss Government Organization Account", Organization = SwissGovernment, EmailSuffix = "admin.ch", Email = "admin@admin.ch", AvatarPicture = avatar_picture_SwissGovernment, Location = SwissGovernmentLocation };
            var DhlAdministratorAccount = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A9"), Name = "Dhl HQ", Description = "Dhl Organization Account", Organization = Dhl, EmailSuffix = "dhl.ch", Email = "admin@dhl.ch", AvatarPicture = avatar_picture_Dhl, Location = DhlLocation };
            var HewlettPackardAdministratorAccount = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1B0"), Name = "Hewlett Packard HQ", Description = "HP Organization Account", Organization = HewlettPackard, EmailSuffix = "hp.ch", Email = "admin@hp.ch", AvatarPicture = avatar_picture_HewlettPackard, Location = HewlettPackardLocation };


            context.OrganizationAccounts.Add(GallikerAdministratorAccount);
            context.OrganizationAccounts.Add(EmmiAdministratorAccount);
            context.OrganizationAccounts.Add(MigrosAdministratorAccount);
            context.OrganizationAccounts.Add(SwissPostAdministratorAccount);
            context.OrganizationAccounts.Add(MartiAdministratorAccount);
            context.OrganizationAccounts.Add(NestleAdministratorAccount);
            context.OrganizationAccounts.Add(ErneAdministratorAccount);
            context.OrganizationAccounts.Add(MontanstahlAdministratorAccount);
            context.OrganizationAccounts.Add(SwissGovernmentAdministratorAccount);
            context.OrganizationAccounts.Add(DhlAdministratorAccount);
            context.OrganizationAccounts.Add(HewlettPackardAdministratorAccount);

            var Galliker_BasicProfile = new BasicProfile { ReferenceKey = GallikerAdministratorAccount.Key, ReferenceType= AccountType.OrganizationAccount};
            var Emmi_BasicProfile = new BasicProfile { ReferenceKey = EmmiAdministratorAccount.Key, ReferenceType = AccountType.OrganizationAccount };
            var Migros_BasicProfile = new BasicProfile { ReferenceKey = MigrosAdministratorAccount.Key, ReferenceType = AccountType.OrganizationAccount };
            var SwissPost_BasicProfile = new BasicProfile { ReferenceKey = SwissPostAdministratorAccount.Key, ReferenceType = AccountType.OrganizationAccount };
            var Marti_BasicProfile = new BasicProfile { ReferenceKey = MartiAdministratorAccount.Key, ReferenceType = AccountType.OrganizationAccount };
            var Nestle_BasicProfile = new BasicProfile { ReferenceKey = NestleAdministratorAccount.Key, ReferenceType = AccountType.OrganizationAccount };
            var Erne_BasicProfile = new BasicProfile { ReferenceKey = ErneAdministratorAccount.Key, ReferenceType = AccountType.OrganizationAccount };
            var Montanstahl_BasicProfile = new BasicProfile { ReferenceKey = MontanstahlAdministratorAccount.Key, ReferenceType = AccountType.OrganizationAccount };
            var SwissGovernment_BasicProfile = new BasicProfile { ReferenceKey = SwissGovernmentAdministratorAccount.Key, ReferenceType = AccountType.OrganizationAccount };
            var Dhl_BasicProfile = new BasicProfile { ReferenceKey = DhlAdministratorAccount.Key, ReferenceType = AccountType.OrganizationAccount };
            var HewlettPackard_BasicProfile = new BasicProfile { ReferenceKey = HewlettPackardAdministratorAccount.Key, ReferenceType = AccountType.OrganizationAccount };

            context.BasicProfiles.Add(Galliker_BasicProfile);
            context.BasicProfiles.Add(Emmi_BasicProfile);
            context.BasicProfiles.Add(Migros_BasicProfile);
            context.BasicProfiles.Add(SwissPost_BasicProfile);
            context.BasicProfiles.Add(Marti_BasicProfile);
            context.BasicProfiles.Add(Nestle_BasicProfile);
            context.BasicProfiles.Add(Erne_BasicProfile);
            context.BasicProfiles.Add(Montanstahl_BasicProfile);
            context.BasicProfiles.Add(SwissGovernment_BasicProfile);
            context.BasicProfiles.Add(Dhl_BasicProfile);
            context.BasicProfiles.Add(HewlettPackard_BasicProfile);

            byte[] avatar_picture_bill_gates = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.bill_gates);
            byte[] avatar_picture_eric_schmidt = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.eric_schmidt);
            byte[] avatar_picture_larry_ellison = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.larry_ellison);
            byte[] avatar_picture_larry_page = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.larry_page);
            byte[] avatar_picture_linus_torvalds = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.linus_torvalds);
            byte[] avatar_picture_marissa_mayer = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.marissa_mayer);
            byte[] avatar_picture_paul_allen = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.paul_allen);
            byte[] avatar_picture_ray_ozzie = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.ray_ozzie);
            byte[] avatar_picture_reid_hoffman = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.reid_hoffman);
            byte[] avatar_picture_scott_guthrie = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.scott_guthrie);
            byte[] avatar_picture_scott_hanselman = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.scott_hanselman);
            byte[] avatar_picture_sergey_brin = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.sergey_brin);
            byte[] avatar_picture_sheryl_sandberg = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.sheryl_sandberg);
            byte[] avatar_picture_steve_ballmer = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.steve_ballmer);
            byte[] avatar_picture_steve_jobs = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.steve_jobs);
            byte[] avatar_picture_steve_wozniak = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.steve_wozniak);
            byte[] avatar_picture_virginia_rometty = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.virginia_rometty);

 
            //Munich
            GeoLocation BillGatesPosition = new GeoLocation() { Latitude = 48.13641, Longitude = 11.57753 };


            //Users
            var BillGates = new User{  Key= new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A0"), FirstName= "Bill", LastName= "Gates", ProfilePicture=avatar_picture_bill_gates, GeoLocation=BillGatesPosition };
            var SergeyBrin = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A1"), FirstName = "Sergey", LastName = "Brin", ProfilePicture=avatar_picture_sergey_brin  };
            var LarryPage = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A2"), FirstName = "Larry", LastName = "Page", ProfilePicture=avatar_picture_larry_page  };
            var LarryEllison = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A3"),   FirstName = "Larry", LastName = "Ellison", ProfilePicture=avatar_picture_larry_ellison  };
            var MarissaMayer = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A4"),  FirstName = "Marissa", LastName = "Mayer", ProfilePicture= avatar_picture_marissa_mayer  };
            var EricSchmidt = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A5"),   FirstName = "Eric", LastName = "Schmidt", ProfilePicture= avatar_picture_eric_schmidt  };
            var SteveJobs = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A6"),   FirstName = "Steve", LastName = "Jobs", ProfilePicture= avatar_picture_steve_jobs  };
            var SteveBallmer = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A7"),   FirstName = "Steve", LastName = "Ballmer", ProfilePicture= avatar_picture_steve_ballmer  };
            var SteveWozniak = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A8"),   FirstName = "Steve", LastName = "Wozniak", ProfilePicture= avatar_picture_steve_wozniak  };
            var PaulAllen = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A9"),   FirstName = "Paul", LastName = "Allen", ProfilePicture=avatar_picture_paul_allen  };
            var SherylSandberg = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A0"),   FirstName = "Sheryl", LastName = "Sandberg", ProfilePicture=avatar_picture_sheryl_sandberg  };
            var ReidHoffman = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A1"),   FirstName = "Reid", LastName = "Hoffman", ProfilePicture=avatar_picture_reid_hoffman  };
            var VirginiaRometty = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A2"),   FirstName = "Virginia", LastName = "Rometty", ProfilePicture=avatar_picture_virginia_rometty  };
            var ScottHanselman = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A3"), FirstName = "Scott", LastName = "Hanselman", ProfilePicture=avatar_picture_scott_hanselman  };
            var ScottGuthrie = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A4"),   FirstName = "Scott", LastName = "Guthrie", ProfilePicture= avatar_picture_scott_guthrie  };
            var LinusTorvalds = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A5"),   FirstName = "Linus", LastName = "Torvalds", ProfilePicture= avatar_picture_linus_torvalds  };
            var RayOzzie = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A6"),  FirstName = "Ray", LastName = "Ozzie", ProfilePicture=avatar_picture_ray_ozzie  };
            

            //Accounts
        
            var gatesb = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1B0"), Email = "gatesb@nestle.ch", User = BillGates, OrganizationAccount= NestleAdministratorAccount }; //Logistics Department
            var brins = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1B1"), Email = "brins@emmi.ch", User = SergeyBrin, OrganizationAccount = EmmiAdministratorAccount }; // Logistics Department
            var pagel = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1B2"), Email = "pagel@emmi.ch", User = LarryPage, OrganizationAccount = EmmiAdministratorAccount };// Product Development
            var ellisonl = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1B3"), Email = "ellisonl@galliker.ch", User = LarryEllison, OrganizationAccount = GallikerAdministratorAccount }; //Branding
            var mayerm = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1B4"), Email = "mayerm@swisspost.ch", User = MarissaMayer, OrganizationAccount = SwissPostAdministratorAccount }; //Losgistics Department
            var schmidte = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1B5"), Email = "schmidte@swisspost.ch", User = EricSchmidt, OrganizationAccount = SwissPostAdministratorAccount }; //Warehousing
            var jobss = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1B6"), Email = "jobss@dhl.ch", User = SteveJobs, OrganizationAccount = DhlAdministratorAccount }; //Warehousing
            var ballmers = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1B7"), Email = "ballmers@galliker.ch", User = SteveBallmer, OrganizationAccount = GallikerAdministratorAccount }; //Procurement
            var wozniaks = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1B8"), Email = "wozniaks@nestle.ch", User = SteveWozniak, OrganizationAccount = NestleAdministratorAccount }; //Product Development
            var allenp = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1B9"), Email = "allenp@marti.ch", User = PaulAllen, OrganizationAccount = MartiAdministratorAccount };//Marketing
            var sandbergs = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B1"), Email = "sandbergs@montanstahl.ch", User = SherylSandberg, OrganizationAccount = MontanstahlAdministratorAccount }; //Point of Sale
            var hoffmanr = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B2"), Email = "hoffmanr@erne.ch", User = ReidHoffman, OrganizationAccount = ErneAdministratorAccount }; //in-site logistics
            var romettyv = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B3"), Email = "romettyv@migros.ch", User = VirginiaRometty, OrganizationAccount = MigrosAdministratorAccount }; //Marketing
            var hanselmans = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B4"), Email = "hanselmans@nestle.ch", User = ScottHanselman, OrganizationAccount = NestleAdministratorAccount}; //Logistics
            var guthries = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B5"), Email = "guthries@admin.ch", User = ScottGuthrie, OrganizationAccount = SwissGovernmentAdministratorAccount }; //Logistics
            var torvaldsl = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B6"), Email = "torvalds@dhl.ch", User = LinusTorvalds, OrganizationAccount = DhlAdministratorAccount }; //Logistics
            var ozzier = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B7"), Email = "ozzier@hp.ch", User = RayOzzie, OrganizationAccount = HewlettPackardAdministratorAccount }; //Logistics


            var gatesb_BasicProfile = new BasicProfile { ReferenceKey = gatesb.Key, ReferenceType = AccountType.UserAccount };
            var brins_BasicProfile = new BasicProfile { ReferenceKey = brins.Key, ReferenceType = AccountType.UserAccount };
            var pagel_BasicProfile = new BasicProfile { ReferenceKey = pagel.Key, ReferenceType = AccountType.UserAccount };
            var ellisonl_BasicProfile = new BasicProfile { ReferenceKey = ellisonl.Key, ReferenceType = AccountType.UserAccount };
            var mayerm_BasicProfile = new BasicProfile { ReferenceKey = mayerm.Key, ReferenceType = AccountType.UserAccount };
            var schmidte_BasicProfile = new BasicProfile { ReferenceKey = schmidte.Key, ReferenceType = AccountType.UserAccount };
            var jobss_BasicProfile = new BasicProfile { ReferenceKey = jobss.Key, ReferenceType = AccountType.UserAccount };
            var ballmers_BasicProfile = new BasicProfile { ReferenceKey = ballmers.Key, ReferenceType = AccountType.UserAccount };
            var wozniaks_BasicProfile = new BasicProfile { ReferenceKey = wozniaks.Key, ReferenceType = AccountType.UserAccount };
            var allenp_BasicProfile = new BasicProfile { ReferenceKey = allenp.Key, ReferenceType = AccountType.UserAccount };
            var sandbergs_BasicProfile = new BasicProfile { ReferenceKey = sandbergs.Key, ReferenceType = AccountType.UserAccount };
            var hoffmanr_BasicProfile = new BasicProfile { ReferenceKey = hoffmanr.Key, ReferenceType = AccountType.UserAccount };
            var romettyv_BasicProfile = new BasicProfile { ReferenceKey = romettyv.Key, ReferenceType = AccountType.UserAccount };
            var hanselmans_BasicProfile = new BasicProfile { ReferenceKey = hanselmans.Key, ReferenceType = AccountType.UserAccount };
            var guthries_BasicProfile = new BasicProfile { ReferenceKey = guthries.Key, ReferenceType = AccountType.UserAccount };
            var torvaldsl_BasicProfile = new BasicProfile { ReferenceKey = torvaldsl.Key, ReferenceType = AccountType.UserAccount };
            var ozzier_BasicProfile = new BasicProfile { ReferenceKey = ozzier.Key, ReferenceType = AccountType.UserAccount };

            context.BasicProfiles.Add(gatesb_BasicProfile);
            context.BasicProfiles.Add(brins_BasicProfile);
            context.BasicProfiles.Add(pagel_BasicProfile);
            context.BasicProfiles.Add(ellisonl_BasicProfile);
            context.BasicProfiles.Add(mayerm_BasicProfile);
            context.BasicProfiles.Add(schmidte_BasicProfile);
            context.BasicProfiles.Add(jobss_BasicProfile);
            context.BasicProfiles.Add(ballmers_BasicProfile);
            context.BasicProfiles.Add(wozniaks_BasicProfile);
            context.BasicProfiles.Add(allenp_BasicProfile);
            context.BasicProfiles.Add(sandbergs_BasicProfile);
            context.BasicProfiles.Add(hoffmanr_BasicProfile);
            context.BasicProfiles.Add(romettyv_BasicProfile);
            context.BasicProfiles.Add(hanselmans_BasicProfile);
            context.BasicProfiles.Add(guthries_BasicProfile);
            context.BasicProfiles.Add(torvaldsl_BasicProfile);
            context.BasicProfiles.Add(ozzier_BasicProfile);

            var rel_ballmers_gatesb = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F0"), Action = FriendshipAction.Accept , Sender = ballmers, Receiver = gatesb, IsActive=true , ActionDateTime = DateTime.Now.AddDays(-1) };
            var rel_gatesb_brins = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F1"), Action = FriendshipAction.Accept, Sender = gatesb, Receiver = brins, IsActive = true, ActionDateTime = DateTime.Now.AddDays(3) };
            var rel_ellisonl_gatesb = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F2"), Action = FriendshipAction.Accept, Sender = ellisonl, Receiver = gatesb, IsActive = true, ActionDateTime = DateTime.Now.AddDays(-2) };
            var rel_pagel_romettyv = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F3"), Action = FriendshipAction.Accept, Sender = pagel, Receiver = romettyv, IsActive = true, ActionDateTime = DateTime.Now.AddDays(1) };
            var rel_romettyv_ballmers = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F4"), Action = FriendshipAction.Accept, Sender = romettyv, Receiver = ballmers, IsActive = true, ActionDateTime = DateTime.Now.AddDays(1) };
            var rel_rometty_gatesb = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F5"), Action = FriendshipAction.Accept, Sender = romettyv, Receiver = gatesb, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_mayerm_torvaldsl = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F7"), Action = FriendshipAction.Accept, Sender = mayerm, Receiver = torvaldsl, IsActive = true, ActionDateTime = DateTime.Now.AddDays(4) };
            var rel_ozzier_torvaldsl = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F8"), Action = FriendshipAction.Accept, Sender = ozzier, Receiver = torvaldsl, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_pagel_brins = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F9"), Action = FriendshipAction.Accept, Sender = pagel, Receiver = brins, IsActive = true, ActionDateTime = DateTime.Now.AddDays(1) };
            var rel_schmidte_mayerm = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2F0"), Action = FriendshipAction.Accept, Sender = schmidte, Receiver = mayerm, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_hoffmanr_sandbergs = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2F1"), Action = FriendshipAction.Accept, Sender = hoffmanr, Receiver = sandbergs, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_sandbergs_allenp = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2F2"), Action = FriendshipAction.Accept, Sender = sandbergs, Receiver = allenp, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_guthries_sandbergs = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2F3"), Action = FriendshipAction.Accept, Sender = guthries, Receiver = sandbergs, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_hoffmanr_guthries = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2F4"), Action = FriendshipAction.Accept, Sender = hoffmanr, Receiver = guthries, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_allenp_guthries = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2F5"), Action = FriendshipAction.Accept, Sender = allenp, Receiver = guthries, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_jobss_torvaldsl = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2F6"), Action = FriendshipAction.Accept, Sender = jobss, Receiver = torvaldsl, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_jobss_ozzier = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2F7"), Action = FriendshipAction.Accept, Sender = jobss, Receiver = ozzier, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_wozniaks_hanselmans = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2F8"), Action = FriendshipAction.Accept, Sender = wozniaks, Receiver = hanselmans, IsActive = true, ActionDateTime = DateTime.Now };
           // var rel_wozniaks_gatesb = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2F9"), Action = FriendshipAction.Accept, Sender = wozniaks, Receiver = gatesb, ActionDateTime = DateTime.Now };
            var rel_gatesb_hanselmans = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E3F0"), Action = FriendshipAction.Accept, Sender = gatesb, Receiver = hanselmans, IsActive = true, ActionDateTime = DateTime.Now };


            context.Friendships.Add(rel_ballmers_gatesb);
            context.Friendships.Add(rel_gatesb_brins);
            context.Friendships.Add(rel_ellisonl_gatesb);
            context.Friendships.Add(rel_pagel_romettyv);
            context.Friendships.Add(rel_romettyv_ballmers);
            context.Friendships.Add(rel_rometty_gatesb);
            context.Friendships.Add(rel_mayerm_torvaldsl);
            context.Friendships.Add(rel_ozzier_torvaldsl);
            context.Friendships.Add(rel_pagel_brins);
            context.Friendships.Add(rel_schmidte_mayerm);
            context.Friendships.Add(rel_hoffmanr_sandbergs);
            context.Friendships.Add(rel_sandbergs_allenp);
            context.Friendships.Add(rel_guthries_sandbergs);
            context.Friendships.Add(rel_hoffmanr_guthries);
            context.Friendships.Add(rel_allenp_guthries);
            context.Friendships.Add(rel_jobss_torvaldsl);
            context.Friendships.Add(rel_jobss_ozzier);
            context.Friendships.Add(rel_wozniaks_hanselmans);
          //  context.Friendships.Add(rel_wozniaks_gatesb);
            context.Friendships.Add(rel_gatesb_hanselmans);
 


            //var gatesb_library_folder_A = new Folder() { Key=new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1F0") , Name="FolderA" };

            //var gatesb_library_folder_B = new Folder() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1F1"), Name = "FolderB" };

            //var gatesb_library_folder_A_subfolder1 = new Folder() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1F2"), ParentFolder = gatesb_library_folder_A, Name = "SubFolderA1" };

            //var gatesb_library_folder_A_subfolder2 = new Folder() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1F3"), ParentFolder = gatesb_library_folder_A, Name = "SubFolderA2" };

            //var gatesb_library_folder_A_subfolder2_subfolder1 = new Folder() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1F4"), ParentFolder = gatesb_library_folder_A_subfolder2, Name = "SubFolderA21" };
           
            //var gatesb_library_folder_B_subfolder1 = new Folder() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1F5"), ParentFolder = gatesb_library_folder_B, Name = "SubFolderB1" };



            //var doc1 = new Document() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1A0"), Name = "MyDocument1.docx", ParentFolder = gatesb_library_folder_A_subfolder1, Author = gatesb, PublishDateTime = DateTime.Now };
            //var doc2 = new Document() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1A1"), Name = "MyDocument2.xlsx", ParentFolder = gatesb_library_folder_A_subfolder1, Author = romettyv, PublishDateTime = DateTime.Now };

            //var doc3 = new Document() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1A2"), Name = "MyDocument3.docx", ParentFolder = gatesb_library_folder_A_subfolder1, Author = ballmers, PublishDateTime = DateTime.Now };
            //var doc4 = new Document() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1A3"), Name = "MyDocument4.xlsx", ParentFolder = gatesb_library_folder_A_subfolder2, Author = gatesb, PublishDateTime = DateTime.Now };

            //var doc5 = new Document() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1A4"), Name = "MyDocument5.pptx", ParentFolder = gatesb_library_folder_A_subfolder2, Author = mayerm, PublishDateTime = DateTime.Now };
            //var doc6 = new Document() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1A5"), Name = "MyDocument6.zip", ParentFolder = gatesb_library_folder_B_subfolder1, Author = brins, PublishDateTime = DateTime.Now };

            //var doc7 = new Document() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1A6"), Name = "MyDocument7.pdf", ParentFolder = gatesb_library_folder_B, Author = schmidte, PublishDateTime = DateTime.Now };
            //var doc8 = new Document() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1A7"), Name = "MyDocument8.txt", ParentFolder = gatesb_library_folder_B, Author = ballmers, PublishDateTime = DateTime.Now };


            //context.Folders.Add(gatesb_library_folder_A);
            //context.Folders.Add(gatesb_library_folder_B);
            //context.Folders.Add(gatesb_library_folder_A_subfolder1);
            //context.Folders.Add(gatesb_library_folder_A_subfolder2);
            //context.Folders.Add(gatesb_library_folder_A_subfolder2_subfolder1);
            //context.Folders.Add(gatesb_library_folder_B_subfolder1);

            //context.Documents.Add(doc1);
            //context.Documents.Add(doc2);
            //context.Documents.Add(doc3);
            //context.Documents.Add(doc4);
            //context.Documents.Add(doc5);
            //context.Documents.Add(doc6);
            //context.Documents.Add(doc7);
            //context.Documents.Add(doc8);

            //var gatesb_library = new Library() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1E0"), Folders = new List<Folder> { gatesb_library_folder_A, gatesb_library_folder_B  }, Owner = gatesb };

            //context.Libraries.Add(gatesb_library);

         

            //var gatesb_workspace = new Workspace() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1D0"), Owner = gatesb, Library=gatesb_library, Wall=gatesb_wall };
            //  var gatesb_workspace = new Workspace() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309E1D0"), Owner = gatesb , Wall=gatesb_wall };

            //context.Workspaces.Add(gatesb_workspace);
         
            //gatesb_library_root_folder.Files = new List<Document>();
            //gatesb_library_root_folder.Files.Add(doc1);
            //gatesb_library_root_folder.Files.Add(doc2);
            //gatesb_library_root_folder_subfolder1.Files.Add(doc3);
            //gatesb_library_root_folder_subfolder1.Files.Add(doc4);



           


            context.UserAccounts.Add(gatesb);
            context.UserAccounts.Add(brins);
            context.UserAccounts.Add(pagel);
            context.UserAccounts.Add(ellisonl);
            context.UserAccounts.Add(mayerm);
            context.UserAccounts.Add(schmidte);
            context.UserAccounts.Add(jobss);
            context.UserAccounts.Add(ballmers);
            context.UserAccounts.Add(wozniaks);
            context.UserAccounts.Add(allenp);
            context.UserAccounts.Add(sandbergs);
            context.UserAccounts.Add(hoffmanr);
            context.UserAccounts.Add(romettyv);
            context.UserAccounts.Add(hanselmans);
            context.UserAccounts.Add(guthries);
            context.UserAccounts.Add(torvaldsl);
            context.UserAccounts.Add(ozzier);


            //Personal accounts
            //var PersonalBillGates = new UserAccount { 
            //    Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A0"), 
            //    Email = "billgates@outlook.com", 
            //    User = BillGates 
            //    };

            //var PersonalSergeyBrin = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A1"), Email = "sergeybrin@gmail.com", User = SergeyBrin }; 
            //var PersonalLarryPage = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A2"), Email = "larrypage@yahoo.com", User = LarryPage }; 
            //var PersonalLarryEllison = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A3"), Email = "larryellison@hotmail.com", User = LarryEllison }; 
            //var PersonalMarissaMayer = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A4"), Email = "marissamayer@hotmail.com", User = MarissaMayer }; 
            //var PersonalEricSchmidt = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A5"), Email = "ericschmidt@gmail.com", User = EricSchmidt }; 
            //var PersonalSteveJobs = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A6"), Email = "stevejobs@yahoo.com", User = SteveJobs }; 
            //var PersonalSteveBallmer = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A7"), Email = "steveballmer@gmail.com", User = SteveBallmer }; 
            //var PersonalSteveWozniak = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A8"), Email = "stevewozniak@gmail.com", User = SteveWozniak }; 
            //var PersonalPaulAllen = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A9"), Email = "paulallen@hotmail.com", User = PaulAllen }; 
            //var PersonalSherylSandberg = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A0"), Email = "sherylsandberg@yahoo.com", User = SherylSandberg }; 
            //var PersonalReidHoffman = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A1"), Email = "reidhoffman@gmail.com", User = ReidHoffman }; 
            //var PersonalVirginiaRometty = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A2"), Email = "virginiarometty@gmail.com", User = VirginiaRometty }; 
            //var PersonalScottHanselman = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A3"), Email = "scotthanselman@gmail.com", User = ScottHanselman }; 
            //var PersonalScottGuthrie = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A4"), Email = "scottguthrie@gmail.com", User = ScottGuthrie }; 
            //var PersonalLinusTorvalds = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A5"), Email = "linustorvalds@gmail.com", User = LinusTorvalds }; 
            //var PersonalRayOzzie = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A6"), Email = "rayozzie@gmail.com", User = RayOzzie };

            ////
            //context.UserAccounts.Add(PersonalBillGates);
            //context.UserAccounts.Add(PersonalSergeyBrin);
            //context.UserAccounts.Add(PersonalLarryPage);
            //context.UserAccounts.Add(PersonalLarryEllison);
            //context.UserAccounts.Add(PersonalMarissaMayer);
            //context.UserAccounts.Add(PersonalEricSchmidt);
            //context.UserAccounts.Add(PersonalSteveJobs);
            //context.UserAccounts.Add(PersonalSteveBallmer);
            //context.UserAccounts.Add(PersonalSteveWozniak);
            //context.UserAccounts.Add(PersonalPaulAllen);
            //context.UserAccounts.Add(PersonalSherylSandberg);
            //context.UserAccounts.Add(PersonalReidHoffman);
            //context.UserAccounts.Add(PersonalVirginiaRometty);
            //context.UserAccounts.Add(PersonalScottHanselman);
            //context.UserAccounts.Add(PersonalScottGuthrie);
            //context.UserAccounts.Add(PersonalLinusTorvalds);
            //context.UserAccounts.Add(PersonalRayOzzie);

            //Assign corporate accounts to users

           // byte[] defaultGroupHeaderPicture = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.groupHeader);
          //  byte[] defaultGroupProfilePicture = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.groupProfile);

            byte[] defaultGroupHeaderPicture = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.groupHeader  );
            byte[] defaultGroupProfilePicture = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.groupProfile );

            //Groups 
            var SwitzerlandIndustrialImportsGroup = new Group { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E0"), Name = "Industrial Imports", Description = "Industrial Imports for Switzerland", HeaderPicture=defaultGroupHeaderPicture , ProfilePicture=defaultGroupProfilePicture  };//, Administrator= isiks}; //scheduling for just-in-time
            var FreshFoodGroup = new Group { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E1"), Name = "Fresh Food", Description = "Fresh food best practices", HeaderPicture = defaultGroupHeaderPicture, ProfilePicture = defaultGroupProfilePicture };//, Administrator=sigristd}; //logistics information for fresh milk products
            var ProductDevelopmentForMilkshakeGroup = new Group { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E2"), Name = "My Milkshake Prod Dev", Description = "Product Development for new Milkshake", HeaderPicture = defaultGroupHeaderPicture, ProfilePicture = defaultGroupProfilePicture };//, Administrator=wirthp}; //nestle and emmi create joint venture
            var MarketingForMilkshakeGroup = new Group { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E3"), Name = "My Milkshake Mkt", Description = "Marketing strategies for new Milkshake", HeaderPicture = defaultGroupHeaderPicture, ProfilePicture = defaultGroupProfilePicture };//, Administrator=binkerta}; //nestle advices coop and migros
            var DistributionForMilkshakeGroup = new Group { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E4"), Name = "My Milkshake Distr", Description = "Marketing strategies", HeaderPicture = defaultGroupHeaderPicture, ProfilePicture = defaultGroupProfilePicture };//, Administrator=binkerta}; //nestle advices coop and migros           
            var SwitzerlandTransporationHPLaptopsGroup = new Group { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E5"), Name = "My new HP Laptops", Description = "Pricing strategies", HeaderPicture = defaultGroupHeaderPicture, ProfilePicture = defaultGroupProfilePicture };//, Administrator = brins }; //pricing strategies, format and reports

            context.Groups.Add(SwitzerlandIndustrialImportsGroup);
            context.Groups.Add(FreshFoodGroup);
            context.Groups.Add(ProductDevelopmentForMilkshakeGroup);
            context.Groups.Add(MarketingForMilkshakeGroup);
            context.Groups.Add(DistributionForMilkshakeGroup);
            context.Groups.Add(SwitzerlandTransporationHPLaptopsGroup);

            var SwitzerlandIndustrialImportsGroup_BasicProfile = new BasicProfile { ReferenceKey=SwitzerlandIndustrialImportsGroup.Key , ReferenceType= AccountType.Group  };
            var FreshFoodGroup_BasicProfile = new BasicProfile { ReferenceKey = FreshFoodGroup.Key, ReferenceType = AccountType.Group };
            var ProductDevelopmentForMilkshakeGroup_BasicProfile = new BasicProfile { ReferenceKey = ProductDevelopmentForMilkshakeGroup.Key, ReferenceType = AccountType.Group };
            var MarketingForMilkshakeGroup_BasicProfile = new BasicProfile { ReferenceKey = MarketingForMilkshakeGroup.Key, ReferenceType = AccountType.Group };
            var DistributionForMilkshakeGroup_BasicProfile = new BasicProfile { ReferenceKey = DistributionForMilkshakeGroup.Key, ReferenceType = AccountType.Group };
            var SwitzerlandTransporationHPLaptopsGroup_BasicProfile = new BasicProfile { ReferenceKey = SwitzerlandTransporationHPLaptopsGroup.Key, ReferenceType = AccountType.Group };


            context.BasicProfiles.Add(SwitzerlandIndustrialImportsGroup_BasicProfile);
            context.BasicProfiles.Add(FreshFoodGroup_BasicProfile);
            context.BasicProfiles.Add(ProductDevelopmentForMilkshakeGroup_BasicProfile);
            context.BasicProfiles.Add(MarketingForMilkshakeGroup_BasicProfile);
            context.BasicProfiles.Add(DistributionForMilkshakeGroup_BasicProfile);
            context.BasicProfiles.Add(SwitzerlandTransporationHPLaptopsGroup_BasicProfile);


            //var group_membership_action_New = new GroupMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309A0A0"), Name = "New" };
            //var group_membership_action_Offer = new GroupMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309A0A1"), Name = "Offer" };
            //var group_membership_action_Allow = new GroupMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309A0A2"), Name = "Allow" };
            //var group_membership_action_Request = new GroupMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309A0A3"), Name = "Request" };
            //var group_membership_action_Accept = new GroupMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309A0A4"), Name = "Accept" };
            //var group_membership_action_Reject = new GroupMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309A0A5"), Name = "Reject" };
            //var group_membership_action_Cancel = new GroupMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F309A0A6"), Name = "Cancel" };

            //context.GroupMembershipActions.Add(group_membership_action_New);
            //context.GroupMembershipActions.Add(group_membership_action_Offer);
            //context.GroupMembershipActions.Add(group_membership_action_Allow);
            //context.GroupMembershipActions.Add(group_membership_action_Request);
            //context.GroupMembershipActions.Add(group_membership_action_Accept);
            //context.GroupMembershipActions.Add(group_membership_action_Reject);
            //context.GroupMembershipActions.Add(group_membership_action_Cancel);



            var memb_sandberg_SwitzerlandIndustrialImportsGroup = new GroupMembershipStateInfo { Key=new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1C0"), GroupMembershipAction=GroupMembershipAction.Accept, RequestedGroup=SwitzerlandIndustrialImportsGroup, RequestorAccount= sandbergs };
            var memb_allenp_SwitzerlandIndustrialImportsGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1C1"), GroupMembershipAction = GroupMembershipAction.Accept,  RequestedGroup = SwitzerlandIndustrialImportsGroup, RequestorAccount = allenp };
            var memb_hoffmanr_SwitzerlandIndustrialImportsGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1C2"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = SwitzerlandIndustrialImportsGroup, RequestorAccount = hoffmanr };
            var memb_guthrie_SwitzerlandIndustrialImportsGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E2A6"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = SwitzerlandIndustrialImportsGroup, RequestorAccount = guthries };

            var memb_ellisonl_FreshFoodGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1C3"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = FreshFoodGroup, RequestorAccount = ellisonl };
            var memb_wozniaks_FreshFoodGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1C4"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = FreshFoodGroup, RequestorAccount = wozniaks };

            var memb_ellisonl_DistributionForMilkshakeGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1C5"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = DistributionForMilkshakeGroup, RequestorAccount = ellisonl };
            var memb_wozniaks_DistributionForMilkshakeGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1C6"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = DistributionForMilkshakeGroup, RequestorAccount = wozniaks };

            var memb_rometty_MarketingForMilkshakeGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1C7"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = MarketingForMilkshakeGroup, RequestorAccount = romettyv };
            var memb_hanselmans_MarketingForMilkshakeGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1C8"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = MarketingForMilkshakeGroup, RequestorAccount = hanselmans };

            var memb_gatesb_ProductDevelopmentForMilkshakeGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1C9"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = ProductDevelopmentForMilkshakeGroup, RequestorAccount = gatesb };
            var memb_brins_ProductDevelopmentForMilkshakeGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E2A0"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = ProductDevelopmentForMilkshakeGroup, RequestorAccount = brins };
            var memb_pagel_ProductDevelopmentForMilkshakeGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E2A2"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = ProductDevelopmentForMilkshakeGroup, RequestorAccount = pagel };

            var memb_mayerm_SwitzerlandTransporationHPLaptopsGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E2A3"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = SwitzerlandTransporationHPLaptopsGroup, RequestorAccount = mayerm };
            var memb_ozzier_SwitzerlandTransporationHPLaptopsGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E2A4"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = SwitzerlandTransporationHPLaptopsGroup, RequestorAccount = ozzier };
            var memb_torvaldsl_SwitzerlandTransporationHPLaptopsGroup = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E2A5"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = SwitzerlandTransporationHPLaptopsGroup, RequestorAccount = torvaldsl };



            context.GroupMemberships.Add(memb_sandberg_SwitzerlandIndustrialImportsGroup);
            context.GroupMemberships.Add(memb_allenp_SwitzerlandIndustrialImportsGroup);
            context.GroupMemberships.Add(memb_hoffmanr_SwitzerlandIndustrialImportsGroup);
            context.GroupMemberships.Add(memb_guthrie_SwitzerlandIndustrialImportsGroup);
            context.GroupMemberships.Add(memb_ellisonl_FreshFoodGroup);
            context.GroupMemberships.Add(memb_wozniaks_FreshFoodGroup);
            context.GroupMemberships.Add(memb_ellisonl_DistributionForMilkshakeGroup);
            context.GroupMemberships.Add(memb_wozniaks_DistributionForMilkshakeGroup);
            context.GroupMemberships.Add(memb_rometty_MarketingForMilkshakeGroup);
            context.GroupMemberships.Add(memb_hanselmans_MarketingForMilkshakeGroup);
            context.GroupMemberships.Add(memb_gatesb_ProductDevelopmentForMilkshakeGroup);
            context.GroupMemberships.Add(memb_brins_ProductDevelopmentForMilkshakeGroup);
            context.GroupMemberships.Add(memb_pagel_ProductDevelopmentForMilkshakeGroup);
            context.GroupMemberships.Add(memb_mayerm_SwitzerlandTransporationHPLaptopsGroup);
            context.GroupMemberships.Add(memb_ozzier_SwitzerlandTransporationHPLaptopsGroup);
            context.GroupMemberships.Add(memb_torvaldsl_SwitzerlandTransporationHPLaptopsGroup);


            //var partnership_action_New = new PartnershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458FA08A2A0"), Name = "New" };
            //var partnership_action_Request = new PartnershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458FA08A2A1"), Name = "Request" };
            //var partnership_action_Accept = new PartnershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458FA08A2A2"), Name = "Accept" };
            //var partnership_action_Reject = new PartnershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458FA08A2A3"), Name = "Reject" };
            //var partnership_action_Cancel = new PartnershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458FA08A2A4"), Name = "Cancel" };

            //context.PartnershipActions.Add(partnership_action_New);
            //context.PartnershipActions.Add(partnership_action_Request);
            //context.PartnershipActions.Add(partnership_action_Accept);
            //context.PartnershipActions.Add(partnership_action_Reject);
            //context.PartnershipActions.Add(partnership_action_Cancel);

            var part_Migros_Nestle = new PartnershipStateInfo { Key= new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A0"), Action= PartnershipAction.Accept, Sender=MigrosAdministratorAccount, Receiver=NestleAdministratorAccount, ActionDateTime=DateTime.Now };
            var part_Migros_Galliker = new PartnershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A1"), Action = PartnershipAction.Accept, Sender = MigrosAdministratorAccount, Receiver = GallikerAdministratorAccount, ActionDateTime = DateTime.Now };
            var part_Nestle_Galliker = new PartnershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A2"), Action = PartnershipAction.Accept, Sender = NestleAdministratorAccount, Receiver = GallikerAdministratorAccount, ActionDateTime = DateTime.Now };
            var part_Nestle_Emmi = new PartnershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A3"), Action = PartnershipAction.Accept, Sender = NestleAdministratorAccount, Receiver = EmmiAdministratorAccount, ActionDateTime = DateTime.Now };

            var part_SwissPost_Dhl = new PartnershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A4"), Action = PartnershipAction.Accept, Sender = SwissPostAdministratorAccount, Receiver = DhlAdministratorAccount, ActionDateTime = DateTime.Now };
            var part_HP_Dhl = new PartnershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A5"), Action = PartnershipAction.Accept, Sender = HewlettPackardAdministratorAccount, Receiver = DhlAdministratorAccount, ActionDateTime = DateTime.Now };

            var part_SwissGovernment_Erne = new PartnershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A6"), Action = PartnershipAction.Accept, Sender = SwissGovernmentAdministratorAccount, Receiver = ErneAdministratorAccount, ActionDateTime = DateTime.Now };
            var part_SwissGovernment_Marti = new PartnershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A7"), Action = PartnershipAction.Accept, Sender = SwissGovernmentAdministratorAccount, Receiver = MartiAdministratorAccount, ActionDateTime = DateTime.Now };
            var part_SwissGovernment_Montanstahl = new PartnershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1A8"), Action = PartnershipAction.Accept, Sender = SwissGovernmentAdministratorAccount, Receiver = MontanstahlAdministratorAccount, ActionDateTime = DateTime.Now };
           

            context.Partnerships.Add(part_Migros_Nestle);
            context.Partnerships.Add(part_Migros_Galliker);
            context.Partnerships.Add(part_Nestle_Galliker);
            context.Partnerships.Add(part_Nestle_Emmi);

            context.Partnerships.Add(part_SwissPost_Dhl);
            context.Partnerships.Add(part_HP_Dhl);

            context.Partnerships.Add(part_SwissGovernment_Erne);
            context.Partnerships.Add(part_SwissGovernment_Marti);
            context.Partnerships.Add(part_SwissGovernment_Montanstahl);


            byte[] defaultAllianceHeaderPicture = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.allianceHeader  );
            byte[] defaultAllianceProfilePicture = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.allianceProfile  );


            var all_NewMilkshake = new Alliance { Key=new Guid("ACBCCE0E-7C9F-4386-99AA-1458F308EBB0"), Name="New Milkshake Brand", Description="We will create a new milkshake", Coordinator=NestleAdministratorAccount, HeaderPicture=defaultAllianceHeaderPicture, ProfilePicture=defaultAllianceProfilePicture  };
            var all_HPLaptopDistribution = new Alliance { Key = new Guid("ACBCCE0E-99AA-4386-98AA-1458F308EBB1"), Name = "Distribution of HP Products in Switzerland", Description = "Distribution of HP Products in Switzerland", Coordinator = HewlettPackardAdministratorAccount, HeaderPicture = defaultAllianceHeaderPicture, ProfilePicture = defaultAllianceProfilePicture };
            var all_ConstructionStandards = new Alliance { Key = new Guid("ACBCCE0E-99AA-4386-98AA-1458F308EBB2"), Name = "Construction Standards", Description = "We talk about construction best practices in Switzerland", Coordinator = SwissGovernmentAdministratorAccount, HeaderPicture = defaultAllianceHeaderPicture, ProfilePicture = defaultAllianceProfilePicture };
           

            context.Alliances.Add(all_NewMilkshake);
            context.Alliances.Add(all_HPLaptopDistribution);
            context.Alliances.Add(all_ConstructionStandards);

            var all_NewMilkshake_BasicProfile = new BasicProfile { ReferenceKey=all_NewMilkshake.Key, ReferenceType= AccountType.Alliance  };
            var all_HPLaptopDistribution_BasicProfile = new BasicProfile  { ReferenceKey=all_HPLaptopDistribution.Key, ReferenceType= AccountType.Alliance  };
            var all_ConstructionStandards_BasicProfile = new BasicProfile { ReferenceKey=all_ConstructionStandards.Key  , ReferenceType=AccountType.Alliance  };

            context.BasicProfiles.Add(all_NewMilkshake_BasicProfile);
            context.BasicProfiles.Add(all_HPLaptopDistribution_BasicProfile);
            context.BasicProfiles.Add(all_ConstructionStandards_BasicProfile);

            //var alliance_action_New = new AllianceMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458A308A1A0"), Name = "New" };
            //var alliance_action_Offer = new AllianceMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458A308A1A1"), Name = "Offer" };
            //var alliance_action_Allow = new AllianceMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458A308A1A2"), Name = "Allow" };
            //var alliance_action_Request = new AllianceMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458A308A1A3"), Name = "Request" };
            //var alliance_action_Accept = new AllianceMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458A308A1A4"), Name = "Accept" };
            //var alliance_action_Reject = new AllianceMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458A308A1A5"), Name = "Reject" };
            //var alliance_action_Cancel = new AllianceMembershipAction { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458A308A1A6"), Name = "Cancel" };

            //context.AllianceMembershipActions.Add(alliance_action_New);
            //context.AllianceMembershipActions.Add(alliance_action_Offer);
            //context.AllianceMembershipActions.Add(alliance_action_Allow);
            //context.AllianceMembershipActions.Add(alliance_action_Request);
            //context.AllianceMembershipActions.Add(alliance_action_Accept);
            //context.AllianceMembershipActions.Add(alliance_action_Reject);
            //context.AllianceMembershipActions.Add(alliance_action_Cancel);



            var memb_Migros_NewMilkshake = new AllianceMembershipStateInfo { Key=new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D0"), AllianceMembershipAction=AllianceMembershipAction.Accept,  AllianceRequested=all_NewMilkshake, OrganizationRequestor=MigrosAdministratorAccount };
            var memb_Nestle_NewMilkshake = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D1"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = all_NewMilkshake, OrganizationRequestor = NestleAdministratorAccount };
            var memb_Emmi_NewMilkshake = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D2"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = all_NewMilkshake, OrganizationRequestor = EmmiAdministratorAccount };


            var memb_SwissPost_HPLaptopDistribution = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D3"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = all_HPLaptopDistribution, OrganizationRequestor = SwissPostAdministratorAccount };
            var memb_Dhl_HPLaptopDistribution = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D4"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = all_HPLaptopDistribution, OrganizationRequestor = DhlAdministratorAccount };
            var memb_HewlettPackard_HPLaptopDistribution = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D5"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = all_HPLaptopDistribution, OrganizationRequestor = HewlettPackardAdministratorAccount };


            var memb_Erne_ConstructionStandards = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D6"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = all_ConstructionStandards, OrganizationRequestor = ErneAdministratorAccount };
            var memb_Marti_ConstructionStandards = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D7"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = all_ConstructionStandards, OrganizationRequestor = MartiAdministratorAccount };
            var memb_SwissGovernment_ConstructionStandards = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D8"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = all_ConstructionStandards, OrganizationRequestor = SwissGovernmentAdministratorAccount };
            var memb_Montanstahl_ConstructionStandards = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D9"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = all_ConstructionStandards, OrganizationRequestor = MontanstahlAdministratorAccount };



            context.AllianceMemberships.Add(memb_Migros_NewMilkshake);
            context.AllianceMemberships.Add(memb_Nestle_NewMilkshake);
            context.AllianceMemberships.Add(memb_Emmi_NewMilkshake);

            context.AllianceMemberships.Add(memb_SwissPost_HPLaptopDistribution);
            context.AllianceMemberships.Add(memb_Dhl_HPLaptopDistribution);
            context.AllianceMemberships.Add(memb_HewlettPackard_HPLaptopDistribution);

            context.AllianceMemberships.Add(memb_Erne_ConstructionStandards);
            context.AllianceMemberships.Add(memb_Marti_ConstructionStandards);
            context.AllianceMemberships.Add(memb_SwissGovernment_ConstructionStandards);
            context.AllianceMemberships.Add(memb_Montanstahl_ConstructionStandards);



            //var wbs_0 = new WorkPackage { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EAA0"), WbsCorrelationToken = "0", Owner=gatesb, Title = "Task 0", Description = "Description of Task 0", Comments = "Comments of Task 0" };

            //var wbs_1 = new WorkPackage { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EAA1"), WbsCorrelationToken = "1", Owner = gatesb, ParentWorkPackage = wbs_0, Title = "Task 1", Description = "Description of Task 1", Comments = "Comments of Task 1" };
            //var wbs_1_1 = new WorkPackage { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EAA2"), WbsCorrelationToken = "1.1", Owner = gatesb, ParentWorkPackage = wbs_1, Title = "Task 1.1", Description = "Description of Task 1.1", Comments = "Comments of Task 1.1" };
            //var wbs_1_2 = new WorkPackage { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EAA3"), WbsCorrelationToken = "1.2", Owner = gatesb, ParentWorkPackage = wbs_1, Title = "Task 1.2", Description = "Description of Task 1.2", Comments = "Comments of Task 1.2" };

            //var wbs_2 = new WorkPackage { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EAA4"), WbsCorrelationToken = "2", Owner = gatesb, ParentWorkPackage = wbs_0, Title = "Task 2", Description = "Description of Task 2", Comments = "Comments of Task 2" };
            //var wbs_2_1 = new WorkPackage { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EAA5"), WbsCorrelationToken = "2.1", Owner = gatesb, ParentWorkPackage = wbs_2, Title = "Task 2.1", Description = "Description of Task 2.1", Comments = "Comments of Task 2.1" };

            //var wbs_3 = new WorkPackage { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EAA6"), WbsCorrelationToken = "3", Owner = gatesb, ParentWorkPackage = wbs_0, Title = "Task 3", Description = "Description of Task 3", Comments = "Comments of Task 3" };
            //var wbs_3_1 = new WorkPackage { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EAA7"), WbsCorrelationToken = "3.1", Owner = gatesb, ParentWorkPackage = wbs_3, Title = "Task 3.1", Description = "Description of Task 3.1", Comments = "Comments of Task 3.1" };
            //var wbs_3_2 = new WorkPackage { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EAA8"), WbsCorrelationToken = "3.2", Owner = gatesb, ParentWorkPackage = wbs_3, Title = "Task 3.2", Description = "Description of Task 3.2", Comments = "Comments of Task 3.2" };
            //var wbs_3_2_1 = new WorkPackage { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EAA9"), WbsCorrelationToken = "3.2.1", Owner = gatesb, ParentWorkPackage = wbs_3_2, Title = "Task 3.2.1", Description = "Description of Task 3.2.1", Comments = "Comments of Task 3.2.1" };

            //var Project1 = new Project { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBA0"), Name="Project1", Description="Description of project 1", Coordinator=NestleAdministratorAccount, WorkBreakdownStructure=wbs_0 };
          
           
            //context.WorkPackages.Add(wbs_3_2_1);
            //context.WorkPackages.Add(wbs_3_2);
            //context.WorkPackages.Add(wbs_3_1);
            //context.WorkPackages.Add(wbs_3);


            //context.WorkPackages.Add(wbs_2_1);
            //context.WorkPackages.Add(wbs_2);

            //context.WorkPackages.Add(wbs_1_1);
            //context.WorkPackages.Add(wbs_1_2);
            //context.WorkPackages.Add(wbs_1);

            //context.WorkPackages.Add(wbs_0);

            //context.Projects.Add(Project1);

            //var trend1 = new Hashtag() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBC0"), Symbol = "Trend1", AllianceContext=all_NewMilkshake };
            //var trend2 = new Hashtag() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBC1"), Symbol = "Trend2", GroupContext=DistributionForMilkshakeGroup   };
            //var trend3 = new Hashtag() { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBC2"), Symbol = "Trend3", OrganizationContext=SwissPostAdministratorAccount  };

            //var trend1_tweet1 = new Tweet { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBB0"), Author = gatesb, Hashtag = trend1, Text = "We should start to plan already", PublishDateTime = DateTime.Now.AddDays(-5), Wall = all_NewMilkshake_wall   };
            //var trend1_tweet2 = new Tweet { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBB1"), Author = hanselmans, Hashtag = trend1, Text = "definetely, who will make the schedule", PublishDateTime = DateTime.Now.AddDays(-4), Wall = all_NewMilkshake_wall };
            //var trend1_tweet3 = new Tweet { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBB2"), Author = sandbergs, Hashtag = trend1, Text = "I will, and I will let you know when I finish", PublishDateTime = DateTime.Now.AddDays(-3), Wall = all_NewMilkshake_wall };

            //var trend2_tweet1 = new Tweet { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBB3"), Author = ballmers, Hashtag = trend2, Text = "So where are we going to launch the rocket?", PublishDateTime = DateTime.Now.AddDays(-2), Wall = SwitzerlandIndustrialImportsGroup_wall };
            //var trend2_tweet2 = new Tweet { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBB4"), Author = mayerm, Hashtag = trend2, Text = "probably from florida, not from houston", PublishDateTime = DateTime.Now.AddDays(-1), Wall = SwitzerlandIndustrialImportsGroup_wall };

            //var trend3_tweet1 = new Tweet { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBB5"), Author = guthries, Hashtag = trend3, Text = "I got the final results", PublishDateTime = DateTime.Now.AddDays(-20), Wall = nestle_wall  };
            //var trend3_tweet2 = new Tweet { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBB6"), Author = torvaldsl, Hashtag = trend3, Text = "so, what is the result?", PublishDateTime = DateTime.Now.AddDays(-16), Wall = nestle_wall };
            //var trend3_tweet3 = new Tweet { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBB7"), Author = ozzier, Hashtag = trend3, Text = "yeah, tell us, we are all interested",  PublishDateTime = DateTime.Now.AddDays(-12), Wall = nestle_wall };
            //var trend3_tweet4 = new Tweet { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308EBB8"), Author = hoffmanr, Hashtag = trend3, Text = "mmm, I'll wait for tomorrow", PublishDateTime = DateTime.Now.AddDays(-6), Wall = nestle_wall };

            //context.Tweets.Add(trend1_tweet1);
            //context.Tweets.Add(trend1_tweet2);
            //context.Tweets.Add(trend1_tweet3);

            //context.Tweets.Add(trend2_tweet1);
            //context.Tweets.Add(trend2_tweet2);

            //context.Tweets.Add(trend3_tweet1);
            //context.Tweets.Add(trend3_tweet2);
            //context.Tweets.Add(trend3_tweet3);
            //context.Tweets.Add(trend3_tweet4);

            //var gatesb_bookmark_contact_1 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECC0"), Owner = gatesb, Type = BookmarkType.Contact, Reference = wozniaks.Key };
            //var gatesb_bookmark_contact_2 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECC1"), Owner = gatesb, Type = BookmarkType.Contact, Reference = jobss.Key};

            //var gatesb_bookmark_organization_1 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECC2"), Owner = gatesb, Type = BookmarkType.Organization, Reference = Emmi.Key  };
            //var gatesb_bookmark_organization_2 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECC3"), Owner = gatesb, Type = BookmarkType.Organization, Reference = SwissPost.Key  };
            //var gatesb_bookmark_organization_3 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECC4"), Owner = gatesb, Type = BookmarkType.Organization, Reference = Galliker.Key  };

            //var gatesb_bookmark_alliance_1 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECC5"), Owner = gatesb, Type = BookmarkType.Alliance, Reference = all_ConstructionStandards.Key  };
            //var gatesb_bookmark_alliance_2 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECC6"), Owner = gatesb, Type = BookmarkType.Alliance, Reference = all_HPLaptopDistribution.Key  };


            //var gatesb_bookmark_document_1 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECC7"), Owner = gatesb, Type = BookmarkType.Document, Reference = doc1.Key  };
            //var gatesb_bookmark_document_2 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECC8"), Owner = gatesb, Type = BookmarkType.Document, Reference = doc2.Key  };

            //var gatesb_bookmark_folder_1 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECC9"), Owner = gatesb, Type = BookmarkType.Folder, Reference =  gatesb_library_folder_A_subfolder2.Key   };
            //var gatesb_bookmark_folder_2 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECD0"), Owner = gatesb, Type = BookmarkType.Folder, Reference = gatesb_library_folder_A_subfolder2_subfolder1.Key  };


            //var gatesb_bookmark_group_1 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECD1"), Owner = gatesb, Type = BookmarkType.Group, Reference = FreshFoodGroup.Key  };
            //var gatesb_bookmark_group_2 = new Bookmark { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308ECD2"), Owner = gatesb, Type = BookmarkType.Group, Reference = DistributionForMilkshakeGroup.Key  };

            //context.Bookmarks.Add(gatesb_bookmark_contact_1);
            //context.Bookmarks.Add(gatesb_bookmark_contact_2);
            //context.Bookmarks.Add(gatesb_bookmark_organization_1);
            //context.Bookmarks.Add(gatesb_bookmark_organization_2);
            //context.Bookmarks.Add(gatesb_bookmark_organization_3);
            //context.Bookmarks.Add(gatesb_bookmark_alliance_1);
            //context.Bookmarks.Add(gatesb_bookmark_alliance_2);
            //context.Bookmarks.Add(gatesb_bookmark_document_1);
            //context.Bookmarks.Add(gatesb_bookmark_folder_1);
            //context.Bookmarks.Add(gatesb_bookmark_group_1);
            //context.Bookmarks.Add(gatesb_bookmark_group_2);

            //context.SaveChanges();
            //base.Seed(context);


            var system_account_gatesb = new SystemAccount() {  Email = gatesb.Email, Password = "login123", Holder=gatesb_BasicProfile,   IsConfirmed = true,   };
            var system_account_brins = new SystemAccount() { Email = brins.Email, Password = "login123", Holder = brins_BasicProfile, IsConfirmed = true, };
            var system_account_pagel = new SystemAccount() { Email = pagel.Email, Password = "login123", Holder = pagel_BasicProfile, IsConfirmed = true, };
            var system_account_ellisonl = new SystemAccount() { Email = ellisonl.Email, Password = "login123", Holder = ellisonl_BasicProfile, IsConfirmed = true, };
            var system_account_mayerm = new SystemAccount() { Email = mayerm.Email, Password = "login123", Holder = mayerm_BasicProfile, IsConfirmed = true, };
            var system_account_schmidte = new SystemAccount() { Email = schmidte.Email, Password = "login123", Holder = schmidte_BasicProfile, IsConfirmed = true, };
            var system_account_jobss = new SystemAccount() { Email = jobss.Email, Password = "login123", Holder = jobss_BasicProfile, IsConfirmed = true, };
            var system_account_ballmers = new SystemAccount() { Email = ballmers.Email, Password = "login123", Holder = ballmers_BasicProfile, IsConfirmed = true, };
            var system_account_wozniaks = new SystemAccount() { Email = wozniaks.Email, Password = "login123", Holder = wozniaks_BasicProfile, IsConfirmed = true, };
            var system_account_allenp = new SystemAccount() { Email = allenp.Email, Password = "login123", Holder = allenp_BasicProfile, IsConfirmed = true, };
            var system_account_sandbergs = new SystemAccount() { Email = sandbergs.Email, Password = "login123", Holder = sandbergs_BasicProfile, IsConfirmed = true, };
            var system_account_hoffmanr = new SystemAccount() { Email = hoffmanr.Email, Password = "login123", Holder = hoffmanr_BasicProfile, IsConfirmed = true, };
            var system_account_romettyv = new SystemAccount() { Email = romettyv.Email, Password = "login123", Holder = romettyv_BasicProfile, IsConfirmed = true, };
            var system_account_hanselmans = new SystemAccount() { Email = hanselmans.Email, Password = "login123", Holder = hanselmans_BasicProfile, IsConfirmed = true, };
            var system_account_guthries = new SystemAccount() { Email = guthries.Email, Password = "login123", Holder = guthries_BasicProfile, IsConfirmed = true, };
            var system_account_torvaldsl = new SystemAccount() { Email = torvaldsl.Email, Password = "login123", Holder = torvaldsl_BasicProfile, IsConfirmed = true, };
            var system_account_ozzier = new SystemAccount() { Email = ozzier.Email, Password = "login123", Holder = ozzier_BasicProfile, IsConfirmed = true, };

            var system_account_Nestle_hq = new SystemAccount() { Email = "admin@nestle.ch", Password = "login123", Holder=Nestle_BasicProfile, IsConfirmed=true  };
            var system_account_Galliker_hq = new SystemAccount() { Email = "admin@galliker.ch", Password = "login123", Holder = Galliker_BasicProfile, IsConfirmed = true };
            var system_account_Emmi_hq = new SystemAccount() { Email = "admin@emmi.ch", Password = "login123", Holder = Emmi_BasicProfile, IsConfirmed = true };
            var system_account_Migros_hq = new SystemAccount() { Email = "admin@migros.ch", Password = "login123", Holder = Migros_BasicProfile, IsConfirmed = true };
            var system_account_SwissPost_hq = new SystemAccount() { Email = "admin@swisspost.ch", Password = "login123", Holder = SwissPost_BasicProfile, IsConfirmed = true };
            var system_account_Marti_hq = new SystemAccount() { Email = "admin@marti.ch", Password = "login123", Holder = Marti_BasicProfile, IsConfirmed = true };
            var system_account_Erne_hq = new SystemAccount() { Email = "admin@erne.ch", Password = "login123", Holder = Erne_BasicProfile, IsConfirmed = true };
            var system_account_Montanstahl_hq = new SystemAccount() { Email = "admin@montanstahl.ch", Password = "login123", Holder = Montanstahl_BasicProfile, IsConfirmed = true };
            var system_account_SwissGovernment_hq = new SystemAccount() { Email = "admin@admin.ch", Password = "login123", Holder = SwissGovernment_BasicProfile, IsConfirmed = true };
            var system_account_Dhl_hq = new SystemAccount() { Email = "admin@dhl.ch", Password = "login123", Holder = Dhl_BasicProfile, IsConfirmed = true };
            var system_account_HewlettPackard_hq = new SystemAccount() { Email = "admin@hp.ch", Password = "login123", Holder = HewlettPackard_BasicProfile, IsConfirmed = true };


            context.SystemAccounts.Add(system_account_gatesb);
            context.SystemAccounts.Add(system_account_brins);
            context.SystemAccounts.Add(system_account_pagel);
            context.SystemAccounts.Add(system_account_ellisonl);
            context.SystemAccounts.Add(system_account_mayerm);
            context.SystemAccounts.Add(system_account_schmidte);
            context.SystemAccounts.Add(system_account_jobss);
            context.SystemAccounts.Add(system_account_ballmers);
            context.SystemAccounts.Add(system_account_wozniaks);
            context.SystemAccounts.Add(system_account_allenp);
            context.SystemAccounts.Add(system_account_sandbergs);
            context.SystemAccounts.Add(system_account_hoffmanr);
            context.SystemAccounts.Add(system_account_romettyv);
            context.SystemAccounts.Add(system_account_hanselmans);
            context.SystemAccounts.Add(system_account_guthries);
            context.SystemAccounts.Add(system_account_torvaldsl);
            context.SystemAccounts.Add(system_account_ozzier);

            context.SystemAccounts.Add(system_account_Nestle_hq);
            context.SystemAccounts.Add(system_account_Galliker_hq);
            context.SystemAccounts.Add(system_account_Emmi_hq);
            context.SystemAccounts.Add(system_account_Migros_hq);
            context.SystemAccounts.Add(system_account_SwissPost_hq);
            context.SystemAccounts.Add(system_account_Marti_hq);
            context.SystemAccounts.Add(system_account_Erne_hq);
            context.SystemAccounts.Add(system_account_Montanstahl_hq);
            context.SystemAccounts.Add(system_account_SwissGovernment_hq);
            context.SystemAccounts.Add(system_account_Dhl_hq);
            context.SystemAccounts.Add(system_account_HewlettPackard_hq);


            var gatesb_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789001"), Owner=gatesb_BasicProfile  };


            var gatesb_wall_post1 = new Post() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789002"), Author=gatesb_BasicProfile , Text = "This is my first post", Wall = gatesb_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-3,50,10)) };

            var gatesb_wall_post1_like_ellisonl = new PostLike { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789003"), Author=ellisonl_BasicProfile  , DateTime = DateTime.Now.Add(new TimeSpan(-3, 50, 15)) };
            var gatesb_wall_post1_like_gatesb = new PostLike { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789004"), Author=gatesb_BasicProfile  , DateTime = DateTime.Now.Add(new TimeSpan(-3, 50, 30)) };

            var gatesb_wall_comment1_post1 = new Comment() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789005"), Author=hanselmans_BasicProfile  , Text = "Congratulations, this is my first comment on a post", Post = gatesb_wall_post1, PublishDateTime = DateTime.Now.Add(new TimeSpan(-3, 20, 10)) };
            var gatesb_wall_comment1_post1_like_mayerm = new CommentLike { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789006"), Author=mayerm_BasicProfile  , Comment = gatesb_wall_comment1_post1, DateTime = DateTime.Now.Add(new TimeSpan(-3, 23, 10)) };
            var gatesb_wall_comment1_post1_like_sandbergs = new CommentLike { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789007"), Author=sandbergs_BasicProfile  , Comment = gatesb_wall_comment1_post1, DateTime = DateTime.Now.Add(new TimeSpan(-3, 25, 10)) };

            var gatesb_wall_comment2_post1 = new Comment() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789008"), Author=brins_BasicProfile  , Text = "This is also my first comment on a post", Post = gatesb_wall_post1, PublishDateTime = DateTime.Now.Add(new TimeSpan(-2, 15, 10)) };
            var gatesb_wall_comment3_post1 = new Comment() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789009"), Author=ballmers_BasicProfile   , Text = "Same here!", Post = gatesb_wall_post1, PublishDateTime = DateTime.Now.Add(new TimeSpan(-2, 23, 40)) };

            var gatesb_wall_post2 = new Post() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-12345678900A"), Author=gatesb_BasicProfile  , Text = "This is my second post", Wall = gatesb_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-2, 12, 15)) };
            var gatesb_wall_comment1_post2 = new Comment() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-12345678900B"), Author=ellisonl_BasicProfile  , Text = "ok, we get it", Post = gatesb_wall_post2, PublishDateTime = DateTime.Now.Add(new TimeSpan(-2, 14, 25)) };
            var gatesb_wall_comment2_post2 = new Comment() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-12345678900C"), Author=romettyv_BasicProfile  , Text = "overly attached user!", Post = gatesb_wall_post2, PublishDateTime = DateTime.Now.Add(new TimeSpan(-2, 17, 36)) };

            var gatesb_wall_post3 = new Post() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-12345678900D"), Author=gatesb_BasicProfile  , Text = "This is my third post", Wall = gatesb_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-1, 50, 10)) };
            var gatesb_wall_comment1_post3 = new Comment() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-12345678900E"), Author=ballmers_BasicProfile  , Text = "we get it, is working", Post = gatesb_wall_post3, PublishDateTime = DateTime.Now.Add(new TimeSpan(-1, 55, 45)) };

            var gatesb_wall_post4 = new Post() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-12345678900F"), Author=gatesb_BasicProfile  , Text = "ok, I think I like to post!", Wall = gatesb_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(0, 24, 15)) };

            context.Posts.Add(gatesb_wall_post1);
            context.Posts.Add(gatesb_wall_post2);
            context.Posts.Add(gatesb_wall_post3);
            context.Posts.Add(gatesb_wall_post4);

            context.Comments.Add(gatesb_wall_comment1_post1);
            context.Comments.Add(gatesb_wall_comment2_post1);
            context.Comments.Add(gatesb_wall_comment3_post1);

            context.Comments.Add(gatesb_wall_comment1_post2);
            context.Comments.Add(gatesb_wall_comment2_post2);

            context.Comments.Add(gatesb_wall_comment1_post3);


            context.PostLikes.Add(gatesb_wall_post1_like_ellisonl);
            context.PostLikes.Add(gatesb_wall_post1_like_gatesb);
            context.CommentLikes.Add(gatesb_wall_comment1_post1_like_mayerm);
            context.CommentLikes.Add(gatesb_wall_comment1_post1_like_sandbergs);


            var brins_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789000"), Owner=brins_BasicProfile  };   
            var schmidte_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789001"), Owner= schmidte_BasicProfile   };
            var mayerm_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789002"), Owner = mayerm_BasicProfile };
            var jobss_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789003"), Owner= jobss_BasicProfile  };
            var ballmers_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789004"), Owner=ballmers_BasicProfile };
            var wozniaks_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789005"), Owner= wozniaks_BasicProfile  };
            var allenp_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789006"), Owner=allenp_BasicProfile  };
            var sandbergs_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789007"), Owner= sandbergs_BasicProfile  };
            var hoffmanr_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789008"), Owner=hoffmanr_BasicProfile  };
            var romettyv_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789009"), Owner=romettyv_BasicProfile  };
            var hanselmans_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678900A"), Owner=hanselmans_BasicProfile  };
            var guthries_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678900B"), Owner=guthries_BasicProfile  };
            var torvaldsl_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678900C"), Owner=torvaldsl_BasicProfile  };
            var ozzier_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678900D"), Owner=ozzier_BasicProfile  };
            var ellisonl_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678900E"), Owner = ellisonl_BasicProfile  };
            var pagel_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678900F"), Owner = pagel_BasicProfile };


            context.ContentStreams.Add(brins_wall);
            context.ContentStreams.Add(pagel_wall);
            context.ContentStreams.Add(schmidte_wall);
            context.ContentStreams.Add(jobss_wall);
            context.ContentStreams.Add(ballmers_wall);
            context.ContentStreams.Add(wozniaks_wall);
            context.ContentStreams.Add(allenp_wall);
            context.ContentStreams.Add(sandbergs_wall);
            context.ContentStreams.Add(hoffmanr_wall);
            context.ContentStreams.Add(romettyv_wall);
            context.ContentStreams.Add(hanselmans_wall);
            context.ContentStreams.Add(guthries_wall);
            context.ContentStreams.Add(torvaldsl_wall);
            context.ContentStreams.Add(ozzier_wall);
            context.ContentStreams.Add(ellisonl_wall);
            context.ContentStreams.Add(mayerm_wall);


            var Galliker_wall = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A01"), Owner=Galliker_BasicProfile  };
            var Emmi_wall = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A02"), Owner=Emmi_BasicProfile   };
            var Migros_wall = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A03"), Owner=Migros_BasicProfile   };
            var SwissPost_wall = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A04"), Owner=SwissPost_BasicProfile    };
            var Marti_wall = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A05"), Owner=Marti_BasicProfile };
            var Erne_wall = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A06"), Owner=Erne_BasicProfile   };
            var Montanstahl_wall = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A07"), Owner=Montanstahl_BasicProfile   };
            var SwissGovernment_wall = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A08"), Owner=SwissGovernment_BasicProfile   };
            var Dhl_wall = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A09"), Owner=Dhl_BasicProfile  };
            var HewlettPackard_wall = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A0A"), Owner=HewlettPackard_BasicProfile   };


            context.ContentStreams.Add(Galliker_wall);
            context.ContentStreams.Add(Emmi_wall);
            context.ContentStreams.Add(Migros_wall);
            context.ContentStreams.Add(SwissPost_wall);
            context.ContentStreams.Add(Marti_wall);
            context.ContentStreams.Add(Erne_wall);
            context.ContentStreams.Add(Montanstahl_wall);
            context.ContentStreams.Add(SwissGovernment_wall);
            context.ContentStreams.Add(Dhl_wall);
            context.ContentStreams.Add(HewlettPackard_wall);
   


            var Nestle_wall = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A01"), Owner=Nestle_BasicProfile  };

            var nestle_wall_post1 = new Post() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A02"), Author = Nestle_BasicProfile  , Text = "This is my first post", Wall = Nestle_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-5,-40,-10)) };

            var nestle_wall_post1_like_ellisonl = new PostLike { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A03"), Author = Emmi_BasicProfile, Post = nestle_wall_post1,  DateTime = DateTime.Now.Add(new TimeSpan(-5, -25, -13)) };
            var nestle_wall_post1_like_gatesb = new PostLike { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A04"), Author = Migros_BasicProfile, Post = nestle_wall_post1, DateTime = DateTime.Now.Add(new TimeSpan(-5, -21, -50)) };

            var nestle_wall_comment1_post1 = new Comment() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A05"), Author = Galliker_BasicProfile  , Text = "Congratulations, this is my first comment on a post", Post = nestle_wall_post1, PublishDateTime = DateTime.Now.Add(new TimeSpan(-5,-14,-32)) };
            var nestle_wall_comment1_post1_like_mayerm = new CommentLike { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A06"), Author = Dhl_BasicProfile, Comment = nestle_wall_comment1_post1, DateTime = DateTime.Now.Add(new TimeSpan(-5, -4, -17)) };
            var nestle_wall_comment1_post1_like_sandbergs = new CommentLike { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A07"), Author = SwissGovernment_BasicProfile, Comment = nestle_wall_comment1_post1, DateTime = DateTime.Now.Add(new TimeSpan(-5, -1, 0)) };

            var nestle_wall_comment2_post1 = new Comment() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A08"), Author = SwissGovernment_BasicProfile  , Text = "This is also my first comment on a post", Post = nestle_wall_post1, PublishDateTime = DateTime.Now.Add(new TimeSpan(-4,32,22)) };
            var nestle_wall_comment3_post1 = new Comment() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A09"), Author = SwissPost_BasicProfile, Text = "Same here!", Post = nestle_wall_post1, PublishDateTime = DateTime.Now.Add(new TimeSpan(-4, -14, -14)) };

            var nestle_wall_post2 = new Post() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A0A"), Author = Nestle_BasicProfile, Text = "This is my second post", Wall = Nestle_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-4, -3, -10)) };
            var nestle_wall_comment1_post2 = new Comment() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A0B"), Author = Nestle_BasicProfile, Text = "ok, we get it", Post = nestle_wall_post2, PublishDateTime = DateTime.Now.Add(new TimeSpan(-3, -20, 10)) };
            var nestle_wall_comment2_post2 = new Comment() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A0C"), Author = Migros_BasicProfile, Text = "overly attached user!", Post = nestle_wall_post2, PublishDateTime = DateTime.Now.Add(new TimeSpan(-2, -41, 14)) };

            var nestle_wall_post3 = new Post() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A0D"), Author = Nestle_BasicProfile, Text = "This is my third post", Wall = Nestle_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-2, -3, 44)) };
            var nestle_wall_comment1_post3 = new Comment() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A0E"), Author = Galliker_BasicProfile, Text = "we get it, is working", Post = nestle_wall_post3, PublishDateTime = DateTime.Now.Add(new TimeSpan(-2, 0, 20)) };

            var nestle_wall_post4 = new Post() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789A0F"), Author = Nestle_BasicProfile, Text = "ok, I think I like to post!", Wall = Nestle_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-1,45,34)) };

            context.Posts.Add(nestle_wall_post1);
            context.Posts.Add(nestle_wall_post2);
            context.Posts.Add(nestle_wall_post3);
            context.Posts.Add(nestle_wall_post4);

            context.Comments.Add(nestle_wall_comment1_post1);
            context.Comments.Add(nestle_wall_comment2_post1);
            context.Comments.Add(nestle_wall_comment3_post1);

            context.Comments.Add(nestle_wall_comment1_post2);
            context.Comments.Add(nestle_wall_comment2_post2);

            context.Comments.Add(nestle_wall_comment1_post3);


            context.PostLikes.Add(nestle_wall_post1_like_ellisonl);
            context.PostLikes.Add(nestle_wall_post1_like_gatesb);
            context.CommentLikes.Add(nestle_wall_comment1_post1_like_mayerm);
            context.CommentLikes.Add(nestle_wall_comment1_post1_like_sandbergs);


            var SwitzerlandIndustrialImportsGroup_wall = new ContentStream { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C01"), Owner = SwitzerlandIndustrialImportsGroup_BasicProfile };

            var SwitzerlandIndustrialImportsGroup_wall_post1 = new Post() { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C02"), Author = sandbergs_BasicProfile, Text = "This is my first post", Wall = SwitzerlandIndustrialImportsGroup_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-10, -3, -14)) };

            var SwitzerlandIndustrialImportsGroup_wall_post1_like_ellisonl = new PostLike { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C03"), Author = ellisonl_BasicProfile, Post = SwitzerlandIndustrialImportsGroup_wall_post1, DateTime = DateTime.Now.Add(new TimeSpan(-9, -57, -14)) };
            var SwitzerlandIndustrialImportsGroup_wall_post1_like_gatesb = new PostLike { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C04"), Author = gatesb_BasicProfile, Post = SwitzerlandIndustrialImportsGroup_wall_post1, DateTime = DateTime.Now.Add(new TimeSpan(-9, -46, -14)) };

            var SwitzerlandIndustrialImportsGroup_wall_comment1_post1 = new Comment() { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C05"), Author = mayerm_BasicProfile, Text = "Congratulations, this is my first comment on a post", Post = SwitzerlandIndustrialImportsGroup_wall_post1, PublishDateTime = DateTime.Now.Add(new TimeSpan(-9, -35, -14)) };
            var SwitzerlandIndustrialImportsGroup_wall_comment1_post1_like_mayerm = new CommentLike { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C06"), Author = hoffmanr_BasicProfile, Comment = SwitzerlandIndustrialImportsGroup_wall_comment1_post1, DateTime = DateTime.Now.Add(new TimeSpan(-9, -31, -14)) };
            var SwitzerlandIndustrialImportsGroup_wall_comment1_post1_like_sandbergs = new CommentLike { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C07"), Author = sandbergs_BasicProfile, Comment = SwitzerlandIndustrialImportsGroup_wall_comment1_post1, DateTime = DateTime.Now.Add(new TimeSpan(-9, -3, -14)) };

            var SwitzerlandIndustrialImportsGroup_wall_comment2_post1 = new Comment() { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C08"), Author = ellisonl_BasicProfile, Text = "This is also my first comment on a post", Post = SwitzerlandIndustrialImportsGroup_wall_post1, PublishDateTime = DateTime.Now.Add(new TimeSpan(-8, -34, -14)) };
            var SwitzerlandIndustrialImportsGroup_wall_comment3_post1 = new Comment() { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C09"), Author = torvaldsl_BasicProfile, Text = "Same here!", Post = SwitzerlandIndustrialImportsGroup_wall_post1, PublishDateTime = DateTime.Now.Add(new TimeSpan(-7, -43, -14)) };

            var SwitzerlandIndustrialImportsGroup_wall_post2 = new Post() { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C0A"), Author = hoffmanr_BasicProfile, Text = "This is my second post", Wall = SwitzerlandIndustrialImportsGroup_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-7, -12, -14)) };
            var SwitzerlandIndustrialImportsGroup_wall_comment1_post2 = new Comment() { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C0B"), Author = sandbergs_BasicProfile, Text = "ok, we get it", Post = SwitzerlandIndustrialImportsGroup_wall_post2, PublishDateTime = DateTime.Now.Add(new TimeSpan(-6, -34, -14)) };
            var SwitzerlandIndustrialImportsGroup_wall_comment2_post2 = new Comment() { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C0C"), Author = wozniaks_BasicProfile, Text = "overly attached user!", Post = SwitzerlandIndustrialImportsGroup_wall_post2, PublishDateTime = DateTime.Now.Add(new TimeSpan(-5, -34, -14)) };

            var SwitzerlandIndustrialImportsGroup_wall_post3 = new Post() { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C0D"), Author = mayerm_BasicProfile, Text = "This is my third post", Wall = SwitzerlandIndustrialImportsGroup_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-4, -59, -14)) };
            var SwitzerlandIndustrialImportsGroup_wall_comment1_post3 = new Comment() { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C0E"), Author = ozzier_BasicProfile, Text = "we get it, is working", Post = SwitzerlandIndustrialImportsGroup_wall_post3, PublishDateTime = DateTime.Now.Add(new TimeSpan(-4, -3, -14)) };

            var SwitzerlandIndustrialImportsGroup_wall_post4 = new Post() { Key = new Guid("ADDEEEFA-EEDD-4386-98AA-123456789C0F"), Author = mayerm_BasicProfile, Text = "ok, I think I like to post!", Wall = SwitzerlandIndustrialImportsGroup_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-3, -56, -14)) };

            context.Posts.Add(SwitzerlandIndustrialImportsGroup_wall_post1);
            context.Posts.Add(SwitzerlandIndustrialImportsGroup_wall_post2);
            context.Posts.Add(SwitzerlandIndustrialImportsGroup_wall_post3);
            context.Posts.Add(SwitzerlandIndustrialImportsGroup_wall_post4);

            context.Comments.Add(SwitzerlandIndustrialImportsGroup_wall_comment1_post1);
            context.Comments.Add(SwitzerlandIndustrialImportsGroup_wall_comment2_post1);
            context.Comments.Add(SwitzerlandIndustrialImportsGroup_wall_comment3_post1);

            context.Comments.Add(SwitzerlandIndustrialImportsGroup_wall_comment1_post2);
            context.Comments.Add(SwitzerlandIndustrialImportsGroup_wall_comment2_post2);

            context.Comments.Add(SwitzerlandIndustrialImportsGroup_wall_comment1_post3);


            context.PostLikes.Add(SwitzerlandIndustrialImportsGroup_wall_post1_like_ellisonl);
            context.PostLikes.Add(SwitzerlandIndustrialImportsGroup_wall_post1_like_gatesb);
            context.CommentLikes.Add(SwitzerlandIndustrialImportsGroup_wall_comment1_post1_like_mayerm);
            context.CommentLikes.Add(SwitzerlandIndustrialImportsGroup_wall_comment1_post1_like_sandbergs);


            var FreshFoodGroup_wall = new ContentStream { Key = new Guid("DDDEEEFF-DEDA-5791-98AA-123456789C01"), Owner = FreshFoodGroup_BasicProfile };
            var ProductDevelopmentForMilkshakeGroup_wall = new ContentStream { Key = new Guid("DDDEEEFF-DEDA-5791-98AA-123456789C02"), Owner = ProductDevelopmentForMilkshakeGroup_BasicProfile };
            var MarketingForMilkshakeGroup_wall = new ContentStream { Key = new Guid("DDDEEEFF-DEDA-5791-98AA-123456789C03"), Owner = MarketingForMilkshakeGroup_BasicProfile };
            var DistributionForMilkshakeGroup_wall = new ContentStream { Key = new Guid("DDDEEEFF-DEDA-5791-98AA-123456789C04"), Owner = DistributionForMilkshakeGroup_BasicProfile };
            var SwitzerlandTransporationHPLaptopsGroup_wall = new ContentStream { Key = new Guid("DDDEEEFF-DEDA-5791-98AA-123456789C05"), Owner = SwitzerlandIndustrialImportsGroup_BasicProfile };


            context.ContentStreams.Add(FreshFoodGroup_wall);
            context.ContentStreams.Add(ProductDevelopmentForMilkshakeGroup_wall);
            context.ContentStreams.Add(MarketingForMilkshakeGroup_wall);
            context.ContentStreams.Add(DistributionForMilkshakeGroup_wall);
            context.ContentStreams.Add(SwitzerlandTransporationHPLaptopsGroup_wall);

            var all_HPLaptopDistribution_wall = new ContentStream { Key = new Guid("DDDEEEFF-FAAA-1289-98BA-123456789C00"), Owner = all_HPLaptopDistribution_BasicProfile };
            var all_ConstructionStandards_wall = new ContentStream { Key = new Guid("DDDEEEFF-FAAA-1289-98BA-123456789C01"), Owner = all_ConstructionStandards_BasicProfile };

            context.ContentStreams.Add(all_HPLaptopDistribution_wall);
            context.ContentStreams.Add(all_ConstructionStandards_wall);


            var all_NewMilkshake_wall = new ContentStream { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789C01"), Owner=all_NewMilkshake_BasicProfile   };

            var all_NewMilkshake_wall_post1 = new Post() { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789C02"), Author = Nestle_BasicProfile, Text = "This is my first post", Wall = all_NewMilkshake_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-20, -30, -40)) };

            var all_NewMilkshake_wall_post1_like_ellisonl = new PostLike { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789C03"), Author = Galliker_BasicProfile, Post = all_NewMilkshake_wall_post1, DateTime = DateTime.Now.Add(new TimeSpan(-20, -26, -40)) };
            var all_NewMilkshake_wall_post1_like_gatesb = new PostLike { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789C04"), Author = Nestle_BasicProfile, Post = all_NewMilkshake_wall_post1, DateTime = DateTime.Now.Add(new TimeSpan(-20, -21, -40)) };

            var all_NewMilkshake_wall_comment1_post1 = new Comment() { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789C05"), Author = Migros_BasicProfile, Text = "Congratulations, this is my first comment on a post", Post = all_NewMilkshake_wall_post1, PublishDateTime = DateTime.Now.Add(new TimeSpan(-20, -10, -40)) };
            var all_NewMilkshake_wall_comment1_post1_like_mayerm = new CommentLike { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789C06"), Author = Dhl_BasicProfile, Comment = all_NewMilkshake_wall_comment1_post1, DateTime = DateTime.Now.Add(new TimeSpan(-17, -3, -40)) };
            var all_NewMilkshake_wall_comment1_post1_like_sandbergs = new CommentLike { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789C07"), Author = Nestle_BasicProfile, Comment = all_NewMilkshake_wall_comment1_post1, DateTime = DateTime.Now.Add(new TimeSpan(-17, -35, -40)) };

            var all_NewMilkshake_wall_comment2_post1 = new Comment() { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789C09"), Author = Migros_BasicProfile, Text = "This is also my first comment on a post", Post = all_NewMilkshake_wall_post1, PublishDateTime = DateTime.Now.Add(new TimeSpan(-17, -12, -40)) };
            var all_NewMilkshake_wall_comment3_post1 = new Comment() { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789CA0"), Author = Nestle_BasicProfile, Text = "Same here!", Post = all_NewMilkshake_wall_post1, PublishDateTime = DateTime.Now.Add(new TimeSpan(-17, -3, -40)) };

            var all_NewMilkshake_wall_post2 = new Post() { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789CA1"), Author = Galliker_BasicProfile, Text = "This is my second post", Wall = all_NewMilkshake_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-16, -30, -40)) };
            var all_NewMilkshake_wall_comment1_post2 = new Comment() { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789CA2"), Author = SwissGovernment_BasicProfile, Text = "ok, we get it", Post = all_NewMilkshake_wall_post2, PublishDateTime = DateTime.Now.Add(new TimeSpan(-16, -12, -40)) };
            var all_NewMilkshake_wall_comment2_post2 = new Comment() { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789CA3"), Author = SwissPost_BasicProfile, Text = "overly attached user!", Post = all_NewMilkshake_wall_post2, PublishDateTime = DateTime.Now.Add(new TimeSpan(-15, -32, -40)) };

            var all_NewMilkshake_wall_post3 = new Post() { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789CA4"), Author = Nestle_BasicProfile, Text = "This is my third post", Wall = all_NewMilkshake_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-15, -5, -40)) };
            var all_NewMilkshake_wall_comment1_post3 = new Comment() { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789CA5"), Author = SwissPost_BasicProfile, Text = "we get it, is working", Post = all_NewMilkshake_wall_post3, PublishDateTime = DateTime.Now.Add(new TimeSpan(-12, -21, -40)) };

            var all_NewMilkshake_wall_post4 = new Post() { Key = new Guid("DDDEEEFF-DDDD-4386-98AA-123456789CA6"), Author = Nestle_BasicProfile, Text = "ok, I think I like to post!", Wall = all_NewMilkshake_wall, PublishDateTime = DateTime.Now.Add(new TimeSpan(-10, -32, -40)) };

            context.Posts.Add(all_NewMilkshake_wall_post1);
            context.Posts.Add(all_NewMilkshake_wall_post2);
            context.Posts.Add(all_NewMilkshake_wall_post3);
            context.Posts.Add(all_NewMilkshake_wall_post4);

            context.Comments.Add(all_NewMilkshake_wall_comment1_post1);
            context.Comments.Add(all_NewMilkshake_wall_comment2_post1);
            context.Comments.Add(all_NewMilkshake_wall_comment3_post1);

            context.Comments.Add(all_NewMilkshake_wall_comment1_post2);
            context.Comments.Add(all_NewMilkshake_wall_comment2_post2);

            context.Comments.Add(all_NewMilkshake_wall_comment1_post3);


            context.PostLikes.Add(all_NewMilkshake_wall_post1_like_ellisonl);
            context.PostLikes.Add(all_NewMilkshake_wall_post1_like_gatesb);
            context.CommentLikes.Add(all_NewMilkshake_wall_comment1_post1_like_mayerm);
            context.CommentLikes.Add(all_NewMilkshake_wall_comment1_post1_like_sandbergs);




     


            context.ContentStreams.Add(gatesb_wall);
            context.ContentStreams.Add(Nestle_wall);
            context.ContentStreams.Add(SwitzerlandIndustrialImportsGroup_wall);
            context.ContentStreams.Add(all_NewMilkshake_wall);



        }

    }
}
