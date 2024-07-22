using MusicSchoolXml.Service;
using System.Security.Cryptography;
using static MusicSchoolXml.Service.MusicSchoolService;
using static MusicSchoolXml.Model.Student;
using MusicSchoolXml.Model;
namespace MusicSchoolXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateXmlIfNotExists();
            //InsertClassroom("guitar jazz");
            //AddTeacher("guitar jazz", "michael star");


            AddManyStudents("guitar jazz",
                new Student("itzhak", new Instrument("piano")),
                new Student("avremi shneor", new Instrument("guitar"))
                );


        }

        





    }
}
