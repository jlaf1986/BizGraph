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
using FHNWPrototype.Domain.Tags;
using FHNWPrototype.Domain.Notifications;

namespace FHNWPrototype.Infrastructure.Repositories.EF
{
    //DropCreateDatabaseIfModelChanges<FHNWPrototypeDB>
    //CreateDatabaseIfNotExists<FHNWPrototypeDB>
    public class DBContextInitializerV2 : CreateDatabaseIfNotExists<FHNWPrototypeDB>
    {

        protected override void Seed(FHNWPrototypeDB  context)
        {

            
            DateTime initialDate = DateTime.Now; //set properties for last check

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

            byte[] header_picture_75 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._75);
            byte[] avatar_picture_75 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_76 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._76);
            byte[] avatar_picture_76 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_77 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._77);
            byte[] avatar_picture_77 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_78 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._78);
            byte[] avatar_picture_78 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_79 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._79);
            byte[] avatar_picture_79 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_80 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._80);
            byte[] avatar_picture_80 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_81 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._81);
            byte[] avatar_picture_81 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_82 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._82);
            byte[] avatar_picture_82 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_83 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._83);
            byte[] avatar_picture_83 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_84 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._84);
            byte[] avatar_picture_84 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_85 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._85);
            byte[] avatar_picture_85 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_86 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._86);
            byte[] avatar_picture_86 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_87 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._87);
            byte[] avatar_picture_87 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_88 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._88);
            byte[] avatar_picture_88 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_89 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._89);
            byte[] avatar_picture_89 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_90 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._90);
            byte[] avatar_picture_90 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_91 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._91);
            byte[] avatar_picture_91 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_92 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._92);
            byte[] avatar_picture_92 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_93 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._93);
            byte[] avatar_picture_93 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_94 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._94);
            byte[] avatar_picture_94 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_95 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._95);
            byte[] avatar_picture_95 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_96 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._96);
            byte[] avatar_picture_96 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_97 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._97);
            byte[] avatar_picture_97 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_98 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._98);
            byte[] avatar_picture_98 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_99 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._99);
            byte[] avatar_picture_99 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_100 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._100);
            byte[] avatar_picture_100 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_101 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._101);
            byte[] avatar_picture_101 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

            byte[] header_picture_102 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources._102);
            byte[] avatar_picture_102 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.logo_company);

           
          



            //Olten
            GeoLocation location_organization69 = new GeoLocation { Latitude = 75.339898, Longitude = 7.901985 };
            //Basel
            GeoLocation location_organization70 = new GeoLocation { Latitude = 75.828807, Longitude = 7.867820 };
            //Berne
            GeoLocation location_organization71 = new GeoLocation { Latitude = 74.976712, Longitude = 7.720769 };
            //Lausanne
            GeoLocation location_organization72 = new GeoLocation { Latitude = 74.799875, Longitude = 6.912335 };
            //Zurich
            GeoLocation location_organization73 = new GeoLocation { Latitude = 75.379888, Longitude = 8.819830 };
            //Geneva
            GeoLocation location_organization74 = new GeoLocation { Latitude = 74.208386, Longitude = 6.170981 };
            //Niederbipp
            GeoLocation location_organization75 = new GeoLocation { Latitude = 75.299298, Longitude = 7.971298 };
            //Oensingen
            GeoLocation location_organization76 = new GeoLocation { Latitude = 75.290397, Longitude = 7.9910194 };
            //Solothurn
            GeoLocation location_organization77 = new GeoLocation { Latitude = 75.210822, Longitude = 7.819727 };
            //Oftringen
            GeoLocation location_organization78 = new GeoLocation { Latitude = 75.319340, Longitude = 7.920925 };
            //Lucerne
            GeoLocation location_organization79 = new GeoLocation { Latitude = 75.077825, Longitude = 8.307175 };
            //Olten
            GeoLocation location_organization80 = new GeoLocation { Latitude = 75.339898, Longitude = 7.901985 };
            //Basel
            GeoLocation location_organization81 = new GeoLocation { Latitude = 75.828807, Longitude = 7.867820 };
            //Berne
            GeoLocation location_organization82 = new GeoLocation { Latitude = 74.976712, Longitude = 7.720769 };
            //Lausanne
            GeoLocation location_organization83 = new GeoLocation { Latitude = 74.799875, Longitude = 6.912335 };
            //Zurich
            GeoLocation location_organization84 = new GeoLocation { Latitude = 75.379888, Longitude = 8.819830 };
            //Geneva
            GeoLocation location_organization85 = new GeoLocation { Latitude = 74.208386, Longitude = 6.170981 };
            //Niederbipp
            GeoLocation location_organization86 = new GeoLocation { Latitude = 75.299298, Longitude = 7.971298 };
            //Oensingen
            GeoLocation location_organization87 = new GeoLocation { Latitude = 75.290397, Longitude = 7.9910194 };
            //Solothurn
            GeoLocation location_organization88 = new GeoLocation { Latitude = 75.210822, Longitude = 7.819727 };
            //Oftringen
            GeoLocation location_organization89 = new GeoLocation { Latitude = 75.319340, Longitude = 7.920925 };
            //Lucerne
            GeoLocation location_organization90 = new GeoLocation { Latitude = 75.077825, Longitude = 8.307175 };
            //Oftringen
            GeoLocation location_organization91 = new GeoLocation { Latitude = 75.319340, Longitude = 7.920925 };
            //Lucerne
            GeoLocation location_organization92 = new GeoLocation { Latitude = 75.077825, Longitude = 8.307175 };
            //Olten
            GeoLocation location_organization93 = new GeoLocation { Latitude = 75.339898, Longitude = 7.901985 };
            //Basel
            GeoLocation location_organization94 = new GeoLocation { Latitude = 75.828807, Longitude = 7.867820 };
            //Berne
            GeoLocation location_organization95 = new GeoLocation { Latitude = 74.976712, Longitude = 7.720769 };
            //Lausanne
            GeoLocation location_organization96 = new GeoLocation { Latitude = 74.799875, Longitude = 6.912335 };
            //Zurich
            GeoLocation location_organization97 = new GeoLocation { Latitude = 75.379888, Longitude = 8.819830 };
            //Geneva
            GeoLocation location_organization98 = new GeoLocation { Latitude = 74.208386, Longitude = 6.170981 };
            //Niederbipp
            GeoLocation location_organization99 = new GeoLocation { Latitude = 75.299298, Longitude = 7.971298 };
            //Oensingen
            GeoLocation location_organization100 = new GeoLocation { Latitude = 75.290397, Longitude = 7.9910194 };
            //Solothurn
            GeoLocation location_organization101 = new GeoLocation { Latitude = 75.210822, Longitude = 7.819727 };
            //Oftringen
            GeoLocation location_organization102 = new GeoLocation { Latitude = 75.319340, Longitude = 7.920925 };
           

            context.Geolocations.Add(location_organization69);
            context.Geolocations.Add(location_organization70);
            context.Geolocations.Add(location_organization71);
            context.Geolocations.Add(location_organization72);
            context.Geolocations.Add(location_organization73);
            context.Geolocations.Add(location_organization74);
            context.Geolocations.Add(location_organization75);
            context.Geolocations.Add(location_organization76);
            context.Geolocations.Add(location_organization77);
            context.Geolocations.Add(location_organization78);
            context.Geolocations.Add(location_organization79);

            context.Geolocations.Add(location_organization80);
            context.Geolocations.Add(location_organization81);
            context.Geolocations.Add(location_organization82);
            context.Geolocations.Add(location_organization83);
            context.Geolocations.Add(location_organization84);
            context.Geolocations.Add(location_organization85);
            context.Geolocations.Add(location_organization86);
            context.Geolocations.Add(location_organization87);
            context.Geolocations.Add(location_organization88);
            context.Geolocations.Add(location_organization89);
            context.Geolocations.Add(location_organization90);

            context.Geolocations.Add(location_organization91);
            context.Geolocations.Add(location_organization92);
            context.Geolocations.Add(location_organization93);
            context.Geolocations.Add(location_organization94);
            context.Geolocations.Add(location_organization95);
            context.Geolocations.Add(location_organization96);
            context.Geolocations.Add(location_organization97);
            context.Geolocations.Add(location_organization98);
            context.Geolocations.Add(location_organization99);
            context.Geolocations.Add(location_organization100);
            context.Geolocations.Add(location_organization101);

            context.Geolocations.Add(location_organization102);
            
            var organization69 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E100"), Name = "Organization 69", Description = "Organization 69", EmailSuffix = "org69.com", HeaderPicture = header_picture_69, HeadquatersLocation = location_organization69 };
            var organization70 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E101"), Name = "Organization 70", Description = "Organization 70", EmailSuffix = "org70.com", HeaderPicture = header_picture_70, HeadquatersLocation = location_organization70 };
            var organization71 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E102"), Name = "Organization 71", Description = "Organization 71", EmailSuffix = "org71.com", HeaderPicture = header_picture_71, HeadquatersLocation = location_organization71 };
            var organization72 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E103"), Name = "Organization 72", Description = "Organization 72", EmailSuffix = "org72.com", HeaderPicture = header_picture_72, HeadquatersLocation = location_organization72 };
            var organization73 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E104"), Name = "Organization 73", Description = "Organization 73", EmailSuffix = "org73.com", HeaderPicture = header_picture_73, HeadquatersLocation = location_organization73 };
            var organization74 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E105"), Name = "Organization 74", Description = "Organization 74", EmailSuffix = "org74.com", HeaderPicture = header_picture_74, HeadquatersLocation = location_organization74 };
            var organization75 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E106"), Name = "Organization 75", Description = "Organization 75", EmailSuffix = "org75.com", HeaderPicture = header_picture_75, HeadquatersLocation = location_organization75 };
            var organization76 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E107"), Name = "Organization 76", Description = "Organization 76", EmailSuffix = "org76.com", HeaderPicture = header_picture_76, HeadquatersLocation = location_organization76 };
            var organization77 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E108"), Name = "Organization 77", Description = "Organization 77", EmailSuffix = "org77.com", HeaderPicture = header_picture_77, HeadquatersLocation = location_organization77 };
            var organization78 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E109"), Name = "Organization 78", Description = "Organization 78", EmailSuffix = "org78.com", HeaderPicture = header_picture_78, HeadquatersLocation = location_organization78 };
            var organization79 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E20A"), Name = "Organization 79", Description = "Organization 79", EmailSuffix = "org79.com", HeaderPicture = header_picture_79, HeadquatersLocation = location_organization79 };

            var organization80 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E10B"), Name = "Organization 80", Description = "Organization 80", EmailSuffix = "org80.com", HeaderPicture = header_picture_80, HeadquatersLocation = location_organization80 };
            var organization81 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E10C"), Name = "Organization 81", Description = "Organization 81", EmailSuffix = "org81.com", HeaderPicture = header_picture_81, HeadquatersLocation = location_organization81 };
            var organization82 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E10D"), Name = "Organization 82", Description = "Organization 82", EmailSuffix = "org82.com", HeaderPicture = header_picture_82, HeadquatersLocation = location_organization82 };
            var organization83 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E10E"), Name = "Organization 83", Description = "Organization 83", EmailSuffix = "org83.com", HeaderPicture = header_picture_83, HeadquatersLocation = location_organization83 };
            var organization84 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E10F"), Name = "Organization 84", Description = "Organization 84", EmailSuffix = "org84.com", HeaderPicture = header_picture_84, HeadquatersLocation = location_organization84 };
            var organization85 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E110"), Name = "Organization 85", Description = "Organization 85", EmailSuffix = "org85.com", HeaderPicture = header_picture_85, HeadquatersLocation = location_organization85 };
            var organization86 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E111"), Name = "Organization 86", Description = "Organization 86", EmailSuffix = "org86.com", HeaderPicture = header_picture_86, HeadquatersLocation = location_organization86 };
            var organization87 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E112"), Name = "Organization 87", Description = "Organization 87", EmailSuffix = "org87.com", HeaderPicture = header_picture_87, HeadquatersLocation = location_organization87 };
            var organization88 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E113"), Name = "Organization 88", Description = "Organization 88", EmailSuffix = "org88.com", HeaderPicture = header_picture_88, HeadquatersLocation = location_organization88 };
            var organization89 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E114"), Name = "Organization 89", Description = "Organization 89", EmailSuffix = "org89.com", HeaderPicture = header_picture_89, HeadquatersLocation = location_organization89 };
            var organization90 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E215"), Name = "Organization 90", Description = "Organization 90", EmailSuffix = "org90.com", HeaderPicture = header_picture_90, HeadquatersLocation = location_organization90 };

            var organization91 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E116"), Name = "Organization 91", Description = "Organization 91", EmailSuffix = "org91.com", HeaderPicture = header_picture_91, HeadquatersLocation = location_organization91 };
            var organization92 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E117"), Name = "Organization 92", Description = "Organization 92", EmailSuffix = "org92.com", HeaderPicture = header_picture_92, HeadquatersLocation = location_organization92 };
            var organization93 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E118"), Name = "Organization 93", Description = "Organization 93", EmailSuffix = "org93.com", HeaderPicture = header_picture_93, HeadquatersLocation = location_organization93 };
            var organization94 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E119"), Name = "Organization 94", Description = "Organization 94", EmailSuffix = "org94.com", HeaderPicture = header_picture_94, HeadquatersLocation = location_organization94 };
            var organization95 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E11A"), Name = "Organization 95", Description = "Organization 95", EmailSuffix = "org95.com", HeaderPicture = header_picture_95, HeadquatersLocation = location_organization95 };
            var organization96 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E11B"), Name = "Organization 96", Description = "Organization 96", EmailSuffix = "org96.com", HeaderPicture = header_picture_96, HeadquatersLocation = location_organization96 };
            var organization97 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E11C"), Name = "Organization 97", Description = "Organization 97", EmailSuffix = "org97.com", HeaderPicture = header_picture_97, HeadquatersLocation = location_organization97 };
            var organization98 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E11D"), Name = "Organization 98", Description = "Organization 98", EmailSuffix = "org98.com", HeaderPicture = header_picture_98, HeadquatersLocation = location_organization98 };
            var organization99 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E11E"), Name = "Organization 99", Description = "Organization 99", EmailSuffix = "org99.com", HeaderPicture = header_picture_99, HeadquatersLocation = location_organization99 };
            var organization100 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E11F"), Name = "Organization 100", Description = "Organization 100", EmailSuffix = "org100.com", HeaderPicture = header_picture_100, HeadquatersLocation = location_organization100 };
            var organization101 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E220"), Name = "Organization 101", Description = "Organization 101", EmailSuffix = "org101.com", HeaderPicture = header_picture_101, HeadquatersLocation = location_organization101 };

            var organization102 = new Organization { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E221"), Name = "Organization 102", Description = "Organization 102", EmailSuffix = "org102.com", HeaderPicture = header_picture_102, HeadquatersLocation = location_organization102 };


            context.Organizations.Add(organization69);
            context.Organizations.Add(organization70);
            context.Organizations.Add(organization71);
            context.Organizations.Add(organization72);
            context.Organizations.Add(organization73);
            context.Organizations.Add(organization74);
            context.Organizations.Add(organization75);
            context.Organizations.Add(organization76);
            context.Organizations.Add(organization77);
            context.Organizations.Add(organization78);
            context.Organizations.Add(organization79);

            context.Organizations.Add(organization80);
            context.Organizations.Add(organization81);
            context.Organizations.Add(organization82);
            context.Organizations.Add(organization83);
            context.Organizations.Add(organization84);
            context.Organizations.Add(organization85);
            context.Organizations.Add(organization86);
            context.Organizations.Add(organization87);
            context.Organizations.Add(organization88);
            context.Organizations.Add(organization89);
            context.Organizations.Add(organization90);

            context.Organizations.Add(organization91);
            context.Organizations.Add(organization92);
            context.Organizations.Add(organization93);
            context.Organizations.Add(organization94);
            context.Organizations.Add(organization95);
            context.Organizations.Add(organization96);
            context.Organizations.Add(organization97);
            context.Organizations.Add(organization98);
            context.Organizations.Add(organization99);
            context.Organizations.Add(organization100);
            context.Organizations.Add(organization101);
            context.Organizations.Add(organization102);

            var organizationAccount69 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E100"), Name = "Intek Co.", Description = "Intek", Organization=organization69, EmailSuffix = "org69.com", Email="admin@org69.com", AvatarPicture = avatar_picture_69, Location = location_organization69 };
            var organizationAccount70 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E101"), Name = "Lipro Co.", Description = "Lipro", Organization = organization70, EmailSuffix = "org70.com", Email = "admin@org70.com", AvatarPicture = avatar_picture_70, Location = location_organization70 };
            var organizationAccount71 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E102"), Name = "Harmony Co.", Description = "Harmony", Organization = organization71, EmailSuffix = "org71.com", Email = "admin@org71.com", AvatarPicture = avatar_picture_71, Location = location_organization71 };
            var organizationAccount72 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E103"), Name = "Jergens Co.", Description = "Jergens", Organization = organization72, EmailSuffix = "org72.com", Email = "admin@org72.com", AvatarPicture = avatar_picture_72, Location = location_organization72 };
            var organizationAccount73 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E104"), Name = "World class Plastics Co.", Description = "World class Plastics", Organization = organization73, EmailSuffix = "org73.com", Email = "admin@org73.com", AvatarPicture = avatar_picture_73, Location = location_organization73 };
            var organizationAccount74 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E105"), Name = "C&C Co.", Description = "C&C", Organization = organization74, EmailSuffix = "org74.com", Email = "admin@org74.com", AvatarPicture = avatar_picture_74, Location = location_organization74 };
            var organizationAccount75 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E106"), Name = "Avery Co.", Description = "Avery", Organization = organization75, EmailSuffix = "org75.com", Email = "admin@org75.com", AvatarPicture = avatar_picture_75, Location = location_organization75 };
            var organizationAccount76 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E107"), Name = "Piqua Co.", Description = "Piqua", Organization = organization76, EmailSuffix = "org76.com", Email = "admin@org76.com", AvatarPicture = avatar_picture_76, Location = location_organization76 };
            var organizationAccount77 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E108"), Name = "Honda Co.", Description = "Honda", Organization = organization77, EmailSuffix = "org77.com", Email = "admin@org77.com", AvatarPicture = avatar_picture_77, Location = location_organization77 };
            var organizationAccount78 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E109"), Name = "JFC Co.", Description = "JFC", Organization = organization78, EmailSuffix = "org78.com", Email = "admin@org78.com", AvatarPicture = avatar_picture_78, Location = location_organization78 };
            var organizationAccount79 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E10A"), Name = "Microtech Co.", Description = "Microtech", Organization = organization79, EmailSuffix = "org79.com", Email = "admin@org79.com", AvatarPicture = avatar_picture_79, Location = location_organization79 };
            var organizationAccount80 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E10B"), Name = "IPG Co.", Description = "IPG", Organization = organization80, EmailSuffix = "org80.com", Email = "admin@org80.com", AvatarPicture = avatar_picture_80, Location = location_organization80 };
            var organizationAccount81 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E10C"), Name = "Honda Trading Co.", Description = "Honda Trading", Organization = organization81, EmailSuffix = "org81.com", Email = "admin@org81.com", AvatarPicture = avatar_picture_81, Location = location_organization81 };
            var organizationAccount82 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E10D"), Name = "Cosco Co.", Description = "Cosco", Organization = organization82, EmailSuffix = "org82.com", Email = "admin@org82.com", AvatarPicture = avatar_picture_82, Location = location_organization82 };
            var organizationAccount83 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E10E"), Name = "Sumitomo Co.", Description = "Sumitomo", Organization = organization83, EmailSuffix = "org83.com", Email = "admin@org83.com", AvatarPicture = avatar_picture_83, Location = location_organization83 };
            var organizationAccount84 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E10F"), Name = "Wagner Co.", Description = "Wagner", Organization = organization84, EmailSuffix = "org84.com", Email = "admin@org84.com", AvatarPicture = avatar_picture_84, Location = location_organization84 };
            var organizationAccount85 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E110"), Name = "Derby Co.", Description = "Derby", Organization = organization85, EmailSuffix = "org85.com", Email = "admin@org85.com", AvatarPicture = avatar_picture_85, Location = location_organization85 };
            var organizationAccount86 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E111"), Name = "Topy Co.", Description = "Topy", Organization = organization86, EmailSuffix = "org86.com", Email = "admin@org86.com", AvatarPicture = avatar_picture_86, Location = location_organization86 };
            var organizationAccount87 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E112"), Name = "Nihon Co.", Description = "Nihon", Organization = organization87, EmailSuffix = "org87.com", Email = "admin@org87.com", AvatarPicture = avatar_picture_87, Location = location_organization87 };
            var organizationAccount88 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E113"), Name = "Iwata Bolt Co.", Description = "Iwata Bolt", Organization = organization88, EmailSuffix = "org88.com", Email = "admin@org88.com", AvatarPicture = avatar_picture_88, Location = location_organization88 };
            var organizationAccount89 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E114"), Name = "J1 Co.", Description = "J1", Organization = organization89, EmailSuffix = "org89.com", Email = "admin@org89.com", AvatarPicture = avatar_picture_89, Location = location_organization89 };
            var organizationAccount90 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E115"), Name = "J3 Co.", Description = "J3", Organization = organization90, EmailSuffix = "org90.com", Email = "admin@org90.com", AvatarPicture = avatar_picture_90, Location = location_organization90 };
            var organizationAccount91 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E116"), Name = "Select Ind Co.", Description = "Select Ind", Organization = organization91, EmailSuffix = "org91.com", Email = "admin@org91.com", AvatarPicture = avatar_picture_91, Location = location_organization91 };
            var organizationAccount92 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E117"), Name = "Tenere Co.", Description = "Tenere", Organization = organization92, EmailSuffix = "org92.com", Email = "admin@org92.com", AvatarPicture = avatar_picture_92, Location = location_organization92 };
            var organizationAccount93 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E118"), Name = "S&M Tool Co.", Description = "S&M Tool", Organization = organization93, EmailSuffix = "org93.com", Email = "admin@org93.com", AvatarPicture = avatar_picture_93, Location = location_organization93 };
            var organizationAccount94 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E119"), Name = "Twist Co.", Description = "Twist", Organization = organization94, EmailSuffix = "org94.com", Email = "admin@org94.com", AvatarPicture = avatar_picture_94, Location = location_organization94 };
            var organizationAccount95 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E11A"), Name = "Arkay Co.", Description = "Arkay", Organization = organization95, EmailSuffix = "org95.com", Email = "admin@org95.com", AvatarPicture = avatar_picture_95, Location = location_organization95 };
            var organizationAccount96 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E11B"), Name = "Master Co.", Description = "Master", Organization = organization96, EmailSuffix = "org96.com", Email = "admin@org96.com", AvatarPicture = avatar_picture_96, Location = location_organization96 };
            var organizationAccount97 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E11C"), Name = "West Michigan Co.", Description = "West Michigan", Organization = organization97, EmailSuffix = "org97.com", Email = "admin@org97.com", AvatarPicture = avatar_picture_97, Location = location_organization97 };
            var organizationAccount98 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E11D"), Name = "HFI Co.", Description = "HFI", Organization = organization98, EmailSuffix = "org98.com", Email = "admin@org98.com", AvatarPicture = avatar_picture_98, Location = location_organization98 };
            var organizationAccount99 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E11E"), Name = "Miken Co.", Description = "Miken", Organization = organization99, EmailSuffix = "org99.com", Email = "admin@org99.com", AvatarPicture = avatar_picture_99, Location = location_organization99 };
            var organizationAccount100 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E11F"), Name = "Tobutsu Co.", Description = "Tobutsu", Organization = organization100, EmailSuffix = "org100.com", Email = "admin@org100.com", AvatarPicture = avatar_picture_100, Location = location_organization100 };
            var organizationAccount101 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E120"), Name = "J2 Co.", Description = "J2", Organization = organization101, EmailSuffix = "org101.com", Email = "admin@org101.com", AvatarPicture = avatar_picture_101, Location = location_organization101 };
            var organizationAccount102 = new OrganizationAccount { Key = new Guid("ACBCCE0E-7C9F-4386-9953-1458F308E121"), Name = "Garden State Co.", Description = "Garden State", Organization = organization102, EmailSuffix = "org102.com", Email = "admin@org102.com", AvatarPicture = avatar_picture_102, Location = location_organization102 };



            context.OrganizationAccounts.Add(organizationAccount69);
            context.OrganizationAccounts.Add(organizationAccount70);
            context.OrganizationAccounts.Add(organizationAccount71);
            context.OrganizationAccounts.Add(organizationAccount72);
            context.OrganizationAccounts.Add(organizationAccount73);
            context.OrganizationAccounts.Add(organizationAccount74);
            context.OrganizationAccounts.Add(organizationAccount75);
            context.OrganizationAccounts.Add(organizationAccount76);
            context.OrganizationAccounts.Add(organizationAccount77);
            context.OrganizationAccounts.Add(organizationAccount78);
            context.OrganizationAccounts.Add(organizationAccount79);

            context.OrganizationAccounts.Add(organizationAccount80);
            context.OrganizationAccounts.Add(organizationAccount81);
            context.OrganizationAccounts.Add(organizationAccount82);
            context.OrganizationAccounts.Add(organizationAccount83);
            context.OrganizationAccounts.Add(organizationAccount84);
            context.OrganizationAccounts.Add(organizationAccount85);
            context.OrganizationAccounts.Add(organizationAccount86);
            context.OrganizationAccounts.Add(organizationAccount87);
            context.OrganizationAccounts.Add(organizationAccount88);
            context.OrganizationAccounts.Add(organizationAccount89);
            context.OrganizationAccounts.Add(organizationAccount90);

            context.OrganizationAccounts.Add(organizationAccount91);
            context.OrganizationAccounts.Add(organizationAccount92);
            context.OrganizationAccounts.Add(organizationAccount93);
            context.OrganizationAccounts.Add(organizationAccount94);
            context.OrganizationAccounts.Add(organizationAccount95);
            context.OrganizationAccounts.Add(organizationAccount96);
            context.OrganizationAccounts.Add(organizationAccount97);
            context.OrganizationAccounts.Add(organizationAccount98);
            context.OrganizationAccounts.Add(organizationAccount99);
            context.OrganizationAccounts.Add(organizationAccount100);
            context.OrganizationAccounts.Add(organizationAccount101);
            context.OrganizationAccounts.Add(organizationAccount102);

            var organization69_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount69.Key, ReferenceType= AccountType.OrganizationAccount  };
            var organization70_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount70.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization71_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount71.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization72_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount72.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization73_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount73.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization74_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount74.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization75_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount75.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization76_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount76.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization77_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount77.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization78_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount78.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization79_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount79.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization80_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount80.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization81_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount81.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization82_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount82.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization83_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount83.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization84_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount84.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization85_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount85.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization86_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount86.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization87_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount87.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization88_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount88.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization89_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount89.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization90_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount90.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization91_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount91.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization92_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount92.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization93_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount93.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization94_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount94.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization95_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount95.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization96_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount96.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization97_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount97.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization98_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount98.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization99_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount99.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization100_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount100.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization101_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount101.Key, ReferenceType = AccountType.OrganizationAccount };
            var organization102_BasicProfile = new BasicProfile { ReferenceKey = organizationAccount102.Key, ReferenceType = AccountType.OrganizationAccount };

            context.BasicProfiles.Add(organization69_BasicProfile);
            context.BasicProfiles.Add(organization70_BasicProfile);
            context.BasicProfiles.Add(organization71_BasicProfile);
            context.BasicProfiles.Add(organization72_BasicProfile);
            context.BasicProfiles.Add(organization73_BasicProfile);
            context.BasicProfiles.Add(organization74_BasicProfile);
            context.BasicProfiles.Add(organization75_BasicProfile);
            context.BasicProfiles.Add(organization76_BasicProfile);
            context.BasicProfiles.Add(organization77_BasicProfile);
            context.BasicProfiles.Add(organization78_BasicProfile);
            context.BasicProfiles.Add(organization79_BasicProfile);
            context.BasicProfiles.Add(organization80_BasicProfile);
            context.BasicProfiles.Add(organization81_BasicProfile);
            context.BasicProfiles.Add(organization82_BasicProfile);
            context.BasicProfiles.Add(organization83_BasicProfile);
            context.BasicProfiles.Add(organization84_BasicProfile);
            context.BasicProfiles.Add(organization85_BasicProfile);
            context.BasicProfiles.Add(organization86_BasicProfile);
            context.BasicProfiles.Add(organization87_BasicProfile);
            context.BasicProfiles.Add(organization88_BasicProfile);
            context.BasicProfiles.Add(organization89_BasicProfile);
            context.BasicProfiles.Add(organization90_BasicProfile);
            context.BasicProfiles.Add(organization91_BasicProfile);
            context.BasicProfiles.Add(organization92_BasicProfile);
            context.BasicProfiles.Add(organization93_BasicProfile);
            context.BasicProfiles.Add(organization94_BasicProfile);
            context.BasicProfiles.Add(organization95_BasicProfile);
            context.BasicProfiles.Add(organization96_BasicProfile);
            context.BasicProfiles.Add(organization97_BasicProfile);
            context.BasicProfiles.Add(organization98_BasicProfile);
            context.BasicProfiles.Add(organization99_BasicProfile);
            context.BasicProfiles.Add(organization100_BasicProfile);
            context.BasicProfiles.Add(organization101_BasicProfile);
            context.BasicProfiles.Add(organization102_BasicProfile);

            byte[] avatar_picture_user1 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user1);
            byte[] avatar_picture_user2 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user3 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user4 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user5 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user5);
            byte[] avatar_picture_user6 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user6);
            byte[] avatar_picture_user7 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user8 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user9 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user9);
            byte[] avatar_picture_user10 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user11 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user12 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user13 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user13);
            byte[] avatar_picture_user14 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user14);
            byte[] avatar_picture_user15 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user15);
            byte[] avatar_picture_user16 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user16);
            byte[] avatar_picture_user17 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user18 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user19 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user20 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user20);
            byte[] avatar_picture_user21 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user21);
            byte[] avatar_picture_user22 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user22);
            byte[] avatar_picture_user23 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user23);
            byte[] avatar_picture_user24 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user24);
            byte[] avatar_picture_user25 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user25);
            byte[] avatar_picture_user26 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user26);
            byte[] avatar_picture_user27 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user27);
            byte[] avatar_picture_user28 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user28);
            byte[] avatar_picture_user29 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user29);
            byte[] avatar_picture_user30 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user30);
            byte[] avatar_picture_user31 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user31);
            byte[] avatar_picture_user32 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user32);
            byte[] avatar_picture_user33 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user33);
            byte[] avatar_picture_user34 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user34);
            byte[] avatar_picture_user35 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user35);
            byte[] avatar_picture_user36 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user36);
            byte[] avatar_picture_user37 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user38 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user39 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user40 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user41 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user42 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user43 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user2);
            byte[] avatar_picture_user44 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user3);
            byte[] avatar_picture_user45 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user46 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user47 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user48 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user49 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user50 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user51 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user52 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user4);
            byte[] avatar_picture_user53 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user54 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user7);
            byte[] avatar_picture_user55 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user8);
            byte[] avatar_picture_user56 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user10);
            byte[] avatar_picture_user57 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user11);
            byte[] avatar_picture_user58 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user12);
            byte[] avatar_picture_user59 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user37);
            byte[] avatar_picture_user60 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user38);
            byte[] avatar_picture_user61 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user39);
            byte[] avatar_picture_user62 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user63 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user64 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user65 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user66 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user67 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
            byte[] avatar_picture_user68 = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.user_icon);
          
             
            //Users
            var user1 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A0"), FirstName = "Anthony", LastName = "Witcher", ProfilePicture = avatar_picture_user1 };
            var user2 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A1"), FirstName = "Norman", LastName = "Brin", ProfilePicture=avatar_picture_user2  };
            var user3 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A2"), FirstName = "Allie", LastName = "Opper", ProfilePicture = avatar_picture_user3 };
            var user4 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A3"), FirstName = "Julio", LastName = "Spelman", ProfilePicture = avatar_picture_user4 };
            var user5 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A4"), FirstName = "Lawrence", LastName = "Schaal", ProfilePicture = avatar_picture_user5 };
            var user6 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1A5"), FirstName = "Charles", LastName = "Gann", ProfilePicture = avatar_picture_user6 };
            var user7 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A6"), FirstName = "Edwina", LastName = "Heimbach", ProfilePicture = avatar_picture_user7 };
            var user8 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A7"), FirstName = "Miriam", LastName = "Walk", ProfilePicture = avatar_picture_user8 };
            var user9 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A8"), FirstName = "Scott", LastName = "Fiore", ProfilePicture = avatar_picture_user9 };
            var user10 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2A9"), FirstName = "Jimmy", LastName = "Bates", ProfilePicture = avatar_picture_user10 };
            var user11 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2AA"), FirstName = "Kelly", LastName = "Glen", ProfilePicture = avatar_picture_user11 };
            var user12 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2AB"), FirstName = "Neil", LastName = "Iannuzzi", ProfilePicture = avatar_picture_user12 };
            var user13 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2AC"), FirstName = "Norman", LastName = "Broadwater", ProfilePicture = avatar_picture_user13 };
            var user14 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2AD"), FirstName = "Joe", LastName = "Sherwin", ProfilePicture = avatar_picture_user14 };
            var user15 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2AE"), FirstName = "Steven", LastName = "Ruch", ProfilePicture = avatar_picture_user15 };
            var user16 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2AF"), FirstName = "Jessie", LastName = "Smail", ProfilePicture = avatar_picture_user16 };
            var user17 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B0"), FirstName = "Ernest", LastName = "Wong", ProfilePicture = avatar_picture_user17 };
            var user18 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B1"), FirstName = "Michael", LastName = "Melgar", ProfilePicture = avatar_picture_user18 };
            var user19 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B2"), FirstName = "Max", LastName = "Sulser", ProfilePicture = avatar_picture_user19 };
            var user20 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B3"), FirstName = "Jerri", LastName = "Buffaloe", ProfilePicture = avatar_picture_user20 };
            var user21 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B4"), FirstName = "Tiffany", LastName = "Cofield", ProfilePicture = avatar_picture_user21 };
            var user22 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B5"), FirstName = "Aaron", LastName = "Yancey", ProfilePicture = avatar_picture_user22 };
            var user23 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B6"), FirstName = "Gladys", LastName = "Brewington", ProfilePicture = avatar_picture_user23 };
            var user24 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B7"), FirstName = "Dennis", LastName = "Muir", ProfilePicture = avatar_picture_user24 };
            var user25 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B8"), FirstName = "Marylou", LastName = "Tookes", ProfilePicture = avatar_picture_user25 };
            var user26 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2B9"), FirstName = "Pearlie", LastName = "Chevere", ProfilePicture = avatar_picture_user26 };
            var user27 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2BA"), FirstName = "Fernando", LastName = "Sparr", ProfilePicture = avatar_picture_user27 };
            var user28 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2BB"), FirstName = "Jeanette", LastName = "Moynihan", ProfilePicture = avatar_picture_user28 };
            var user29 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2BC"), FirstName = "George", LastName = "Chrisman", ProfilePicture = avatar_picture_user29 };
            var user30 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2BD"), FirstName = "Clinton", LastName = "Coulston", ProfilePicture = avatar_picture_user30 };
            var user31 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2BE"), FirstName = "Darren", LastName = "Tinkham", ProfilePicture = avatar_picture_user31 };
            var user32 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2BF"), FirstName = "Vanessa", LastName = "Valenti", ProfilePicture = avatar_picture_user32 };
            var user33 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C0"), FirstName = "Beverly", LastName = "Headley", ProfilePicture = avatar_picture_user33 };
            var user34 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C1"), FirstName = "Neil", LastName = "Rockhill", ProfilePicture = avatar_picture_user34 };
            var user35 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C2"), FirstName = "Jacob", LastName = "Braswell", ProfilePicture = avatar_picture_user35 };
            var user36 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C3"), FirstName = "Brandon", LastName = "Worsham", ProfilePicture = avatar_picture_user36 };
            var user37 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C4"), FirstName = "Joshua", LastName = "Luna", ProfilePicture = avatar_picture_user37 };
            var user38 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C5"), FirstName = "Jeffrey", LastName = "Swope", ProfilePicture = avatar_picture_user38 };
            var user39 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C6"), FirstName = "Martin", LastName = "Segal", ProfilePicture = avatar_picture_user39 };
            var user40 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C7"), FirstName = "Thomas", LastName = "Caesar", ProfilePicture = avatar_picture_user40 };

            var user41 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C8"), FirstName = "Danny", LastName = "Bullins", ProfilePicture = avatar_picture_user41 };
            var user42 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2C9"), FirstName = "Phillip", LastName = "Caruthers", ProfilePicture = avatar_picture_user42 };
            var user43 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2CA"), FirstName = "Gary", LastName = "Westerman", ProfilePicture = avatar_picture_user43 };
            var user44 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2CB"), FirstName = "Philip", LastName = "Burgin", ProfilePicture = avatar_picture_user44 };
            var user45 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2CC"), FirstName = "Arthur", LastName = "Neill", ProfilePicture = avatar_picture_user45 };
            var user46 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2CD"), FirstName = "Rachel", LastName = "Prater", ProfilePicture = avatar_picture_user46 };
            var user47 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2CE"), FirstName = "Lisa", LastName = "Temple", ProfilePicture = avatar_picture_user47 };
            var user48 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2CF"), FirstName = "Nellie", LastName = "Woody", ProfilePicture = avatar_picture_user48 };
            var user49 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2D0"), FirstName = "Kristine", LastName = "Detwiler", ProfilePicture = avatar_picture_user49 };
            var user50 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2D1"), FirstName = "Jeremy", LastName = "Sansom", ProfilePicture = avatar_picture_user50 };
            var user51 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2D2"), FirstName = "Henry", LastName = "Harness", ProfilePicture = avatar_picture_user51 };
            var user52 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2D3"), FirstName = "Nellie", LastName = "Burch", ProfilePicture = avatar_picture_user52 };
            var user53 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2D4"), FirstName = "Raymond", LastName = "Whiteman", ProfilePicture = avatar_picture_user53 };
            var user54 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2D5"), FirstName = "Luis", LastName = "Peltier", ProfilePicture = avatar_picture_user54 };
            var user55 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2D6"), FirstName = "Earl", LastName = "Pennington", ProfilePicture = avatar_picture_user55 };
            var user56 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2D7"), FirstName = "Louise", LastName = "Mooney", ProfilePicture = avatar_picture_user56 };
            var user57 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2D8"), FirstName = "Hazel", LastName = "Ortiz", ProfilePicture = avatar_picture_user57 };
            var user58 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2D9"), FirstName = "Judy", LastName = "Angelo", ProfilePicture = avatar_picture_user58 };
            var user59 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2DA"), FirstName = "Jacquelyn", LastName = "Wing", ProfilePicture = avatar_picture_user59 };
            var user60 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2DB"), FirstName = "Martin", LastName = "Keesee", ProfilePicture = avatar_picture_user60 };
            var user61 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2DC"), FirstName = "Mike", LastName = "Kemper", ProfilePicture = avatar_picture_user61 };
            var user62 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2DD"), FirstName = "Carl", LastName = "Hedges", ProfilePicture = avatar_picture_user62 };
            var user63 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2DF"), FirstName = "Carrie", LastName = "Budde", ProfilePicture = avatar_picture_user63 };
            var user64 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2E0"), FirstName = "Manuel", LastName = "Younts", ProfilePicture = avatar_picture_user64 };
            var user65 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2E1"), FirstName = "Scott", LastName = "Theriault", ProfilePicture = avatar_picture_user65 };
            var user66 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2E2"), FirstName = "Louis", LastName = "Rollins", ProfilePicture = avatar_picture_user66 };
            var user67 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2E3"), FirstName = "Christopher", LastName = "Bauer", ProfilePicture = avatar_picture_user67 };
            var user68 = new User { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E2E4"), FirstName = "Steven", LastName = "Hoppe", ProfilePicture = avatar_picture_user68 };
           

            //Accounts


            var user_account_1 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E201"), Tag = "#Contract2013", Email = "user1@org69.com", User = user1, OrganizationAccount = organizationAccount69, LastAccessOnNotifications = initialDate }; //Logistics Department
            var user_account_2 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E202"), Tag = "#Contract2013", Email = "user2@org70.com", User = user2, OrganizationAccount = organizationAccount70, LastAccessOnNotifications = initialDate }; // Logistics Department
            var user_account_3 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E203"), Tag = "#Contract2013", Email = "user3@org71.com", User = user3, OrganizationAccount = organizationAccount71, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_4 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E204"), Tag = "#Contract2013", Email = "user4@org72.com", User = user4, OrganizationAccount = organizationAccount72, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_5 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E205"), Tag = "#Contract2013", Email = "user5@org73.com", User = user5, OrganizationAccount = organizationAccount73, LastAccessOnNotifications = initialDate };// Product Development
            var user_account_6 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E206"), Tag = "#Contract2013", Email = "user6@org74.com", User = user6, OrganizationAccount = organizationAccount74, LastAccessOnNotifications = initialDate }; //Branding
            var user_account_7 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E207"), Tag = "#Contract2013", Email = "user7@org75.com", User = user7, OrganizationAccount = organizationAccount75, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_8 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E208"), Tag = "#Contract2013", Email = "user8@org76.com", User = user8, OrganizationAccount = organizationAccount76, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_9 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E209"), Tag = "#Contract2013", Email = "user9@org77.com", User = user9, OrganizationAccount = organizationAccount77, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_10 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E20A"), Tag = "#Contract2013", Email = "user10@org78.com", User = user10, OrganizationAccount = organizationAccount78, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_11 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E20B"), Tag = "#Contract2013", Email = "user11@org79.com", User = user11, OrganizationAccount = organizationAccount79, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_12 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E20C"), Tag = "#Contract2013", Email = "user12@org80.com", User = user12, OrganizationAccount = organizationAccount80, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_13 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E20D"), Tag = "#Contract2013", Email = "user13@org81.com", User = user13, OrganizationAccount = organizationAccount81, LastAccessOnNotifications = initialDate }; //Losgistics Department
            var user_account_14 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E20E"), Tag = "#Contract2013", Email = "user14@org82.com", User = user14, OrganizationAccount = organizationAccount82, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_15 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E20F"), Tag = "#Contract2013", Email = "user15@org83.com", User = user15, OrganizationAccount = organizationAccount83, LastAccessOnNotifications = initialDate }; //Warehousing
            var user_account_16 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E210"), Tag = "#Contract2013", Email = "user16@org84.com", User = user16, OrganizationAccount = organizationAccount84, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_17 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E211"), Tag = "#Contract2013", Email = "user17@org85.com", User = user17, OrganizationAccount = organizationAccount85, LastAccessOnNotifications = initialDate }; //Warehousing
            var user_account_18 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E212"), Tag = "#Contract2013", Email = "user18@org86.com", User = user18, OrganizationAccount = organizationAccount86, LastAccessOnNotifications = initialDate }; //Procurement
            var user_account_19 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E213"), Tag = "#Contract2013", Email = "user19@org87.com", User = user19, OrganizationAccount = organizationAccount87, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_20 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E214"), Tag = "#Contract2013", Email = "user20@org88.com", User = user20, OrganizationAccount = organizationAccount88, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_21 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E215"), Tag = "#Contract2013", Email = "user21@org89.com", User = user21, OrganizationAccount = organizationAccount89, LastAccessOnNotifications = initialDate }; //Product Development
            var user_account_22 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E216"), Tag = "#Contract2013", Email = "user22@org90.com", User = user22, OrganizationAccount = organizationAccount90, LastAccessOnNotifications = initialDate };//Marketing
            var user_account_23 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E217"), Tag = "#Contract2013", Email = "user23@org91.com", User = user23, OrganizationAccount = organizationAccount91, LastAccessOnNotifications = initialDate }; //in-site logistics
            var user_account_24 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E218"), Tag = "#Contract2013", Email = "user29@org92.com", User = user24, OrganizationAccount = organizationAccount92, LastAccessOnNotifications = initialDate }; //Marketing
            var user_account_25 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E219"), Tag = "#Contract2013", Email = "user25@org93.com", User = user25, OrganizationAccount = organizationAccount93, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_26 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E21A"), Tag = "#Contract2013", Email = "user26@org94.com", User = user26, OrganizationAccount = organizationAccount94, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_27 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E21B"), Tag = "#Contract2013", Email = "user27@org95.com", User = user27, OrganizationAccount = organizationAccount95, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_28 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E21C"), Tag = "#Contract2013", Email = "user28@org96.com", User = user28, OrganizationAccount = organizationAccount96, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_29 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E21D"), Tag = "#Contract2013", Email = "user29@org97.com", User = user29, OrganizationAccount = organizationAccount97, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_30 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E21E"), Tag = "#Contract2013", Email = "user30@org98.com", User = user30, OrganizationAccount = organizationAccount98, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_31 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E21F"), Tag = "#Contract2013", Email = "user31@org99.com", User = user31, OrganizationAccount = organizationAccount99, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_32 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E220"), Tag = "#Contract2013", Email = "user32@org100.com", User = user32, OrganizationAccount = organizationAccount100, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_33 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E221"), Tag = "#Contract2013", Email = "user33@org101.com", User = user33, OrganizationAccount = organizationAccount101, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_34 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E222"), Tag = "#Contract2013", Email = "user34@org102.com", User = user34, OrganizationAccount = organizationAccount102, LastAccessOnNotifications = initialDate }; //Logistics
            
            var user_account_35 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E223"), Tag = "#Contract2013", Email = "user35@org69.com", User = user35, OrganizationAccount = organizationAccount69, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_36 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E224"), Tag = "#Contract2013", Email = "user36@org70.com", User = user36, OrganizationAccount = organizationAccount70, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_37 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E225"), Tag = "#Contract2013", Email = "user37@org71.com", User = user37, OrganizationAccount = organizationAccount71, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_38 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E226"), Tag = "#Contract2013", Email = "user38@org72.com", User = user38, OrganizationAccount = organizationAccount72, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_39 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E227"), Tag = "#Contract2013", Email = "user39@org73.com", User = user39, OrganizationAccount = organizationAccount73, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_40 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E228"), Tag = "#Contract2013", Email = "user40@org74.com", User = user40, OrganizationAccount = organizationAccount74, LastAccessOnNotifications = initialDate }; //Point of Sale
            var user_account_41 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E229"), Tag = "#MaterialFlow", Email = "user1@org75.com", User = user41, OrganizationAccount = organizationAccount75, LastAccessOnNotifications = initialDate }; //Logistics Department
            var user_account_42 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E22A"), Tag = "#MaterialFlow", Email = "user2@org76.com", User = user42, OrganizationAccount = organizationAccount76, LastAccessOnNotifications = initialDate }; // Logistics Department
            var user_account_43 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E22B"), Tag = "#MaterialFlow", Email = "user3@org77.com", User = user43, OrganizationAccount = organizationAccount77, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_44 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E22C"), Tag = "#MaterialFlow", Email = "user4@org78.com", User = user44, OrganizationAccount = organizationAccount78, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_45 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E22D"), Tag = "#MaterialFlow", Email = "user5@org79.com", User = user45, OrganizationAccount = organizationAccount79, LastAccessOnNotifications = initialDate };// Product Development
            var user_account_46 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E22E"), Tag = "#MaterialFlow", Email = "user6@org80.com", User = user46, OrganizationAccount = organizationAccount80, LastAccessOnNotifications = initialDate }; //Branding
            var user_account_47 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E22F"), Tag = "#MaterialFlow", Email = "user7@org81.com", User = user47, OrganizationAccount = organizationAccount81, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_48 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E230"), Tag = "#MaterialFlow", Email = "user8@org82.com", User = user48, OrganizationAccount = organizationAccount82, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_49 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E231"), Tag = "#MaterialFlow", Email = "user9@org83.com", User = user49, OrganizationAccount = organizationAccount83, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_50 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E232"), Tag = "#MaterialFlow", Email = "user10@org84.com", User = user50, OrganizationAccount = organizationAccount84, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_51 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E233"), Tag = "#MaterialFlow", Email = "user11@org85.com", User = user51, OrganizationAccount = organizationAccount85, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_52 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E234"), Tag = "#MaterialFlow", Email = "user12@org86.com", User = user52, OrganizationAccount = organizationAccount86, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_53 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E235"), Tag = "#MaterialFlow", Email = "user13@org87.com", User = user53, OrganizationAccount = organizationAccount87, LastAccessOnNotifications = initialDate }; //Losgistics Department
            var user_account_54 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E236"), Tag = "#MaterialFlow", Email = "user14@org88.com", User = user54, OrganizationAccount = organizationAccount88, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_55 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E237"), Tag = "#MaterialFlow", Email = "user15@org89.com", User = user55, OrganizationAccount = organizationAccount89, LastAccessOnNotifications = initialDate }; //Warehousing
            var user_account_56 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E238"), Tag = "#MaterialFlow", Email = "user16@org90.com", User = user56, OrganizationAccount = organizationAccount90, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_57 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E239"), Tag = "#MaterialFlow", Email = "user17@org91.com", User = user57, OrganizationAccount = organizationAccount91, LastAccessOnNotifications = initialDate }; //Warehousing
            var user_account_58 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E23A"), Tag = "#MaterialFlow", Email = "user18@org92.com", User = user58, OrganizationAccount = organizationAccount92, LastAccessOnNotifications = initialDate }; //Procurement
            var user_account_59 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E23B"), Tag = "#MaterialFlow", Email = "user19@org93.com", User = user59, OrganizationAccount = organizationAccount93, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_60 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E23C"), Tag = "#MaterialFlow", Email = "user20@org94.com", User = user60, OrganizationAccount = organizationAccount94, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_61 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E23D"), Tag = "#MaterialFlow", Email = "user21@org95.com", User = user61, OrganizationAccount = organizationAccount95, LastAccessOnNotifications = initialDate }; //Product Development
            var user_account_62 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E23E"), Tag = "#MaterialFlow", Email = "user22@org96.com", User = user62, OrganizationAccount = organizationAccount96, LastAccessOnNotifications = initialDate };//Marketing
            var user_account_63 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E23F"), Tag = "#MaterialFlow", Email = "user23@org97.com", User = user63, OrganizationAccount = organizationAccount97, LastAccessOnNotifications = initialDate }; //in-site logistics
            var user_account_64 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E240"), Tag = "#MaterialFlow", Email = "user29@org98.com", User = user64, OrganizationAccount = organizationAccount98, LastAccessOnNotifications = initialDate }; //Marketing
            var user_account_65 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E241"), Tag = "#MaterialFlow", Email = "user25@org99.com", User = user65, OrganizationAccount = organizationAccount99, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_66 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E242"), Tag = "#MaterialFlow", Email = "user26@org100.com", User = user66, OrganizationAccount = organizationAccount100, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_67 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E243"), Tag = "#MaterialFlow", Email = "user27@org101.com", User = user67, OrganizationAccount = organizationAccount101, LastAccessOnNotifications = initialDate }; //Logistics
            var user_account_68 = new UserAccount { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E244"), Tag = "#MaterialFlow", Email = "user28@org102.com", User = user68, OrganizationAccount = organizationAccount102, LastAccessOnNotifications = initialDate }; //Logistics
         

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
            var user_account_41_BasicProfile = new BasicProfile { ReferenceKey = user_account_41.Key, ReferenceType = AccountType.UserAccount };
            var user_account_42_BasicProfile = new BasicProfile { ReferenceKey = user_account_42.Key, ReferenceType = AccountType.UserAccount };
            var user_account_43_BasicProfile = new BasicProfile { ReferenceKey = user_account_43.Key, ReferenceType = AccountType.UserAccount };
            var user_account_44_BasicProfile = new BasicProfile { ReferenceKey = user_account_44.Key, ReferenceType = AccountType.UserAccount };
            var user_account_45_BasicProfile = new BasicProfile { ReferenceKey = user_account_45.Key, ReferenceType = AccountType.UserAccount };
            var user_account_46_BasicProfile = new BasicProfile { ReferenceKey = user_account_46.Key, ReferenceType = AccountType.UserAccount };
            var user_account_47_BasicProfile = new BasicProfile { ReferenceKey = user_account_47.Key, ReferenceType = AccountType.UserAccount };
            var user_account_48_BasicProfile = new BasicProfile { ReferenceKey = user_account_48.Key, ReferenceType = AccountType.UserAccount };
            var user_account_49_BasicProfile = new BasicProfile { ReferenceKey = user_account_49.Key, ReferenceType = AccountType.UserAccount };
            var user_account_50_BasicProfile = new BasicProfile { ReferenceKey = user_account_50.Key, ReferenceType = AccountType.UserAccount };
            var user_account_51_BasicProfile = new BasicProfile { ReferenceKey = user_account_51.Key, ReferenceType = AccountType.UserAccount };
            var user_account_52_BasicProfile = new BasicProfile { ReferenceKey = user_account_52.Key, ReferenceType = AccountType.UserAccount };
            var user_account_53_BasicProfile = new BasicProfile { ReferenceKey = user_account_53.Key, ReferenceType = AccountType.UserAccount };
            var user_account_54_BasicProfile = new BasicProfile { ReferenceKey = user_account_54.Key, ReferenceType = AccountType.UserAccount };
            var user_account_55_BasicProfile = new BasicProfile { ReferenceKey = user_account_55.Key, ReferenceType = AccountType.UserAccount };
            var user_account_56_BasicProfile = new BasicProfile { ReferenceKey = user_account_56.Key, ReferenceType = AccountType.UserAccount };
            var user_account_57_BasicProfile = new BasicProfile { ReferenceKey = user_account_57.Key, ReferenceType = AccountType.UserAccount };
            var user_account_58_BasicProfile = new BasicProfile { ReferenceKey = user_account_58.Key, ReferenceType = AccountType.UserAccount };
            var user_account_59_BasicProfile = new BasicProfile { ReferenceKey = user_account_59.Key, ReferenceType = AccountType.UserAccount };
            var user_account_60_BasicProfile = new BasicProfile { ReferenceKey = user_account_60.Key, ReferenceType = AccountType.UserAccount };
            var user_account_61_BasicProfile = new BasicProfile { ReferenceKey = user_account_61.Key, ReferenceType = AccountType.UserAccount };
            var user_account_62_BasicProfile = new BasicProfile { ReferenceKey = user_account_62.Key, ReferenceType = AccountType.UserAccount };
            var user_account_63_BasicProfile = new BasicProfile { ReferenceKey = user_account_63.Key, ReferenceType = AccountType.UserAccount };
            var user_account_64_BasicProfile = new BasicProfile { ReferenceKey = user_account_64.Key, ReferenceType = AccountType.UserAccount };
            var user_account_65_BasicProfile = new BasicProfile { ReferenceKey = user_account_65.Key, ReferenceType = AccountType.UserAccount };
            var user_account_66_BasicProfile = new BasicProfile { ReferenceKey = user_account_66.Key, ReferenceType = AccountType.UserAccount };
            var user_account_67_BasicProfile = new BasicProfile { ReferenceKey = user_account_67.Key, ReferenceType = AccountType.UserAccount };
            var user_account_68_BasicProfile = new BasicProfile { ReferenceKey = user_account_68.Key, ReferenceType = AccountType.UserAccount };
           

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
            context.BasicProfiles.Add(user_account_41_BasicProfile);
            context.BasicProfiles.Add(user_account_42_BasicProfile);
            context.BasicProfiles.Add(user_account_43_BasicProfile);
            context.BasicProfiles.Add(user_account_44_BasicProfile);
            context.BasicProfiles.Add(user_account_45_BasicProfile);
            context.BasicProfiles.Add(user_account_46_BasicProfile);
            context.BasicProfiles.Add(user_account_47_BasicProfile);
            context.BasicProfiles.Add(user_account_48_BasicProfile);
            context.BasicProfiles.Add(user_account_49_BasicProfile);
            context.BasicProfiles.Add(user_account_50_BasicProfile);
            context.BasicProfiles.Add(user_account_51_BasicProfile);
            context.BasicProfiles.Add(user_account_52_BasicProfile);
            context.BasicProfiles.Add(user_account_53_BasicProfile);
            context.BasicProfiles.Add(user_account_54_BasicProfile);
            context.BasicProfiles.Add(user_account_55_BasicProfile);
            context.BasicProfiles.Add(user_account_56_BasicProfile);
            context.BasicProfiles.Add(user_account_57_BasicProfile);
            context.BasicProfiles.Add(user_account_58_BasicProfile);
            context.BasicProfiles.Add(user_account_59_BasicProfile);
            context.BasicProfiles.Add(user_account_60_BasicProfile);
            context.BasicProfiles.Add(user_account_61_BasicProfile);
            context.BasicProfiles.Add(user_account_62_BasicProfile);
            context.BasicProfiles.Add(user_account_63_BasicProfile);
            context.BasicProfiles.Add(user_account_64_BasicProfile);
            context.BasicProfiles.Add(user_account_65_BasicProfile);
            context.BasicProfiles.Add(user_account_66_BasicProfile);
            context.BasicProfiles.Add(user_account_67_BasicProfile);
            context.BasicProfiles.Add(user_account_68_BasicProfile);
         
            var rel_user1_user2 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_2, SCMRelationshipType = SCMRelationship.Upstream , IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user3 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_3, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user4 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_4, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user5 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_5, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user7 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_7, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user8 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_8, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user9 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_9, SCMRelationshipType = SCMRelationship.Downstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user10 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_10, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user11 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_11, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user12 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_12, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user13 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_13, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user17 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_17, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user18 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_18, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user19 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_19, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user20 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_20, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user23 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_23, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user27 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_27, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user31 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_31, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user32 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_32, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user1_user34 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_1, Receiver = user_account_34, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };

            var rel_user5_user6 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_5, Receiver = user_account_6, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };

            var rel_user13_user14 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_13, Receiver = user_account_14, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user13_user15 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_13, Receiver = user_account_15, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user13_user16 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_13, Receiver = user_account_16, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };


            var rel_user20_user21 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_20, Receiver = user_account_21, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user20_user22 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_20, Receiver = user_account_22, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };

            var rel_user23_user20 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_23, Receiver = user_account_20, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user23_user25 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_23, Receiver = user_account_25, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user23_user24 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_23, Receiver = user_account_24, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user23_user26 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_23, Receiver = user_account_26, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };

            var rel_user27_user20 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_27, Receiver = user_account_20, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user27_user23 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_27, Receiver = user_account_23, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user27_user26 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_27, Receiver = user_account_26, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user27_user28 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_27, Receiver = user_account_28, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user27_user29 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_27, Receiver = user_account_29, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user27_user30 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_27, Receiver = user_account_30, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };

            var rel_user30_user20 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_30, Receiver = user_account_20, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user30_user25 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_30, Receiver = user_account_25, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user30_user24 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_30, Receiver = user_account_26, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };

            var rel_user32_user20 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_32, Receiver = user_account_20, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };

            var rel_user35_user63 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_63, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user64 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_64, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user57 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_57, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user61 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_61, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user36 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_36, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user66 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_66, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user37 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_37, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user42 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_42, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user41 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_41, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user51 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_51, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user45 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_45, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user38 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_38, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user39 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_39, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user53 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_53, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };

            var rel_user57_user58 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_57, Receiver = user_account_58, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user57_user59 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_57, Receiver = user_account_59, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user57_user60 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_57, Receiver = user_account_60, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user57_user61 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_57, Receiver = user_account_61, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };

            var rel_user60_user61 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_60, Receiver = user_account_61, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };

            var rel_user61_user62 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_61, Receiver = user_account_62, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user66_user67 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_66, Receiver = user_account_67, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user35_user43 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_35, Receiver = user_account_43, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };

            var rel_user43_user48 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_43, Receiver = user_account_48, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user43_user49 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_43, Receiver = user_account_49, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user43_user54 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_43, Receiver = user_account_54, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user43_user40 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_43, Receiver = user_account_40, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user43_user46 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_43, Receiver = user_account_46, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user43_user47 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_43, Receiver = user_account_47, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user43_user52 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_43, Receiver = user_account_52, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user43_user65 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_43, Receiver = user_account_65, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user43_user68 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_43, Receiver = user_account_68, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };

            var rel_user68_user44 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_68, Receiver = user_account_44, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user54_user55 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_54, Receiver = user_account_55, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            var rel_user54_user56 = new FriendshipStateInfo { Key = Guid.NewGuid(), Action = FriendshipAction.Accept, Sender = user_account_54, Receiver = user_account_56, SCMRelationshipType = SCMRelationship.Upstream, IsActive = true, ActionDateTime = DateTime.Now };
            




            context.Friendships.Add(rel_user1_user2);
            context.Friendships.Add(rel_user1_user3);
            context.Friendships.Add(rel_user1_user4);
            context.Friendships.Add(rel_user1_user5);
            context.Friendships.Add(rel_user1_user7);
            context.Friendships.Add(rel_user1_user8);
            context.Friendships.Add(rel_user1_user9);
            context.Friendships.Add(rel_user1_user10);
            context.Friendships.Add(rel_user1_user11);
            context.Friendships.Add(rel_user1_user12);
            context.Friendships.Add(rel_user1_user13);
            context.Friendships.Add(rel_user1_user17);
            context.Friendships.Add(rel_user1_user18);
            context.Friendships.Add(rel_user1_user19);
            context.Friendships.Add(rel_user1_user20);
            context.Friendships.Add(rel_user1_user23);
            context.Friendships.Add(rel_user1_user27);
            context.Friendships.Add(rel_user1_user31);
            context.Friendships.Add(rel_user1_user32);
            context.Friendships.Add(rel_user1_user34);

            context.Friendships.Add(rel_user5_user6);

            context.Friendships.Add(rel_user13_user14);
            context.Friendships.Add(rel_user13_user15);
            context.Friendships.Add(rel_user13_user16);

            context.Friendships.Add(rel_user20_user21);
            context.Friendships.Add(rel_user20_user22);

            context.Friendships.Add(rel_user23_user20);
            context.Friendships.Add(rel_user23_user25);
            context.Friendships.Add(rel_user23_user24);
            context.Friendships.Add(rel_user23_user26);

            context.Friendships.Add(rel_user27_user20);
            context.Friendships.Add(rel_user27_user23);
            context.Friendships.Add(rel_user27_user26);
            context.Friendships.Add(rel_user27_user28);
            context.Friendships.Add(rel_user27_user29);
            context.Friendships.Add(rel_user27_user30);

            context.Friendships.Add(rel_user30_user20);
            context.Friendships.Add(rel_user30_user25);
            context.Friendships.Add(rel_user30_user24);

            context.Friendships.Add(rel_user32_user20);

            context.Friendships.Add(rel_user35_user63);
            context.Friendships.Add(rel_user35_user64);
            context.Friendships.Add(rel_user35_user57);
            context.Friendships.Add(rel_user35_user61);
            context.Friendships.Add(rel_user35_user36);
            context.Friendships.Add(rel_user35_user66);
            context.Friendships.Add(rel_user35_user37);
            context.Friendships.Add(rel_user35_user42);
            context.Friendships.Add(rel_user35_user41);
            context.Friendships.Add(rel_user35_user51);
            context.Friendships.Add(rel_user35_user45);
            context.Friendships.Add(rel_user35_user38);
            context.Friendships.Add(rel_user35_user39);
            context.Friendships.Add(rel_user35_user53);

            context.Friendships.Add(rel_user57_user58);
            context.Friendships.Add(rel_user57_user59);
            context.Friendships.Add(rel_user57_user60);
            context.Friendships.Add(rel_user57_user61);

            context.Friendships.Add(rel_user60_user61);

            context.Friendships.Add(rel_user61_user62);
            context.Friendships.Add(rel_user66_user67);
            context.Friendships.Add(rel_user35_user43);

            context.Friendships.Add(rel_user43_user48);
            context.Friendships.Add(rel_user43_user49);
            context.Friendships.Add(rel_user43_user54);
            context.Friendships.Add(rel_user43_user40);
            context.Friendships.Add(rel_user43_user46);
            context.Friendships.Add(rel_user43_user47);
            context.Friendships.Add(rel_user43_user52);
            context.Friendships.Add(rel_user43_user65);
            context.Friendships.Add(rel_user43_user68);

            context.Friendships.Add(rel_user68_user44);
            context.Friendships.Add(rel_user54_user55);
            context.Friendships.Add(rel_user54_user56);

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

            context.UserAccounts.Add(user_account_41);
            context.UserAccounts.Add(user_account_42);
            context.UserAccounts.Add(user_account_43);
            context.UserAccounts.Add(user_account_44);
            context.UserAccounts.Add(user_account_45);
            context.UserAccounts.Add(user_account_46);
            context.UserAccounts.Add(user_account_47);
            context.UserAccounts.Add(user_account_48);
            context.UserAccounts.Add(user_account_49);
            context.UserAccounts.Add(user_account_50);
            context.UserAccounts.Add(user_account_51);
            context.UserAccounts.Add(user_account_52);
            context.UserAccounts.Add(user_account_53);
            context.UserAccounts.Add(user_account_54);
            context.UserAccounts.Add(user_account_55);
            context.UserAccounts.Add(user_account_56);
            context.UserAccounts.Add(user_account_57);
            context.UserAccounts.Add(user_account_58);
            context.UserAccounts.Add(user_account_59);
            context.UserAccounts.Add(user_account_60);
            context.UserAccounts.Add(user_account_61);
            context.UserAccounts.Add(user_account_62);
            context.UserAccounts.Add(user_account_63);
            context.UserAccounts.Add(user_account_64);
            context.UserAccounts.Add(user_account_65);
            context.UserAccounts.Add(user_account_66);
            context.UserAccounts.Add(user_account_67);
            context.UserAccounts.Add(user_account_68);
             
            byte[] defaultGroupHeaderPicture = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.groupHeader  );
            byte[] defaultGroupProfilePicture = Utilities.ConvertImageToByteArray(FHNWPrototype.Infrastructure.Properties.Resources.groupProfile );

            var group105 = new Group { Key = new Guid("ACBCCE0E-7C9F-7186-99AA-1766F308EBB0"), Name = "Group 1", Description = "Group 1", HeaderPicture = defaultGroupHeaderPicture, ProfilePicture = defaultGroupProfilePicture };//, Administrator = brins }; //pricing strategies, format and reports
            var group106 = new Group { Key = new Guid("ACBCCE0E-99AA-4386-98AA-1458F308EBB1"), Name = "Group 2", Description = "Group 2", HeaderPicture = defaultGroupHeaderPicture, ProfilePicture = defaultGroupProfilePicture };//, Administrator = brins }; //pricing strategies, format and reports
            var group107 = new Group { Key = new Guid("ACBCCE0E-99AA-4386-98AA-1458F308EBB2"), Name = "Group 3", Description = "Group 3", HeaderPicture = defaultGroupHeaderPicture, ProfilePicture = defaultGroupProfilePicture };//, Administrator = brins }; //pricing strategies, format and reports
            
            context.Groups.Add(group105);
            context.Groups.Add(group106);
            context.Groups.Add(group107);

            var group105_BasicProfile = new BasicProfile { ReferenceKey=group105.Key , ReferenceType= AccountType.Group };
            var group106_BasicProfile = new BasicProfile { ReferenceKey = group106.Key, ReferenceType = AccountType.Group };
            var group107_BasicProfile = new BasicProfile { ReferenceKey = group107.Key, ReferenceType = AccountType.Group };

            context.BasicProfiles.Add(group105_BasicProfile);
            context.BasicProfiles.Add(group106_BasicProfile);
            context.BasicProfiles.Add(group107_BasicProfile);
          

            var memb_user61_group105 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E201"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group105, RequestorAccount = user_account_61 };
            var memb_user60_group105 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E202"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group105, RequestorAccount = user_account_60 };
            var memb_user57_group105 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E203"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group105, RequestorAccount = user_account_57 };
            var memb_user54_group105 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E204"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group105, RequestorAccount = user_account_54 };



            var memb_user26_group106 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E204"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group106, RequestorAccount = user_account_26 };
            var memb_user23_group106 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E205"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group106, RequestorAccount = user_account_23 };
            var memb_user27_group106 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E205"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group106, RequestorAccount = user_account_27 };
            var memb_user1_group106 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E205"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group106, RequestorAccount = user_account_1 };

            var memb_user27_group107 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E205"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group106, RequestorAccount = user_account_23 };
            var memb_user32_group107 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E205"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group106, RequestorAccount = user_account_27 };
            var memb_user33_group107 = new GroupMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E205"), GroupMembershipAction = GroupMembershipAction.Accept, RequestedGroup = group106, RequestorAccount = user_account_1 };
            

            context.GroupMemberships.Add(memb_user61_group105);
            context.GroupMemberships.Add(memb_user60_group105);
            context.GroupMemberships.Add(memb_user57_group105);
            context.GroupMemberships.Add(memb_user54_group105);

            context.GroupMemberships.Add(memb_user26_group106);
            context.GroupMemberships.Add(memb_user23_group106);
            context.GroupMemberships.Add(memb_user27_group106);
            context.GroupMemberships.Add(memb_user1_group106);


            context.GroupMemberships.Add(memb_user27_group107);
            context.GroupMemberships.Add(memb_user32_group107);
            context.GroupMemberships.Add(memb_user33_group107); 

            //var alliance98 = new Alliance { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E1"), Name = "Alliance98", Description = "Alliance98", Coordinator = organizationAccount69, HeaderPicture = null, ProfilePicture = null };
            //var alliance99 = new Alliance { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E2"), Name = "Alliance99", Description = "Alliance99", Coordinator = organizationAccount69, HeaderPicture = null, ProfilePicture = null };
            //var alliance100 = new Alliance { Key = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E1E3"), Name = "Alliance100", Description = "Alliance100", Coordinator = organizationAccount69, HeaderPicture = null, ProfilePicture = null };
           

            //context.Alliances.Add(alliance98);
            //context.Alliances.Add(alliance99);
            //context.Alliances.Add(alliance100);

            //var alliance98_BasicProfile = new BasicProfile { ReferenceKey=alliance98.Key, ReferenceType= AccountType.Alliance  };
            //var alliance99_BasicProfile = new BasicProfile  { ReferenceKey=alliance99.Key, ReferenceType= AccountType.Alliance  };
            //var alliance100_BasicProfile = new BasicProfile { ReferenceKey=alliance100.Key  , ReferenceType=AccountType.Alliance  };

            //context.BasicProfiles.Add(alliance98_BasicProfile);
            //context.BasicProfiles.Add(alliance99_BasicProfile);
            //context.BasicProfiles.Add(alliance100_BasicProfile);

            
            //var memb_organization69_alliance98 = new AllianceMembershipStateInfo { Key=new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D0"), AllianceMembershipAction=AllianceMembershipAction.Accept,  AllianceRequested=alliance98, OrganizationRequestor=organizationAccount69 };
            //var memb_organization70_alliance98 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D1"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance98, OrganizationRequestor = organizationAccount70 };
            //var memb_organization72_alliance98 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D1"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance98, OrganizationRequestor = organizationAccount72 };
            
 
            //var memb_organization69_alliance99 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D2"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance99, OrganizationRequestor = organizationAccount69 };
            //var memb_organization73_alliance99 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D3"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance99, OrganizationRequestor = organizationAccount73 };
            //var memb_organization76_alliance99 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D1"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance99, OrganizationRequestor = organizationAccount76 };
            
            //var memb_organization69_alliance100 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D4"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance100, OrganizationRequestor = organizationAccount69 };
            //var memb_organization81_alliance100 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D5"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance100, OrganizationRequestor = organizationAccount81 };
            //var memb_organization83_alliance100 = new AllianceMembershipStateInfo { Key = new Guid("ACBCCE0E-7C9F-4386-98AA-1458F308E1D6"), AllianceMembershipAction = AllianceMembershipAction.Accept, AllianceRequested = alliance100, OrganizationRequestor = organizationAccount83 };

            //context.AllianceMemberships.Add(memb_organization69_alliance98);
            //context.AllianceMemberships.Add(memb_organization70_alliance98);
            //context.AllianceMemberships.Add(memb_organization72_alliance98);

            //context.AllianceMemberships.Add(memb_organization69_alliance99);
            //context.AllianceMemberships.Add(memb_organization73_alliance99);
            //context.AllianceMemberships.Add(memb_organization76_alliance99);

            //context.AllianceMemberships.Add(memb_organization69_alliance100);
            //context.AllianceMemberships.Add(memb_organization81_alliance100);
            //context.AllianceMemberships.Add(memb_organization83_alliance100);
            
            var system_account_user1 = new SystemAccount() { Email = user_account_1.Email, Password = "login123", Holder=user_account_1_BasicProfile,   IsConfirmed = true, LastCheck=initialDate   };
            var system_account_user2 = new SystemAccount() { Email = user_account_2.Email, Password = "login123", Holder = user_account_2_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user3 = new SystemAccount() { Email = user_account_3.Email, Password = "login123", Holder = user_account_3_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user4 = new SystemAccount() { Email = user_account_4.Email, Password = "login123", Holder = user_account_4_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user5 = new SystemAccount() { Email = user_account_5.Email, Password = "login123", Holder = user_account_5_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user6 = new SystemAccount() { Email = user_account_6.Email, Password = "login123", Holder = user_account_6_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user7 = new SystemAccount() { Email = user_account_7.Email, Password = "login123", Holder = user_account_7_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user8 = new SystemAccount() { Email = user_account_8.Email, Password = "login123", Holder = user_account_8_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user9 = new SystemAccount() { Email = user_account_9.Email, Password = "login123", Holder = user_account_9_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user10 = new SystemAccount() { Email = user_account_10.Email, Password = "login123", Holder = user_account_10_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user11 = new SystemAccount() { Email = user_account_11.Email, Password = "login123", Holder = user_account_11_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user12 = new SystemAccount() { Email = user_account_12.Email, Password = "login123", Holder = user_account_12_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user13 = new SystemAccount() { Email = user_account_13.Email, Password = "login123", Holder = user_account_13_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user14 = new SystemAccount() { Email = user_account_14.Email, Password = "login123", Holder = user_account_14_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user15 = new SystemAccount() { Email = user_account_15.Email, Password = "login123", Holder = user_account_15_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user16 = new SystemAccount() { Email = user_account_16.Email, Password = "login123", Holder = user_account_16_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user17 = new SystemAccount() { Email = user_account_17.Email, Password = "login123", Holder = user_account_17_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user18 = new SystemAccount() { Email = user_account_18.Email, Password = "login123", Holder = user_account_18_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user19 = new SystemAccount() { Email = user_account_19.Email, Password = "login123", Holder = user_account_19_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user20 = new SystemAccount() { Email = user_account_20.Email, Password = "login123", Holder = user_account_20_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user21 = new SystemAccount() { Email = user_account_21.Email, Password = "login123", Holder = user_account_21_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user22 = new SystemAccount() { Email = user_account_22.Email, Password = "login123", Holder = user_account_22_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user23 = new SystemAccount() { Email = user_account_23.Email, Password = "login123", Holder = user_account_23_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user24 = new SystemAccount() { Email = user_account_24.Email, Password = "login123", Holder = user_account_24_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user25 = new SystemAccount() { Email = user_account_25.Email, Password = "login123", Holder = user_account_25_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user26 = new SystemAccount() { Email = user_account_26.Email, Password = "login123", Holder = user_account_26_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user27 = new SystemAccount() { Email = user_account_27.Email, Password = "login123", Holder = user_account_27_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user28 = new SystemAccount() { Email = user_account_28.Email, Password = "login123", Holder = user_account_28_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user29 = new SystemAccount() { Email = user_account_29.Email, Password = "login123", Holder = user_account_29_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user30 = new SystemAccount() { Email = user_account_30.Email, Password = "login123", Holder = user_account_30_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user31 = new SystemAccount() { Email = user_account_31.Email, Password = "login123", Holder = user_account_31_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user32 = new SystemAccount() { Email = user_account_32.Email, Password = "login123", Holder = user_account_32_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user33 = new SystemAccount() { Email = user_account_33.Email, Password = "login123", Holder = user_account_33_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user34 = new SystemAccount() { Email = user_account_34.Email, Password = "login123", Holder = user_account_34_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user35 = new SystemAccount() { Email = user_account_35.Email, Password = "login123", Holder = user_account_35_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user36 = new SystemAccount() { Email = user_account_36.Email, Password = "login123", Holder = user_account_36_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user37 = new SystemAccount() { Email = user_account_37.Email, Password = "login123", Holder = user_account_37_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user38 = new SystemAccount() { Email = user_account_38.Email, Password = "login123", Holder = user_account_38_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user39 = new SystemAccount() { Email = user_account_39.Email, Password = "login123", Holder = user_account_39_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user40 = new SystemAccount() { Email = user_account_40.Email, Password = "login123", Holder = user_account_40_BasicProfile, IsConfirmed = true, LastCheck = initialDate };

            var system_account_user41 = new SystemAccount() { Email = user_account_41.Email, Password = "login123", Holder = user_account_41_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user42 = new SystemAccount() { Email = user_account_42.Email, Password = "login123", Holder = user_account_42_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user43 = new SystemAccount() { Email = user_account_43.Email, Password = "login123", Holder = user_account_43_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user44 = new SystemAccount() { Email = user_account_44.Email, Password = "login123", Holder = user_account_44_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user45 = new SystemAccount() { Email = user_account_45.Email, Password = "login123", Holder = user_account_45_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user46 = new SystemAccount() { Email = user_account_46.Email, Password = "login123", Holder = user_account_46_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user47 = new SystemAccount() { Email = user_account_47.Email, Password = "login123", Holder = user_account_47_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user48 = new SystemAccount() { Email = user_account_48.Email, Password = "login123", Holder = user_account_48_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user49 = new SystemAccount() { Email = user_account_49.Email, Password = "login123", Holder = user_account_49_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user50 = new SystemAccount() { Email = user_account_50.Email, Password = "login123", Holder = user_account_50_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user51 = new SystemAccount() { Email = user_account_51.Email, Password = "login123", Holder = user_account_51_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user52 = new SystemAccount() { Email = user_account_52.Email, Password = "login123", Holder = user_account_52_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user53 = new SystemAccount() { Email = user_account_53.Email, Password = "login123", Holder = user_account_53_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user54 = new SystemAccount() { Email = user_account_54.Email, Password = "login123", Holder = user_account_54_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user55 = new SystemAccount() { Email = user_account_55.Email, Password = "login123", Holder = user_account_55_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user56 = new SystemAccount() { Email = user_account_56.Email, Password = "login123", Holder = user_account_56_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user57 = new SystemAccount() { Email = user_account_57.Email, Password = "login123", Holder = user_account_57_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user58 = new SystemAccount() { Email = user_account_58.Email, Password = "login123", Holder = user_account_58_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user59 = new SystemAccount() { Email = user_account_59.Email, Password = "login123", Holder = user_account_59_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user60 = new SystemAccount() { Email = user_account_60.Email, Password = "login123", Holder = user_account_60_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user61 = new SystemAccount() { Email = user_account_61.Email, Password = "login123", Holder = user_account_61_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user62 = new SystemAccount() { Email = user_account_62.Email, Password = "login123", Holder = user_account_62_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user63 = new SystemAccount() { Email = user_account_63.Email, Password = "login123", Holder = user_account_63_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user64 = new SystemAccount() { Email = user_account_64.Email, Password = "login123", Holder = user_account_64_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user65 = new SystemAccount() { Email = user_account_65.Email, Password = "login123", Holder = user_account_65_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user66 = new SystemAccount() { Email = user_account_66.Email, Password = "login123", Holder = user_account_66_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user67 = new SystemAccount() { Email = user_account_67.Email, Password = "login123", Holder = user_account_67_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_user68 = new SystemAccount() { Email = user_account_68.Email, Password = "login123", Holder = user_account_68_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
           

            var system_account_organization69 = new SystemAccount() { Email = "admin@org69.com", Password = "login123", Holder = organization69_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization70 = new SystemAccount() { Email = "admin@org70.com", Password = "login123", Holder = organization70_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization71 = new SystemAccount() { Email = "admin@org71.com", Password = "login123", Holder = organization71_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization72 = new SystemAccount() { Email = "admin@org72.com", Password = "login123", Holder = organization72_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization73 = new SystemAccount() { Email = "admin@org73.com", Password = "login123", Holder = organization73_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization74 = new SystemAccount() { Email = "admin@org74.com", Password = "login123", Holder = organization74_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization75 = new SystemAccount() { Email = "admin@org75.com", Password = "login123", Holder = organization75_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization76 = new SystemAccount() { Email = "admin@org76.com", Password = "login123", Holder = organization76_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization77 = new SystemAccount() { Email = "admin@org77.com", Password = "login123", Holder = organization77_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization78 = new SystemAccount() { Email = "admin@org78.com", Password = "login123", Holder = organization78_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization79 = new SystemAccount() { Email = "admin@org79.com", Password = "login123", Holder = organization79_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization80 = new SystemAccount() { Email = "admin@org80.com", Password = "login123", Holder = organization80_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization81 = new SystemAccount() { Email = "admin@org81.com", Password = "login123", Holder = organization81_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization82 = new SystemAccount() { Email = "admin@org82.com", Password = "login123", Holder = organization82_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization83 = new SystemAccount() { Email = "admin@org83.com", Password = "login123", Holder = organization83_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization84 = new SystemAccount() { Email = "admin@org84.com", Password = "login123", Holder = organization84_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization85 = new SystemAccount() { Email = "admin@org85.com", Password = "login123", Holder = organization85_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization86 = new SystemAccount() { Email = "admin@org86.com", Password = "login123", Holder = organization86_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization87 = new SystemAccount() { Email = "admin@org87.com", Password = "login123", Holder = organization87_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization88 = new SystemAccount() { Email = "admin@org88.com", Password = "login123", Holder = organization88_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization89 = new SystemAccount() { Email = "admin@org89.com", Password = "login123", Holder = organization89_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization90 = new SystemAccount() { Email = "admin@org90.com", Password = "login123", Holder = organization90_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization91 = new SystemAccount() { Email = "admin@org91.com", Password = "login123", Holder = organization91_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization92 = new SystemAccount() { Email = "admin@org92.com", Password = "login123", Holder = organization92_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization93 = new SystemAccount() { Email = "admin@org93.com", Password = "login123", Holder = organization93_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization94 = new SystemAccount() { Email = "admin@org94.com", Password = "login123", Holder = organization94_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization95 = new SystemAccount() { Email = "admin@org95.com", Password = "login123", Holder = organization95_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization96 = new SystemAccount() { Email = "admin@org96.com", Password = "login123", Holder = organization96_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization97 = new SystemAccount() { Email = "admin@org97.com", Password = "login123", Holder = organization97_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization98 = new SystemAccount() { Email = "admin@org98.com", Password = "login123", Holder = organization98_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization99 = new SystemAccount() { Email = "admin@org99.com", Password = "login123", Holder = organization99_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization100 = new SystemAccount() { Email = "admin@org100.com", Password = "login123", Holder = organization100_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization101 = new SystemAccount() { Email = "admin@org101.com", Password = "login123", Holder = organization101_BasicProfile, IsConfirmed = true, LastCheck = initialDate };
            var system_account_organization102 = new SystemAccount() { Email = "admin@org102.com", Password = "login123", Holder = organization102_BasicProfile, IsConfirmed = true, LastCheck = initialDate };


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

            context.SystemAccounts.Add(system_account_user41);
            context.SystemAccounts.Add(system_account_user42);
            context.SystemAccounts.Add(system_account_user43);
            context.SystemAccounts.Add(system_account_user44);
            context.SystemAccounts.Add(system_account_user45);
            context.SystemAccounts.Add(system_account_user46);
            context.SystemAccounts.Add(system_account_user47);
            context.SystemAccounts.Add(system_account_user48);
            context.SystemAccounts.Add(system_account_user49);
            context.SystemAccounts.Add(system_account_user50);
            context.SystemAccounts.Add(system_account_user51);
            context.SystemAccounts.Add(system_account_user52);
            context.SystemAccounts.Add(system_account_user53);
            context.SystemAccounts.Add(system_account_user54);
            context.SystemAccounts.Add(system_account_user55);
            context.SystemAccounts.Add(system_account_user56);
            context.SystemAccounts.Add(system_account_user57);
            context.SystemAccounts.Add(system_account_user58);
            context.SystemAccounts.Add(system_account_user59);
            context.SystemAccounts.Add(system_account_user60);
            context.SystemAccounts.Add(system_account_user61);
            context.SystemAccounts.Add(system_account_user62);
            context.SystemAccounts.Add(system_account_user63);
            context.SystemAccounts.Add(system_account_user64);
            context.SystemAccounts.Add(system_account_user65);
            context.SystemAccounts.Add(system_account_user66);
            context.SystemAccounts.Add(system_account_user67);
            context.SystemAccounts.Add(system_account_user68);
            

            context.SystemAccounts.Add(system_account_organization69);
            context.SystemAccounts.Add(system_account_organization70);
            context.SystemAccounts.Add(system_account_organization71);
            context.SystemAccounts.Add(system_account_organization72);
            context.SystemAccounts.Add(system_account_organization73);
            context.SystemAccounts.Add(system_account_organization74);
            context.SystemAccounts.Add(system_account_organization75);
            context.SystemAccounts.Add(system_account_organization76);
            context.SystemAccounts.Add(system_account_organization77);
            context.SystemAccounts.Add(system_account_organization78);
            context.SystemAccounts.Add(system_account_organization79);
            context.SystemAccounts.Add(system_account_organization80);
            context.SystemAccounts.Add(system_account_organization81);
            context.SystemAccounts.Add(system_account_organization82);
            context.SystemAccounts.Add(system_account_organization83);
            context.SystemAccounts.Add(system_account_organization84);
            context.SystemAccounts.Add(system_account_organization85);
            context.SystemAccounts.Add(system_account_organization86);
            context.SystemAccounts.Add(system_account_organization87);
            context.SystemAccounts.Add(system_account_organization88);
            context.SystemAccounts.Add(system_account_organization89);
            context.SystemAccounts.Add(system_account_organization90);
            context.SystemAccounts.Add(system_account_organization91);
            context.SystemAccounts.Add(system_account_organization92);
            context.SystemAccounts.Add(system_account_organization93);
            context.SystemAccounts.Add(system_account_organization94);
            context.SystemAccounts.Add(system_account_organization95);
            context.SystemAccounts.Add(system_account_organization96);
            context.SystemAccounts.Add(system_account_organization97);
            context.SystemAccounts.Add(system_account_organization98);
            context.SystemAccounts.Add(system_account_organization99);
            context.SystemAccounts.Add(system_account_organization100);
            context.SystemAccounts.Add(system_account_organization101);
            context.SystemAccounts.Add(system_account_organization102);


            var wall_user1 = new ContentStream() { Key = Guid.NewGuid(), Owner=user_account_1_BasicProfile };
            var wall_user2 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_2_BasicProfile };
            var wall_user3 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_3_BasicProfile };
            var wall_user4 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_4_BasicProfile };
            var wall_user5 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_5_BasicProfile };
            var wall_user6 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_6_BasicProfile };
            var wall_user7 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_7_BasicProfile };
            var wall_user8 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_8_BasicProfile };
            var wall_user9 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_9_BasicProfile };
            var wall_user10 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_10_BasicProfile };
            var wall_user11 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_11_BasicProfile };
            var wall_user12 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_12_BasicProfile };
            var wall_user13 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_13_BasicProfile };
            var wall_user14 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_14_BasicProfile };
            var wall_user15 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_15_BasicProfile };
            var wall_user16 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_16_BasicProfile };
            var wall_user17 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_17_BasicProfile };
            var wall_user18 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_18_BasicProfile };
            var wall_user19 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_19_BasicProfile };
            var wall_user20 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_20_BasicProfile };
            var wall_user21 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_21_BasicProfile };
            var wall_user22 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_22_BasicProfile };
            var wall_user23 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_23_BasicProfile };
            var wall_user24 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_24_BasicProfile };
            var wall_user25 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_25_BasicProfile };
            var wall_user26 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_26_BasicProfile };
            var wall_user27 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_27_BasicProfile };
            var wall_user28 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_28_BasicProfile };
            var wall_user29 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_29_BasicProfile };
            var wall_user30 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_30_BasicProfile };
            var wall_user31 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_31_BasicProfile };
            var wall_user32 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_32_BasicProfile };
            var wall_user33 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_33_BasicProfile };
            var wall_user34 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_34_BasicProfile };
            var wall_user35 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_35_BasicProfile };
            var wall_user36 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_36_BasicProfile };
            var wall_user37 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_37_BasicProfile };
            var wall_user38 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_38_BasicProfile };
            var wall_user39 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_39_BasicProfile };
            var wall_user40 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_40_BasicProfile };

            var wall_user41 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_41_BasicProfile };
            var wall_user42 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_42_BasicProfile };
            var wall_user43 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_43_BasicProfile };
            var wall_user44 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_44_BasicProfile };
            var wall_user45 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_45_BasicProfile };
            var wall_user46 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_46_BasicProfile };
            var wall_user47 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_47_BasicProfile };
            var wall_user48 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_48_BasicProfile };
            var wall_user49 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_49_BasicProfile };
            var wall_user50 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_50_BasicProfile };
            var wall_user51 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_51_BasicProfile };
            var wall_user52 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_52_BasicProfile };
            var wall_user53 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_53_BasicProfile };
            var wall_user54 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_54_BasicProfile };
            var wall_user55 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_55_BasicProfile };
            var wall_user56 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_56_BasicProfile };
            var wall_user57 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_57_BasicProfile };
            var wall_user58 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_58_BasicProfile };
            var wall_user59 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_59_BasicProfile };
            var wall_user60 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_60_BasicProfile };
            var wall_user61 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_61_BasicProfile };
            var wall_user62 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_62_BasicProfile };
            var wall_user63 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_63_BasicProfile };
            var wall_user64 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_64_BasicProfile };
            var wall_user65 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_65_BasicProfile };
            var wall_user66 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_66_BasicProfile };
            var wall_user67 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_67_BasicProfile };
            var wall_user68 = new ContentStream() { Key = Guid.NewGuid(), Owner = user_account_68_BasicProfile };

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

            context.ContentStreams.Add(wall_user41);
            context.ContentStreams.Add(wall_user42);
            context.ContentStreams.Add(wall_user43);
            context.ContentStreams.Add(wall_user44);
            context.ContentStreams.Add(wall_user45);
            context.ContentStreams.Add(wall_user46);
            context.ContentStreams.Add(wall_user47);
            context.ContentStreams.Add(wall_user48);
            context.ContentStreams.Add(wall_user49);
            context.ContentStreams.Add(wall_user50);
            context.ContentStreams.Add(wall_user51);
            context.ContentStreams.Add(wall_user52);
            context.ContentStreams.Add(wall_user53);
            context.ContentStreams.Add(wall_user54);
            context.ContentStreams.Add(wall_user55);
            context.ContentStreams.Add(wall_user56);
            context.ContentStreams.Add(wall_user57);
            context.ContentStreams.Add(wall_user58);
            context.ContentStreams.Add(wall_user59);
            context.ContentStreams.Add(wall_user60);
            context.ContentStreams.Add(wall_user61);
            context.ContentStreams.Add(wall_user62);
            context.ContentStreams.Add(wall_user63);
            context.ContentStreams.Add(wall_user64);
            context.ContentStreams.Add(wall_user65);
            context.ContentStreams.Add(wall_user66);
            context.ContentStreams.Add(wall_user67);
            context.ContentStreams.Add(wall_user68);


            var wall_organization69 = new ContentStream() { Key = Guid.NewGuid(), Owner=organization69_BasicProfile   };
            var wall_organization70 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization70_BasicProfile };
            var wall_organization71 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization71_BasicProfile };
            var wall_organization72 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization72_BasicProfile };
            var wall_organization73 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization73_BasicProfile };
            var wall_organization74 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization74_BasicProfile };
            var wall_organization75 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization75_BasicProfile };
            var wall_organization76 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization76_BasicProfile };
            var wall_organization77 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization77_BasicProfile };
            var wall_organization78 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization78_BasicProfile };
            var wall_organization79 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization79_BasicProfile };
            var wall_organization80 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization80_BasicProfile };
            var wall_organization81 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization81_BasicProfile };
            var wall_organization82 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization82_BasicProfile };
            var wall_organization83 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization83_BasicProfile };
            var wall_organization84 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization84_BasicProfile };
            var wall_organization85 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization85_BasicProfile };
            var wall_organization86 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization86_BasicProfile };
            var wall_organization87 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization87_BasicProfile };
            var wall_organization88 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization88_BasicProfile };
            var wall_organization89 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization89_BasicProfile };
            var wall_organization90 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization90_BasicProfile };
            var wall_organization91 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization91_BasicProfile };
            var wall_organization92 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization92_BasicProfile };
            var wall_organization93 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization93_BasicProfile };
            var wall_organization94 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization94_BasicProfile };
            var wall_organization95 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization95_BasicProfile };
            var wall_organization96 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization96_BasicProfile };
            var wall_organization97 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization97_BasicProfile };
            var wall_organization98 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization98_BasicProfile };
            var wall_organization99 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization99_BasicProfile };
            var wall_organization100 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization100_BasicProfile };
            var wall_organization101 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization101_BasicProfile };
            var wall_organization102 = new ContentStream() { Key = Guid.NewGuid(), Owner = organization102_BasicProfile };


            context.ContentStreams.Add(wall_organization69);
            context.ContentStreams.Add(wall_organization70);
            context.ContentStreams.Add(wall_organization71);
            context.ContentStreams.Add(wall_organization72);
            context.ContentStreams.Add(wall_organization73);
            context.ContentStreams.Add(wall_organization74);
            context.ContentStreams.Add(wall_organization75);
            context.ContentStreams.Add(wall_organization76);
            context.ContentStreams.Add(wall_organization77);
            context.ContentStreams.Add(wall_organization78);
            context.ContentStreams.Add(wall_organization79);
            context.ContentStreams.Add(wall_organization80);
            context.ContentStreams.Add(wall_organization81);
            context.ContentStreams.Add(wall_organization82);
            context.ContentStreams.Add(wall_organization83);
            context.ContentStreams.Add(wall_organization84);
            context.ContentStreams.Add(wall_organization85);
            context.ContentStreams.Add(wall_organization86);
            context.ContentStreams.Add(wall_organization87);
            context.ContentStreams.Add(wall_organization88);
            context.ContentStreams.Add(wall_organization89);
            context.ContentStreams.Add(wall_organization90);
            context.ContentStreams.Add(wall_organization91);
            context.ContentStreams.Add(wall_organization92);
            context.ContentStreams.Add(wall_organization93);
            context.ContentStreams.Add(wall_organization94);
            context.ContentStreams.Add(wall_organization95);
            context.ContentStreams.Add(wall_organization96);
            context.ContentStreams.Add(wall_organization97);
            context.ContentStreams.Add(wall_organization98);
            context.ContentStreams.Add(wall_organization99);
            context.ContentStreams.Add(wall_organization100);
            context.ContentStreams.Add(wall_organization101);
            context.ContentStreams.Add(wall_organization102);

             
            var wall_group105 = new ContentStream { Key = Guid.NewGuid(), Owner = group105_BasicProfile };
            var wall_group106 = new ContentStream { Key = Guid.NewGuid(), Owner = group106_BasicProfile };
            
            context.ContentStreams.Add(wall_group105);
            context.ContentStreams.Add(wall_group106);
         
            //var wall_alliance98 = new ContentStream { Key = new Guid("DDDEEEFF-FAAA-1289-98BA-123767869C00"), Owner = alliance98_BasicProfile };
            //var wall_alliance99 = new ContentStream { Key = new Guid("DDDEEEFF-FAAA-1289-98BA-123767869C01"), Owner = alliance99_BasicProfile };
            //var wall_alliance100 = new ContentStream { Key = new Guid("DDDEEEFF-FAAA-1289-98BA-123767869C02"), Owner = alliance100_BasicProfile };


            //context.ContentStreams.Add(wall_alliance98);
            //context.ContentStreams.Add(wall_alliance99);
            //context.ContentStreams.Add(wall_alliance100);

             

            var tag103 = new Tag { Key = new Guid("AFBFCFDF-AAAA-0123-ABCD-123767869000"), Name = "#Contract2013" };
            var tag104 = new Tag { Key = new Guid("AFBFCFDF-AAAA-0123-ABCD-123767869001"), Name = "#MaterialFlow" };
 

            context.Tags.Add(tag103);
            context.Tags.Add(tag104);
          

            var suscription_user1_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_1_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user2_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_2_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user3_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_3_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user4_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_4_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user5_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_5_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user6_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_6_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user7_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_7_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user8_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_8_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user9_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_9_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user10_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_10_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user11_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_11_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user12_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_12_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user13_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_13_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user14_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_14_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user15_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_15_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user16_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_16_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user17_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_17_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user18_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_18_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user19_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_19_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user20_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_20_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user21_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_21_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user22_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_22_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user23_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_23_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user24_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_24_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user25_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_25_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user26_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_26_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user27_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_27_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user28_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_28_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user29_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_29_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user30_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_30_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user31_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_31_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user32_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_32_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user33_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_33_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user34_tag103 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_34_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag103.Key };
            var suscription_user35_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_35_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user36_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_36_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user37_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_37_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user38_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_38_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user39_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_39_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user40_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_40_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user41_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_41_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user42_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_42_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user43_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_43_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user44_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_44_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user45_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_45_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user46_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_46_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user47_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_47_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user48_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_48_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user49_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_49_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user50_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_50_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user51_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_51_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user52_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_52_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user53_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_53_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user54_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_54_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user55_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_55_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user56_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_56_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user57_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_57_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user58_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_58_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user59_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_59_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user60_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_60_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user61_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_61_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user62_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_62_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user63_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_63_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user64_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_64_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user65_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_65_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user66_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_66_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user67_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_67_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
            var suscription_user68_tag104 = new Suscription { Key = Guid.NewGuid(), Suscriber = user_account_68_BasicProfile, Type = SuscriptionType.TweetOnTagIBelong, ReferencePoint = tag104.Key };
           


            context.Suscriptions.Add(suscription_user1_tag103);
            context.Suscriptions.Add(suscription_user2_tag103);
            context.Suscriptions.Add(suscription_user3_tag103);
            context.Suscriptions.Add(suscription_user4_tag103);
            context.Suscriptions.Add(suscription_user5_tag103);
            context.Suscriptions.Add(suscription_user6_tag103);
            context.Suscriptions.Add(suscription_user7_tag103);
            context.Suscriptions.Add(suscription_user8_tag103);
            context.Suscriptions.Add(suscription_user9_tag103);
            context.Suscriptions.Add(suscription_user10_tag103);
            context.Suscriptions.Add(suscription_user11_tag103);
            context.Suscriptions.Add(suscription_user12_tag103);
            context.Suscriptions.Add(suscription_user13_tag103);
            context.Suscriptions.Add(suscription_user14_tag103);
            context.Suscriptions.Add(suscription_user15_tag103);
            context.Suscriptions.Add(suscription_user16_tag103);
            context.Suscriptions.Add(suscription_user17_tag103);
            context.Suscriptions.Add(suscription_user18_tag103);
            context.Suscriptions.Add(suscription_user19_tag103);
            context.Suscriptions.Add(suscription_user20_tag103);
            context.Suscriptions.Add(suscription_user21_tag103);
            context.Suscriptions.Add(suscription_user22_tag103);
            context.Suscriptions.Add(suscription_user23_tag103);
            context.Suscriptions.Add(suscription_user24_tag103);
            context.Suscriptions.Add(suscription_user25_tag103);
            context.Suscriptions.Add(suscription_user26_tag103);
            context.Suscriptions.Add(suscription_user27_tag103);
            context.Suscriptions.Add(suscription_user28_tag103);
            context.Suscriptions.Add(suscription_user29_tag103);
            context.Suscriptions.Add(suscription_user30_tag103);
            context.Suscriptions.Add(suscription_user31_tag103);
            context.Suscriptions.Add(suscription_user32_tag103);
            context.Suscriptions.Add(suscription_user33_tag103);
            context.Suscriptions.Add(suscription_user34_tag103);

            context.Suscriptions.Add(suscription_user35_tag104);
            context.Suscriptions.Add(suscription_user36_tag104);
            context.Suscriptions.Add(suscription_user37_tag104);
            context.Suscriptions.Add(suscription_user38_tag104);
            context.Suscriptions.Add(suscription_user39_tag104);
            context.Suscriptions.Add(suscription_user40_tag104);
            context.Suscriptions.Add(suscription_user41_tag104);
            context.Suscriptions.Add(suscription_user42_tag104);
            context.Suscriptions.Add(suscription_user43_tag104);
            context.Suscriptions.Add(suscription_user44_tag104);
            context.Suscriptions.Add(suscription_user45_tag104);
            context.Suscriptions.Add(suscription_user46_tag104);
            context.Suscriptions.Add(suscription_user47_tag104);
            context.Suscriptions.Add(suscription_user48_tag104);
            context.Suscriptions.Add(suscription_user49_tag104);
            context.Suscriptions.Add(suscription_user50_tag104);
            context.Suscriptions.Add(suscription_user51_tag104);
            context.Suscriptions.Add(suscription_user52_tag104);
            context.Suscriptions.Add(suscription_user53_tag104);
            context.Suscriptions.Add(suscription_user54_tag104);
            context.Suscriptions.Add(suscription_user55_tag104);
            context.Suscriptions.Add(suscription_user56_tag104);
            context.Suscriptions.Add(suscription_user57_tag104);
            context.Suscriptions.Add(suscription_user58_tag104);
            context.Suscriptions.Add(suscription_user59_tag104);
            context.Suscriptions.Add(suscription_user60_tag104);
            context.Suscriptions.Add(suscription_user61_tag104);
            context.Suscriptions.Add(suscription_user62_tag104);
            context.Suscriptions.Add(suscription_user63_tag104);
            context.Suscriptions.Add(suscription_user64_tag104);
            context.Suscriptions.Add(suscription_user65_tag104);
            context.Suscriptions.Add(suscription_user66_tag104);
            context.Suscriptions.Add(suscription_user67_tag104);
            context.Suscriptions.Add(suscription_user68_tag104);

        }

    }
}
