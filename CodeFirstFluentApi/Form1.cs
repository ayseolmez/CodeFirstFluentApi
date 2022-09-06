using DataAccess.ConcreteRepository;
using DataAccess.Context;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstFluentApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            _codeFirstDbContext = new CodeFirstDBContext(); //DbSetlerin oluşması için
            _schoolRepository = new SchoolRepository(_codeFirstDbContext);
            _teacherRepository = new TeacherRepository(_codeFirstDbContext);
            InitializeComponent();
        }

        private CodeFirstDBContext _codeFirstDbContext;
        private SchoolRepository _schoolRepository;
        private TeacherRepository _teacherRepository;

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            School eklenecekOkul = new School();
            eklenecekOkul.Name = txtSchoolName.Text;
            eklenecekOkul.NumberOfStudent = Convert.ToInt32(txtNumberOfStudent.Text);
            eklenecekOkul.NumberOfEmployee=Convert.ToInt32(txtNumberOfEmployee.Text);

            _schoolRepository.Add(eklenecekOkul);
            Clear();
            
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dgvOkul.DataSource = _schoolRepository.GetAll();
        }
        int aranacakOkulID;
        private void dgvOkul_SelectionChanged(object sender, EventArgs e)
        {
            aranacakOkulID = Convert.ToInt32(dgvOkul.CurrentRow.Cells["ID"].Value);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var silinecekOkul = _schoolRepository.GetById(aranacakOkulID);
            silinecekOkul.DeletedDate=DateTime.Now;
            _schoolRepository.Delete(silinecekOkul);
            dgvOkul.DataSource = _schoolRepository.GetAll();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var guncellenecekOkul = _schoolRepository.GetById(aranacakOkulID);
            guncellenecekOkul.Name = txtSchoolName.Text;
            guncellenecekOkul.NumberOfStudent = Convert.ToInt32(txtNumberOfStudent.Text);
            guncellenecekOkul.NumberOfEmployee = Convert.ToInt32(txtNumberOfEmployee.Text);
            guncellenecekOkul.ModifiedDate = DateTime.Now;
            _schoolRepository.Update(guncellenecekOkul);

            dgvOkul.DataSource = _schoolRepository.GetAll();
            Clear();
        }

        private void Clear()
        {
            foreach (var item in this.groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = " ";    
                }
            }
        }
    }
}
