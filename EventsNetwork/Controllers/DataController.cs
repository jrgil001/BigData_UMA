using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EventsNetwork
{
    public class DataController : ApiController
    {
        Random random;

        public DataController()
        {
            random = new Random();
        }

        public async Task<string> GenerateData()
        {
            string json = "";

            
            using (StreamWriter writetext = new StreamWriter("C:/Users/joser/Desktop/comments_type_one_simple.txt"))
            {
                for (int i = 0; i < 2000000; i++)
                {
                    json = CreateJsonType_1_1();
                    writetext.WriteLine(json);
                }                
            }

            return json;
        }

        public async Task<string> GenerateDataCase2()
        {
            string json = "";


            using (StreamWriter writetext = new StreamWriter("C:/Users/joser/Desktop/comments_type_two.txt"))
            {
                for (int i = 0; i < 1; i++)
                {
                    json = CreateJsonType_2();
                    writetext.WriteLine(json);
                }
            }

            return json;
        }
        
        private string CreateJsonType_1_1()
        {
            Comment_Type_1_1 comment1_1 = new Comment_Type_1_1();
            comment1_1._id = CreateRandomValue(0, 999999999).ToString();
            comment1_1.discussion_id = CreateRandomValue(0, 999999999).ToString();
            comment1_1.slug = CreateRandomSlug();
            comment1_1.posted = CreateRandomDate().ToString();
            comment1_1.author = CreateAuthorsJson();
            comment1_1.text = CreateRandomValueFromList(Constants.texts);

            string json = JsonConvert.SerializeObject(comment1_1);

            return json;
        }

        private string CreateJsonType_2()
        {
            Comment_Type_2 comment2 = CreateCommentType_2();

            string json = JsonConvert.SerializeObject(comment2);

            return json;
        }

        private Comment_Type_2 CreateCommentType_2()
        {
            Comment_Type_2 comment2 = new Comment_Type_2();
            comment2._id = CreateRandomValue(0, 999999999).ToString();
            comment2.discussion_id = CreateRandomValue(0, 999999999).ToString();
            comment2.slug = CreateRandomSlug();
            comment2.posted = CreateRandomDate().ToString();
            comment2.author = CreateAuthorsJson();
            comment2.text = CreateRandomValueFromList(Constants.texts);
            comment2.replies = CreateRepliesJson();
            
            return comment2;
        }

        private Author [] CreateAuthorsJson()
        {
            int numberOfAuthors = CreateRandomValue(1, 5);
            Author [] authors = new Author [numberOfAuthors];

            for (int i = 0; i < numberOfAuthors; i++)
            {
                authors[i] = CreateAuthorJson();
            }
            
            return authors;
        }

        private Author CreateAuthorJson()
        {
            Author author = new Author();
            author._id = CreateRandomValue(0, 999999999).ToString();
            author.name = CreateRandomValueFromList(Constants.names);

            return author;
        }

        private string CreateRandomValueFromList(string[] values)
        {           
            int start2 = random.Next(0, values.Length);
            return values[start2];
        }

        private int CreateRandomValue(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
        
        private DateTime CreateRandomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        private string CreateRandomSlug()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private Comment_Type_2[] CreateRepliesJson()
        {
            int numberOfAuthors = CreateRandomValue(0, 20);
            Comment_Type_2[] replies = new Comment_Type_2[numberOfAuthors];

            for (int i = 0; i < numberOfAuthors; i++)
            {
                replies[i] = CreateCommentType_2();
            }

            return replies;
        }
        
    }
}