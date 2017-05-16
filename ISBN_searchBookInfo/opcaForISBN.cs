using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// author:loserStar
/// email:362527240@qq.com
/// 通过国家图书馆联机公共目录查询系统的查询页面，使用ISBN编码得到图书信息
/// 依赖：HtmlAgilityPack（此框架使用XPath表达式解析节点）
/// 
/// </summary>
namespace ISBNQuery
{
    public static class opcaForISBN
    {
        public static HtmlWeb htmlWeb = new HtmlWeb();

        /// <summary>
        /// 得到查询用的加密key
        /// </summary>
        /// <returns></returns>
        public static String getKey()
        {
            String key = "";
            HtmlAgilityPack.HtmlDocument htmlDoc = htmlWeb.Load(@"http://opac.nlc.cn/F/");
            HtmlNode form1 = htmlDoc.DocumentNode.SelectSingleNode("//form[@name='form1']");
            key = form1.GetAttributeValue("action", "");
            return key;
        }

        /// <summary>
        /// 根据isbn编码获取整个结果页面string
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public static String getHtmlStr(String isbn)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument htmlDoc = htmlWeb.Load(getKey() + "?func=find-b&find_code=ISB&request=" + isbn);
            HtmlNode documentNode = htmlDoc.DocumentNode;
            return documentNode.OuterHtml;


            //微软自己的类，HtmlAgilityPack也提供远程获取数据就没使用这个
            /*
            WebClient MyWebClient = new WebClient();


            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据

            Byte[] pageData = MyWebClient.DownloadData(getKey() + "?func=find-b&find_code=ISB&request=" + isbn); //从指定网站下载数据

            //string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            

            string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
            */

        }

        /// <summary>
        /// 根据整个html解析得到保存主数据的那个table
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static String getTableStr(String html)
        {
            String s = "";
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode feedbackbar = doc.DocumentNode.SelectSingleNode("//div[@id='feedbackbar']");
            if (feedbackbar.InnerText.Contains("数据库里没有这条请求记录"))
            {
                throw new Exception("没有查到此书的记录");
            }
            else
            {
                s =  doc.DocumentNode.SelectSingleNode("//table[@id='td']").OuterHtml;
            }
            return s;
        }

        /// <summary>
        /// 传入table的整个html字符串，解析得到里面td标签的text值
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<String> getTdList(String table)
        {
            if (null==table||"".Equals(table))
            {
                throw new Exception("请传入table的HTML字符串");
            }
            List<String> returnList = new List<String>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(table);
            HtmlNodeCollection nodeCollecation =  doc.DocumentNode.SelectNodes("//td[@class='td1']");
            foreach(HtmlNode node in nodeCollecation)
            {
                String Htmlstring = node.InnerText;
                Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                //删除HTML  
                //Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<div", "<p", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"</div>", "</p>", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

                returnList.Add(Htmlstring.TrimStart().TrimEnd());
            }
            return returnList;
        }

        /// <summary>
        /// 通过isbn查询图书信息
        /// </summary>
        /// <param name="isbn">isbn图书编号</param>
        /// <returns>一个Map存对应的值
        /// </returns>
        public static Dictionary<String, String> getbookInfo(String isbn)
        {
            List<String> list = getTdList(getTableStr(getHtmlStr(isbn)));
            Dictionary<String, String> map = new Dictionary<String, String>();
            for(int i = 0;i < list.Count; i++)
            {
                String s = list[i];
                if ("头标区".Equals(s))
                {
                    map.Add("头标区", list[i+1]);
                }
                if("ID 号".Equals(s))
                {
                    map.Add("ID 号",list[i+1]);
                }
                if ("通用数据".Equals(s))
                {
                    map.Add("通用数据", list[i + 1]);
                }
                if ("题名与责任".Equals(s))
                {
                    map.Add("题名与责任", list[i + 1]);
                }
                if ("出版项".Equals(s))
                {
                    map.Add("出版项", list[i + 1]);
                }
                if ("载体形态项".Equals(s))
                {
                    map.Add("载体形态项", list[i + 1]);
                }
                if ("语言".Equals(s))
                {
                    map.Add("语言", list[i + 1]);
                }
                if ("相关附注".Equals(s))
                {
                    map.Add("相关附注", list[i + 1]);
                }
                if ("内容提要".Equals(s))
                {
                    map.Add("内容提要", list[i + 1]);
                }
                if ("题名".Equals(s))
                {
                    map.Add("题名", list[i + 1]);
                }
                if ("主题".Equals(s))
                {
                    map.Add("主题", list[i + 1]);
                }
                if ("中图分类号".Equals(s))
                {
                    map.Add("中图分类号", list[i + 1]);
                }
                if ("著者".Equals(s))
                {
                    map.Add("著者", list[i + 1]);
                }
            }
            return map;
        }

    }
}
