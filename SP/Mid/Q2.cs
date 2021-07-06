using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Mid
{
    class Q2
    {
        static DataTable GetUsers()
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("Username", Type.GetType("System.String")));
            table.Columns.Add(new DataColumn("Password", Type.GetType("System.String")));
            table.Columns.Add(new DataColumn("Gender", Type.GetType("System.Char")));
            table.Columns.Add(new DataColumn("RoleId", Type.GetType("System.Int32")));
            table.Rows.Add(new object[] { "Osama", "1313", 'M', 0 });
            table.Rows.Add(new object[] { "Shahzeb", "1222", 'M', 1 });
            table.Rows.Add(new object[] { "Junaid", "1311", 'M' });
            table.Rows.Add(new object[] { "Ayesha", "1311", 'F', 2 });
            table.Rows.Add(new object[] { "Ajmal", "1311", 'M', 2 });
            return table;
        }

        static DataTable GetRoles()
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("RoleId", Type.GetType("System.Int32")));
            table.Columns.Add(new DataColumn("Title", Type.GetType("System.String")));
            table.Rows.Add(new object[] { 0, "Admin" });
            table.Rows.Add(new object[] { 1, "Super Moderator" });
            table.Rows.Add(new object[] { 2, "Moderator" });
            return table;
        }

        public static void PartA(string[] args)
        {
            DataTable dtUsers = GetUsers();
            DataTable dtRoles = GetRoles();

            var res = dtUsers.AsEnumerable().GroupJoin(
                dtRoles.AsEnumerable(),
                u => u["RoleId"],
                r => r["RoleId"],
                (u, r) => new { u, r }).
            SelectMany(
                r => r.r.DefaultIfEmpty(),
                (u1, r1) => new
                {
                    Name = u1.u.Field<string>("Username"),
                    Role = r1 == null ? "N/A" : r1.Field<string>("Title")
                }
            );

            foreach (var r in res)
            {
                Console.WriteLine(r);
            }
        }

        public static void PartB(string[] args)
        {
            DataTable dtUsers = GetUsers();
            DataTable dtRoles = GetRoles();

            var res = dtUsers.AsEnumerable().GroupJoin(
                dtRoles.AsEnumerable(),
                u => u["RoleId"],
                r => r["RoleId"],
                (u, r) => new { u, r }).
            SelectMany(
                r => r.r.DefaultIfEmpty(),
                (u1, r1) => new
                {
                    Gender = u1.u.Field<char>("Gender"),
                    Role = r1 == null ? "N/A" : r1.Field<string>("Title"),
                    RoleId = r1 == null ? -1 : r1.Field<int>("RoleId")
                })
            .OrderBy(r => r.Role)
            .GroupBy(u => u.Role);

            foreach (var r in res)
            {
                Console.WriteLine("------ Role: {0} ------", r.Key);
                Console.WriteLine("Male Users: {0}", r.Count(u => u.Gender == 'M'));
                Console.WriteLine("Female Users: {0}", r.Count(u => u.Gender == 'F'));
            }
        }
    }
}
