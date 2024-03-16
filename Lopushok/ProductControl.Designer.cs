namespace Lopushok
{
    partial class ProductControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCost = new Label();
            label1 = new Label();
            lbl = new Label();
            lblArticle = new Label();
            lblTitle = new Label();
            lblTypeTitle = new Label();
            productPicture = new PictureBox();
            label2 = new Label();
            lblMaterials = new Label();
            ((System.ComponentModel.ISupportInitialize)productPicture).BeginInit();
            SuspendLayout();
            // 
            // lblCost
            // 
            lblCost.AutoSize = true;
            lblCost.Location = new Point(541, 3);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(67, 15);
            lblCost.TabIndex = 15;
            lblCost.Text = "Стоимость";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(201, 3);
            label1.Name = "label1";
            label1.Size = new Size(10, 15);
            label1.TabIndex = 13;
            label1.Text = "|";
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(121, 37);
            lbl.Name = "lbl";
            lbl.Size = new Size(74, 15);
            lbl.TabIndex = 12;
            lbl.Text = "Материалы:";
            // 
            // lblArticle
            // 
            lblArticle.AutoSize = true;
            lblArticle.Location = new Point(121, 21);
            lblArticle.Name = "lblArticle";
            lblArticle.Size = new Size(53, 15);
            lblArticle.TabIndex = 11;
            lblArticle.Text = "Артикул";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(210, 3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(90, 15);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "Наименование";
            // 
            // lblTypeTitle
            // 
            lblTypeTitle.AutoSize = true;
            lblTypeTitle.Location = new Point(121, 3);
            lblTypeTitle.Name = "lblTypeTitle";
            lblTypeTitle.Size = new Size(83, 15);
            lblTypeTitle.TabIndex = 9;
            lblTypeTitle.Text = "Тип продукта ";
            // 
            // productPicture
            // 
            productPicture.Location = new Point(3, 3);
            productPicture.Name = "productPicture";
            productPicture.Size = new Size(100, 97);
            productPicture.TabIndex = 16;
            productPicture.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(541, 27);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 17;
            label2.Text = "рублей";
            // 
            // lblMaterials
            // 
            lblMaterials.AutoSize = true;
            lblMaterials.Location = new Point(201, 37);
            lblMaterials.Name = "lblMaterials";
            lblMaterials.Size = new Size(69, 15);
            lblMaterials.TabIndex = 18;
            lblMaterials.Text = "материалы";
            // 
            // ProductControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblMaterials);
            Controls.Add(label2);
            Controls.Add(productPicture);
            Controls.Add(lblCost);
            Controls.Add(label1);
            Controls.Add(lbl);
            Controls.Add(lblArticle);
            Controls.Add(lblTitle);
            Controls.Add(lblTypeTitle);
            Name = "ProductControl";
            Size = new Size(626, 178);
            ((System.ComponentModel.ISupportInitialize)productPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCost;
        private Label label1;
        private Label lbl;
        private Label lblArticle;
        private Label lblTitle;
        private Label lblTypeTitle;
        private PictureBox productPicture;
        private Label label2;
        private Label lblMaterials;
    }
}