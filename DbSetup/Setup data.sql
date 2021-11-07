

insert into course ("name", price) values 
	('C# Basic', 10000),
	('C# Professional', 12000), 
	('C# Expert', 15000)
--select * from course

insert into lesson (courseid, "name") values
	(1, 'Типы данных'),
	(1, 'Синтаксические конструкции'),
	(2, 'Шаблоны проектирования'),
	(2, 'Многопоточное программирование'),
	(2, 'Подключение к базами данных'),
	(3, 'CI/CD'),
	(3, 'ASP.NET')
--select * from lesson 

insert into student (fio) values
	('Абрикосов Алексей'), 
	('Бузина Борис'),
	('Вишневский Валерий'),
	('Грушевский Георгий'),
	('Дынькин Дмитрий')
--select * from student 

insert into studentcourses (courseid, studentid) values
	(1, 1),
	(1, 2),
	(2, 3),
	(2, 4),
	(2, 5),
	(3, 5)

--select 
--	sc.id, s.fio, c."name", l.id, l."name" 
--from studentcourses sc 
--	join student s on s.id = sc.studentid 
--	join course  c on c.id = sc.courseid 
--	join lesson  l on l.courseid = c.id
--order by s.id, c.id, l.id

insert into studentlessons (studentcourcesid, lessonid, homeworkgrade) values 
	(1, 1, 5),
	(2, 1, 5),
	(2, 2, 4),
	(3, 3, 4),
	(3, 4, 5),
	(4, 4, 4),
	(5, 6, 3),
	(6, 3, 5),
	(6, 4, 5),
	(6, 5, 4)
	
select 
	s.fio as "Студент", 
	c."name" as "Курс", 
	l."name" as "Урок", 
	sl.homeworkgrade as "Оценка"
from student s 
	join studentcourses sc on s.id = sc.studentid 
	join course  c on c.id = sc.courseid 
	join lesson  l on l.courseid = c.id 
	left join studentlessons sl on sl.lessonid = l.id and sl.studentcourcesid = sc.id 
order by s.id, c.id, l.id
	