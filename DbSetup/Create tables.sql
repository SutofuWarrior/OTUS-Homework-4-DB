

create table Course
(
	Id serial primary key,
	Name varchar(255) unique,
	Price money
	
)

create table Lesson
(
	Id serial primary key,
	Name varchar(255) not null,
	CourseId int references Course (Id) not null
)

create table Student
(
	Id serial primary key,
	FIO varchar(1024) not null
)

create table StudentCourses
(
	Id serial primary key,
	CourseId int references Course (Id) not null,
	StudentId int references Student (Id) not null
)

create table StudentLessons
(
	Id serial primary key,
	StudentCourcesId int references StudentCourses (Id) not null,
	LessonId int references Lesson (Id) not null,
	HomeworkGrade smallint
)