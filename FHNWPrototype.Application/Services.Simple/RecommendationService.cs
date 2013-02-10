using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{

    public class CypherQuery
    {
        public string query { get; set; }

        [DisplayName("params")]
        public string parameters { get; set; }
    }

    public class CypherQueryResults
    {
        public List<String> columns { get; set; }
        public List<List<String>> data { get; set; }
    }

    public class Node
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
    }

    public static class RecommendationService
    {


        public static CompleteProfile  GetWorkContactSuggestionByBasicProfile(string referenceKey){

           var _address = "http://ef1ead3b4.hosted.neo4j.org:7968";
           var _host = "ef1ead3b4.hosted.neo4j.org:7968";
           var _content = "application/json";
           var  _authorization = "Basic NmI5YzY4M2VkOmI2MzZjMjgxOA==";
           RestClient client = new RestClient(_address);

            CompleteProfile profile = null;

            List<Node> result = new List<Node>();

            var request = new RestRequest();

            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;

            request.Resource = "/db/data/cypher";
            //request.AddHeader("Content-Length", requestText.Length.ToString());
            request.AddHeader("Host", _host);
            request.AddHeader("Accept", _content);
            request.AddHeader("Content-Type", _content);
            request.AddHeader("Authorization", _authorization);

            CypherQuery query = new CypherQuery();

            query.query = "START origin=node(" + "1" + ") MATCH coworker-[:works_at]->company<-[:works_at]-origin " +
                          "RETURN id(coworker) as Id, coworker.Key as Key, coworker.Name as Name " +
                          "LIMIT 1";

            //query.query = "START origin=node(" + "1" + ") MATCH origin-[:has_downstream_friend|has_upstream_friend*1..3]-my_partner, " +
            //            "my_partner-[:is_known_for]->tag," + " coworker-[:works_at]->company<-[:works_at]-origin, " +
            //            "my_coworkers_partner-[:has_downstream_friend|has_upstream_friend*1..3]-coworker, " +
            //            "tag<-[:is_known_for]-my_coworkers_partner " +
            //            "RETURN id(coworker) as Id, coworker.Key as Key, coworker.Name as Name " +
            //            "LIMIT 1";

            request.AddBody(query);

            var response = client.Execute<CypherQueryResults>(request);

            var thisColumns = response.Data.columns;
            var thisData = response.Data.data;

            foreach (var l in thisData)
            {
                result.Add(new Node { Id = Int32.Parse(l[0]), Key = l[1], Name = l[2] });
            }

            if (result.Count > 0)
            {
                profile = new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = new Guid(result[0].Key), ReferenceType = AccountType.UserAccount }, FullName = result[0].Name, Description1 = "", Description2 = "" };
            }

            return profile;
        }

        public static CompleteProfile GetPartnershipContactSuggestionByBasicProfile(string referenceKey)
        {
            var _address = "http://ef1ead3b4.hosted.neo4j.org:7968";
            var _host = "ef1ead3b4.hosted.neo4j.org:7968";
            var _content = "application/json";
            var _authorization = "Basic NmI5YzY4M2VkOmI2MzZjMjgxOA==";
            RestClient client = new RestClient(_address);

            CompleteProfile profile = null;

            List<Node> result = new List<Node>();

            var request = new RestRequest();

            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;

            request.Resource = "/db/data/cypher";
            //request.AddHeader("Content-Length", requestText.Length.ToString());
            request.AddHeader("Host", _host);
            request.AddHeader("Accept", _content);
            request.AddHeader("Content-Type", _content);
            request.AddHeader("Authorization", _authorization);

            CypherQuery query = new CypherQuery();

            query.query = "START origin=node(" + "1" + ") " +
                            "MATCH origin-[:has_downstream_friend|has_upstream_friend]-my_partner, " +
                            "my_partner-[:is_known_for]->tag " +
                            "RETURN id(my_partner) as Id, my_partner.Key? as Key, my_partner.Name? as Name " +
                            "LIMIT 1";

            //query.query = "START origin=node(" + "61" + ") " +
            //    "MATCH origin-[:has_downstream_friend|has_upstream_friend]-my_partner, " +
            //    "my_partner-[:is_known_for]->tag, " +
            //    "coworker-[:works_at]->company<-[:works_at]-origin, " +
            //    "my_coworkers_partner-[:has_downstream_friend|has_upstream_friend]-coworker, " +
            //    "tag<-[:is_known_for]-my_coworkers_partner " +
            //    "RETURN id(my_partner) as Id, my_partner.Key? as Key, my_partner.Name? as Name " +
            //    "LIMIT 1";


            request.AddBody(query);

            var response = client.Execute<CypherQueryResults>(request);

            var thisColumns = response.Data.columns;
            var thisData = response.Data.data;

            foreach (var l in thisData)
            {
                result.Add(new Node { Id = Int32.Parse(l[0]), Key = l[1], Name = l[2] });
            }
            if (result.Count > 0)
            {
                profile = new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = new Guid(result[0].Key), ReferenceType = AccountType.UserAccount }, FullName = result[0].Name, Description1 = "", Description2 = "" };
            }
            return profile;
        }


        public static CompleteProfile GetGroupSuggestionByBasicProfile(string referenceKey)
        {
            var _address = "http://ef1ead3b4.hosted.neo4j.org:7968";
            var _host = "ef1ead3b4.hosted.neo4j.org:7968";
            var _content = "application/json";
            var _authorization = "Basic NmI5YzY4M2VkOmI2MzZjMjgxOA==";
            RestClient client = new RestClient(_address);

            CompleteProfile profile = null;

            List<Node> result = new List<Node>();

            var request = new RestRequest();

            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;

            request.Resource = "/db/data/cypher";
            //request.AddHeader("Content-Length", requestText.Length.ToString());
            request.AddHeader("Host", _host);
            request.AddHeader("Accept", _content);
            request.AddHeader("Content-Type", _content);
            request.AddHeader("Authorization", _authorization);

            CypherQuery query = new CypherQuery();

            query.query = "START origin=node(" + "1" + ") " +
                      "MATCH origin-[:is_known_for]->tag, " +
                      "tag<-[:is_known_for]-colleague, " +
                      "colleague-[:is_group_member_of]-group " +
                      "WHERE NOT (group<-[:is_group_member_of]-origin) " +
                      "RETURN DISTINCT id(group) as Id, group.Key? as Key, group.Name? as Name " +
                      "LIMIT 1";

            request.AddBody(query);

            var response = client.Execute<CypherQueryResults>(request);

            var thisColumns = response.Data.columns;
            var thisData = response.Data.data;

            foreach (var l in thisData)
            {
                result.Add(new Node { Id = Int32.Parse(l[0]), Key = l[1], Name = l[2] });
            }

            if (result.Count > 0)
            {
                profile = new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = new Guid(result[0].Key), ReferenceType = AccountType.Group  }, FullName = result[0].Name, Description1 = "", Description2 = "" };
            }
            return profile;
        }
         
    }
}
