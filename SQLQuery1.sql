create database simulation;

use simulation;

select * from Doctor;
select * from Patient;
select * from Booking;
select * from Users;

CREATE TABLE Doctor (
    DoctorID int NOT NULL,
    DName varchar(255) NOT NULL,
	Special varchar(255) NOT NULL,
    PRIMARY KEY (DoctorID)
);

CREATE TABLE Booking (
	BookingID int NOT NULL,
    PatientID int FOREIGN KEY REFERENCES Patient(PatientID),
	DoctorID int FOREIGN KEY REFERENCES Doctor(DoctorID),
	DateOFBooking date,
    PRIMARY KEY (BookingID)
);

CREATE TABLE Patient (
    PatientID int NOT NULL,
    PName varchar(255) NOT NULL,
	Disease varchar(255) NOT NULL,
    PRIMARY KEY (PatientID),
	
);

CREATE TABLE Users (
	UserId Int Identity(1,1) Not null Primary Key,
	Email Varchar(50) Not null,
	Password Varchar(20) Not null
)


insert into Doctor values(001,'Arun','ENT');
insert into Doctor values(002,'Arpit','Dental');
insert into Doctor values(003,'Saurab','Kidney');
insert into Doctor values(004,'Jen','Brain');

insert into Patient values(101,'Rahul','Ear');
insert into Patient values(102,'Peter','Ear');
insert into Patient values(103,'Rick','Kidney');
insert into Patient values(104,'Morty','Brain');

insert into Booking values(201,102,001,'2020-01-22');
insert into Booking values(202,102,001,'2020-01-22');

insert into Users values('arpit@123','admin');
insert into Users values('mandal@123','admin');


