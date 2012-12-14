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
using FHNWPrototype.Domain._Base.SCMRelationships;

namespace FHNWPrototype.Infrastructure.Repositories.EF
{
    //DropCreateDatabaseIfModelChanges<FHNWPrototypeDB>
    //CreateDatabaseIfNotExists<FHNWPrototypeDB>
    public class DBContextInitializer : CreateDatabaseIfNotExists<FHNWPrototypeDB>
    {

        protected override void Seed(FHNWPrototypeDB  context)
        {

            byte[] header_picture_41 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._41);
            byte[] avatar_picture_41 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_42 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._42);
            byte[] avatar_picture_42 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_43 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._43);
            byte[] avatar_picture_43 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_44 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._44);
            byte[] avatar_picture_44 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_45 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._45);
            byte[] avatar_picture_45 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_46 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._46);
            byte[] avatar_picture_46 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_47 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._47);
            byte[] avatar_picture_47 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_48 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._48);
            byte[] avatar_picture_48 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_49 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._49);
            byte[] avatar_picture_49 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_50 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._50);
            byte[] avatar_picture_50 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_51 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._51);
            byte[] avatar_picture_51 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_52 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._52);
            byte[] avatar_picture_52 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_53 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._53);
            byte[] avatar_picture_53 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_54 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._54);
            byte[] avatar_picture_54 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_55 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._55);
            byte[] avatar_picture_55 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_56 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._56);
            byte[] avatar_picture_56 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_57 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._57);
            byte[] avatar_picture_57 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_58 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._58);
            byte[] avatar_picture_58 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_59 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._59);
            byte[] avatar_picture_59 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_60 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._60);
            byte[] avatar_picture_60 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_61 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._61);
            byte[] avatar_picture_61 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_62 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._62);
            byte[] avatar_picture_62 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_63 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._63);
            byte[] avatar_picture_63 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_64 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._64);
            byte[] avatar_picture_64 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_65 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._65);
            byte[] avatar_picture_65 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_66 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._66);
            byte[] avatar_picture_66 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_67 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._67);
            byte[] avatar_picture_67 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_68 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._68);
            byte[] avatar_picture_68 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_69 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._69);
            byte[] avatar_picture_69 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_70 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._70);
            byte[] avatar_picture_70 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_71 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._71);
            byte[] avatar_picture_71 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_72 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._72);
            byte[] avatar_picture_72 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_73 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._73);
            byte[] avatar_picture_73 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_74 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._74);
            byte[] avatar_picture_74 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

           
          



            //Olten
            GeoLocation location_organization41 = new GeoLocation { Latitude = 47.339870, Longitude = 7.901985 };
            //Basel
            GeoLocation location_organization42 = new GeoLocation { Latitude = 47.548807, Longitude = 7.587820 };
            //Berne
            GeoLocation location_organization43 = new GeoLocation { Latitude = 46.948432, Longitude = 7.440461 };
            //Lausanne
            GeoLocation location_organization44 = new GeoLocation { Latitude = 46.519595, Longitude = 6.632335 };
            //Zurich
            GeoLocation location_organization45 = new GeoLocation { Latitude = 47.377060, Longitude = 8.539550 };
            //Geneva
            GeoLocation location_organization46 = new GeoLocation { Latitude = 46.208358, Longitude = 6.142701 };
            //Niederbipp
            GeoLocation location_organization47 = new GeoLocation { Latitude = 47.271270, Longitude = 7.691270 };
            //Oensingen
            GeoLocation location_organization48 = new GeoLocation { Latitude = 47.290369, Longitude = 7.717394 };
            //Solothurn
            GeoLocation location_organization49 = new GeoLocation { Latitude = 47.210542, Longitude = 7.536927 };
            //Oftringen
            GeoLocation location_organization50 = new GeoLocation { Latitude = 47.316540, Longitude = 7.920925 };
            //Lucerne
            GeoLocation location_organization51 = new GeoLocation { Latitude = 47.049545, Longitude = 8.304375 };
            //Olten
            GeoLocation location_organization52 = new GeoLocation { Latitude = 47.339870, Longitude = 7.901985 };
            //Basel
            GeoLocation location_organization53 = new GeoLocation { Latitude = 47.548807, Longitude = 7.587820 };
            //Berne
            GeoLocation location_organization54 = new GeoLocation { Latitude = 46.948432, Longitude = 7.440461 };
            //Lausanne
            GeoLocation location_organization55 = new GeoLocation { Latitude = 46.519595, Longitude = 6.632335 };
            //Zurich
            GeoLocation location_organization56 = new GeoLocation { Latitude = 47.377060, Longitude = 8.539550 };
            //Geneva
            GeoLocation location_organization57 = new GeoLocation { Latitude = 46.208358, Longitude = 6.142701 };
            //Niederbipp
            GeoLocation location_organization58 = new GeoLocation { Latitude = 47.271270, Longitude = 7.691270 };
            //Oensingen
            GeoLocation location_organization59 = new GeoLocation { Latitude = 47.290369, Longitude = 7.717394 };
            //Solothurn
            GeoLocation location_organization60 = new GeoLocation { Latitude = 47.210542, Longitude = 7.536927 };
            //Oftringen
            GeoLocation location_organization61 = new GeoLocation { Latitude = 47.316540, Longitude = 7.920925 };
            //Lucerne
            GeoLocation location_organization62 = new GeoLocation { Latitude = 47.049545, Longitude = 8.304375 };
            //Oftringen
            GeoLocation location_organization63 = new GeoLocation { Latitude = 47.316540, Longitude = 7.920925 };
            //Lucerne
            GeoLocation location_organization64 = new GeoLocation { Latitude = 47.049545, Longitude = 8.304375 };
            //Olten
            GeoLocation location_organization65 = new GeoLocation { Latitude = 47.339870, Longitude = 7.901985 };
            //Basel
            GeoLocation location_organization66 = new GeoLocation { Latitude = 47.548807, Longitude = 7.587820 };
            //Berne
            GeoLocation location_organization67 = new GeoLocation { Latitude = 46.948432, Longitude = 7.440461 };
            //Lausanne
            GeoLocation location_organization68 = new GeoLocation { Latitude = 46.519595, Longitude = 6.632335 };
            //Zurich
            GeoLocation location_organization69 = new GeoLocation { Latitude = 47.377060, Longitude = 8.539550 };
            //Geneva
            GeoLocation location_organization70 = new GeoLocation { Latitude = 46.208358, Longitude = 6.142701 };
            //Niederbipp
            GeoLocation location_organization71 = new GeoLocation { Latitude = 47.271270, Longitude = 7.691270 };
            //Oensingen
            GeoLocation location_organization72 = new GeoLocation { Latitude = 47.290369, Longitude = 7.717394 };
            //Solothurn
            GeoLocation location_organization73 = new GeoLocation { Latitude = 47.210542, Longitude = 7.536927 };
            //Oftringen
            GeoLocation location_organization74 = new GeoLocation { Latitude = 47.316540, Longitude = 7.920925 };
           

            context.Geolocations.Add(location_organization41);
            context.Geolocations.Add(location_organization42);
            context.Geolocations.Add(location_organization44);
            context.Geolocations.Add(location_organization43);
            context.Geolocations.Add(location_organization45);
            context.Geolocations.Add(location_organization46);
            context.Geolocations.Add(location_organization47);
            context.Geolocations.Add(location_organization48);
            context.Geolocations.Add(location_organization49);
            context.Geolocations.Add(location_organization50);
            context.Geolocations.Add(location_organization51);

            context.Geolocations.Add(location_organization52);
            context.Geolocations.Add(location_organization53);
            context.Geolocations.Add(location_organization54);
            context.Geolocations.Add(location_organization55);
            context.Geolocations.Add(location_organization56);
            context.Geolocations.Add(location_organization57);
            context.Geolocations.Add(location_organization58);
            context.Geolocations.Add(location_organization59);
            context.Geolocations.Add(location_organization60);
            context.Geolocations.Add(location_organization61);
            context.Geolocations.Add(location_organization62);

            context.Geolocations.Add(location_organization63);
            context.Geolocations.Add(location_organization64);
            context.Geolocations.Add(location_organization65);
            context.Geolocations.Add(location_organization66);
            context.Geolocations.Add(location_organization67);
            context.Geolocations.Add(location_organization68);
            context.Geolocations.Add(location_organization69);
            context.Geolocations.Add(location_organization70);
            context.Geolocations.Add(location_organization71);
            context.Geolocations.Add(location_organization72);
            context.Geolocations.Add(location_organization73);

            context.Geolocations.Add(location_organization74);
            
            var organization41 = new Organization { Key= new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E100"), Name= "Organization 41", Description= "Organization 41", EmailSuffix= "org41.com",  HeaderPicture= header_picture_41, HeadquatersLocation=location_organization41 };
            var organization42 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E101"), Name = "Organization 42", Description = "Organization 42", EmailSuffix = "org42.com", HeaderPicture = header_picture_42, HeadquatersLocation = location_organization42 };
            var organization43 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E102"), Name = "Organization 43", Description = "Organization 43", EmailSuffix = "org43.com", HeaderPicture = header_picture_43, HeadquatersLocation = location_organization44 };
            var organization44 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E103"), Name = "Organization 44", Description = "Organization 44", EmailSuffix = "org44.com", HeaderPicture = header_picture_44, HeadquatersLocation = location_organization43 };
            var organization45 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E104"), Name = "Organization 45", Description = "Organization 45", EmailSuffix = "org45.com", HeaderPicture = header_picture_45, HeadquatersLocation = location_organization45 };
            var organization46 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E105"), Name = "Organization 46", Description = "Organization 46", EmailSuffix = "org46.com", HeaderPicture = header_picture_46, HeadquatersLocation = location_organization46 };
            var organization47 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E106"), Name = "Organization 47", Description = "Organization 47", EmailSuffix = "org47.com", HeaderPicture = header_picture_47, HeadquatersLocation = location_organization47 };
            var organization48 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E107"), Name = "Organization 48", Description = "Organization 48", EmailSuffix = "org48.com", HeaderPicture = header_picture_48, HeadquatersLocation = location_organization48 };
            var organization49 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E108"), Name = "Organization 49", Description = "Organization 49", EmailSuffix = "org49.com", HeaderPicture = header_picture_49, HeadquatersLocation = location_organization49 };
            var organization50 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E109"), Name = "Organization 50", Description = "Organization 50", EmailSuffix = "org50.com", HeaderPicture = header_picture_50, HeadquatersLocation = location_organization50 };
            var organization51 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E20A"), Name = "Organization 51", Description = "Organization 51", EmailSuffix = "org51.com", HeaderPicture = header_picture_51, HeadquatersLocation = location_organization51 };

            var organization52 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E10B"), Name = "Organization 52", Description = "Organization 52", EmailSuffix = "org52.com", HeaderPicture = header_picture_52, HeadquatersLocation = location_organization52 };
            var organization53 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E10C"), Name = "Organization 53", Description = "Organization 53", EmailSuffix = "org53.com", HeaderPicture = header_picture_53, HeadquatersLocation = location_organization53 };
            var organization54 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E10D"), Name = "Organization 54", Description = "Organization 54", EmailSuffix = "org54.com", HeaderPicture = header_picture_54, HeadquatersLocation = location_organization54 };
            var organization55 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E10E"), Name = "Organization 55", Description = "Organization 55", EmailSuffix = "org55.com", HeaderPicture = header_picture_55, HeadquatersLocation = location_organization55 };
            var organization56 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E10F"), Name = "Organization 56", Description = "Organization 56", EmailSuffix = "org56.com", HeaderPicture = header_picture_56, HeadquatersLocation = location_organization56 };
            var organization57 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E110"), Name = "Organization 57", Description = "Organization 57", EmailSuffix = "org57.com", HeaderPicture = header_picture_57, HeadquatersLocation = location_organization57 };
            var organization58 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E111"), Name = "Organization 58", Description = "Organization 58", EmailSuffix = "org58.com", HeaderPicture = header_picture_58, HeadquatersLocation = location_organization58 };
            var organization59 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E112"), Name = "Organization 59", Description = "Organization 59", EmailSuffix = "org59.com", HeaderPicture = header_picture_59, HeadquatersLocation = location_organization59 };
            var organization60 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E113"), Name = "Organization 60", Description = "Organization 60", EmailSuffix = "org60.com", HeaderPicture = header_picture_60, HeadquatersLocation = location_organization60 };
            var organization61 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E114"), Name = "Organization 61", Description = "Organization 61", EmailSuffix = "org61.com", HeaderPicture = header_picture_61, HeadquatersLocation = location_organization61 };
            var organization62 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E215"), Name = "Organization 62", Description = "Organization 62", EmailSuffix = "org62.com", HeaderPicture = header_picture_62, HeadquatersLocation = location_organization62 };

            var organization63 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E116"), Name = "Organization 63", Description = "Organization 63", EmailSuffix = "org63.com", HeaderPicture = header_picture_63, HeadquatersLocation = location_organization63 };
            var organization64 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E117"), Name = "Organization 64", Description = "Organization 64", EmailSuffix = "org64.com", HeaderPicture = header_picture_64, HeadquatersLocation = location_organization64 };
            var organization65 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E118"), Name = "Organization 65", Description = "Organization 65", EmailSuffix = "org65.com", HeaderPicture = header_picture_65, HeadquatersLocation = location_organization65 };
            var organization66 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E119"), Name = "Organization 66", Description = "Organization 66", EmailSuffix = "org66.com", HeaderPicture = header_picture_66, HeadquatersLocation = location_organization66 };
            var organization67 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E11A"), Name = "Organization 67", Description = "Organization 67", EmailSuffix = "org67.com", HeaderPicture = header_picture_67, HeadquatersLocation = location_organization67 };
            var organization68 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E11B"), Name = "Organization 68", Description = "Organization 68", EmailSuffix = "org68.com", HeaderPicture = header_picture_68, HeadquatersLocation = location_organization68 };
            var organization69 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E11C"), Name = "Organization 69", Description = "Organization 69", EmailSuffix = "org69.com", HeaderPicture = header_picture_69, HeadquatersLocation = location_organization69 };
            var organization70 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E11D"), Name = "Organization 70", Description = "Organization 70", EmailSuffix = "org70.com", HeaderPicture = header_picture_70, HeadquatersLocation = location_organization70 };
            var organization71 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E11E"), Name = "Organization 71", Description = "Organization 71", EmailSuffix = "org71.com", HeaderPicture = header_picture_71, HeadquatersLocation = location_organization71 };
            var organization72 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E11F"), Name = "Organization 72", Description = "Organization 72", EmailSuffix = "org72.com", HeaderPicture = header_picture_72, HeadquatersLocation = location_organization72 };
            var organization73 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E220"), Name = "Organization 73", Description = "Organization 73", EmailSuffix = "org73.com", HeaderPicture = header_picture_73, HeadquatersLocation = location_organization73 };

            var organization74 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E221"), Name = "Organization 74", Description = "Organization 74", EmailSuffix = "org74.com", HeaderPicture = header_picture_74, HeadquatersLocation = location_organization74 };


            context.Organizations.Add(organization41);
            context.Organizations.Add(organization42);
            context.Organizations.Add(organization43);
            context.Organizations.Add(organization44);
            context.Organizations.Add(organization45);
            context.Organizations.Add(organization46);
            context.Organizations.Add(organization47);
            context.Organizations.Add(organization48);
            context.Organizations.Add(organization49);
            context.Organizations.Add(organization50);
            context.Organizations.Add(organization51);

            context.Organizations.Add(organization52);
            context.Organizations.Add(organization53);
            context.Organizations.Add(organization54);
            context.Organizations.Add(organization55);
            context.Organizations.Add(organization56);
            context.Organizations.Add(organization57);
            context.Organizations.Add(organization58);
            context.Organizations.Add(organization59);
            context.Organizations.Add(organization60);
            context.Organizations.Add(organization61);
            context.Organizations.Add(organization62);

            context.Organizations.Add(organization63);
            context.Organizations.Add(organization64);
            context.Organizations.Add(organization65);
            context.Organizations.Add(organization66);
            context.Organizations.Add(organization67);
            context.Organizations.Add(organization68);
            context.Organizations.Add(organization69);
            context.Organizations.Add(organization70);
            context.Organizations.Add(organization71);
            context.Organizations.Add(organization72);
            context.Organizations.Add(organization73);
            context.Organizations.Add(organization74);

            var organizationAccount41 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E100"), Name = "Car Manufacturer Co.", Description = "We manufacture cars", Organization=organization41, EmailSuffix = "org41.com", Email="admin@org41.com", AvatarPicture = avatar_picture_41, Location = location_organization41 };
            var organizationAccount42 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E101"), Name = "Piston Manufacturer Co.", Description = "We manufacture pistons for cars", Organization = organization42, EmailSuffix = "org42.com", Email = "admin@org42.com", AvatarPicture = avatar_picture_42, Location = location_organization42 };
            var organizationAccount43 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E102"), Name = "Steel Manufacturer 1 Co.", Description = "We provide steel", Organization = organization43, EmailSuffix = "org43.com", Email = "admin@org43.com", AvatarPicture = avatar_picture_43, Location = location_organization44 };
            var organizationAccount44 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E103"), Name = "Electronics Manufacturer 1 Co.", Description = "We manufacture electronic devices", Organization = organization44, EmailSuffix = "org44.com", Email = "admin@org44.com", AvatarPicture = avatar_picture_44, Location = location_organization43 };
            var organizationAccount45 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E104"), Name = "Air Conditioner Co.", Description = "We manufacture air conditioners for cars", Organization = organization45, EmailSuffix = "org45.com", Email = "admin@org45.com", AvatarPicture = avatar_picture_45, Location = location_organization45 };
            var organizationAccount46 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E105"), Name = "Electronics Manufacturer 2 Co.", Description = "We manufacture electronic devices", Organization = organization46, EmailSuffix = "org46.com", Email = "admin@org46.com", AvatarPicture = avatar_picture_46, Location = location_organization46 };
            var organizationAccount47 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E106"), Name = "Electric System Provider 1 Co.", Description = "We provide components for electric circuits", Organization = organization47, EmailSuffix = "org47.com", Email = "admin@org47.com", AvatarPicture = avatar_picture_47, Location = location_organization47 };
            var organizationAccount48 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E107"), Name = "Electric System Provider 2 Co.", Description = "We provide components for electric circuits", Organization = organization48, EmailSuffix = "org48.com", Email = "admin@org48.com", AvatarPicture = avatar_picture_48, Location = location_organization48 };
            var organizationAccount49 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E108"), Name = "Fabrics Provider 1 Co.", Description = "We provide many types of industrial fabrics", Organization = organization49, EmailSuffix = "org49.com", Email = "admin@org49.com", AvatarPicture = avatar_picture_49, Location = location_organization49 };
            var organizationAccount50 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E109"), Name = "Steel Manufacturer 2 Co.", Description = "We provide steel", Organization = organization50, EmailSuffix = "org50.com", Email = "admin@org50.com", AvatarPicture = avatar_picture_50, Location = location_organization50 };
            var organizationAccount51 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E10A"), Name = "Steel Manufacturer 3 Co.", Description = "We provide steel", Organization = organization51, EmailSuffix = "org51.com", Email = "admin@org51.com", AvatarPicture = avatar_picture_51, Location = location_organization51 };
            var organizationAccount52 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E10B"), Name = "Electric System Provider 3 Co.", Description = "We provide components for electric circuits", Organization = organization52, EmailSuffix = "org52.com", Email = "admin@org52.com", AvatarPicture = avatar_picture_52, Location = location_organization52 };
            var organizationAccount53 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E10C"), Name = "Suspension Provider 1 Co.", Description = "We manufacture suspensions for cars", Organization = organization53, EmailSuffix = "org53.com", Email = "admin@org53.com", AvatarPicture = avatar_picture_53, Location = location_organization53 };
            var organizationAccount54 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E10D"), Name = "Steel Manufacturer 4 Co.", Description = "We provide steel", Organization = organization54, EmailSuffix = "org54.com", Email = "admin@org54.com", AvatarPicture = avatar_picture_54, Location = location_organization54 };
            var organizationAccount55 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E10E"), Name = "Wheels Provider 1 Co.", Description = "We provide wheels for cars", Organization = organization55, EmailSuffix = "org55.com", Email = "admin@org55.com", AvatarPicture = avatar_picture_55, Location = location_organization55 };
            var organizationAccount56 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E10F"), Name = "Tires Provider 1 Co.", Description = "We manufacture tires for cars", Organization = organization56, EmailSuffix = "org56.com", Email = "admin@org56.com", AvatarPicture = avatar_picture_56, Location = location_organization56 };
            var organizationAccount57 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E110"), Name = "Fabrics Provider 2 Co.", Description = "We provide many types of industrial fabrics", Organization = organization57, EmailSuffix = "org57.com", Email = "admin@org57.com", AvatarPicture = avatar_picture_57, Location = location_organization57 };
            var organizationAccount58 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E111"), Name = "Brakes Provider 1 Co.", Description = "We manufacture breakes for cars", Organization = organization58, EmailSuffix = "org58.com", Email = "admin@org58.com", AvatarPicture = avatar_picture_58, Location = location_organization58 };
            var organizationAccount59 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E112"), Name = "Fabrics Provider 3 Co.", Description = "We provide many types of industrial fabrics", Organization = organization59, EmailSuffix = "org59.com", Email = "admin@org59.com", AvatarPicture = avatar_picture_59, Location = location_organization59 };
            var organizationAccount60 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E113"), Name = "Steel Manufacturer 5 Co.", Description = "We provide steel", Organization = organization60, EmailSuffix = "org60.com", Email = "admin@org60.com", AvatarPicture = avatar_picture_60, Location = location_organization60 };
            var organizationAccount61 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E114"), Name = "Regional Distributor USA", Description = "We distribute cars nationally", Organization = organization61, EmailSuffix = "org61.com", Email = "admin@org61.com", AvatarPicture = avatar_picture_61, Location = location_organization61 };
            var organizationAccount62 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E115"), Name = "Local Dealership USA", Description = "We sell cars to the final customer", Organization = organization62, EmailSuffix = "org62.com", Email = "admin@org62.com", AvatarPicture = avatar_picture_62, Location = location_organization62 };
            var organizationAccount63 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E116"), Name = "Spare Parts Distributor USA", Description = "We resell car spare parts", Organization = organization63, EmailSuffix = "org63.com", Email = "admin@org63.com", AvatarPicture = avatar_picture_63, Location = location_organization63 };
            var organizationAccount64 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E117"), Name = "Regional Distributor UK", Description = "We distribute cars nationally", Organization = organization64, EmailSuffix = "org64.com", Email = "admin@org64.com", AvatarPicture = avatar_picture_64, Location = location_organization64 };
            var organizationAccount65 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E118"), Name = "Local Dealership UK", Description = "We sell cars to the final customer", Organization = organization65, EmailSuffix = "org65.com", Email = "admin@org65.com", AvatarPicture = avatar_picture_65, Location = location_organization65 };
            var organizationAccount66 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E119"), Name = "Spare Parts Distributor UK", Description = "We resell car spare parts", Organization = organization66, EmailSuffix = "org66.com", Email = "admin@org66.com", AvatarPicture = avatar_picture_66, Location = location_organization66 };
            var organizationAccount67 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E11A"), Name = "Regional Distributor Germany", Description = "We distribute cars nationally", Organization = organization67, EmailSuffix = "org67.com", Email = "admin@org67.com", AvatarPicture = avatar_picture_67, Location = location_organization67 };
            var organizationAccount68 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E11B"), Name = "Local Dealership Germany", Description = "We sell cars to the final customer", Organization = organization68, EmailSuffix = "org68.com", Email = "admin@org68.com", AvatarPicture = avatar_picture_68, Location = location_organization68 };
            var organizationAccount69 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E11C"), Name = "Spare Parts Distributor Germany", Description = "We resell car spare parts", Organization = organization69, EmailSuffix = "org69.com", Email = "admin@org69.com", AvatarPicture = avatar_picture_69, Location = location_organization69 };
            var organizationAccount70 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E11D"), Name = "Regional Distributor Switzerland", Description = "We distribute cars nationally", Organization = organization70, EmailSuffix = "org70.com", Email = "admin@org70.com", AvatarPicture = avatar_picture_70, Location = location_organization70 };
            var organizationAccount71 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E11E"), Name = "Local Dealership Switzerland", Description = "We sell cars to the final customer", Organization = organization71, EmailSuffix = "org71.com", Email = "admin@org71.com", AvatarPicture = avatar_picture_71, Location = location_organization71 };
            var organizationAccount72 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E11F"), Name = "Regional Distributor Norway", Description = "We distribute cars nationally", Organization = organization72, EmailSuffix = "org72.com", Email = "admin@org72.com", AvatarPicture = avatar_picture_72, Location = location_organization72 };
            var organizationAccount73 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E120"), Name = "Local Dealership Norway", Description = "We sell cars to the final customer", Organization = organization73, EmailSuffix = "org73.com", Email = "admin@org73.com", AvatarPicture = avatar_picture_73, Location = location_organization73 };
            var organizationAccount74 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E121"), Name = "Spare Parts Distributor Switzerland", Description = "", Organization = organization74, EmailSuffix = "org74.com", Email = "admin@org74.com", AvatarPicture = avatar_picture_74, Location = location_organization74 };



            context.OrganizationAccounts.Add(organizationAccount41);
            context.OrganizationAccounts.Add(organizationAccount42);
            context.OrganizationAccounts.Add(organizationAccount43);
            context.OrganizationAccounts.Add(organizationAccount44);
            context.OrganizationAccounts.Add(organizationAccount45);
            context.OrganizationAccounts.Add(organizationAccount46);
            context.OrganizationAccounts.Add(organizationAccount47);
            context.OrganizationAccounts.Add(organizationAccount48);
            context.OrganizationAccounts.Add(organizationAccount49);
            context.OrganizationAccounts.Add(organizationAccount50);
            context.OrganizationAccounts.Add(organizationAccount51);

            context.OrganizationAccounts.Add(organizationAccount52);
            context.OrganizationAccounts.Add(organizationAccount53);
            context.OrganizationAccounts.Add(organizationAccount54);
            context.OrganizationAccounts.Add(organizationAccount55);
            context.OrganizationAccounts.Add(organizationAccount56);
            context.OrganizationAccounts.Add(organizationAccount57);
            context.OrganizationAccounts.Add(organizationAccount58);
            context.OrganizationAccounts.Add(organizationAccount59);
            context.OrganizationAccounts.Add(organizationAccount60);
            context.OrganizationAccounts.Add(organizationAccount61);
            context.OrganizationAccounts.Add(organizationAccount62);

            context.OrganizationAccounts.Add(organizationAccount63);
            context.OrganizationAccounts.Add(organizationAccount64);
            context.OrganizationAccounts.Add(organizationAccount65);
            context.OrganizationAccounts.Add(organizationAccount66);
            context.OrganizationAccounts.Add(organizationAccount67);
            context.OrganizationAccounts.Add(organizationAccount68);
            context.OrganizationAccounts.Add(organizationAccount69);
            context.OrganizationAccounts.Add(organizationAccount70);
            context.OrganizationAccounts.Add(organizationAccount71);
            context.OrganizationAccounts.Add(organizationAccount72);
            context.OrganizationAccounts.Add(organizationAccount73);
            context.OrganizationAccounts.Add(organizationAccount74);

            var organization41_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount41.Key, ReferenceType= AccountType.OrganizationAccount};
            var organization42_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount42.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization43_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount43.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization44_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount44.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization45_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount45.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization46_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount46.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization47_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount47.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization48_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount48.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization49_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount49.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization50_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount50.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization51_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount51.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization52_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount52.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization53_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount53.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization54_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount54.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization55_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount55.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization56_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount56.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization57_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount57.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization58_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount58.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization59_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount59.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization60_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount60.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization61_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount61.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization62_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount62.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization63_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount63.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization64_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount64.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization65_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount65.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization66_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount66.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization67_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount67.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization68_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount68.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization69_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount69.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization70_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount70.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization71_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount71.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization72_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount72.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization73_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount73.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization74_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount74.Key, ReferenceType = AccountType.OrganizationAccount };

            context.BasicProfiles.Add(organization41_BasicProfile);
            context.BasicProfiles.Add(organization42_BasicProfile);
            context.BasicProfiles.Add(organization43_BasicProfile);
            context.BasicProfiles.Add(organization44_BasicProfile);
            context.BasicProfiles.Add(organization45_BasicProfile);
            context.BasicProfiles.Add(organization46_BasicProfile);
            context.BasicProfiles.Add(organization47_BasicProfile);
            context.BasicProfiles.Add(organization48_BasicProfile);
            context.BasicProfiles.Add(organization49_BasicProfile);
            context.BasicProfiles.Add(organization50_BasicProfile);
            context.BasicProfiles.Add(organization51_BasicProfile);
            context.BasicProfiles.Add(organization52_BasicProfile);
            context.BasicProfiles.Add(organization53_BasicProfile);
            context.BasicProfiles.Add(organization54_BasicProfile);
            context.BasicProfiles.Add(organization55_BasicProfile);
            context.BasicProfiles.Add(organization56_BasicProfile);
            context.BasicProfiles.Add(organization57_BasicProfile);
            context.BasicProfiles.Add(organization58_BasicProfile);
            context.BasicProfiles.Add(organization59_BasicProfile);
            context.BasicProfiles.Add(organization60_BasicProfile);
            context.BasicProfiles.Add(organization61_BasicProfile);
            context.BasicProfiles.Add(organization62_BasicProfile);
            context.BasicProfiles.Add(organization63_BasicProfile);
            context.BasicProfiles.Add(organization64_BasicProfile);
            context.BasicProfiles.Add(organization65_BasicProfile);
            context.BasicProfiles.Add(organization66_BasicProfile);
            context.BasicProfiles.Add(organization67_BasicProfile);
            context.BasicProfiles.Add(organization68_BasicProfile);
            context.BasicProfiles.Add(organization69_BasicProfile);
            context.BasicProfiles.Add(organization70_BasicProfile);
            context.BasicProfiles.Add(organization71_BasicProfile);
            context.BasicProfiles.Add(organization72_BasicProfile);
            context.BasicProfiles.Add(organization73_BasicProfile);
            context.BasicProfiles.Add(organization74_BasicProfile);

            byte[] avatar_picture_user1 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.bill_gates);
            byte[] avatar_picture_user2 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.sergey_brin);
            byte[] avatar_picture_user3 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user4 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user5 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.larry_page);
            byte[] avatar_picture_user6 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.larry_ellison);
            byte[] avatar_picture_user7 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user8 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.ray_ozzie);
            byte[] avatar_picture_user9 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.scott_guthrie);
            byte[] avatar_picture_user10 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.linus_torvalds);
            byte[] avatar_picture_user11 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user12 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user13 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.marissa_mayer);
            byte[] avatar_picture_user14 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user15 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.eric_schmidt);
            byte[] avatar_picture_user16 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user17 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.steve_jobs);
            byte[] avatar_picture_user18 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.steve_ballmer);
            byte[] avatar_picture_user19 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user20 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user21 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.steve_wozniak);
            byte[] avatar_picture_user22 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.paul_allen);
            byte[] avatar_picture_user23 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.reid_hoffman);
            byte[] avatar_picture_user24 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.virginia_rometty);
            byte[] avatar_picture_user25 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user26 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user27 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user28 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user29 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user30 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user31 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user32 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user33 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.scott_hanselman);
            byte[] avatar_picture_user34 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user35 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user36 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user37 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user38 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user39 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user40 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.sheryl_sandberg);

             
            //Users
            var user1 = new User{  Key= new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A0"), FirstName= "Bill", LastName= "Gates", ProfilePicture=avatar_picture_user1 };
            var user2 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A1"), FirstName = "Sergey", LastName = "Brin", ProfilePicture=avatar_picture_user2  };
            var user3 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A2"), FirstName = "Allie", LastName = "Opper", ProfilePicture = avatar_picture_user3 };
            var user4 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A3"), FirstName = "Julio", LastName = "Spelman", ProfilePicture = avatar_picture_user4 };
            var user5 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A4"), FirstName = "Larry", LastName = "Page", ProfilePicture=avatar_picture_user5  };
            var user6 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A5"),   FirstName = "Larry", LastName = "Ellison", ProfilePicture=avatar_picture_user6  };
            var user7 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A6"), FirstName = "Edwina", LastName = "Heimbach", ProfilePicture = avatar_picture_user7 };
            var user8 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A7"), FirstName = "Ray", LastName = "Ozzie", ProfilePicture = avatar_picture_user8 };
            var user9 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A8"), FirstName = "Scott", LastName = "Guthrie", ProfilePicture = avatar_picture_user9 };
            var user10 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A9"), FirstName = "Linus", LastName = "Torvalds", ProfilePicture = avatar_picture_user10 };
            var user11 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2AA"), FirstName = "Kelly", LastName = "Glen", ProfilePicture = avatar_picture_user11 };
            var user12 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2AB"), FirstName = "Neil", LastName = "Iannuzzi", ProfilePicture = avatar_picture_user12 };
            var user13 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2AC"), FirstName = "Marissa", LastName = "Mayer", ProfilePicture= avatar_picture_user13  };
            var user14 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2AD"), FirstName = "Joe", LastName = "Sherwin", ProfilePicture = avatar_picture_user14 };
            var user15 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2AE"), FirstName = "Eric", LastName = "Schmidt", ProfilePicture= avatar_picture_user15  };
            var user16 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2AF"), FirstName = "Jessie", LastName = "Smail", ProfilePicture = avatar_picture_user16 };
            var user17 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B0"), FirstName = "Steve", LastName = "Jobs", ProfilePicture= avatar_picture_user17  };
            var user18 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B1"), FirstName = "Steve", LastName = "Ballmer", ProfilePicture= avatar_picture_user18  };
            var user19 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B2"), FirstName = "Max", LastName = "Sulser", ProfilePicture = avatar_picture_user19 };
            var user20 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B3"), FirstName = "Jerri", LastName = "Buffaloe", ProfilePicture = avatar_picture_user20 };
            var user21 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B4"), FirstName = "Steve", LastName = "Wozniak", ProfilePicture= avatar_picture_user21  };
            var user22 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B5"), FirstName = "Paul", LastName = "Allen", ProfilePicture=avatar_picture_user22  };
            var user23 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B6"), FirstName = "Reid", LastName = "Hoffman", ProfilePicture=avatar_picture_user23  };
            var user24 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B7"), FirstName = "Virginia", LastName = "Rometty", ProfilePicture=avatar_picture_user24  };
            var user25 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B8"), FirstName = "Marylou", LastName = "Tookes", ProfilePicture = avatar_picture_user25 };
            var user26 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B9"), FirstName = "Pearlie", LastName = "Chevere", ProfilePicture = avatar_picture_user26 };
            var user27 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2BA"), FirstName = "Fernando", LastName = "Sparr", ProfilePicture = avatar_picture_user27 };
            var user28 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2BB"), FirstName = "Jeanette", LastName = "Moynihan", ProfilePicture = avatar_picture_user28 };
            var user29 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2BC"), FirstName = "George", LastName = "Chrisman", ProfilePicture = avatar_picture_user29 };
            var user30 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2BD"), FirstName = "Clinton", LastName = "Coulston", ProfilePicture = avatar_picture_user30 };
            var user31 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2BE"), FirstName = "Darren", LastName = "Tinkham", ProfilePicture = avatar_picture_user31 };
            var user32 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2BF"), FirstName = "Vanessa", LastName = "Valenti", ProfilePicture = avatar_picture_user32 };
            var user33 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C0"), FirstName = "Scott", LastName = "Hanselman", ProfilePicture=avatar_picture_user33  };
            var user34 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C1"), FirstName = "Neil", LastName = "Rockhill", ProfilePicture = avatar_picture_user34 };
            var user35 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C2"), FirstName = "Jacob", LastName = "Braswell", ProfilePicture = avatar_picture_user35 };
            var user36 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C3"), FirstName = "Brandon", LastName = "Worsham", ProfilePicture = avatar_picture_user36 };
            var user37 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C4"), FirstName = "Joshua", LastName = "Luna", ProfilePicture = avatar_picture_user37 };
            var user38 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C5"), FirstName = "Jeffrey", LastName = "Swope", ProfilePicture = avatar_picture_user38 };
            var user39 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C6"), FirstName = "Martin", LastName = "Segal", ProfilePicture = avatar_picture_user39 };
            var user40 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C7"), FirstName = "Sheryl", LastName = "Sandberg", ProfilePicture = avatar_picture_user40 };
            

            //Accounts
        
            var user_account_1 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E201"), Tag="#EngineAssembler", Email = "user1@org41.com", User = user1, OrganizationAccount= organizationAccount41 }; //Logistics Department
            var user_account_2 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E202"), Tag = "#PistonsManufacturer", Email = "user2@org42.com", User = user2, OrganizationAccount = organizationAccount42 }; // Logistics Department
            var user_account_3 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E203"), Tag = "#SteelManufacturer", Email = "user3@org43.com", User = user3, OrganizationAccount = organizationAccount43 }; //Logistics
            var user_account_4 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E204"), Tag = "#ElectronicsManufacturer", Email = "user4@org44.com", User = user4, OrganizationAccount = organizationAccount44 }; //Logistics
            var user_account_5 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E105"), Tag = "#InteriorComponentsProcurement", Email = "user5@org41.com", User = user5, OrganizationAccount = organizationAccount42 };// Product Development
            var user_account_6 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E106"), Tag = "#AirConditionerManufacturer", Email = "user6@org45.com", User = user6, OrganizationAccount = organizationAccount41 }; //Branding
            var user_account_7 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E207"), Tag = "#ElectronicsManufacturer", Email = "user7@org46.com", User = user7, OrganizationAccount = organizationAccount46 }; //Logistics
            var user_account_8 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E008"), Tag = "#ElectricSystemProvider", Email = "user8@org47.com", User = user8, OrganizationAccount = organizationAccount51 }; //Logistics
            var user_account_9 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E209"), Tag = "#ElectricSystemProvider", Email = "user9@org48.com", User = user9, OrganizationAccount = organizationAccount49 }; //Logistics
            var user_account_10 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E20A"), Tag = "#SeatsAssembler", Email = "user10@org41.com", User = user10, OrganizationAccount = organizationAccount50 }; //Logistics
            var user_account_11 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E20B"), Tag = "#FabricsProvider", Email = "user11@org49.com", User = user11, OrganizationAccount = organizationAccount49 }; //Logistics
            var user_account_12 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E20C"), Tag = "#SteelManufacturer", Email = "user12@org50.com", User = user12, OrganizationAccount = organizationAccount50 }; //Logistics
            var user_account_13 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E10D"), Tag = "#ChassisAssembler", Email = "user13@org41.com", User = user13, OrganizationAccount = organizationAccount44 }; //Losgistics Department
            var user_account_14 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E20E"), Tag = "#SteelManufacturer", Email = "user14@org51.com", User = user14, OrganizationAccount = organizationAccount51 }; //Logistics
            var user_account_15 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E10F"), Tag = "#LightningSystemAssembler", Email = "user15@org41.com", User = user15, OrganizationAccount = organizationAccount44 }; //Warehousing
            var user_account_16 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E210"), Tag = "#EngineAssembler", Email = "user16@org52.com", User = user16, OrganizationAccount = organizationAccount52 }; //Logistics
            var user_account_17 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E111"), Tag = "#SteeringSystemAssembler", Email = "user17@org41.com", User = user17, OrganizationAccount = organizationAccount41 }; //Warehousing
            var user_account_18 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E112"), Tag = "#SuspensionProvider", Email = "user18@org53.com", User = user18, OrganizationAccount = organizationAccount53 }; //Procurement
            var user_account_19 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E213"), Tag = "#SteelManufacturer", Email = "user19@org54.com", User = user19, OrganizationAccount = organizationAccount54 }; //Logistics
            var user_account_20 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E214"), Tag = "#WheelsProvider", Email = "user20@org55.com", User = user20, OrganizationAccount = organizationAccount55 }; //Logistics
            var user_account_21 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E115"), Tag = "#TiresProvider", Email = "user21@org56.com", User = user21, OrganizationAccount = organizationAccount46 }; //Product Development
            var user_account_22 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E116"), Tag = "#FabricsProvider", Email = "user22@org57.com", User = user22, OrganizationAccount = organizationAccount45 };//Marketing
            var user_account_23 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E217"), Tag = "#Brakes", Email = "user23@org58.com", User = user23, OrganizationAccount = organizationAccount47 }; //in-site logistics
            var user_account_24 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E218"), Tag = "#FabricsProvider", Email = "user29@org59.com", User = user24, OrganizationAccount = organizationAccount43 }; //Marketing
            var user_account_25 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E219"), Tag = "#SteelManufacturer", Email = "user25@org60.com", User = user25, OrganizationAccount = organizationAccount60 }; //Logistics
            var user_account_26 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E21A"), Tag = "#SalesAndDistribution", Email = "user26@org41.com", User = user26, OrganizationAccount = organizationAccount41 }; //Logistics
            var user_account_27 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E21B"), Tag = "#RegionalSales", Email = "user27@org61.com", User = user27, OrganizationAccount = organizationAccount61 }; //Logistics
            var user_account_28 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E21C"), Tag = "#Retailer", Email = "user28@org62.com", User = user28, OrganizationAccount = organizationAccount62 }; //Logistics
            var user_account_29 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E21D"), Tag = "#AutoSparePartsReseller", Email = "user29@org63.com", User = user29, OrganizationAccount = organizationAccount63 }; //Logistics
            var user_account_30 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E21E"), Tag = "#RegionalSales", Email = "user30@org64.com", User = user30, OrganizationAccount = organizationAccount64 }; //Logistics
            var user_account_31 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E21F"), Tag = "#Retailer", Email = "user31@org65.com", User = user31, OrganizationAccount = organizationAccount65 }; //Logistics
            var user_account_32 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E220"), Tag = "#AutoSparePartsReseller", Email = "user32@org66.com", User = user32, OrganizationAccount = organizationAccount66 }; //Logistics
            var user_account_33 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E221"), Tag = "#RegionalSales", Email = "user33@org67.com", User = user33, OrganizationAccount = organizationAccount46 }; //Logistics
            var user_account_34 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E222"), Tag = "#Retailer", Email = "user34@org68.com", User = user34, OrganizationAccount = organizationAccount68 }; //Logistics
            var user_account_35 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E223"), Tag = "#AutoSparePartsReseller", Email = "user35@org69.com", User = user35, OrganizationAccount = organizationAccount69 }; //Logistics
            var user_account_36 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E224"), Tag = "#RegionalSales", Email = "user36@org70.com", User = user36, OrganizationAccount = organizationAccount70 }; //Logistics
            var user_account_37 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E225"), Tag = "#Retailer", Email = "user37@org71.com", User = user37, OrganizationAccount = organizationAccount71 }; //Logistics
            var user_account_38 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E226"), Tag = "#RegionalSales", Email = "user38@org73.com", User = user38, OrganizationAccount = organizationAccount73 }; //Logistics
            var user_account_39 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E227"), Tag = "#Retailer", Email = "user39@org72.com", User = user39, OrganizationAccount = organizationAccount72 }; //Logistics
            var user_account_40 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E228"), Tag = "#AutoSparePartsReseller", Email = "user40@org74.com", User = user40, OrganizationAccount = organizationAccount74 }; //Point of Sale
           

            var user_account_1_BasicProfile = new BasicProfile { ReferenceKey = user_account_1.Key, ReferenceType = AccountType.UserAccount };
            var user_account_2_BasicProfile = new BasicProfile { ReferenceKey = user_account_2.Key, ReferenceType = AccountType.UserAccount };
            var user_account_3_BasicProfile = new BasicProfile { ReferenceKey = user_account_3.Key, ReferenceType = AccountType.UserAccount };
            var user_account_4_BasicProfile = new BasicProfile { ReferenceKey = user_account_4.Key, ReferenceType = AccountType.UserAccount };
            var user_account_5_BasicProfile = new BasicProfile { ReferenceKey = user_account_5.Key, ReferenceType = AccountType.UserAccount };
            var user_account_6_BasicProfile = new BasicProfile { ReferenceKey = user_account_6.Key, ReferenceType = AccountType.UserAccount };
            var user_account_7_BasicProfile = new BasicProfile { ReferenceKey = user_account_7.Key, ReferenceType = AccountType.UserAccount };
            var user_account_8_BasicProfile = new BasicProfile { ReferenceKey = user_account_8.Key, ReferenceType = AccountType.UserAccount };
            var user_account_9_BasicProfile = new BasicProfile { ReferenceKey = user_account_9.Key, ReferenceType = AccountType.UserAccount };
            var user_account_10_BasicProfile = new BasicProfile { ReferenceKey = user_account_10.Key, ReferenceType = AccountType.UserAccount };
            var user_account_11_BasicProfile = new BasicProfile { ReferenceKey = user_account_11.Key, ReferenceType = AccountType.UserAccount };
            var user_account_12_BasicProfile = new BasicProfile { ReferenceKey = user_account_12.Key, ReferenceType = AccountType.UserAccount };
            var user_account_13_BasicProfile = new BasicProfile { ReferenceKey = user_account_13.Key, ReferenceType = AccountType.UserAccount };
            var user_account_14_BasicProfile = new BasicProfile { ReferenceKey = user_account_14.Key, ReferenceType = AccountType.UserAccount };
            var user_account_15_BasicProfile = new BasicProfile { ReferenceKey = user_account_15.Key, ReferenceType = AccountType.UserAccount };
            var user_account_16_BasicProfile = new BasicProfile { ReferenceKey = user_account_16.Key, ReferenceType = AccountType.UserAccount };
            var user_account_17_BasicProfile = new BasicProfile { ReferenceKey = user_account_17.Key, ReferenceType = AccountType.UserAccount };
            var user_account_18_BasicProfile = new BasicProfile { ReferenceKey = user_account_18.Key, ReferenceType = AccountType.UserAccount };
            var user_account_19_BasicProfile = new BasicProfile { ReferenceKey = user_account_19.Key, ReferenceType = AccountType.UserAccount };
            var user_account_20_BasicProfile = new BasicProfile { ReferenceKey = user_account_20.Key, ReferenceType = AccountType.UserAccount };
            var user_account_21_BasicProfile = new BasicProfile { ReferenceKey = user_account_21.Key, ReferenceType = AccountType.UserAccount };
            var user_account_22_BasicProfile = new BasicProfile { ReferenceKey = user_account_22.Key, ReferenceType = AccountType.UserAccount };
            var user_account_23_BasicProfile = new BasicProfile { ReferenceKey = user_account_23.Key, ReferenceType = AccountType.UserAccount };
            var user_account_24_BasicProfile = new BasicProfile { ReferenceKey = user_account_24.Key, ReferenceType = AccountType.UserAccount };
            var user_account_25_BasicProfile = new BasicProfile { ReferenceKey = user_account_25.Key, ReferenceType = AccountType.UserAccount };
            var user_account_26_BasicProfile = new BasicProfile { ReferenceKey = user_account_26.Key, ReferenceType = AccountType.UserAccount };
            var user_account_27_BasicProfile = new BasicProfile { ReferenceKey = user_account_27.Key, ReferenceType = AccountType.UserAccount };
            var user_account_28_BasicProfile = new BasicProfile { ReferenceKey = user_account_28.Key, ReferenceType = AccountType.UserAccount };
            var user_account_29_BasicProfile = new BasicProfile { ReferenceKey = user_account_29.Key, ReferenceType = AccountType.UserAccount };
            var user_account_30_BasicProfile = new BasicProfile { ReferenceKey = user_account_30.Key, ReferenceType = AccountType.UserAccount };
            var user_account_31_BasicProfile = new BasicProfile { ReferenceKey = user_account_31.Key, ReferenceType = AccountType.UserAccount };
            var user_account_32_BasicProfile = new BasicProfile { ReferenceKey = user_account_32.Key, ReferenceType = AccountType.UserAccount };
            var user_account_33_BasicProfile = new BasicProfile { ReferenceKey = user_account_33.Key, ReferenceType = AccountType.UserAccount };
            var user_account_34_BasicProfile = new BasicProfile { ReferenceKey = user_account_34.Key, ReferenceType = AccountType.UserAccount };
            var user_account_35_BasicProfile = new BasicProfile { ReferenceKey = user_account_35.Key, ReferenceType = AccountType.UserAccount };
            var user_account_36_BasicProfile = new BasicProfile { ReferenceKey = user_account_36.Key, ReferenceType = AccountType.UserAccount };
            var user_account_37_BasicProfile = new BasicProfile { ReferenceKey = user_account_37.Key, ReferenceType = AccountType.UserAccount };
            var user_account_38_BasicProfile = new BasicProfile { ReferenceKey = user_account_38.Key, ReferenceType = AccountType.UserAccount };
            var user_account_39_BasicProfile = new BasicProfile { ReferenceKey = user_account_39.Key, ReferenceType = AccountType.UserAccount };
            var user_account_40_BasicProfile = new BasicProfile { ReferenceKey = user_account_40.Key, ReferenceType = AccountType.UserAccount };
            

            context.BasicProfiles.Add(user_account_1_BasicProfile);
            context.BasicProfiles.Add(user_account_2_BasicProfile);
            context.BasicProfiles.Add(user_account_3_BasicProfile);
            context.BasicProfiles.Add(user_account_4_BasicProfile);
            context.BasicProfiles.Add(user_account_5_BasicProfile);
            context.BasicProfiles.Add(user_account_6_BasicProfile);
            context.BasicProfiles.Add(user_account_7_BasicProfile);
            context.BasicProfiles.Add(user_account_8_BasicProfile);
            context.BasicProfiles.Add(user_account_9_BasicProfile);
            context.BasicProfiles.Add(user_account_10_BasicProfile);
            context.BasicProfiles.Add(user_account_11_BasicProfile);
            context.BasicProfiles.Add(user_account_12_BasicProfile);
            context.BasicProfiles.Add(user_account_13_BasicProfile);
            context.BasicProfiles.Add(user_account_14_BasicProfile);
            context.BasicProfiles.Add(user_account_15_BasicProfile);
            context.BasicProfiles.Add(user_account_16_BasicProfile);
            context.BasicProfiles.Add(user_account_17_BasicProfile);
            context.BasicProfiles.Add(user_account_18_BasicProfile);
            context.BasicProfiles.Add(user_account_19_BasicProfile);
            context.BasicProfiles.Add(user_account_20_BasicProfile);
            context.BasicProfiles.Add(user_account_21_BasicProfile);
            context.BasicProfiles.Add(user_account_22_BasicProfile);
            context.BasicProfiles.Add(user_account_23_BasicProfile);
            context.BasicProfiles.Add(user_account_24_BasicProfile);
            context.BasicProfiles.Add(user_account_25_BasicProfile);
            context.BasicProfiles.Add(user_account_26_BasicProfile);
            context.BasicProfiles.Add(user_account_27_BasicProfile);
            context.BasicProfiles.Add(user_account_28_BasicProfile);
            context.BasicProfiles.Add(user_account_29_BasicProfile);
            context.BasicProfiles.Add(user_account_30_BasicProfile);
            context.BasicProfiles.Add(user_account_31_BasicProfile);
            context.BasicProfiles.Add(user_account_32_BasicProfile);
            context.BasicProfiles.Add(user_account_33_BasicProfile);
            context.BasicProfiles.Add(user_account_34_BasicProfile);
            context.BasicProfiles.Add(user_account_35_BasicProfile);
            context.BasicProfiles.Add(user_account_36_BasicProfile);
            context.BasicProfiles.Add(user_account_37_BasicProfile);
            context.BasicProfiles.Add(user_account_38_BasicProfile);
            context.BasicProfiles.Add(user_account_39_BasicProfile);
            context.BasicProfiles.Add(user_account_40_BasicProfile);
         
            var rel_user1_user2 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F0"), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_2, SCMRelationshipType = SCMRelationship.Upstream , IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user2_user3 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F1"), Action = FriendshipAction.Accept, Sender = user_account_2, Receiver = user_account_3, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user4 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F2"), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_4, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user5_user6 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F3"), Action = FriendshipAction.Accept, Sender = user_account_5, Receiver = user_account_6, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user6_user7 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F4"), Action = FriendshipAction.Accept, Sender = user_account_6, Receiver = user_account_7, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user6_user8 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F5"), Action = FriendshipAction.Accept, Sender = user_account_6, Receiver = user_account_8, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user5_user9 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F6"), Action = FriendshipAction.Accept, Sender = user_account_5, Receiver = user_account_9, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user10_user11 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F7"), Action = FriendshipAction.Accept, Sender = user_account_10, Receiver = user_account_11, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user10_user12 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F8"), Action = FriendshipAction.Accept, Sender = user_account_10, Receiver = user_account_12, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user13_user14 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1F9"), Action = FriendshipAction.Accept, Sender = user_account_13, Receiver = user_account_14, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user15_user16 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1FA"), Action = FriendshipAction.Accept, Sender = user_account_15, Receiver = user_account_16, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user17_user18 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1FB"), Action = FriendshipAction.Accept, Sender = user_account_17, Receiver = user_account_18, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user18_user19 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1FC"), Action = FriendshipAction.Accept, Sender = user_account_18, Receiver = user_account_19, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user20_user21 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1FD"), Action = FriendshipAction.Accept, Sender = user_account_20, Receiver = user_account_21, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user21_user22 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1FE"), Action = FriendshipAction.Accept, Sender = user_account_21, Receiver = user_account_22, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user23_user24 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1FF"), Action = FriendshipAction.Accept, Sender = user_account_23, Receiver = user_account_24, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user23_user25 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E0"), Action = FriendshipAction.Accept, Sender = user_account_23, Receiver = user_account_25, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user26_user27 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E1"), Action = FriendshipAction.Accept, Sender = user_account_26, Receiver = user_account_27, SCMRelationshipType = SCMRelationship.Downstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user27_user28 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E2"), Action = FriendshipAction.Accept, Sender = user_account_27, Receiver = user_account_28, SCMRelationshipType = SCMRelationship.Downstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user27_user29 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E3"), Action = FriendshipAction.Accept, Sender = user_account_27, Receiver = user_account_29, SCMRelationshipType = SCMRelationship.Downstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user30_user31 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E4"), Action = FriendshipAction.Accept, Sender = user_account_30, Receiver = user_account_31, SCMRelationshipType = SCMRelationship.Downstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user30_user32 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E5"), Action = FriendshipAction.Accept, Sender = user_account_30, Receiver = user_account_32, SCMRelationshipType = SCMRelationship.Downstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user33_user34 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E6"), Action = FriendshipAction.Accept, Sender = user_account_33, Receiver = user_account_34, SCMRelationshipType = SCMRelationship.Downstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user33_user35 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E7"), Action = FriendshipAction.Accept, Sender = user_account_33, Receiver = user_account_35, SCMRelationshipType = SCMRelationship.Downstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user36_user37 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E8"), Action = FriendshipAction.Accept, Sender = user_account_36, Receiver = user_account_37, SCMRelationshipType = SCMRelationship.Downstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user36_user35 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E9"), Action = FriendshipAction.Accept, Sender = user_account_36, Receiver = user_account_35, SCMRelationshipType = SCMRelationship.Downstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user38_user39 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1EA"), Action = FriendshipAction.Accept, Sender = user_account_38, Receiver = user_account_39, SCMRelationshipType = SCMRelationship.Downstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user38_user35 = new FriendshipStateInfo { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1EB"), Action = FriendshipAction.Accept, Sender = user_account_38, Receiver = user_account_35, SCMRelationshipType = SCMRelationship.Downstream, IsActive = true, ActionDateTime = DateTime.Now };

            context.Friendships.Add(rel_user1_user2);
            context.Friendships.Add(rel_user2_user3);
            context.Friendships.Add(rel_user1_user4);

            context.Friendships.Add(rel_user5_user6);
            context.Friendships.Add(rel_user6_user7);
            context.Friendships.Add(rel_user6_user8);
            context.Friendships.Add(rel_user5_user9);

            context.Friendships.Add(rel_user10_user11);
            context.Friendships.Add(rel_user10_user12);

            context.Friendships.Add(rel_user13_user14);
            context.Friendships.Add(rel_user15_user16);

            context.Friendships.Add(rel_user17_user18);
            context.Friendships.Add(rel_user18_user19);
            context.Friendships.Add(rel_user20_user21);
            context.Friendships.Add(rel_user21_user22);
            context.Friendships.Add(rel_user23_user24);
            context.Friendships.Add(rel_user23_user25);

            context.Friendships.Add(rel_user26_user27);
            context.Friendships.Add(rel_user27_user28);
            context.Friendships.Add(rel_user27_user29);

            context.Friendships.Add(rel_user30_user31);
            context.Friendships.Add(rel_user30_user32);

            context.Friendships.Add(rel_user33_user34);
            context.Friendships.Add(rel_user33_user35);

            context.Friendships.Add(rel_user36_user37);
            context.Friendships.Add(rel_user36_user35);

            context.Friendships.Add(rel_user38_user39);
            context.Friendships.Add(rel_user38_user35);

            

            context.UserAccounts.Add(user_account_1);
            context.UserAccounts.Add(user_account_2);
            context.UserAccounts.Add(user_account_3);
            context.UserAccounts.Add(user_account_4);
            context.UserAccounts.Add(user_account_5);
            context.UserAccounts.Add(user_account_6);
            context.UserAccounts.Add(user_account_7);
            context.UserAccounts.Add(user_account_8);
            context.UserAccounts.Add(user_account_9);
            context.UserAccounts.Add(user_account_10);
            context.UserAccounts.Add(user_account_11);
            context.UserAccounts.Add(user_account_12);
            context.UserAccounts.Add(user_account_13);
            context.UserAccounts.Add(user_account_14);
            context.UserAccounts.Add(user_account_15);
            context.UserAccounts.Add(user_account_16);
            context.UserAccounts.Add(user_account_17);
            context.UserAccounts.Add(user_account_18);
            context.UserAccounts.Add(user_account_19);
            context.UserAccounts.Add(user_account_20);
            context.UserAccounts.Add(user_account_21);
            context.UserAccounts.Add(user_account_22);
            context.UserAccounts.Add(user_account_23);
            context.UserAccounts.Add(user_account_24);
            context.UserAccounts.Add(user_account_25);
            context.UserAccounts.Add(user_account_26);
            context.UserAccounts.Add(user_account_27);
            context.UserAccounts.Add(user_account_28);
            context.UserAccounts.Add(user_account_29);
            context.UserAccounts.Add(user_account_30);
            context.UserAccounts.Add(user_account_31);
            context.UserAccounts.Add(user_account_32);
            context.UserAccounts.Add(user_account_33);
            context.UserAccounts.Add(user_account_34);
            context.UserAccounts.Add(user_account_35);
            context.UserAccounts.Add(user_account_36);
            context.UserAccounts.Add(user_account_37);
            context.UserAccounts.Add(user_account_38);
            context.UserAccounts.Add(user_account_39);
            context.UserAccounts.Add(user_account_40);
             
            byte[] defaultGroupHeaderPicture = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.groupHeader  );
            byte[] defaultGroupProfilePicture = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.groupProfile );

            var group95 = new Group { Key = new Guid("ACBCCE0E-7C9F-4386-99AA-1458F308EBB0"), Name = "Electric Providers Group", Description = "Electric Providers Group", HeaderPicture = defaultGroupHeaderPicture, ProfilePicture = defaultGroupProfilePicture };//, Administrator = brins }; //pricing strategies, format and reports
            var group96 = new Group { Key = new Guid("ACBCCE0E-99AA-4386-98AA-1458F308EBB1"), Name = "Fabric Providers Group", Description = "Fabric Providers Group", HeaderPicture = defaultGroupHeaderPicture, ProfilePicture = defaultGroupProfilePicture };//, Administrator = brins }; //pricing strategies, format and reports
            var group97 = new Group { Key = new Guid("ACBCCE0E-99AA-4386-98AA-1458F308EBB2"), Name = "Steel Providers Group", Description = "Steel Providers Group", HeaderPicture = defaultGroupHeaderPicture, ProfilePicture = defaultGroupProfilePicture };//, Administrator = brins }; //pricing strategies, format and reports
            //var group101 = new Group { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E4"), Name = "Group101", Description = "Group101", HeaderPicture = defaultGroupHeaderPicture, ProfilePicture = defaultGroupProfilePicture };//, Administrator = brins }; //pricing strategies, format and reports

            context.Groups.Add(group95);
            context.Groups.Add(group96);
            context.Groups.Add(group97);
            //context.Groups.Add(group101);

            var group95_BasicProfile = new BasicProfile { ReferenceKey=group95.Key , ReferenceType= AccountType.Group  };
            var group96_BasicProfile = new BasicProfile { ReferenceKey = group96.Key, ReferenceType = AccountType.Group };
            var group97_BasicProfile = new BasicProfile { ReferenceKey = group97.Key, ReferenceType = AccountType.Group };
            //var group101_BasicProfile = new BasicProfile { ReferenceKey = group101.Key, ReferenceType = AccountType.Group };
            

            context.BasicProfiles.Add(group95_BasicProfile);
            context.BasicProfiles.Add(group96_BasicProfile);
            context.BasicProfiles.Add(group97_BasicProfile);
            //context.BasicProfiles.Add(group101_BasicProfile);
          

            var memb_user8_group95 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E201"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group95, RequestorAccount = user_account_8 };
            var memb_user9_group95 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E202"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group95, RequestorAccount = user_account_9 };
            //var memb_user4_group100 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E203"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group98, RequestorAccount = user_account_4 };


            var memb_user11_group96 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E204"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group96, RequestorAccount = user_account_11 };
            var memb_user22_group96 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E205"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group96, RequestorAccount = user_account_22 };
            //var memb_user9_group101 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E206"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group98, RequestorAccount = user_account_4 };

            var memb_user12_group97 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E207"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group97, RequestorAccount = user_account_12 };
            var memb_user14_group97 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E208"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group97, RequestorAccount = user_account_14 };
            var memb_user19_group97 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E209"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group97, RequestorAccount = user_account_19 };

            //var memb_user20_group103 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E20A"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group98, RequestorAccount = user_account_1 };
            //var memb_user21_group103 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E20B"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group98, RequestorAccount = user_account_2 };
            //var memb_user23_group103 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E20C"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group98, RequestorAccount = user_account_4 };


            context.GroupMemberships.Add(memb_user8_group95);
            context.GroupMemberships.Add(memb_user9_group95);
            //context.GroupMemberships.Add(memb_user4_group100);

            context.GroupMemberships.Add(memb_user11_group96);
            context.GroupMemberships.Add(memb_user22_group96);
            //context.GroupMemberships.Add(memb_user9_group101);

            context.GroupMemberships.Add(memb_user12_group97);
            context.GroupMemberships.Add(memb_user14_group97);
            context.GroupMemberships.Add(memb_user19_group97);

            //context.GroupMemberships.Add(memb_user20_group103);
            //context.GroupMemberships.Add(memb_user21_group103);
            //context.GroupMemberships.Add(memb_user23_group103);

            var alliance98 = new Alliance { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E1"), Name = "Alliance98", Description = "Alliance98", Coordinator = organizationAccount41, HeaderPicture = null, ProfilePicture = null };
            var alliance99 = new Alliance { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E2"), Name = "Alliance99", Description = "Alliance99", Coordinator = organizationAccount41, HeaderPicture = null, ProfilePicture = null };
            var alliance100 = new Alliance { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E3"), Name = "Alliance100", Description = "Alliance100", Coordinator = organizationAccount41, HeaderPicture = null, ProfilePicture = null };
           

            context.Alliances.Add(alliance98);
            context.Alliances.Add(alliance99);
            context.Alliances.Add(alliance100);

            var alliance98_BasicProfile = new BasicProfile { ReferenceKey=alliance98.Key, ReferenceType= AccountType.Alliance  };
            var alliance99_BasicProfile = new BasicProfile  { ReferenceKey=alliance99.Key, ReferenceType= AccountType.Alliance  };
            var alliance100_BasicProfile = new BasicProfile { ReferenceKey=alliance100.Key  , ReferenceType=AccountType.Alliance  };

            context.BasicProfiles.Add(alliance98_BasicProfile);
            context.BasicProfiles.Add(alliance99_BasicProfile);
            context.BasicProfiles.Add(alliance100_BasicProfile);

            
            var memb_organization41_alliance98 = new AllianceMembershipStateInfo { Key=new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D0"), AllianceMembershipAction=AllianceMembershipAction.Accept,  AllianceRequested=alliance98, OrganizationRequestor=organizationAccount41 };
            var memb_organization42_alliance98 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D1"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance98, OrganizationRequestor = organizationAccount42 };
            var memb_organization44_alliance98 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D1"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance98, OrganizationRequestor = organizationAccount44 };
            
 
            var memb_organization41_alliance99 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D2"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance99, OrganizationRequestor = organizationAccount41 };
            var memb_organization45_alliance99 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D3"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance99, OrganizationRequestor = organizationAccount45 };
            var memb_organization48_alliance99 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D1"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance99, OrganizationRequestor = organizationAccount48 };
            
            var memb_organization41_alliance100 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D4"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance100, OrganizationRequestor = organizationAccount41 };
            var memb_organization53_alliance100 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D5"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance100, OrganizationRequestor = organizationAccount53 };
            var memb_organization55_alliance100 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D6"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance100, OrganizationRequestor = organizationAccount55 };

            context.AllianceMemberships.Add(memb_organization41_alliance98);
            context.AllianceMemberships.Add(memb_organization42_alliance98);
            context.AllianceMemberships.Add(memb_organization44_alliance98);

            context.AllianceMemberships.Add(memb_organization41_alliance99);
            context.AllianceMemberships.Add(memb_organization45_alliance99);
            context.AllianceMemberships.Add(memb_organization48_alliance99);

            context.AllianceMemberships.Add(memb_organization41_alliance100);
            context.AllianceMemberships.Add(memb_organization53_alliance100);
            context.AllianceMemberships.Add(memb_organization55_alliance100);
            
            var system_account_user1 = new SystemAccount() {  Email = user_account_1.Email, Password = "login123", Holder=user_account_1_BasicProfile,   IsConfirmed = true,   };
            var system_account_user2 = new SystemAccount() { Email = user_account_2.Email, Password = "login123", Holder = user_account_2_BasicProfile, IsConfirmed = true, };
            var system_account_user3 = new SystemAccount() { Email = user_account_3.Email, Password = "login123", Holder = user_account_3_BasicProfile, IsConfirmed = true, };
            var system_account_user4 = new SystemAccount() { Email = user_account_4.Email, Password = "login123", Holder = user_account_4_BasicProfile, IsConfirmed = true, };
            var system_account_user5 = new SystemAccount() { Email = user_account_5.Email, Password = "login123", Holder = user_account_5_BasicProfile, IsConfirmed = true, };
            var system_account_user6 = new SystemAccount() { Email = user_account_6.Email, Password = "login123", Holder = user_account_6_BasicProfile, IsConfirmed = true, };
            var system_account_user7 = new SystemAccount() { Email = user_account_7.Email, Password = "login123", Holder = user_account_7_BasicProfile, IsConfirmed = true, };
            var system_account_user8 = new SystemAccount() { Email = user_account_8.Email, Password = "login123", Holder = user_account_8_BasicProfile, IsConfirmed = true, };
            var system_account_user9 = new SystemAccount() { Email = user_account_9.Email, Password = "login123", Holder = user_account_9_BasicProfile, IsConfirmed = true, };
            var system_account_user10 = new SystemAccount() { Email = user_account_10.Email, Password = "login123", Holder = user_account_10_BasicProfile, IsConfirmed = true, };
            var system_account_user11 = new SystemAccount() { Email = user_account_11.Email, Password = "login123", Holder = user_account_11_BasicProfile, IsConfirmed = true, };
            var system_account_user12 = new SystemAccount() { Email = user_account_12.Email, Password = "login123", Holder = user_account_12_BasicProfile, IsConfirmed = true, };
            var system_account_user13 = new SystemAccount() { Email = user_account_13.Email, Password = "login123", Holder = user_account_13_BasicProfile, IsConfirmed = true, };
            var system_account_user14 = new SystemAccount() { Email = user_account_14.Email, Password = "login123", Holder = user_account_14_BasicProfile, IsConfirmed = true, };
            var system_account_user15 = new SystemAccount() { Email = user_account_15.Email, Password = "login123", Holder = user_account_15_BasicProfile, IsConfirmed = true, };
            var system_account_user16 = new SystemAccount() { Email = user_account_16.Email, Password = "login123", Holder = user_account_16_BasicProfile, IsConfirmed = true, };
            var system_account_user17 = new SystemAccount() { Email = user_account_17.Email, Password = "login123", Holder = user_account_17_BasicProfile, IsConfirmed = true, };
            var system_account_user18 = new SystemAccount() { Email = user_account_18.Email, Password = "login123", Holder = user_account_18_BasicProfile, IsConfirmed = true, };
            var system_account_user19 = new SystemAccount() { Email = user_account_19.Email, Password = "login123", Holder = user_account_19_BasicProfile, IsConfirmed = true, };
            var system_account_user20 = new SystemAccount() { Email = user_account_20.Email, Password = "login123", Holder = user_account_20_BasicProfile, IsConfirmed = true, };
            var system_account_user21 = new SystemAccount() { Email = user_account_21.Email, Password = "login123", Holder = user_account_21_BasicProfile, IsConfirmed = true, };
            var system_account_user22 = new SystemAccount() { Email = user_account_22.Email, Password = "login123", Holder = user_account_22_BasicProfile, IsConfirmed = true, };
            var system_account_user23 = new SystemAccount() { Email = user_account_23.Email, Password = "login123", Holder = user_account_23_BasicProfile, IsConfirmed = true, };
            var system_account_user24 = new SystemAccount() { Email = user_account_24.Email, Password = "login123", Holder = user_account_24_BasicProfile, IsConfirmed = true, };
            var system_account_user25 = new SystemAccount() { Email = user_account_25.Email, Password = "login123", Holder = user_account_25_BasicProfile, IsConfirmed = true, };
            var system_account_user26 = new SystemAccount() { Email = user_account_26.Email, Password = "login123", Holder = user_account_26_BasicProfile, IsConfirmed = true, };
            var system_account_user27 = new SystemAccount() { Email = user_account_27.Email, Password = "login123", Holder = user_account_27_BasicProfile, IsConfirmed = true, };
            var system_account_user28 = new SystemAccount() { Email = user_account_28.Email, Password = "login123", Holder = user_account_28_BasicProfile, IsConfirmed = true, };
            var system_account_user29 = new SystemAccount() { Email = user_account_29.Email, Password = "login123", Holder = user_account_29_BasicProfile, IsConfirmed = true, };
            var system_account_user30 = new SystemAccount() { Email = user_account_30.Email, Password = "login123", Holder = user_account_30_BasicProfile, IsConfirmed = true, };
            var system_account_user31 = new SystemAccount() { Email = user_account_31.Email, Password = "login123", Holder = user_account_31_BasicProfile, IsConfirmed = true, };
            var system_account_user32 = new SystemAccount() { Email = user_account_32.Email, Password = "login123", Holder = user_account_32_BasicProfile, IsConfirmed = true, };
            var system_account_user33 = new SystemAccount() { Email = user_account_33.Email, Password = "login123", Holder = user_account_33_BasicProfile, IsConfirmed = true, };
            var system_account_user34 = new SystemAccount() { Email = user_account_34.Email, Password = "login123", Holder = user_account_34_BasicProfile, IsConfirmed = true, };
            var system_account_user35 = new SystemAccount() { Email = user_account_35.Email, Password = "login123", Holder = user_account_35_BasicProfile, IsConfirmed = true, };
            var system_account_user36 = new SystemAccount() { Email = user_account_36.Email, Password = "login123", Holder = user_account_36_BasicProfile, IsConfirmed = true, };
            var system_account_user37 = new SystemAccount() { Email = user_account_37.Email, Password = "login123", Holder = user_account_37_BasicProfile, IsConfirmed = true, };
            var system_account_user38 = new SystemAccount() { Email = user_account_38.Email, Password = "login123", Holder = user_account_38_BasicProfile, IsConfirmed = true, };
            var system_account_user39 = new SystemAccount() { Email = user_account_39.Email, Password = "login123", Holder = user_account_39_BasicProfile, IsConfirmed = true, };
            var system_account_user40 = new SystemAccount() { Email = user_account_40.Email, Password = "login123", Holder = user_account_40_BasicProfile, IsConfirmed = true, };
            
            
            var system_account_organization41 = new SystemAccount() { Email = "admin@org41.com", Password = "login123", Holder = organization41_BasicProfile, IsConfirmed = true };
            var system_account_organization42 = new SystemAccount() { Email = "admin@org42.com", Password = "login123", Holder = organization42_BasicProfile, IsConfirmed = true };
            var system_account_organization43 = new SystemAccount() { Email = "admin@org43.com", Password = "login123", Holder = organization43_BasicProfile, IsConfirmed = true };
            var system_account_organization44 = new SystemAccount() { Email = "admin@org44.com", Password = "login123", Holder = organization44_BasicProfile, IsConfirmed = true };
            var system_account_organization45 = new SystemAccount() { Email = "admin@org45.com", Password = "login123", Holder = organization45_BasicProfile, IsConfirmed = true };
            var system_account_organization46 = new SystemAccount() { Email = "admin@org46.com", Password = "login123", Holder = organization46_BasicProfile, IsConfirmed = true };
            var system_account_organization47 = new SystemAccount() { Email = "admin@org47.com", Password = "login123", Holder = organization47_BasicProfile, IsConfirmed = true };
            var system_account_organization48 = new SystemAccount() { Email = "admin@org48.com", Password = "login123", Holder = organization48_BasicProfile, IsConfirmed = true };
            var system_account_organization49 = new SystemAccount() { Email = "admin@org49.com", Password = "login123", Holder = organization49_BasicProfile, IsConfirmed = true };
            var system_account_organization50 = new SystemAccount() { Email = "admin@org50.com", Password = "login123", Holder = organization50_BasicProfile, IsConfirmed = true };
            var system_account_organization51 = new SystemAccount() { Email = "admin@org51.com", Password = "login123", Holder = organization51_BasicProfile, IsConfirmed = true };
            var system_account_organization52 = new SystemAccount() { Email = "admin@org52.com", Password = "login123", Holder = organization52_BasicProfile, IsConfirmed = true };
            var system_account_organization53 = new SystemAccount() { Email = "admin@org53.com", Password = "login123", Holder = organization53_BasicProfile, IsConfirmed = true };
            var system_account_organization54 = new SystemAccount() { Email = "admin@org54.com", Password = "login123", Holder = organization54_BasicProfile, IsConfirmed = true };
            var system_account_organization55 = new SystemAccount() { Email = "admin@org55.com", Password = "login123", Holder = organization55_BasicProfile, IsConfirmed = true };
            var system_account_organization56 = new SystemAccount() { Email = "admin@org56.com", Password = "login123", Holder = organization56_BasicProfile, IsConfirmed = true };
            var system_account_organization57 = new SystemAccount() { Email = "admin@org57.com", Password = "login123", Holder = organization57_BasicProfile, IsConfirmed = true };
            var system_account_organization58 = new SystemAccount() { Email = "admin@org58.com", Password = "login123", Holder = organization58_BasicProfile, IsConfirmed = true };
            var system_account_organization59 = new SystemAccount() { Email = "admin@org59.com", Password = "login123", Holder = organization59_BasicProfile, IsConfirmed = true };
            var system_account_organization60 = new SystemAccount() { Email = "admin@org60.com", Password = "login123", Holder = organization60_BasicProfile, IsConfirmed = true };
            var system_account_organization61 = new SystemAccount() { Email = "admin@org61.com", Password = "login123", Holder = organization61_BasicProfile, IsConfirmed = true };
            var system_account_organization62 = new SystemAccount() { Email = "admin@org62.com", Password = "login123", Holder = organization62_BasicProfile, IsConfirmed = true };
            var system_account_organization63 = new SystemAccount() { Email = "admin@org63.com", Password = "login123", Holder = organization63_BasicProfile, IsConfirmed = true };
            var system_account_organization64 = new SystemAccount() { Email = "admin@org64.com", Password = "login123", Holder = organization64_BasicProfile, IsConfirmed = true };
            var system_account_organization65 = new SystemAccount() { Email = "admin@org65.com", Password = "login123", Holder = organization65_BasicProfile, IsConfirmed = true };
            var system_account_organization66 = new SystemAccount() { Email = "admin@org66.com", Password = "login123", Holder = organization66_BasicProfile, IsConfirmed = true };
            var system_account_organization67 = new SystemAccount() { Email = "admin@org67.com", Password = "login123", Holder = organization67_BasicProfile, IsConfirmed = true };
            var system_account_organization68 = new SystemAccount() { Email = "admin@org68.com", Password = "login123", Holder = organization68_BasicProfile, IsConfirmed = true };
            var system_account_organization69 = new SystemAccount() { Email = "admin@org69.com", Password = "login123", Holder = organization69_BasicProfile, IsConfirmed = true };
            var system_account_organization70 = new SystemAccount() { Email = "admin@org70.com", Password = "login123", Holder = organization70_BasicProfile, IsConfirmed = true };
            var system_account_organization71 = new SystemAccount() { Email = "admin@org71.com", Password = "login123", Holder = organization71_BasicProfile, IsConfirmed = true };
            var system_account_organization72 = new SystemAccount() { Email = "admin@org72.com", Password = "login123", Holder = organization72_BasicProfile, IsConfirmed = true };
            var system_account_organization73 = new SystemAccount() { Email = "admin@org73.com", Password = "login123", Holder = organization73_BasicProfile, IsConfirmed = true };
            var system_account_organization74 = new SystemAccount() { Email = "admin@org74.com", Password = "login123", Holder = organization74_BasicProfile, IsConfirmed = true };


            context.SystemAccounts.Add(system_account_user1);
            context.SystemAccounts.Add(system_account_user2);
            context.SystemAccounts.Add(system_account_user3);
            context.SystemAccounts.Add(system_account_user4);
            context.SystemAccounts.Add(system_account_user5);
            context.SystemAccounts.Add(system_account_user6);
            context.SystemAccounts.Add(system_account_user7);
            context.SystemAccounts.Add(system_account_user8);
            context.SystemAccounts.Add(system_account_user9);
            context.SystemAccounts.Add(system_account_user10);
            context.SystemAccounts.Add(system_account_user11);
            context.SystemAccounts.Add(system_account_user12);
            context.SystemAccounts.Add(system_account_user13);
            context.SystemAccounts.Add(system_account_user14);
            context.SystemAccounts.Add(system_account_user15);
            context.SystemAccounts.Add(system_account_user16);
            context.SystemAccounts.Add(system_account_user17);
            context.SystemAccounts.Add(system_account_user18);
            context.SystemAccounts.Add(system_account_user19);
            context.SystemAccounts.Add(system_account_user20);
            context.SystemAccounts.Add(system_account_user21);
            context.SystemAccounts.Add(system_account_user22);
            context.SystemAccounts.Add(system_account_user23);
            context.SystemAccounts.Add(system_account_user24);
            context.SystemAccounts.Add(system_account_user25);
            context.SystemAccounts.Add(system_account_user26);
            context.SystemAccounts.Add(system_account_user27);
            context.SystemAccounts.Add(system_account_user28);
            context.SystemAccounts.Add(system_account_user29);
            context.SystemAccounts.Add(system_account_user30);
            context.SystemAccounts.Add(system_account_user31);
            context.SystemAccounts.Add(system_account_user32);
            context.SystemAccounts.Add(system_account_user33);
            context.SystemAccounts.Add(system_account_user34);
            context.SystemAccounts.Add(system_account_user35);
            context.SystemAccounts.Add(system_account_user36);
            context.SystemAccounts.Add(system_account_user37);
            context.SystemAccounts.Add(system_account_user38);
            context.SystemAccounts.Add(system_account_user39);
            context.SystemAccounts.Add(system_account_user40);
            

            context.SystemAccounts.Add(system_account_organization41);
            context.SystemAccounts.Add(system_account_organization42);
            context.SystemAccounts.Add(system_account_organization43);
            context.SystemAccounts.Add(system_account_organization44);
            context.SystemAccounts.Add(system_account_organization45);
            context.SystemAccounts.Add(system_account_organization46);
            context.SystemAccounts.Add(system_account_organization47);
            context.SystemAccounts.Add(system_account_organization48);
            context.SystemAccounts.Add(system_account_organization49);
            context.SystemAccounts.Add(system_account_organization50);
            context.SystemAccounts.Add(system_account_organization51);
            context.SystemAccounts.Add(system_account_organization52);
            context.SystemAccounts.Add(system_account_organization53);
            context.SystemAccounts.Add(system_account_organization54);
            context.SystemAccounts.Add(system_account_organization55);
            context.SystemAccounts.Add(system_account_organization56);
            context.SystemAccounts.Add(system_account_organization57);
            context.SystemAccounts.Add(system_account_organization58);
            context.SystemAccounts.Add(system_account_organization59);
            context.SystemAccounts.Add(system_account_organization60);
            context.SystemAccounts.Add(system_account_organization61);
            context.SystemAccounts.Add(system_account_organization62);
            context.SystemAccounts.Add(system_account_organization63);
            context.SystemAccounts.Add(system_account_organization64);
            context.SystemAccounts.Add(system_account_organization65);
            context.SystemAccounts.Add(system_account_organization66);
            context.SystemAccounts.Add(system_account_organization67);
            context.SystemAccounts.Add(system_account_organization68);
            context.SystemAccounts.Add(system_account_organization69);
            context.SystemAccounts.Add(system_account_organization70);
            context.SystemAccounts.Add(system_account_organization71);
            context.SystemAccounts.Add(system_account_organization72);
            context.SystemAccounts.Add(system_account_organization73);
            context.SystemAccounts.Add(system_account_organization74);


            var wall_user1 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-4386-98AA-123456789001"), Owner=user_account_1_BasicProfile  };
            var wall_user2 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789002"), Owner=user_account_2_BasicProfile  };
            var wall_user3 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789003"), Owner = user_account_3_BasicProfile };
            var wall_user4 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789004"), Owner = user_account_4_BasicProfile };
            var wall_user5 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789005"), Owner = user_account_5_BasicProfile };
            var wall_user6 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789006"), Owner = user_account_6_BasicProfile };
            var wall_user7 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789007"), Owner = user_account_7_BasicProfile };
            var wall_user8 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789008"), Owner = user_account_8_BasicProfile };
            var wall_user9 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789009"), Owner = user_account_9_BasicProfile };
            var wall_user10 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678900A"), Owner = user_account_10_BasicProfile };
            var wall_user11 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678900B"), Owner = user_account_11_BasicProfile };
            var wall_user12 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678900C"), Owner = user_account_12_BasicProfile };
            var wall_user13 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678900D"), Owner = user_account_13_BasicProfile };
            var wall_user14 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678900E"), Owner = user_account_14_BasicProfile };
            var wall_user15 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678900F"), Owner= user_account_15_BasicProfile   };
            var wall_user16 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789010"), Owner = user_account_16_BasicProfile };
            var wall_user17 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789011"), Owner= user_account_17_BasicProfile  };
            var wall_user18 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789012"), Owner=user_account_18_BasicProfile };
            var wall_user19 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789013"), Owner = user_account_19_BasicProfile };
            var wall_user20 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789014"), Owner = user_account_20_BasicProfile };
            var wall_user21 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789015"), Owner= user_account_21_BasicProfile  };
            var wall_user22 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789016"), Owner=user_account_22_BasicProfile  };
            var wall_user23 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789017"), Owner=user_account_23_BasicProfile  };
            var wall_user24 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789018"), Owner=user_account_24_BasicProfile  };
            var wall_user25 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789019"), Owner = user_account_25_BasicProfile };
            var wall_user26 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678901A"), Owner = user_account_26_BasicProfile };
            var wall_user27 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678901B"), Owner = user_account_27_BasicProfile };
            var wall_user28 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678901C"), Owner = user_account_28_BasicProfile };
            var wall_user29 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678901D"), Owner = user_account_29_BasicProfile };
            var wall_user30 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-12345678901E"), Owner = user_account_30_BasicProfile };
            var wall_user31 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789020"), Owner = user_account_31_BasicProfile };
            var wall_user32 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789021"), Owner = user_account_32_BasicProfile };
            var wall_user33 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789022"), Owner=user_account_33_BasicProfile  };
            var wall_user34 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789023"), Owner = user_account_34_BasicProfile };
            var wall_user35 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789024"), Owner = user_account_35_BasicProfile };
            var wall_user36 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789025"), Owner = user_account_36_BasicProfile };
            var wall_user37 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789026"), Owner = user_account_37_BasicProfile };
            var wall_user38 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789027"), Owner = user_account_38_BasicProfile };
            var wall_user39 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789028"), Owner = user_account_39_BasicProfile };
            var wall_user40 = new ContentStream() { Key = new Guid("AAABBBCC-DDDD-AABB-98AA-123456789029"), Owner = user_account_40_BasicProfile };
            

            context.ContentStreams.Add(wall_user1);
            context.ContentStreams.Add(wall_user2);
            context.ContentStreams.Add(wall_user3);
            context.ContentStreams.Add(wall_user4);
            context.ContentStreams.Add(wall_user5);
            context.ContentStreams.Add(wall_user6);
            context.ContentStreams.Add(wall_user7);
            context.ContentStreams.Add(wall_user8);
            context.ContentStreams.Add(wall_user9);
            context.ContentStreams.Add(wall_user10);
            context.ContentStreams.Add(wall_user11);
            context.ContentStreams.Add(wall_user12);
            context.ContentStreams.Add(wall_user13);
            context.ContentStreams.Add(wall_user14);
            context.ContentStreams.Add(wall_user15);
            context.ContentStreams.Add(wall_user16);
            context.ContentStreams.Add(wall_user17);
            context.ContentStreams.Add(wall_user18);
            context.ContentStreams.Add(wall_user19);
            context.ContentStreams.Add(wall_user20);
            context.ContentStreams.Add(wall_user21);
            context.ContentStreams.Add(wall_user22);
            context.ContentStreams.Add(wall_user23);
            context.ContentStreams.Add(wall_user24);
            context.ContentStreams.Add(wall_user25);
            context.ContentStreams.Add(wall_user26);
            context.ContentStreams.Add(wall_user27);
            context.ContentStreams.Add(wall_user28);
            context.ContentStreams.Add(wall_user29);
            context.ContentStreams.Add(wall_user30);
            context.ContentStreams.Add(wall_user31);
            context.ContentStreams.Add(wall_user32);
            context.ContentStreams.Add(wall_user33);
            context.ContentStreams.Add(wall_user34);
            context.ContentStreams.Add(wall_user35);
            context.ContentStreams.Add(wall_user36);
            context.ContentStreams.Add(wall_user37);
            context.ContentStreams.Add(wall_user38);
            context.ContentStreams.Add(wall_user39);
            context.ContentStreams.Add(wall_user40);
           


            var wall_organization41 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A01"), Owner=organization41_BasicProfile  };
            var wall_organization42 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A02"), Owner=organization42_BasicProfile   };
            var wall_organization43 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A03"), Owner=organization43_BasicProfile   };
            var wall_organization44 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A04"), Owner=organization44_BasicProfile    };
            var wall_organization45 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A05"), Owner=organization45_BasicProfile };
            var wall_organization46 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A06"), Owner=organization46_BasicProfile   };
            var wall_organization47 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A07"), Owner=organization47_BasicProfile   };
            var wall_organization48 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A08"), Owner=organization48_BasicProfile   };
            var wall_organization49 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A09"), Owner=organization49_BasicProfile  };
            var wall_organization50 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A0A"), Owner=organization50_BasicProfile   };
            var wall_organization51 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A0B"), Owner = organization51_BasicProfile };
            var wall_organization52 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A0C"), Owner = organization52_BasicProfile };
            var wall_organization53 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A0D"), Owner = organization53_BasicProfile };
            var wall_organization54 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A0E"), Owner = organization54_BasicProfile };
            var wall_organization55 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A0F"), Owner = organization55_BasicProfile };
            var wall_organization56 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A10"), Owner = organization56_BasicProfile };
            var wall_organization57 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A11"), Owner = organization57_BasicProfile };
            var wall_organization58 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A12"), Owner = organization58_BasicProfile };
            var wall_organization59 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A13"), Owner = organization59_BasicProfile };
            var wall_organization60 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A14"), Owner = organization60_BasicProfile };
            var wall_organization61 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A15"), Owner = organization61_BasicProfile };
            var wall_organization62 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A16"), Owner = organization62_BasicProfile };
            var wall_organization63 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A17"), Owner = organization63_BasicProfile };
            var wall_organization64 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A18"), Owner = organization64_BasicProfile };
            var wall_organization65 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A19"), Owner = organization65_BasicProfile };
            var wall_organization66 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A1A"), Owner = organization66_BasicProfile };
            var wall_organization67 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A1B"), Owner = organization67_BasicProfile };
            var wall_organization68 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A1C"), Owner = organization68_BasicProfile };
            var wall_organization69 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A1D"), Owner = organization69_BasicProfile };
            var wall_organization70 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A1E"), Owner = organization70_BasicProfile };
            var wall_organization71 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A1F"), Owner = organization71_BasicProfile };
            var wall_organization72 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A20"), Owner = organization72_BasicProfile };
            var wall_organization73 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A21"), Owner = organization73_BasicProfile };
            var wall_organization74 = new ContentStream() { Key = new Guid("AABBCCEE-DADF-4386-98AA-123456789A22"), Owner = organization74_BasicProfile };


            context.ContentStreams.Add(wall_organization41);
            context.ContentStreams.Add(wall_organization42);
            context.ContentStreams.Add(wall_organization43);
            context.ContentStreams.Add(wall_organization44);
            context.ContentStreams.Add(wall_organization45);
            context.ContentStreams.Add(wall_organization46);
            context.ContentStreams.Add(wall_organization47);
            context.ContentStreams.Add(wall_organization48);
            context.ContentStreams.Add(wall_organization49);
            context.ContentStreams.Add(wall_organization50);
            context.ContentStreams.Add(wall_organization51);
            context.ContentStreams.Add(wall_organization52);
            context.ContentStreams.Add(wall_organization53);
            context.ContentStreams.Add(wall_organization54);
            context.ContentStreams.Add(wall_organization55);
            context.ContentStreams.Add(wall_organization56);
            context.ContentStreams.Add(wall_organization57);
            context.ContentStreams.Add(wall_organization58);
            context.ContentStreams.Add(wall_organization59);
            context.ContentStreams.Add(wall_organization60);
            context.ContentStreams.Add(wall_organization61);
            context.ContentStreams.Add(wall_organization62);
            context.ContentStreams.Add(wall_organization63);
            context.ContentStreams.Add(wall_organization64);
            context.ContentStreams.Add(wall_organization65);
            context.ContentStreams.Add(wall_organization66);
            context.ContentStreams.Add(wall_organization67);
            context.ContentStreams.Add(wall_organization68);
            context.ContentStreams.Add(wall_organization69);
            context.ContentStreams.Add(wall_organization70);
            context.ContentStreams.Add(wall_organization71);
            context.ContentStreams.Add(wall_organization72);
            context.ContentStreams.Add(wall_organization73);
            context.ContentStreams.Add(wall_organization74);

             
            var wall_group95 = new ContentStream { Key = new Guid("DDDEEEFF-DEDA-5791-98AA-123456789C01"), Owner = group95_BasicProfile };
            var wall_group96 = new ContentStream { Key = new Guid("DDDEEEFF-DEDA-5791-98AA-123456789C02"), Owner = group96_BasicProfile };
            var wall_group97 = new ContentStream { Key = new Guid("DDDEEEFF-DEDA-5791-98AA-123456789C03"), Owner = group97_BasicProfile };
            //var wall_group101 = new ContentStream { Key = new Guid("DDDEEEFF-DEDA-5791-98AA-123456789C04"), Owner = group101_BasicProfile };
          
            context.ContentStreams.Add(wall_group95);
            context.ContentStreams.Add(wall_group96);
            context.ContentStreams.Add(wall_group97);
           // context.ContentStreams.Add(wall_group101);
            
            var wall_alliance98 = new ContentStream { Key = new Guid("DDDEEEFF-FAAA-1289-98BA-123456789C00"), Owner = alliance98_BasicProfile };
            var wall_alliance99 = new ContentStream { Key = new Guid("DDDEEEFF-FAAA-1289-98BA-123456789C01"), Owner = alliance99_BasicProfile };
            var wall_alliance100 = new ContentStream { Key = new Guid("DDDEEEFF-FAAA-1289-98BA-123456789C02"), Owner = alliance100_BasicProfile };


            context.ContentStreams.Add(wall_alliance98);
            context.ContentStreams.Add(wall_alliance99);
            context.ContentStreams.Add(wall_alliance100);
  
        }

    }
}
