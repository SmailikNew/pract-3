using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMas
{
    public class Arrayx
    {

        Random rnd = new Random();
        int[,] array;
        public int LineLength => array.GetLength(0);
        public int ColumnLength => array.GetLength(1);

        public void Initialize(int min = -10, int max = 10)
        {
            for (int i = 0; i < LineLength; i++)
            {
                for (int j = 0; j < ColumnLength; j++)
                {
                    array[i, j] = rnd.Next(min, max);
                }
            }
        }

        public void Save(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(LineLength);
                writer.WriteLine(ColumnLength);

                for (int i = 0; i < LineLength; i++)
                {
                    for (int j = 0; j < ColumnLength; j++)
                    {
                        writer.WriteLine(array[i, j]);
                    }
                }
            }
        }

        public void Open(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                int rowlength = int.Parse(reader.ReadLine());
                int columnlength = int.Parse(reader.ReadLine());

                for (int i = 0; i < rowlength; i++)
                {
                    for (int j = 0; j < columnlength; j++)
                    {
                        array[i, j] = int.Parse(reader.ReadLine());
                    }
                }
            }
        }

        public Arrayx(int line, int column)
        {
            array = new int[line, column];
        }

        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < LineLength; i++)
            {
                res.Columns.Add("col" + (i + 1));
            }

            for (int i = 0; i < ColumnLength; i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < ColumnLength; j++)
                {
                    row[j] = array[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }

        public int this[int index1, int index2]
        {
            get
            {
                return array[index1, index2];
            }
            set
            {
                array[index1, index2] = value;
            }
        }
        public void Clear()
        {
            Initialize(0, 0);
        }
    }
}
