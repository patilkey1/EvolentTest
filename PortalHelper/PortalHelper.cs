using DBMapper;
using DBMapper.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalLibrary
{
    public static class PortalHelper
    {
        /// <summary>
        /// Single instance object for database connection
        /// </summary>
        static EFDBContext db = EFDBContext.contextInstance;

        public static List<ContactInfo> GetContacts()
        {
            List<ContactInfo> lstContactInfo = new List<ContactInfo>();
            try
            {
                lstContactInfo = db.ContactInfo.ToList();
            }
            catch (Exception ex)
            {
                Logging.Logging.WriteErrorLog(ex);
            }

            return lstContactInfo;
        }

        public static ContactInfo GetContactById(int ID)
        {
            ContactInfo objContactInfo = new ContactInfo();
            try
            {
                objContactInfo = db.ContactInfo.Where(x => x.ID == ID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logging.Logging.WriteErrorLog(ex);
            }

            return objContactInfo;
        }

        public static string AddUpdateContact(ContactInfo Info)
        {
            try
            {
                var ExistingContact = db.ContactInfo.Where(x => x.ID == Info.ID).FirstOrDefault();

                if (ExistingContact == null)
                {
                    db.ContactInfo.Add(Info);
                    db.SaveChanges();
                    return "1";
                }
                else
                {
                    ExistingContact.firstName = Info.firstName;
                    ExistingContact.lastName = Info.lastName;
                    ExistingContact.Email = Info.Email;
                    ExistingContact.PhoneNumber = Info.PhoneNumber;
                    ExistingContact.isActive = Info.isActive;

                    db.Entry(ExistingContact).State = EntityState.Modified;
                    db.SaveChanges();
                    return "2";
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.WriteErrorLog(ex);
                return "0";
            }
        }
    }
}
