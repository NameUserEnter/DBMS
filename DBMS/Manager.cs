using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS
{
    public class Manager
    {
        public Database db;

        public bool CreateNewDB(string Name)
        {
            if (String.IsNullOrEmpty(Name)) 
                return false;
            db = new Database(Name);
            return true;
        }

        public bool AddTable(string Name)
        {
            if (Name.Equals("")) return false;
            if (db == null) return false;

            db.Tables.Add(new Table(Name));
            return true;
        }

        public Table GetTable(int index)
        {
            if (index == -1) index = 0;
            return db.Tables[index];
        }

        public bool AddColumn(int tIndex, string cname, string ctype)
        {
            if (db == null) return false;
            if (db.Tables.Count <= 0) return false;

            db.Tables[tIndex].Columns.Add(Column.CreateColumn(cname, ctype));
            for (int i = 0; i < db.Tables[tIndex].Rows.Count; ++i)
            {
                if (ctype != "PICTURE FILE")
                {
                db.Tables[tIndex].Rows[i].Values.Add("");
                }
                else
                {
                    db.Tables[tIndex].Rows[i].Values.Add(new List<byte>());
                }
            }
            return true;
        }

        public bool AddRow(int tIndex)
        {
            if (db == null) return false;
            if (db.Tables.Count <= 0) return false;
            if (db.Tables[tIndex].Columns.Count <= 0) return false;

            db.Tables[tIndex].Rows.Add(new Row());
            for (int i = 0; i < db.Tables[tIndex].Columns.Count; i++)
            {
                    if (db.Tables[tIndex].Columns[i].Type != "PICTURE FILE")
                    {
                        db.Tables[tIndex].Rows.Last().Values.Add("");
                    }
                    else
                    {
                        db.Tables[tIndex].Rows.Last().Values.Add(new List<byte>());
                    }
            }
            return true;
        }

        public bool ChangeValue(object newValue, int tind, int cind, int rind)
        {
            if (db.Tables[tind].Columns[cind].Validate(newValue))
            {
                db.Tables[tind].Rows[rind].Values[cind] = newValue;
                return true;
            }

            return false;
        }

        public void DeleteRow(int tind, int rind)
        {
            db.Tables[tind].Rows.RemoveAt(rind);
        }

        public void DeleteColumn(int tind, int cind)
        {
            db.Tables[tind].Columns.RemoveAt(cind);
            for (int i = 0; i < db.Tables[tind].Rows.Count; ++i)
            {
                db.Tables[tind].Rows[i].Values.RemoveAt(cind);
            }
        }

        public void DeleteTable(int tind)
        {
            db.Tables.RemoveAt(tind);
        }

        public void SaveDB(string path)
        {
            char sep = '$';
            char space = '#';
            StreamWriter sw = new StreamWriter(path);

            sw.WriteLine(db.Name);
            foreach (Table t in db.Tables)
            {
                sw.WriteLine(sep);
                sw.WriteLine(t.Name);
                foreach (Column c in t.Columns)
                {
                    sw.Write(c.Name + space);
                }
                sw.WriteLine();
                foreach (Column c in t.Columns)
                {
                    sw.Write(c.Type + space);
                }
                sw.WriteLine();
                foreach (Row r in t.Rows)
                {
                    foreach (var s in r.Values)
                    {
                        if (s is List<byte>)
                        {
                            byte[] byteArray = ((List<byte>)s).ToArray();
                            string base64String = Convert.ToBase64String(byteArray);
                            sw.Write(base64String + space);
                        }
                        else
                        { sw.Write(s.ToString() + space); }
                    }
                    sw.WriteLine();
                }
            }

            sw.Close();
        }
        public bool OpenPicture(string FileName, string img, int tind, int rind, int cind)
        {
            if (db.Tables[tind].Columns[cind].Validate(img))
            {
                Image image = Image.FromFile(img);
                var encodedImg = ImageToByteArray(image);
                db.Tables[tind].Rows[rind].Values[cind]=encodedImg;
                return true;
            }

            return false;
        }
        public static List<byte> ImageToByteArray(Image image)
        {
            List<byte> byteList = new List<byte>();
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byteList.AddRange(ms.ToArray());
            }
            return byteList;
        }
        public static Image ByteArrayToImage(List<byte> byteList)
        {
            if (byteList == null || byteList.Count == 0)
            {
                return null;
            }
            using (MemoryStream stream = new MemoryStream(byteList.ToArray()))
            {
                Image image = Image.FromStream(stream);
                return image;
            }
        }
        public bool OpenDB(string path)
        {
            try
            {
                char sep = '$';
                char space = '#';
                StreamReader sr = new StreamReader(path);
                string file = sr.ReadToEnd();
                string[] parts = file.Split(sep);

                db = new Database(parts[0]);

                for (int i = 1; i < parts.Length; ++i)
                {
                    parts[i] = parts[i].Replace("\r\n", "\r");
                    List<string> buf = parts[i].Split('\r').ToList();
                    buf.RemoveAt(0);
                    buf.RemoveAt(buf.Count - 1);

                    if (buf.Count > 0)
                    {
                        db.Tables.Add(new Table(buf[0]));
                    }
                    if (buf.Count > 2)
                    {
                        string[] cname = buf[1].Split(space);
                        string[] ctype = buf[2].Split(space);
                        int length = cname.Length - 1;
                        List<int> colindexes = new List<int>();
                        for (int j = 0; j < length; ++j)
                        {
                            db.Tables[i - 1].Columns.Add(Column.CreateColumn(cname[j], ctype[j]));
                            if (ctype[j] == "PICTURE FILE") { colindexes.Add(db.Tables[i - 1].Columns.Count - 1); }
                        }

                        for (int j = 3; j < buf.Count; ++j)
                        {
                            db.Tables[i - 1].Rows.Add(new Row());
                            List<string> values = buf[j].Split(space).ToList();
                            values.RemoveAt(values.Count - 1);
                            db.Tables[i - 1].Rows.Last().Values.AddRange(values);
                        }
                        for (int h = 0; h < db.Tables[i - 1].Rows.Count; h++)
                        {
                            foreach (var col in colindexes)
                            {
                                byte[] byteArray = Convert.FromBase64String((string)db.Tables[i - 1].Rows[h].Values[col]);
                                db.Tables[i - 1].Rows[h].Values[col] = new List<byte>(byteArray);
                            }

                        }
                    }
                }

                sr.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<string> GetTableNameList()
        {
            List<string> res = new List<string>();
                foreach (Table t in db.Tables)
                    res.Add(t.Name);
                return res;
        }

        public bool RepeatedRows(int tIndex)
        {
            List<Row> uniqueRows = new List<Row>();
            uniqueRows.Add(db.Tables[tIndex].Rows[0]);
            for (var i = 1; i < db.Tables[tIndex].Rows.Count; i++)
            {
                bool isUnique = true;
                for (var j = 0; j < uniqueRows.Count; j++)
                {
                    if ((uniqueRows[j].Values.Select(v => v.ToString()).SequenceEqual(db.Tables[tIndex].Rows[i].Values.Select(v => v.ToString()))))
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique)
                {
                    uniqueRows.Add(db.Tables[tIndex].Rows[i]);
                }
                else
                {
                    db.Tables[tIndex].Rows.RemoveAt(i);
                    i--; 
                }
            }
            return true;
        }

    }
}
