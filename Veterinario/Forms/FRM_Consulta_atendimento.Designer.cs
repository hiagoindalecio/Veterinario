namespace Veterinario.Forms
{
    partial class FRM_Consulta_atendimento
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
            this.gbDados = new System.Windows.Forms.GroupBox();
            this.lblRaca = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstAtendimento = new System.Windows.Forms.ListView();
            this.clnIDAtendimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnNomeAnimal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnFuncionario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDescricao = new System.Windows.Forms.GroupBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.gbDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbDescricao.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDados
            // 
            this.gbDados.Controls.Add(this.lblRaca);
            this.gbDados.Controls.Add(this.lblTipo);
            this.gbDados.Controls.Add(this.label5);
            this.gbDados.Controls.Add(this.label4);
            this.gbDados.Controls.Add(this.lblNome);
            this.gbDados.Controls.Add(this.picFoto);
            this.gbDados.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.gbDados.Location = new System.Drawing.Point(853, 110);
            this.gbDados.Name = "gbDados";
            this.gbDados.Size = new System.Drawing.Size(415, 371);
            this.gbDados.TabIndex = 18;
            this.gbDados.TabStop = false;
            this.gbDados.Text = "Dados Animal";
            this.gbDados.Visible = false;
            // 
            // lblRaca
            // 
            this.lblRaca.AutoSize = true;
            this.lblRaca.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaca.Location = new System.Drawing.Point(79, 328);
            this.lblRaca.Name = "lblRaca";
            this.lblRaca.Size = new System.Drawing.Size(50, 22);
            this.lblRaca.TabIndex = 62;
            this.lblRaca.Text = "raça";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(79, 306);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(50, 22);
            this.lblTipo.TabIndex = 61;
            this.lblTipo.Text = "tipo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 22);
            this.label5.TabIndex = 58;
            this.label5.Text = "Tipo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 22);
            this.label4.TabIndex = 57;
            this.label4.Text = "Raça:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(35, 35);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(58, 24);
            this.lblNome.TabIndex = 56;
            this.lblNome.Text = "Nome";
            // 
            // picFoto
            // 
            this.picFoto.Image = global::Veterinario.Properties.Resources.Vazio;
            this.picFoto.Location = new System.Drawing.Point(93, 76);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(211, 200);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 55;
            this.picFoto.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstAtendimento);
            this.groupBox1.Controls.Add(this.txtFiltro);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 371);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atendimentos";
            // 
            // lstAtendimento
            // 
            this.lstAtendimento.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lstAtendimento.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnIDAtendimento,
            this.clnNomeAnimal,
            this.clnData,
            this.clnFuncionario});
            this.lstAtendimento.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAtendimento.FullRowSelect = true;
            this.lstAtendimento.HideSelection = false;
            this.lstAtendimento.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lstAtendimento.Location = new System.Drawing.Point(19, 56);
            this.lstAtendimento.Name = "lstAtendimento";
            this.lstAtendimento.Size = new System.Drawing.Size(800, 302);
            this.lstAtendimento.TabIndex = 9;
            this.lstAtendimento.UseCompatibleStateImageBehavior = false;
            this.lstAtendimento.View = System.Windows.Forms.View.Details;
            this.lstAtendimento.SelectedIndexChanged += new System.EventHandler(this.ObterDados);
            // 
            // clnIDAtendimento
            // 
            this.clnIDAtendimento.Text = "ID";
            this.clnIDAtendimento.Width = 66;
            // 
            // clnNomeAnimal
            // 
            this.clnNomeAnimal.Text = "Nome Animal";
            this.clnNomeAnimal.Width = 255;
            // 
            // clnData
            // 
            this.clnData.Text = "Data";
            this.clnData.Width = 205;
            // 
            // clnFuncionario
            // 
            this.clnFuncionario.Text = "Funcionario";
            this.clnFuncionario.Width = 269;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(111, 20);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(708, 30);
            this.txtFiltro.TabIndex = 10;
            this.txtFiltro.TextChanged += new System.EventHandler(this.Filtrar);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RemoverFiltro);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Pesquisa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(414, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "Bem vindo à área de consulta de atendimentos.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 34);
            this.label1.TabIndex = 15;
            this.label1.Text = "Consulta de Atendimento";
            // 
            // gbDescricao
            // 
            this.gbDescricao.Controls.Add(this.txtDescricao);
            this.gbDescricao.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.gbDescricao.Location = new System.Drawing.Point(12, 487);
            this.gbDescricao.Name = "gbDescricao";
            this.gbDescricao.Size = new System.Drawing.Size(1256, 85);
            this.gbDescricao.TabIndex = 19;
            this.gbDescricao.TabStop = false;
            this.gbDescricao.Text = "Descrição";
            this.gbDescricao.Visible = false;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Location = new System.Drawing.Point(7, 25);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(1233, 54);
            this.txtDescricao.TabIndex = 0;
            // 
            // FRM_Consulta_atendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.ControlBox = false;
            this.Controls.Add(this.gbDescricao);
            this.Controls.Add(this.gbDados);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_Consulta_atendimento";
            this.Text = "Consulta de Atendimentos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Close);
            this.Load += new System.EventHandler(this.LoadAll);
            this.gbDados.ResumeLayout(false);
            this.gbDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbDescricao.ResumeLayout(false);
            this.gbDescricao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDados;
        private System.Windows.Forms.Label lblRaca;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstAtendimento;
        private System.Windows.Forms.ColumnHeader clnIDAtendimento;
        private System.Windows.Forms.ColumnHeader clnNomeAnimal;
        private System.Windows.Forms.ColumnHeader clnData;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader clnFuncionario;
        private System.Windows.Forms.GroupBox gbDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
    }
}