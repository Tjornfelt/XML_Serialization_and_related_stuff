using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using XmlTestExamples.Models;

namespace XmlTestExamples.Helpers
{
    public static class XMLHelpers
    {
        public static bool NewUserAsXml(UserData userData, bool update = true)
        {
            if (userData != null)
            {
                if (userData.RelatedUsers == null)
                {
                    userData.RelatedUsers = new List<int>();
                }

                Users users = null;
                var serializer = new XmlSerializer(typeof(Users));
                //Try reading the existing XML document.
                try
                {
                    var result = ReadUsersFromXml();
                    if(result != null)
                    {
                        users = result;
                    }
                    else
                    {
                        throw new ArgumentException("users.xml could not be read.");
                    }
                }
                catch (Exception whoCares)
                {

                }

                if (users != null)
                {
                    //XmlDocument already exists - look through it and give userData an id, then add userData to it
                    int largestId = 1;
                    foreach (var user in users.UserList)
                    {
                        if (user.Id > largestId)
                        {
                            largestId = user.Id;
                        }                        
                    }
                    userData.Id = largestId + 1;
                    users.UserList.Add(userData);
                }
                else
                {
                    //XmlDocument does not exist - create a new object and add userData to it
                    List<UserData> udList = new List<UserData>();
                    userData.Id = 1;
                    udList.Add(userData);

                    users = new Users()
                    {
                        UserList = udList
                    };
                }

                using (var writer = XmlWriter.Create("users.xml"))
                {
                    serializer.Serialize(writer, users);
                }
                return true;
            }
            return false;
        }

        public static bool RemoveXmlUser(int userId)
        {
            try
            {
                //A user could not be selected if the XML document doesnt exist - it is safe to assume it can be read.
                Users users = ReadUsersFromXml();

                var userData = users.UserList.FirstOrDefault(x => x.Id == userId);

                users.UserList.Remove(userData);

                var serializer = new XmlSerializer(typeof(Users));
                using (var writer = XmlWriter.Create("users.xml"))
                {
                    serializer.Serialize(writer, users);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Users ReadUsersFromXml()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Users));
                Users users;
                using (var reader = XmlReader.Create("users.xml"))
                {
                    users = (Users)serializer.Deserialize(reader);
                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
