using System;

namespace ex{
    public abstract class Person
     {
        public string Name;
        public string Surname;

        public Person(string Name, string Surname){
            this.Name = Name;
            this.Surname = Surname;
        }
        public abstract void Accept(IVisitor visitor);
    }

    public class Student : Person
    {
        public int Course;
        public Student (string Name, string Surname, int Course) : base(Name, Surname){
            this.Course = Course;
        }

        public override void Accept(IVisitor visitor){
            visitor.VisitStudent(this);
        }

        public string toPrintString(){
            return String.Format("{0}, {1}, {2}", Name, Surname, Course);
        }
        public void Print(){
            Console.WriteLine("Студент", Name, Surname, Course);
        }

        public void SayHi(){
            Console.WriteLine("Привіт");
        }
    }

    public class Professor : Person
    {
        public string Cathedra;
        public Professor (string Name, string Surname,  string Cathedra) : base(Name, Surname){
            this.Cathedra = Cathedra;
        }
        public override void Accept(IVisitor visitor){
            visitor.VisitProfessor(this);
        }
        
        public string toPrintString(){
            return String.Format("{0}, {1}, {2}", Name, Surname, Cathedra);
        }
        public void Print(){
            Console.WriteLine("Викладач", Name, Surname, Cathedra);
        }

        public void SayHi(){
            Console.WriteLine("Доброго дня");
        }
    }

    public interface IVisitor
    {
        void VisitStudent(Student student);
        void VisitProfessor(Professor professor);
    }

    public class Printer: IVisitor
    {
        public void VisitStudent(Student student){
            Console.WriteLine("Друкую студент");
            Console.WriteLine(student.toPrintString());
        }
        public void VisitProfessor(Professor professor){
            Console.WriteLine("Друкую професора");
            Console.WriteLine(professor.toPrintString());
        }
    }

    public class Hi: IVisitor{
         public void VisitStudent(Student student){
             Console.WriteLine("Привіт");
         }
        public void VisitProfessor(Professor professor){
            Console.WriteLine("Доброго дня");
        }
    }

    class AtherPrinter{
        public void Print(Person person){
            if (person is Student)
                Console.WriteLine((person as Student).Course);
            if (person is Professor){
                Console.WriteLine((person as Professor).Cathedra);
            }
        }
    }
}