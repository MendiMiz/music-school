using MusicSchoolXml.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MusicSchoolXml.Configuration.MusicSchoolConfiguration;


namespace MusicSchoolXml.Service
{
    internal static class MusicSchoolService
    {
        public static void stamCacha()
        {
            Console.WriteLine("ajahgsdg");
        }

        public static void CreateXmlIfNotExists()
        {
            if (!File.Exists(musicSchoolPath))
            {
                // create a new document .xml
                XDocument document = new();
                // create an element
                XElement musicSchool = new("music-school");
                //document add element
                document.Add(musicSchool);
                //document save changes to provided path
                document.Save(musicSchoolPath);
            }
        }

        public static void InsertClassroom(string classRoomName)
        {
            //load document 
            XDocument document = XDocument.Load(musicSchoolPath);

            // find music-school (root)
            XElement? musicSchool = document.Descendants("music-school").FirstOrDefault();

            //validate music-school existance
            if (musicSchool == null)
            {
                return;
            }

            //create new x elemnt (class-room)
            XElement classRoom = new(
                "class-room",
                new XAttribute("name", classRoomName)
                );

            musicSchool.Add(classRoom);
            document.Save(musicSchoolPath);
        }

        public static void AddTeacher(string classRoomName, string teacherName)
        {
            //load document 
            XDocument document = XDocument.Load(musicSchoolPath);

            // find music-school (root)
            XElement? musicSchool = document.Descendants("music-school").FirstOrDefault();

            //validate music-school existance
            if (musicSchool == null)
            {
                return;
            }

            XElement? classRoom = musicSchool.Descendants("class-room")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);

            if (classRoom == null)
            {
                return;
            }

            //create new x elemnt (class-room)
            XElement teacher = new(
                "teacher",
                new XAttribute("name", teacherName)
                );

            classRoom.Add(teacher);
            document.Save(musicSchoolPath);
        }

        public static void AddStudent(string classRoomName, string studentName, string instrumentName)
        {
            //load document 
            XDocument document = XDocument.Load(musicSchoolPath);

            // find music-school (root)
            XElement? musicSchool = document.Descendants("music-school").FirstOrDefault();

            //validate music-school existance
            if (musicSchool == null)
            {
                return;
            }

            XElement? classRoom = musicSchool.Descendants("class-room")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);

            if (classRoom == null)
            {
                return;
            }



            //create new x elemnt (class-room)
            XElement student = new(
                "student",
                new XAttribute("name", studentName),
                new XElement("instrument", instrumentName)
                );

            classRoom.Add(student);
            document.Save(musicSchoolPath);
        }





        private static XElement ConvertStudentToElement(Student student) =>
                    new(
                        "student",
                        new XAttribute("name", student.studentName),
                        new XElement("instrument", student.instrument.name)
                        );

        public static void AddManyStudents(string classRoomName, params Student[] students)
        {
           
            //load document 
            XDocument document = XDocument.Load(musicSchoolPath);

            // find music-school (root)
            XElement? musicSchool = document.Descendants("music-school").FirstOrDefault();

            //validate music-school existance
            if (musicSchool == null)
            {
                return;
            }

            XElement? classRoom = musicSchool.Descendants("class-room")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);

            if (classRoom == null)
            {
                return;
            }
           
            List<XElement> studentElemntsList = students
                .Select(ConvertStudentToElement)
                .ToList();
            //student => new XElement("student", new XAttribute("name", student.studentName),
            //new XElement("instrument", student.instrument.name))).ToList();
            
            classRoom.Add(studentElemntsList);
            document.Save(musicSchoolPath);
        }
    
        public static void UpdateInstrumentByName(string studentName, Instrument instrument)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? studentElement = document.Descendants("student")
                .FirstOrDefault(s => s.Attribute("name")?.Value == studentName);
            if (studentElement == null) { return; }
            studentElement.SetElementValue("instrument", instrument.name);
        }

        public static void UpdateTeacher(string oldTeacher, string newTeacher)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? oldToNew = document.Descendants("teacher")
                .FirstOrDefault(s => s.Attribute("name")?.Value == oldTeacher);
            if (oldToNew == null) { return; }
            oldToNew.SetAttributeValue("name", newTeacher);
        }
        
        public static void replaceStudent(string studentName, string newStudentName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? studentElement = document.Descendants("student")
                .FirstOrDefault(s => s.Attribute("name")?.Value == studentName);
            if (studentElement == null) { return; }

        }

    }
}

