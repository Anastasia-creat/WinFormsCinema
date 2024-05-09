
namespace Kursovaya_V._1.Pages
{
    partial class FormHelpDesk
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
            this.components = new System.ComponentModel.Container();
            this.button6 = new System.Windows.Forms.Button();
            this.cinemaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cinemaDb2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cinemaDb2DataSet = new Kursovaya_V._1.CinemaDb2DataSet();
            this.cinemaTableAdapter = new Kursovaya_V._1.CinemaDb2DataSetTableAdapters.CinemaTableAdapter();
            this.cinemaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cinemaDb2DataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.movieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sessionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cinemaDb2DataSetBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.sessionTableAdapter = new Kursovaya_V._1.CinemaDb2DataSetTableAdapters.SessionTableAdapter();
            this.movieTableAdapter = new Kursovaya_V._1.CinemaDb2DataSetTableAdapters.MovieTableAdapter();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDb2DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDb2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDb2DataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDb2DataSetBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button6.Location = new System.Drawing.Point(12, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "Назад";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cinemaBindingSource
            // 
            this.cinemaBindingSource.DataMember = "Cinema";
            this.cinemaBindingSource.DataSource = this.cinemaDb2DataSetBindingSource;
            // 
            // cinemaDb2DataSetBindingSource
            // 
            this.cinemaDb2DataSetBindingSource.DataSource = this.cinemaDb2DataSet;
            this.cinemaDb2DataSetBindingSource.Position = 0;
            // 
            // cinemaDb2DataSet
            // 
            this.cinemaDb2DataSet.DataSetName = "CinemaDb2DataSet";
            this.cinemaDb2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cinemaTableAdapter
            // 
            this.cinemaTableAdapter.ClearBeforeFill = true;
            // 
            // cinemaBindingSource1
            // 
            this.cinemaBindingSource1.DataMember = "Cinema";
            this.cinemaBindingSource1.DataSource = this.cinemaDb2DataSetBindingSource1;
            // 
            // cinemaDb2DataSetBindingSource1
            // 
            this.cinemaDb2DataSetBindingSource1.DataSource = this.cinemaDb2DataSet;
            this.cinemaDb2DataSetBindingSource1.Position = 0;
            // 
            // movieBindingSource
            // 
            this.movieBindingSource.DataMember = "Movie";
            this.movieBindingSource.DataSource = this.cinemaDb2DataSet;
            // 
            // sessionBindingSource
            // 
            this.sessionBindingSource.DataMember = "Session";
            this.sessionBindingSource.DataSource = this.cinemaDb2DataSetBindingSource2;
            // 
            // cinemaDb2DataSetBindingSource2
            // 
            this.cinemaDb2DataSetBindingSource2.DataSource = this.cinemaDb2DataSet;
            this.cinemaDb2DataSetBindingSource2.Position = 0;
            // 
            // sessionTableAdapter
            // 
            this.sessionTableAdapter.ClearBeforeFill = true;
            // 
            // movieTableAdapter
            // 
            this.movieTableAdapter.ClearBeforeFill = true;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.MediumPurple;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button4.Location = new System.Drawing.Point(22, 65);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(247, 52);
            this.button4.TabIndex = 32;
            this.button4.Text = "Просмотр адреса выбранного кинотеатра";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumPurple;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(333, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 52);
            this.button1.TabIndex = 33;
            this.button1.Text = "Просмотр свободных мест ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.MediumPurple;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button7.Location = new System.Drawing.Point(186, 154);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(253, 52);
            this.button7.TabIndex = 35;
            this.button7.Text = "Просмотр данных о фильме";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // FormHelpDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(652, 259);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Name = "FormHelpDesk";
            this.Text = "FormHelpDesk";
            this.Load += new System.EventHandler(this.FormHelpDesk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDb2DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDb2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDb2DataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDb2DataSetBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.BindingSource cinemaDb2DataSetBindingSource;
        private CinemaDb2DataSet cinemaDb2DataSet;
        private System.Windows.Forms.BindingSource cinemaBindingSource;
        private CinemaDb2DataSetTableAdapters.CinemaTableAdapter cinemaTableAdapter;
        private System.Windows.Forms.BindingSource cinemaBindingSource1;
        private System.Windows.Forms.BindingSource cinemaDb2DataSetBindingSource1;
        private System.Windows.Forms.BindingSource cinemaDb2DataSetBindingSource2;
        private System.Windows.Forms.BindingSource sessionBindingSource;
        private CinemaDb2DataSetTableAdapters.SessionTableAdapter sessionTableAdapter;
        private System.Windows.Forms.BindingSource movieBindingSource;
        private CinemaDb2DataSetTableAdapters.MovieTableAdapter movieTableAdapter;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
    }
}