﻿using System;
using DataAccess.Entities;
using DataAccess.EntityFramework;
using DataAccess.Implementations;

namespace PostgresDBConnector
{
    class Program
    {
        static void Main()
        {
            using var db = new DatabaseContext();
            Menu(db);
        }

        static void Menu(DatabaseContext db)
        {
            ConsoleKeyInfo key;

            do
            {
                Console.WriteLine("0 - Выход");
                Console.WriteLine("1 - Показать содержимое таблиц");
                Console.WriteLine("2 - Добавить курс");
                Console.WriteLine("3 - Добавить урок");
                Console.WriteLine("4 - Добавить студента");
                Console.WriteLine("5 - Записать студента на курс");
                Console.WriteLine("6 - Добавить студенту пройденный урок");

                Console.WriteLine();
                Console.Write(">>> ");
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.D0:
                        break;

                    case ConsoleKey.D1:
                        ShowAllTables(db);
                        break;

                    case ConsoleKey.D2:
                        AddCourse(db);
                        break;

                    case ConsoleKey.D3:
                        AddLesson(db);
                        break;

                    case ConsoleKey.D4:
                        AddStudent(db);
                        break;

                    case ConsoleKey.D5:
                        AddStudentToCourse(db);
                        break;

                    case ConsoleKey.D6:
                        AddStudentLesson(db);
                        break;
                }

            } while (key.Key != ConsoleKey.D0);

        }

        static void ShowAllTables(DatabaseContext db)
        {
            const string SeparatorLine = "----------------------------------------";
            Console.WriteLine();

            Console.WriteLine(SeparatorLine);
            Console.WriteLine(">>> Course");

            foreach (var course in new CourseRepository(db).GetAll())
                Console.WriteLine($"Id: {course.Id}, Name: {course.Name}");


            Console.WriteLine(SeparatorLine);
            Console.WriteLine(">>> Lesson");

            foreach (var lesson in new LessonRepository(db).GetAll())
                Console.WriteLine($"Id: {lesson.Id}, CourseId: {lesson.CourseId}, Name: {lesson.Name}");


            Console.WriteLine(SeparatorLine);
            Console.WriteLine(">>> Student");

            foreach (var student in new StudentRepository(db).GetAll())
                Console.WriteLine($"Id: {student.Id}, FIO: {student.Fio}");


            Console.WriteLine(SeparatorLine);
            Console.WriteLine(">>> StudentCourse");

            foreach (var sc in new StudentCoursesRepository(db).GetAll())
                Console.WriteLine($"Id: {sc.Id}, Student: {sc.Student.Fio}, Course: {sc.Course.Name}");


            Console.WriteLine(SeparatorLine);
            Console.WriteLine(">>> StudentLessons");

            foreach (var sl in new StudentLessonsRepository(db).GetAll())
                Console.WriteLine($"Id: {sl.Id}, Student: {sl.StudentCourse.Student.Fio}, " +
                    $"Course: {sl.StudentCourse.Course.Name}, Lesson: {sl.Lesson.Name}, Grade: {sl.HomeworkGrade}");
        }

        static void AddCourse(DatabaseContext db)
        {
            Console.Clear();
            var repo = new CourseRepository(db);

            var course = new Course();

            Console.Write("Название курса: ");
            course.Name = Console.ReadLine();

            repo.Add(course);
            repo.SaveChanges();
        }

        static void AddLesson(DatabaseContext db)
        {
            Console.Clear();
            var repo = new LessonRepository(db);

            var lesson = new Lesson();

            Console.Write("ID курса: ");
            lesson.CourseId = int.Parse(Console.ReadLine());

            Console.Write("Название урока: ");
            lesson.Name = Console.ReadLine();

            repo.Add(lesson);
            repo.SaveChanges();
        }

        static void AddStudent(DatabaseContext db)
        {
            Console.Clear();
            var repo = new StudentRepository(db);

            var student = new Student();

            Console.Write("ФИО: ");
            student.Fio = Console.ReadLine();

            repo.Add(student);
            repo.SaveChanges();
        }

        static void AddStudentToCourse(DatabaseContext db)
        {
            Console.Clear();
            var repo = new StudentCoursesRepository(db);

            var entity = new StudentCourses();

            Console.Write("ID курса: ");
            entity.CourseId = int.Parse(Console.ReadLine());

            Console.Write("ID студента: ");
            entity.StudentId = int.Parse(Console.ReadLine());

            repo.Add(entity);
            repo.SaveChanges();
        }

        static void AddStudentLesson(DatabaseContext db)
        {
            Console.Clear();
            var repo = new StudentLessonsRepository(db);

            var entity = new StudentLessons();

            Console.Write("ID курса студента: ");
            entity.StudentCourseId = int.Parse(Console.ReadLine());

            Console.Write("ID урока: ");
            entity.LessonId = int.Parse(Console.ReadLine());

            Console.Write("Оценка: ");
            entity.HomeworkGrade = short.Parse(Console.ReadLine());

            repo.Add(entity);
            repo.SaveChanges();
        }
    }
}
