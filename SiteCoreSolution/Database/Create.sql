Create DataBase SiteCore

Use SiteCore

Create Table Member
(
ID bigint identity(1,1) primary key,
UserName varchar(50) unique not null,
Password varchar(50) not null,
CreatedDate DateTime default(getdate()) not null,
UpdatedDate DateTime default(getdate()) not null
)

Create Table MemberLoginLog
(
ID bigint identity(1,1) primary key,
UserName varchar(50) references Member(UserName),
LoginDate DateTime default(getdate()) not null
)