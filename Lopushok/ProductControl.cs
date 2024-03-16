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
    public partial class ProductControl : UserControl
    {
        public ProductControl()
        {
            InitializeComponent();
        }

        public void Cost(string cost) => lblCost.Text = cost;
        public void Title(string title) => lblTitle.Text = title;
        public void Article(string article) => lblArticle.Text = article;
        public void TypeTitle(string typeTitle) => lblTypeTitle.Text = typeTitle;
        public void Materials(string materials) => lblMaterials.Text = materials;
        public void PicLoc(string location) => productPicture.ImageLocation = location;
        public void PicSizeMode(PictureBoxSizeMode sizeMode) => productPicture.SizeMode = sizeMode;
    }
}
