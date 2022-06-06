using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class PublishersBLL
    {
        private static PublishersBLL _Instance;
        public static PublishersBLL Instance
        {
            get
            {
                if(_Instance == null) return new PublishersBLL();
                return _Instance;
            }
            set { }
        }
        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"~!@#$%^&*()_+`1234567890-=[]\{}|;':,./<>?";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
        public DataTable LoadAllPublishers()
        {
            return PublishersDAL.Instance.LoadAllPublishers();
        }
        public string AddPublisher(Publishers pub)
        {
            if (pub.name == "") return "Publisher's Name cann't be left blank!";
            if (hasSpecialChar(pub.name)) return "Publisher's Name cann't contain special char!";
            if (hasSpecialChar(pub.country)) return "Country cann't contain special char!";
            PublishersDAL.Instance.AddPublisher(pub);    
            return "OK";
        }
        public string EditPublisher(Publishers pub, string id)
        {
            if (pub.name == "") return "Publisher's Name cann't be left blank!";
            if (hasSpecialChar(pub.name)) return "Publisher's Name cann't contain special char!";
            if (hasSpecialChar(pub.country)) return "Country cann't contain special char!";
            PublishersDAL.Instance.EditPublisher(pub,id);
            return "OK";
        }
        public void DeletePublisher(string id)
        {
            PublishersDAL.Instance.DeletePublishers(id);
        }
        public DataTable SearchPublishers(string s)
        {
            return PublishersDAL.Instance.SearchPublisher(s);
        }

    }
}
