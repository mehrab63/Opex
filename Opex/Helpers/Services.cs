using Microsoft.AspNetCore.Http;
using Opex.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Security.Cryptography;

namespace Opex.Helpers
{
    [Authorize]
    public class Services
    {
        private readonly DB_Context _context;
        public Services(DB_Context dB_Context)
        {
            this._context = dB_Context;

        }
        public static int UserMemberId { get; set; }
        public static int PhoneNumber { get; set; }
        public static List<TblOfficeMember> CurrentOfficeMembers { get; set; }
        public static List<TblMembers> MemberList { get; set; }
        public static List<TblBinarys> BinaryList { get; set; }
        public static TblOfficeMembers financialBalances { get; set; }
        public static TblMembers CurrentMember { get; set; }
        public static TblOfficeMember OfficeMembers { get; set; }
        public static string ParvandeState { get; set; }
        public static string ToShamsi(DateTime date)
        {
            DateTime miladi = date;
            PersianCalendar shamsi = new PersianCalendar();
            return string.Format("{0}/{1}/{2}", shamsi.GetYear(miladi), shamsi.GetMonth(miladi), shamsi.GetDayOfMonth(miladi));

        } 
        public static void RunInBackground(DB_Context context)
        {
            try
            {
                CurrentOfficeMembers = context.TblOfficeMembers.Where(m => m.SystemCode == CurrentMember.MemberId).ToList();
                BinaryList = context.TblBinarys.Where(b => b.CreateUser == UserMemberId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static async Task<bool> CheckDuplicate(DB_Context context, string Code)
        {
            if (Code != null)
                return await context.TblOfficeMembers.AnyAsync(e => e.ShMelli == Code);
            return false;
        }
        public static async Task<List<TblLetters>> Letterslist(DB_Context context)
        {
            return await context.TblLetters.ToListAsync();
        } 
        public static async Task<bool> RequestCheck(DB_Context context, string phone)
        {
            if (phone != null)
                return await context.TblLetters.AnyAsync(e => e.CreateUserName == phone);
            return false;
        }
        public static List<long> GetBinaryIds(string BinaryIds)
        {
            List<long> binaryIdList = new List<long>();
            //if (BinaryIds.StartsWith(','))
            //{
                string[] ids = BinaryIds.Split(",");
                foreach (string c in ids)
                {
                    if(c!=""&c!=null)
                    binaryIdList.Add(Convert.ToInt64(c.Substring(c.IndexOf(",") + 1)));
                }
                return binaryIdList;
            //}
           // return binaryIdList;
        }
        public async Task<List<TblMembers>> CurrentMem(string ShMelli)
        {
            List<TblMembers> lst = new List<TblMembers>();
            try
            {
                var mem = await _context.TblMembers.SingleOrDefaultAsync(u => u.کدملی == ShMelli);
                ParvandeState = mem.وضعیتپرونده;
                MemberList.Add(mem);
                if (mem.کدملی == ShMelli)
                    lst.Add(mem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }
        public static async Task<byte[]> Upload(IFormFile Binary)
        {
            if (Binary != null && Binary.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await Binary.CopyToAsync(stream);
                    return stream.ToArray();
                }
            }

            return null;
        }
        public static void InsertReference(DB_Context context, TblRefrences reference)
        {
            context.TblRefrences.Add(reference);
            context.SaveChanges();
        }
        public static async Task<List<TblBinarys>> GetBinarys(DB_Context context)
        {
            return BinaryList = await context.TblBinarys.Where(b => b.CreateUser == UserMemberId).ToListAsync();
        }
        public static async Task<TblMembers> GetMember(DB_Context context, string usernameVal)
        {
            return CurrentMember = await context.TblMembers.Where(u => u.کدملی == usernameVal).FirstOrDefaultAsync();
        } 
        public static string FormatNumber(string number)
        {
            if (string.IsNullOrEmpty(number)) return "";

            decimal toDec = decimal.Parse(number);
            var num = toDec.ToString("###,###,###");
            return toDec.ToString("###,###,###");
        } 
        public static string EncryptString(string letterID)
        {
            string trackingcode="";
            var n = Encoding.ASCII.GetBytes(letterID[1].ToString()); 
                trackingcode = n[0].ToString()+letterID; 
            return trackingcode;
        } 
        public static string DecryptString(string letterID)
        {
            var id =""; 
            id = letterID.Substring(2, letterID.Length - 2);  
            return id.ToString();
        }

    }
}
