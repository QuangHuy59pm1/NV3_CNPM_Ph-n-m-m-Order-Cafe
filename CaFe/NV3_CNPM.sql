create database QLCafe
use QLCafe
drop database QLCafe

create table drink(
tendo nvarchar(50) primary key not null,
gia float
)
insert into drink
values (N'Nước cam','25000'),
		(N'Bạc Xỉu','25000'),
		(N'Nước Dừa','25000'),
		(N'Cà Phê Nâu Phin','25000'),
		(N'Cà Phê Đen Phin','25000');
select * from drink
create table cftable(
id int identity primary key not null,
tinhtrang nvarchar(50) default 'Trống'
)
insert into cftable
values (''),(''),(''),(''),(''),(''),(''),(''),(''),(''),(''),(''),('');
select * from cftable
create table bills(
id int identity primary key not null,
idcftable int not null,
tendo nvarchar(50),
dongia float,
soluong int,
thanhtien float
foreign key(idcftable) references cftable(id),
foreign key(tendo) references drink(tendo),
foreign key(dongia) references drink(gia)
)
select * from bills

create table oderlist(
idtable int,
tendo nvarchar(50),
soluong int,
foreign key(tendo) references drink(tendo),
foreign key(idtable) references cftable(id)
)