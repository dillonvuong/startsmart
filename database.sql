DROP DATABASE IF EXISTS startsmardb;
CREATE DATABASE starsmartdb;
USE startsmartdb;

CREATE TABLE User (
    id VARCHAR(10),
    email VARCHAR(100) UNIQUE NOT NULL,
    username VARCHAR(100) UNIQUE NOT NULL,
    passwordHash VARCHAR(100) NOT NULL,
    firstName VARCHAR(100) NOT NULL,
    middleName VARCHAR(100),
    lastName VARCHAR(100) NOT NULL,
    birthDate DATE,
    PRIMARY KEY(id)
)

CREATE TABLE Mentor (
    id VARCHAR(10),
    PRIMARY KEY (id),
    FOREIGN KEY (id) REFERENCES User (id) ON DELETE CASCADE
)

CREATE TABLE Student (
    id VARCHAR(10),
    PRIMARY KEY (id),
    FOREIGN KEY (id) REFERENCES User (id) ON DELETE CASCADE
)

CREATE TABLE Lesson (
    studentId VARCHAR(10),
    id VARCHAR(10),
    title VARCHAR(100) NOT NULL,
    finished BOOLEAN DEFAULT false, 
    PRIMARY KEY(id)
    FOREIGN KEY (userId) REFERENCES Student (id) ON DELETE CASCADE
)

CREATE TABLE Task (
    lessonId VARCHAR(10)
    id VARCHAR(10),
    taskToBeDone VARCHAR(100) NOT NULL,
    finished BOOLEAN DEFAULT false,
    PRIMARY KEY(lessonId, id)
    FOREIGN KEY (lessonId) REFERENCES Lesson (id) ON DELETE CASCADE
)

CREATE TABLE Mentoring (
    mentorId VARCHAR(10),
    studentId VARCHAR(10),
    PRIMARY KEY (mentorId, studentId),
    FOREIGN KEY (mentorId) REFERENCES Mentor(id) ON DELETE CASCADE,
    FOREIGN KEY (studentId) REFERENCES Student(id) ON DELETE CASCADE,
)
