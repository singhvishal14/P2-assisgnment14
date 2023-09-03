Create Database PlayerDb

Use PlayerDb

Create Table Player
(Id int Primary Key,
FirstName nvarchar(50),
LastName nvarchar(50),
JerseyNumber int,
Position nvarchar(50),
Team nvarchar(50));

Insert Into Player Values 
(01, 'Virat', 'Kohli', 18, 'One Down', 'India'),
(02, 'Rohit', 'Sharma', 45, 'Opener', 'India'),
(03, 'Joe', 'Root', 24, 'Top Order', 'England'),
(04, 'Kane', 'Williamson', 11, 'Captain', 'New Zealand'),
(05, 'Steve', 'Smith', 49, 'Batsman', 'Australia'),
(06, 'AB', 'de Villiers', 17, 'Middle Order', 'South Africa'),
(07, 'David', 'Warner', 32, 'Opener', 'Australia'),
(08, 'Babar', 'Azam', 33, 'Top Order', 'Pakistan'),
(09, 'Kusal', 'Perera', 07, 'Wicketkeeper', 'Sri Lanka'),
(10, 'Shakib', 'Al Hasan', 75, 'All-Rounder', 'Bangladesh');

Select * From Player

drop table player