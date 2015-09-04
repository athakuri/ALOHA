CREATE DATABASE ALOHA;

USE ALOHA;

CREATE TABLE users_info
(
id_user int not null IDENTITY(1,1) PRIMARY KEY,
name_user nvarchar(100),
type_user nvarchar(100),
password_user nvarchar(32),
email_user nvarchar(100),
date_user date,
phoneNo_user varchar(50)
);

select *from users_info;

CREATE TABLE CATEGORY
(
id_category int not null IDENTITY(1,1) PRIMARY KEY,
name_category nvarchar(100),
description_category nvarchar(max)
);

SELECT *FROM category;
CREATE TABLE THREADS
(
id_thread int not null IDENTITY(1,1) PRIMARY KEY,
us_id int FOREIGN KEY REFERENCES users_info(id_user),
c_id int FOREIGN KEY REFERENCES category(id_category),
title_thread nvarchar(100),
content_thread nvarchar(max),
date_thread date
);
SELECT *FROM threads;
CREATE TABLE Replies
(
id_replies int not null IDENTITY(1,1) PRIMARY KEY,
us_id int FOREIGN KEY REFERENCES users_info(id_user),
c_id int FOREIGN KEY REFERENCES category(id_category),
th_id int FOREIGN KEY REFERENCES threads(id_thread),
content_reply nvarchar(max),
date_reply date
);
SELECT *FROM Replies;





