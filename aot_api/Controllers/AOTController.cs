using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace aot_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AOTController : Controller
    {
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            List<ResultClass> test = new List<ResultClass>();

            ResultClass temp1 = new ResultClass();
            temp1.Count = 999;

            temp1.Palindrome = new List<string>();

            temp1.Palindrome.Add("palindrome");

            test.Add(temp1);

            return Json(test);
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post(PostData postData)
        {

            ResultClass result = new ResultClass();
            result.Count = CountOccurences(postData.query, postData.message);

            result.Palindrome = new List<string>();

            string[] words = postData.message.Split(' ');

            foreach(string word in words)
            {
                if(CheckPalindrome(word))
                {
                    result.Palindrome.Add(word);
                }
            }


            return Json(result);
        }

        public int CountOccurences(string query, string message)
        {
            message = message.Replace(" ", "");
            int count = message.Split(query).Length - 1;

            return count;
        }

        public bool CheckPalindrome(string strOriginal)
        {
            string strReverse = "";
            int len = strOriginal.Length;

            for (int i = len - 1; i >= 0; i--)
            {
                strReverse = strReverse + strOriginal[i].ToString();
            }

            if (strOriginal == strReverse)
            {
                return true;
            }

            return false;
        }

    }

    


}
