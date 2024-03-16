namespace Lopushok
{
    partial class Form2
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
            radioButtonDESC = new RadioButton();
            radioButtonASC = new RadioButton();
            label3 = new Label();
            sortingComboBox = new ComboBox();
            label2 = new Label();
            textBoxSearch = new TextBox();
            filterComboBox = new ComboBox();
            flowLayoutPanelProducts = new FlowLayoutPanel();
            flowLayoutPanelPages = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // radioButtonDESC
            // 
            radioButtonDESC.AutoSize = true;
            radioButtonDESC.Location = new Point(292, 79);
            radioButtonDESC.Name = "radioButtonDESC";
            radioButtonDESC.Size = new Size(102, 19);
            radioButtonDESC.TabIndex = 23;
            radioButtonDESC.TabStop = true;
            radioButtonDESC.Text = "По убыванию\r\n";
            radioButtonDESC.UseVisualStyleBackColor = true;
            radioButtonDESC.CheckedChanged += radioButtonDESC_CheckedChanged;
            // 
            // radioButtonASC
            // 
            radioButtonASC.AutoSize = true;
            radioButtonASC.Location = new Point(292, 55);
            radioButtonASC.Name = "radioButtonASC";
            radioButtonASC.Size = new Size(116, 19);
            radioButtonASC.TabIndex = 22;
            radioButtonASC.TabStop = true;
            radioButtonASC.Text = "По возрастанию";
            radioButtonASC.UseVisualStyleBackColor = true;
            radioButtonASC.CheckedChanged += radioButtonASC_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(292, 8);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 21;
            label3.Text = "Сортировка:";
            // 
            // sortingComboBox
            // 
            sortingComboBox.FormattingEnabled = true;
            sortingComboBox.Location = new Point(292, 26);
            sortingComboBox.Name = "sortingComboBox";
            sortingComboBox.Size = new Size(234, 23);
            sortingComboBox.TabIndex = 20;
            sortingComboBox.SelectedIndexChanged += sortingComboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(532, 8);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 19;
            label2.Text = "Фильтрация:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(12, 26);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Введите для поиска";
            textBoxSearch.Size = new Size(274, 23);
            textBoxSearch.TabIndex = 18;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // filterComboBox
            // 
            filterComboBox.FormattingEnabled = true;
            filterComboBox.Location = new Point(532, 26);
            filterComboBox.Name = "filterComboBox";
            filterComboBox.Size = new Size(114, 23);
            filterComboBox.TabIndex = 17;
            filterComboBox.SelectedIndexChanged += filterComboBox_SelectedIndexChanged;
            // 
            // flowLayoutPanelProducts
            // 
            flowLayoutPanelProducts.AutoScroll = true;
            flowLayoutPanelProducts.BackColor = SystemColors.ButtonFace;
            flowLayoutPanelProducts.Location = new Point(12, 104);
            flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            flowLayoutPanelProducts.Size = new Size(634, 384);
            flowLayoutPanelProducts.TabIndex = 24;
            // 
            // flowLayoutPanelPages
            // 
            flowLayoutPanelPages.Location = new Point(451, 505);
            flowLayoutPanelPages.Name = "flowLayoutPanelPages";
            flowLayoutPanelPages.Size = new Size(165, 44);
            flowLayoutPanelPages.TabIndex = 25;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(658, 561);
            Controls.Add(flowLayoutPanelPages);
            Controls.Add(flowLayoutPanelProducts);
            Controls.Add(radioButtonDESC);
            Controls.Add(radioButtonASC);
            Controls.Add(label3);
            Controls.Add(sortingComboBox);
            Controls.Add(label2);
            Controls.Add(textBoxSearch);
            Controls.Add(filterComboBox);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioButtonDESC;
        private RadioButton radioButtonASC;
        private Label label3;
        private ComboBox sortingComboBox;
        private Label label2;
        private TextBox textBoxSearch;
        private ComboBox filterComboBox;
        private FlowLayoutPanel flowLayoutPanelProducts;
        private FlowLayoutPanel flowLayoutPanelPages;
    }
}