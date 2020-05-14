DROP DATABASE IF EXISTS startsmardb;
CREATE DATABASE starsmartdb;
USE startsmartdb;

CREATE TABLE User (
    id INT AUTO_INCREMENT,
    email VARCHAR(100) UNIQUE NOT NULL,
    username VARCHAR(100) UNIQUE NOT NULL,
    passwordHash VARCHAR(100) NOT NULL,
    firstName VARCHAR(100) NOT NULL,
    middleName VARCHAR(100),
    lastName VARCHAR(100) NOT NULL,
    birthDate DATE,
    PRIMARY KEY(id)
)

CREATE TABLE Student (
    sid INT,
    PRIMARY KEY (sid),
    FOREIGN KEY (sid) REFERENCES User (id) ON DELETE CASCADE
)

CREATE TABLE Cirriculum (
	cid INT,
	progress INT,
	currentModuleId VARCHAR(10),
	lastSavedTaskId VARCHAR(10),
	FOREIGN KEY (currentModuleId) REFERENCES Module (mid),
	FOREIGN KEY (lastSavedTaskId) REFERENCES Task (tid) 
)	

CREATE TABLE Module(
	mid INT AUTO_INCREMENT,
	cid INT,
	name VARCHAR(100) NOT NULL,
	PRIMARY KEY (mid),
	FOREIGN KEY (cid) REFERENCES Cirriculum (cid) ON DELETE CASCADE
)

CREATE TABLE Task (
    tid INT AUTO_INCREMENT,
    mid INT,
    name VARCHAR (300) NOT NULL,
    completed BOOLEAN DEFAULT false,
    PRIMARY KEY(tid),
    FOREIGN KEY (mid) REFERENCES Module (mid) ON DELETE CASCADE
)

CREATE TABLE Video ( 
	vid INT AUTO_INCREMENT,
	tid INT,
	title VARCHAR(300) NOT NULL,
	videoLink VARCHAR(1000) NOT NULL,
	completed BOOLEAN DEFAULT false,
	PRIMARY KEY (vid),
	FOREIGN KEY(tid) REFERENCES Task (tid) ON DELETE CASCADE
)

CREATE TABLE Quiz (
	quizId INT AUTO_INCREMENT,
	tid INT,
	title VARCHAR(300) NOT NULL,
	otherDetails VARCHAR(300),
	percentToPass float,
	passed BOOLEAN DEFAULT false,
	PRIMARY KEY (quizId),
	FOREIGN KEY(tid) REFERENCES Task (tid) ON DELETE CASCADE
) 

CREATE TABLE QuizQuestion (
	questionId INT AUTO_INCREMENT,
	quizId INT,
	otherDetails VARCHAR(300),
	questionText VARCHAR(3000),
	PRIMARY KEY (questionId, quizId),
	FOREIGN KEY (quizId) REFERENCES Quiz (quizId) ON DELETE CASCADE
)

CREATE TABLE QuizQuestionAnswer (
	quizI INT,
	questionId INT,
	answerId INT AUTO_INCREMENT,
	answerText VARCHAR(300),
	correctAnswer BOOLEAN,
	otherDetails VARCHAR(300),
	PRIMARY KEY(quizId, questionId, answerId),
	FOREIGN KEY (quizId) REFERENCES Quiz (quizId) ON DELETE CASCADE,
	FOREIGN KEY (questionId) REFERENCES Question (questionId) ON DELETE CASCADE

)

CREATE TABLE Deliverable (
	did INT AUTO_INCREMENT,
	tid INT,
	fileName VARCHAR(500),
	approved BOOLEAN DEFAULT false,
)

CREATE TABLE DeliverableComment (
	dcid INT AUTO_INCREMENT,
	did INT,
	comment VARCHAR (5000),
	PRIMARY KEY (dcid),
	FOREIGN KEY (did) REFERENCES Deliverable (did) ON DELETE CASCADE
)

CREATE TABLE Event (
	eid INT AUTO_INCREMENT,
	description VARCHAR(5000),
	location VARCHAR(500),
	hostId INT,
	eventBriteLink VARCHAR(5000),
	PRIMARY KEY (eid),
	FOREIGN KEY (hostId) REFERENCES EventHost (hostId) ON DELETE CASCADE
)

CREATE TABLE EventUser (
	uid INT,
	eid INT,
	FOREIGN KEY (uid) REFERENCES User (uid) ON DELETE CASCADE,
	FOREIGN KEY (eid) REFERENCES Event (eid) ON DELETE CASCADE
)

CREATE TABLE EventHost (
	hostId INT AUTO_INCREMENT,
	email VARCHAR(100) UNIQUE NOT NULL,
    firstName VARCHAR(100) NOT NULL,
    middleName VARCHAR(100),
    lastName VARCHAR(100) NOT NULL,
    company  VARCHAR(500),
   	PRIMARY KEY (hostId)
)

CREATE TABLE EventApplication (
	applicationId INT AUTO_INCREMENT,
	description VARCHAR(5000),
	title VARCHAR(500),
	location VARCHAR(500),
	hostId INT,
	eventBriteLink VARCHAR(5000),
	PRIMARY KEY (applicationId),
	FOREIGN KEY (hostId) REFERENCES EventHost (hostId) ON DELETE CASCADE
)