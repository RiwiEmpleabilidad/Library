-- Active: 1722286015049@@bajzbxguvxdxkekag9dn-mysql.services.clever-cloud.com@3306@bajzbxguvxdxkekag9dn
CREATE TABLE genders (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) 
);

CREATE TABLE authors (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) 
);



CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) ,
    email VARCHAR(255)  UNIQUE,
    password VARCHAR(255)
);

CREATE TABLE books (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) ,
    publicationdate DATE ,
    genderid INT,
    authorid INT,
    TotalCopias INT ,
    status ENUM('active', 'inactive'),
    CopiasAvailable INT ,
    FOREIGN KEY (genderid) REFERENCES genders(id),
    FOREIGN KEY (authorid) REFERENCES authors(id)
);

INSERT INTO books(name,publicationdate,genderid,authorid,TotalCopias,status,CopiasAvailable)
VALUES("el primero","2024-01-12",1,1,1,"active",0);

CREATE TABLE employess (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) ,
    email VARCHAR(255) ,
    password VARCHAR(255) 
);

CREATE TABLE loans (
    id INT AUTO_INCREMENT PRIMARY KEY,
    userid INT,
    bookid INT,
    startdate DATE ,
    enddate DATE ,
    employessId INT,
    status ENUM('active', 'lose', 'cancelled') ,
    returndate DATE,
    FOREIGN KEY (userid) REFERENCES users(id),
    FOREIGN KEY (bookid) REFERENCES books(id),
    FOREIGN KEY (employessId) REFERENCES employess(id)
);

CREATE TABLE histories (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_prestamo INT,
    FOREIGN KEY (id_prestamo) REFERENCES loans(id)
);

SELECT * FROM authors;