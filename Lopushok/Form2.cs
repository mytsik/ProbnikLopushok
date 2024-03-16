using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lopushok
{
    public partial class Form2 : Form
    {
        int lastPageNum = 0; //номер последней страницы
        int currentPageNum = 1;        

        string sqlCommand = "SELECT * FROM public.\"Product\"" +
            "JOIN public.\"ProductType\" ON public.\"Product\".\"ProductTypeID\" = public.\"ProductType\".\"ID\"" +
             " ORDER BY public.\"Product\".\"ID\" ASC";
        public static DataSet dataSet;
        public static DataTable dataTable;
        public static NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=ProbnikMyScript;User Id=postgres;Password=24601;");

        public Form2()
        {
            InitializeComponent();
            oneProductPagePanel(sqlCommand);
            pageNumbersPanel(lastPageNum);

            filterComboBox.Items.AddRange(new string[] { "Все типы", "Один слой", "Два слоя", "Три слоя", "Детская", "Супер мягкая" });
            filterComboBox.SelectedIndex = 0; // по умолчанию стоит "все типы"
            sortingComboBox.Items.AddRange(new string[] { "По наименованию", "По номеру производственного цеха", "По минимальной стоимости для агента" });
        }

        public static void SQLtoDB(string sql)
        {
            conn.Open();            
            NpgsqlDataAdapter dataAd = new NpgsqlDataAdapter(sql, conn);
            dataSet = new DataSet();
            dataSet.Reset();
            dataAd.Fill(dataSet);
            dataTable = dataSet.Tables[0];
            conn.Close();
        }

        public void setLastPageNum(string sql)
        {
            SQLtoDB(sql);
            if (dataTable.Rows.Count % 20 != 0)
            {
                lastPageNum = dataTable.Rows.Count / 20 + 1;
            }
            else
            {
                lastPageNum = dataTable.Rows.Count / 20;
            }
        }

        public void oneProductPagePanel(string sql)
        {
            flowLayoutPanelProducts.Controls.Clear();
            int maxIndex = 20; //максимальное число записей на одной странице
            setLastPageNum(sql);
            if (currentPageNum == lastPageNum)
            {
                if (dataTable.Rows.Count % 20 != 0)
                {
                    maxIndex = dataTable.Rows.Count % 20;
                }
            }

            for (int i = 0 + (20 * (currentPageNum - 1)); i < maxIndex + (20 * (currentPageNum - 1)); i++)
            {
                SQLtoDB(sqlCommand);//новый DataTable (Product + ProductType)
                int prodID = Convert.ToInt32(dataTable.Rows[i][0]);
                string agentCost = dataTable.Rows[i][8].ToString();

                ProductControl productCont = new ProductControl();
                productCont.Size = new Size(600, 104);
                productCont.Title(dataTable.Rows[i][1].ToString());
                productCont.Article(dataTable.Rows[i][3].ToString());                
                productCont.TypeTitle(dataTable.Rows[i][10].ToString());

                string sqlCommandMat = string.Format("SELECT * FROM public.\"ProductMaterial\" " +
                    "JOIN public.\"Material\" ON public.\"Material\".\"ID\" = public.\"ProductMaterial\".\"MaterialID\" " +
                    "WHERE public.\"ProductMaterial\".\"ProductID\" = '{0}'", prodID);
                SQLtoDB(sqlCommandMat); //новый DataTable (ProductMaterial + Material)

                string matResult = "";
                double matCountCost = 0;

                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    matResult += dataTable.Rows[j][4].ToString() + "\r\n";

                    double count = Convert.ToDouble(dataTable.Rows[j][2]);
                    double cost = Convert.ToDouble(dataTable.Rows[j][7]);
                    double countInPack = Convert.ToDouble(dataTable.Rows[j][5]);
                    double oneMatCountCost = count * (cost / countInPack);
                    matCountCost += oneMatCountCost;
                }
                if (dataTable.Rows.Count != 0) //если есть материалы
                {
                    productCont.Materials(matResult);
                    productCont.Cost(Math.Round(matCountCost, 2).ToString());                    
                }
                else
                {
                    productCont.Materials("-");
                    productCont.Cost(agentCost);
                }
                
                Random rnd = new Random();
                productCont.PicLoc($"C:\\Users\\user\\Desktop\\учеба\\пробник демки\\поповские файлы\\Promezhutochny_kontrol\\Промежуточный контроль\\Сессия 1\\products\\paper_{rnd.Next(0, 26)}.jpeg");
                productCont.PicSizeMode(PictureBoxSizeMode.Zoom);

                flowLayoutPanelProducts.Controls.Add(productCont);
            }
        }

        public void pageNumbersPanel(int lastPage)
        {
            flowLayoutPanelPages.Controls.Clear();

            if (currentPageNum != 1)
            {
                Label label = new Label();
                label.Name = "lblGoBack";
                label.Size = new Size(15, 15);
                label.Text = "<";
                label.Click += labelChangePage_Click;
                flowLayoutPanelPages.Controls.Add(label);
            }

            for (int i = 1; i <= lastPage; i++) //генерация номеров страниц
            {
                Label label = new Label();
                label = new Label();
                label.Size = new Size(15, 15);
                label.Text = $"{i}";
                label.Click += labelChangePage_Click;
                flowLayoutPanelPages.Controls.Add(label);

                if (currentPageNum.ToString() == label.Text)
                {
                    label.Font = new Font(Label.DefaultFont, FontStyle.Underline);
                }
            }

            if (currentPageNum != lastPageNum)
            {
                Label label = new Label();
                label.Name = "lblGoNext";
                label = new Label();
                label.Size = new Size(15, 15);
                label.Text = ">";
                label.Click += labelChangePage_Click;
                flowLayoutPanelPages.Controls.Add(label);
            }
        }

        private void labelChangePage_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;


            if (label.Text == "<")
            {
                currentPageNum -= 1;
            }
            else if (label.Text == ">")
            {
                currentPageNum += 1;
            }
            else
            {
                currentPageNum = Convert.ToInt32(label.Text); //присваиваем значение главной переменной

            }
            oneProductPagePanel(sqlCommand);
            pageNumbersPanel(lastPageNum);
        }

        public void Search()
        {
            string main = "SELECT * FROM public.\"Product\" JOIN " +
            "public.\"ProductType\" ON public.\"Product\".\"ProductTypeID\" = public.\"ProductType\".\"ID\"";
            bool where = false;
            bool and = false;
            string searchSQL = "";
            string sortType = "";
            string filterSQL = "";
            string result = "";

            //поиск
            if (textBoxSearch.Text != "")
            {
                sqlCommand = $"SELECT EXISTS ({main} WHERE (public.\"Product\".\"Title\" ILIKE '%{textBoxSearch.Text}%' " +
                    $"OR public.\"Product\".\"Description\" ILIKE '%{textBoxSearch.Text}%'));";
                SQLtoDB(sqlCommand);
                if (dataTable.Rows[0][0].ToString() == "True")
                {
                    searchSQL = $"(public.\"Product\".\"Title\" ILIKE '%{textBoxSearch.Text}%' " +
                        $"OR public.\"Product\".\"Description\" ILIKE '%{textBoxSearch.Text}%')";
                    where = true;
                }
            }

            // если без поиска то за where и searchSQL будет отвечать фильтр
            //фильтрация           

            if (filterComboBox.Text != "Все типы")
            {
                if (where != true) //без поиска
                {
                    sqlCommand = $"SELECT EXISTS ({main} WHERE public.\"ProductType\".\"Title\" ILIKE '%{filterComboBox.Text}%');";
                    SQLtoDB(sqlCommand);
                    if (dataTable.Rows[0][0].ToString() == "True")
                    {
                        searchSQL = $"public.\"ProductType\".\"Title\" ILIKE '%{filterComboBox.Text}%'";
                        where = true;
                    }
                }
                else //если с поиском
                {
                    sqlCommand = $"SELECT EXISTS ({main} WHERE {searchSQL} AND public.\"ProductType\".\"Title\" ILIKE '%{filterComboBox.Text}%');";
                    SQLtoDB(sqlCommand);
                    if (dataTable.Rows[0][0].ToString() == "True")
                    {
                        filterSQL = $"public.\"ProductType\".\"Title\" ILIKE '%{filterComboBox.Text}%'";
                        and = true;
                    }
                }                
            }

            //сортировка
            switch (sortingComboBox.SelectedIndex)
            {
                case -1: //если ничего не выбрано
                    sortType = " ORDER BY public.\"Product\".\"ID\" ASC";
                    break;
                case 0:
                    if (radioButtonASC.Checked)
                    {
                        sortType = " ORDER BY public.\"Product\".\"Title\" ASC";
                    }
                    else if (radioButtonDESC.Checked)
                    {
                        sortType = " ORDER BY public.\"Product\".\"Title\" DESC";
                    }
                    break;
                case 1:
                    if (radioButtonASC.Checked)
                    {
                        sortType = " ORDER BY public.\"Product\".\"ProductionWorkshopNumber\" ASC";
                    }
                    else if (radioButtonDESC.Checked)
                    {
                        sortType = " ORDER BY public.\"Product\".\"ProductionWorkshopNumber\" DESC";
                    }
                    break;
                case 2:
                    if (radioButtonASC.Checked)
                    {
                        sortType = " ORDER BY public.\"Product\".\"MinCostForAgent\" ASC";
                    }
                    else if (radioButtonDESC.Checked)
                    {
                        sortType = " ORDER BY public.\"Product\".\"MinCostForAgent\" DESC";
                    }
                    break;
            }

            //and не может быть без where а where без and может
            if ((where == true) & (and == true))//поиск фильтрация и сортировка   
            {
                result = $"{main} WHERE {searchSQL} AND {filterSQL} {sortType}";
                
            }
            else if ((where == true) & (and != true)) //поиск(или фильтрация) и сортировка
            {
                result = $"{main} WHERE {searchSQL} {sortType}";
            }
            else if (where != true)//только сортировка
            {
                result = $"{main} {sortType}";
            }           

            currentPageNum = 1;
            sqlCommand = result;
            oneProductPagePanel(sqlCommand);
            pageNumbersPanel(lastPageNum);
        }

        private void sortingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void radioButtonASC_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void radioButtonDESC_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
